using AlmassarGate.Domain.DTO;
using AlmassarGate.Domain.Enums;
using AlmassarGate.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Repository.UnitOfWork;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AlmassarGate.Domain.Models.Common;
using Service.Services.Common;
using Domains.DTO;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Google.Apis.Auth;
using Domains.Models;

namespace Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly LoggedInUserService _loggedInUserService;
        private readonly IConfiguration _configuration;
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly IConfigurationSection _goolgeSettings;
        AppConfiguration _appConfiguration = new AppConfiguration();
        private EmailSender emailSender;
        public AuthService(IConfiguration configuration, UserManager<ApplicationUser> userManager, IRepositoryUnitOfWork repositoryUnitOfWork, SignInManager<ApplicationUser> signInManager, LoggedInUserService loggedInUserService)
        {
            _loggedInUserService = loggedInUserService;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _goolgeSettings = _configuration.GetSection("GoogleAuthSettings");
            emailSender = new EmailSender();
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO model)
        { 
            ApplicationUser user = _userManager.Users.FirstOrDefault(x => x.UserName == model.Username || x.Email == model.Username || x.PhoneNumber == model.Username);

            if (user != null)
            {
                SignInResult oSignInResult = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

                if (oSignInResult.Succeeded)
                {
                    IList<string> roles = await _userManager.GetRolesAsync(user);
                    IList<Claim> claims = await BuildClaims(user);

                    LoginResponseDTO oLoginResponseDTO = new LoginResponseDTO()
                    {
                        AccessToken = WriteToken(claims),
                        UserId = user.Id.ToString(),
                        UserName = user.UserName,
                        FullName = user.FullName,
                        PhoneNumber = user.PhoneNumber,
                        Email = user.Email,
                        Roles = roles
                    };

                    return oLoginResponseDTO;
                }
                else
                {
                    throw new ValidationException("Password Is Wrong");
                }
            }
            else
            {
                throw new ValidationException("UserName is Wrong");
            }
        }
        public async Task<SocialLoginResponseDTO> ExternalLogin(ExternalAuthDTO externalAuth)
        {
            GoogleJsonWebSignature.Payload payload = await VerifyGoogleToken(externalAuth);
            if (payload == null)
                throw new ValidationException("Invalid External Authentication");
            UserLoginInfo info = new UserLoginInfo(externalAuth.Provider, payload.Subject, externalAuth.Provider);
            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new ApplicationUser { Email = payload.Email, UserName = payload.Email };
                    if (_userManager.Users.Any(x => x.UserName == user.UserName))
                    {
                        throw new ValidationException("UserName Already Exists");
                    }
                    await _userManager.CreateAsync(user);
                    //prepare and send an email for the email confirmation
                    await _userManager.AddToRoleAsync(user, "User");
                    await _userManager.AddLoginAsync(user, info);
                }
                else
                {
                    await _userManager.AddLoginAsync(user, info);
                }
            }
            if (user == null)
                throw new ValidationException("Invalid External Authentication");
            //check for the Locked out account
            IList<Claim> claims = await BuildClaims(user);
            IList<string> roles = await _userManager.GetRolesAsync(user);
            string token = WriteToken(claims);
            return new SocialLoginResponseDTO { Token = token, IsAuthSuccessful = true };
        }
        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDTO externalAuth)
        {
            try
            {
                IConfigurationSection googleAuth = _configuration.GetSection("Authentication:Google");

                GoogleJsonWebSignature.ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { googleAuth["ClientId"] }
                };
                GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
                return payload;
            }
            catch (Exception ex)
            {
                //log an exception
                return null;
            }
        }


        public async Task<LoginResponseDTO> AdminLogin(LoginRequestDTO model)
        {
            ApplicationUser user = _userManager.Users.FirstOrDefault(x => x.UserName == model.Username);

            if (user != null)
            {
                IList<UserRoles> UserRoleslst = _repositoryUnitOfWork.UserRoles.Value.Find(x => x.UserId == user.Id).ToList();

                if (UserRoleslst.Any(x => x.RoleId == RoleTypes.Admin.GetHashCode()))
                {
                    SignInResult oSignInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

                    if (oSignInResult.Succeeded)
                    {
                        IList<string> roles = await _userManager.GetRolesAsync(user);
                        IList<Claim> claims = await BuildClaims(user);

                        LoginResponseDTO oLoginResponseDTO = new LoginResponseDTO()
                        {
                            AccessToken = WriteToken(claims),
                            UserId = user.Id.ToString(),
                            UserName = user.UserName,
                            FullName = user.FullName,
                            PhoneNumber = user.PhoneNumber,
                            Email = user.Email,
                            Roles = roles
                        };
                        return oLoginResponseDTO;
                    }
                    else
                    {
                        throw new ValidationException("Password Is Wrong");
                    }
                }
                else
                {
                    throw new ValidationException("You Dont have Permission");
                }
            }
            else
            {
                throw new ValidationException("UserName is Wrong");
            }
        }
        public DashboardResponseDTO GetDashboardData()
        {
            IEnumerable<ApplicationUser> applicationsUsers = _userManager.Users.ToList();
           
            List<DashboardDTO> dashboards = new List<DashboardDTO>
            {
                new DashboardDTO { Name = "Total Users", Value = applicationsUsers.Count().ToString(),Url="/users-management/list-users",Icon="person" },
            };
            DateTime thisWeekFirstDate = FirstDateOfWeek(DateTime.Now.Year, GetIso8601WeekOfYear(DateTime.Now));
            DateTime thisWeekLastDate = thisWeekFirstDate.AddDays(7);
            DashboardChartDTO dashboardChartDTO = new DashboardChartDTO();
            dashboardChartDTO.NumberOfApprovals = new List<int>();
            dashboardChartDTO.NumberOfUsers = new List<int>();
            int maximumNumberOfApprovals = 0;
            int maximumNumberOfUsers = 0;
            DateTime maximumNumberOfApprovalsDate=new DateTime();
            DateTime maximumNumberOfUsersDate = new DateTime();
            for (int day= 1;day<=7;day++)
            {
                DateTime dateTime = thisWeekFirstDate.AddDays(day - 1).Date;                                 
               

            }
            dashboardChartDTO.MaximumNumberOfApprovalsDate = maximumNumberOfApprovalsDate;
            dashboardChartDTO.MaximumNumberOfUsersDate = maximumNumberOfUsersDate;
            DashboardResponseDTO response = new DashboardResponseDTO
            {
                Dashboards = dashboards,
                Charts = dashboardChartDTO
            };
            return response;
        }
        private static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
        private static DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }
        public async Task<bool> ChangePassword(UpdatePasswordDTO updatePasswordDTO)
        {
            int userId = _loggedInUserService.GetUserId();

            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());

            IdentityResult result = await _userManager.ChangePasswordAsync(user, updatePasswordDTO.OldPassword, updatePasswordDTO.NewPassword);
            if (result.Succeeded)
            {
                return true;
            }
            else if (result.Errors.Any())
            {
                throw new Exception(result.Errors.FirstOrDefault().Description);
            }
            else
            {
                throw new Exception("Error while updating Password");
            }
        }

        //public async Task<string> ForgetPassword(ForgetPasswordDTO oForgetPasswordDTO) {

        //    var user = await _userManager.FindByEmailAsync(oForgetPasswordDTO.EmailAddress);
        //    if (user != null && await _userManager.IsEmailConfirmedAsync(user))
        //    {
        //        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        //        return token;
        //    }
        //}

        public async Task<UserRegistrationResponseDTO> UserRegistration(UserRegistrationDTO user)
        {
            if (_userManager.Users.Any(x => x.PhoneNumber == user.PhoneNumber))
            {
                throw new ValidationException("Phone Number Already Exists");
            }
            if (_userManager.Users.Any(x => x.Email == user.Email))
            {
                throw new ValidationException("Email Already Exists");
            }
            if (_userManager.Users.Any(x => x.UserName == user.UserName))
            {
                throw new ValidationException("UserName Already Exists");
            }

            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber
            };
            
            IdentityResult result = await _userManager.CreateAsync(applicationUser, user.Password);
            if (result.Succeeded)
            {
                var userRole = _repositoryUnitOfWork.RoleRepository.Value.FirstOrDefault(x => x.Name.Equals("user"));
                _repositoryUnitOfWork.UserRoles.Value.Add(new UserRoles
                {
                    RoleId = userRole.Id,
                    UserId = applicationUser.Id,
                });

                var token =await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);

                if(!string.IsNullOrEmpty(token))
                {
                    emailSender.sendEmailConfirmationEmail(applicationUser, token,user.Language);
                }
                UserRegistrationResponseDTO responseDTO = new UserRegistrationResponseDTO
                {
                    UserId = applicationUser.Id,
                    Email = applicationUser.Email,
                    FullName = applicationUser.FullName,
                    UserName = applicationUser.UserName
                };
                return responseDTO;
            }
            else
            {
                throw new ValidationException("Error While Creating User");
            }

        }

        private async Task<IList<Claim>> BuildClaims(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id > 0 ? user.Id.ToString() : string.Empty),
                new Claim(ClaimTypes.Name, !string.IsNullOrEmpty(user.FullName) ? user.FullName : ""),
                new Claim(ClaimTypes.MobilePhone, !string.IsNullOrEmpty(user.PhoneNumber) ? user.PhoneNumber : "")
            };
            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            return claims;
        }

        private string WriteToken(IList<Claim> claims)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfiguration.JWTKey));

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                    issuer: _appConfiguration.Issuer,
                    audience: _appConfiguration.Audience,
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddYears(100),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }

        public async Task<bool> ForgetPassword(ForgetPasswordDTO forgetPassword)
        {
            if (!string.IsNullOrEmpty(forgetPassword.EmailAddress) && _userManager.Users.Any(x => x.Email.Equals(forgetPassword.EmailAddress)))
            {
                var user = await _userManager.FindByEmailAsync(forgetPassword.EmailAddress);
                if(user != null && await _userManager.IsEmailConfirmedAsync(user))
                {
                    string token =await _userManager.GeneratePasswordResetTokenAsync(user);
                    if (!string.IsNullOrEmpty(token))
                    {
                         emailSender.sendResetPasswordEmail(user, token,forgetPassword.Language);
                    }

                    return true;
                }

                throw new ValidationException("There is a problem with this user");
            }
            else if(!string.IsNullOrEmpty(forgetPassword.PhoneNumber) && _userManager.Users.Any(x => x.PhoneNumber.Equals(forgetPassword.PhoneNumber)))
            {
                ApplicationUser user =  _userManager.Users.FirstOrDefault(x=>x.PhoneNumber.Equals(forgetPassword.PhoneNumber));
                if (user != null && await _userManager.IsPhoneNumberConfirmedAsync(user))
                {
                    string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    if (!string.IsNullOrEmpty(token))
                    {
                         emailSender.sendResetPasswordEmail(user, token,forgetPassword.Language);
                    }

                    return true;
                }

                throw new ValidationException("There is a problem with this user");
            }
            else
            {
                throw new ValidationException("Email Not Correct");

            }
        }

        public async Task<bool> ResetPassword(RestPasswordDTO restPassword)
        {
            var user =await _userManager.FindByEmailAsync(restPassword.EmailAddress);
            if(user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, restPassword.Token, restPassword.Password);
                if (result.Succeeded)
                {
                    return true;
                }
                throw new ValidationException("problem");

            }
            throw new ValidationException("User Not Exisits");
        }

        public async Task<bool> ConfirmEmailAsync(string userEmail, string token)
        { 
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return true;
                }
                throw new ValidationException("error while proccessing your request");
            }
            throw new ValidationException("Cannot Find The User");

        }

        public async Task<bool> UpdateRegistedUser(UpdateUserRegistrationDTO updateUserRegistrationDTO)
        {
            ApplicationUser user =  _userManager.Users.FirstOrDefault(x => x.Id == updateUserRegistrationDTO.ApplicationUserId);
            if(user != null)
            {

                var res = await _userManager.UpdateAsync(user);
                return true;
            }
            else
            {
                throw new ValidationException("");
            }

        }
    }
}
