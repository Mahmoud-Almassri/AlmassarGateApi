using AutoMapper;
using AlmassarGate.Domain.DTO;
using AlmassarGate.Domain.Models;
using AlmassarGate.Domain.Models.Common;
using Domain.SearchModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.UnitOfWork;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domains.Models;
using AlmassarGateApi.Domain.SearchModels;
using Domains.DTO;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private UserManager<ApplicationUser> _userManager;
        private LoggedInUserService _loggedInUserService;
        private IMapper _mapper;
        AppConfiguration _appConfiguration = new AppConfiguration();

        public UserService(UserManager<ApplicationUser> userManager, IRepositoryUnitOfWork repositoryUnitOfWork, LoggedInUserService loggedInUserService, IMapper mapper)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _userManager = userManager;
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
        }

        //For Admin
        public async Task<UserResponseDTO> Register(RegisterDTO model)
        {
            if (_userManager.Users.Any(x => x.PhoneNumber == model.PhoneNumber))
            {
                throw new ValidationException("Phone Number Already Exists");
            }
            if (_userManager.Users.Any(x => x.UserName == model.UserName))
            {
                throw new ValidationException("UserName Already Exists");
            }

            ApplicationUser user = new ApplicationUser
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                IsActive=true
            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                _repositoryUnitOfWork.UserRoles.Value.Add(new UserRoles
                {
                    RoleId = model.RoleId,
                    UserId = user.Id,
                });
                return _mapper.Map<UserResponseDTO>(user);
            }
            else
            {
                throw new ValidationException("Error While Creating User");
            }
        }

        public async Task<UserResponseDTO> UpdateUserInfo(UserRequestDTO userInfo)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userInfo.Id.ToString());

            user.Email = userInfo.Email;
            user.PhoneNumber = userInfo.PhoneNumber;
            user.FullName = userInfo.FullName;
            user.IsActive = !user.IsActive;
          

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return _mapper.Map<UserResponseDTO>(user); ;
            }
            throw new Exception("Error in Updating User Info");
        }

        public async Task<bool> RemoveUser(int userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new ValidationException("User not found");
            }

            IdentityResult result = await _userManager.DeleteAsync(user);

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
                throw new Exception("Error while removing user");
            }
        }

        public async Task<UserResponseDTO> GetUserInfo(int userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
            UserResponseDTO userDTO = _mapper.Map<UserResponseDTO>(user);
            return userDTO;
        }

        public async Task<ListResponse<UserResponseDTO>> GetUsersList(UserSearchModel search)
        {
            List<ApplicationUser> users = await _userManager.Users.Where(x =>
                                                 (string.IsNullOrEmpty(search.SearchValue) ||
                                                 (x.FullName.Contains(search.SearchValue) || x.UserName.Contains(search.SearchValue) || x.Email.Contains(search.SearchValue) || x.PhoneNumber.Contains(search.SearchValue))) &&
                                                 (!search.RoleType.HasValue || x.UserRoles.Any(y => y.RoleId == search.RoleType))).ToListAsync();

            int pageCount = users.Count();

            users = users.Skip(_appConfiguration.PageSize * (search.PageNumber - 1)).Take(_appConfiguration.PageSize).ToList();

            ListResponse<UserResponseDTO> UsersListResponse = new ListResponse<UserResponseDTO>
            {
                entities = _mapper.Map<List<UserResponseDTO>>(users),
                TotalCount = pageCount
            };

            return UsersListResponse;
        }

        public BaseListResponse<UserRoles> GetList(GroupSearch groupSearch)
        {
            return _repositoryUnitOfWork.UserRoles.Value.GetList(groupSearch);
        }
        // For LoggedIn User
        public async Task<UserProfileResponseDTO> GetUserProfile()
        {
            long userId = _loggedInUserService.GetUserId();
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
            UserProfileResponseDTO userProfileDTO = _mapper.Map<UserProfileResponseDTO>(user);
            return userProfileDTO;
        }

        public async Task<UserProfileResponseDTO> UpdateUserProfile(UserProfileRequestDTO userProfile)
        {
            long userId = _loggedInUserService.GetUserId();
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());

            user.Email = userProfile.Email;
            user.PhoneNumber = userProfile.PhoneNumber;
            user.FullName = userProfile.FullName;

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return _mapper.Map<UserProfileResponseDTO>(user); ;
            }
            throw new Exception("Error in Updating User Info");
        }

        public IList<RoleDTO> GetRoles()
        {
            IList<RoleDTO> roles = _repositoryUnitOfWork.UserRoles.Value.GetRoles();
            return roles;
        }
        public IEnumerable<RoleDTO> GetBaseRoles()
        {
            IList<RoleDTO> roles = _repositoryUnitOfWork.UserRoles.Value.GetRoles();
            IEnumerable<RoleDTO> roleDTOs = roles.Where(x => x.Name.Trim().ToLower() != "Admin");
            return roleDTOs;
        }
        public IList<UserResponseDTO> GetUsers()
        {
            IList<UserResponseDTO> users = _repositoryUnitOfWork.UserRoles.Value.GetUsers();
            return users;
        }
        public UserRolesDTO AddUserGroup(UserRolesDTO userRole)
        {
            var user = _mapper.Map<UserRoles>(userRole);
            _repositoryUnitOfWork.UserRoles.Value.Add(user);
            return userRole;
        }
        public UserRolesDTO RemoveUserRole(UserRolesDTO userRoles)
        {
            UserRoles user = new UserRoles
            {
                RoleId = userRoles.RoleId,
                UserId = userRoles.UserId
            };
            _repositoryUnitOfWork.UserRoles.Value.RemoveEmployeeRole(userRoles);
            return userRoles;
        }
    }
}
