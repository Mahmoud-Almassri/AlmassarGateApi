using AlmassarGate.Domain.DTO;
using Domains.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AlmassarGate.Controllers.auth
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public AuthController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO loginDTO)
        {
            try
            {
                LoginResponseDTO tokenResponseDTO = await _serviceUnitOfWork.Auth.Value.Login(loginDTO);
                return Ok(tokenResponseDTO);

            }
            catch (Exception e)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> ExternalLogin([FromBody] ExternalAuthDTO externalAuth)
        {

            SocialLoginResponseDTO tokenResponseDTO = await _serviceUnitOfWork.Auth.Value.ExternalLogin(externalAuth);
            return Ok(tokenResponseDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AdminLogin(LoginRequestDTO loginDTO)
        {
            LoginResponseDTO tokenResponseDTO = await _serviceUnitOfWork.Auth.Value.AdminLogin(loginDTO);
            return Ok(tokenResponseDTO);
        }
        [HttpGet]
        public IActionResult GetDashboardData()
        {
            try
            {
                DashboardResponseDTO dashboardDTOs = _serviceUnitOfWork.Auth.Value.GetDashboardData();
                return Ok(dashboardDTOs);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] UpdatePasswordDTO updatePasswordDTO)
        {
            bool result = await _serviceUnitOfWork.Auth.Value.ChangePassword(updatePasswordDTO);
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDTO forgetPasswordDTO)
        {
            var res = await _serviceUnitOfWork.Auth.Value.ForgetPassword(forgetPasswordDTO);
            return Ok(res);
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> ResetPassword(RestPasswordDTO restPasswordDTO)
        {
            restPasswordDTO.Token = restPasswordDTO.Token.Replace(' ', '+');
            var res = await _serviceUnitOfWork.Auth.Value.ResetPassword(restPasswordDTO);
            return Ok(res);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> UserRegistration(UserRegistrationDTO user)
        {
            try
            {

                UserRegistrationResponseDTO res = await _serviceUnitOfWork.Auth.Value.UserRegistration(user);
                return Ok(res);
            }
            catch (ValidationException e)
            {

                return BadRequest(e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string uemail, string token)
        {
            if (!string.IsNullOrEmpty(uemail) && !string.IsNullOrEmpty(token))
            {
                token = token.Replace(' ', '+');
                var res = await _serviceUnitOfWork.Auth.Value.ConfirmEmailAsync(uemail, token);
                return Ok(res);

            }
            else
            {
                throw new ValidationException("error");
            }
        }
    }
}
