using AlmassarGate.Domain.Models;
using System.Threading.Tasks;
using AlmassarGate.Domain.DTO;
using Domains.DTO;
using Google.Apis.Auth;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO model);
        Task<LoginResponseDTO> AdminLogin(LoginRequestDTO model);
        Task<bool> ChangePassword(UpdatePasswordDTO updatePasswordDTO);
        DashboardResponseDTO GetDashboardData();
        Task<bool> ForgetPassword(ForgetPasswordDTO forgetPassword);
        Task<UserRegistrationResponseDTO> UserRegistration(UserRegistrationDTO user);

        Task<bool> ResetPassword(RestPasswordDTO restPassword);
        Task<bool> ConfirmEmailAsync(string userEmail, string token);
        Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDTO externalAuth);
        Task<SocialLoginResponseDTO> ExternalLogin(ExternalAuthDTO externalAuth);
    }
}
