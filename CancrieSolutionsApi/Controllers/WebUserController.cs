using AlmassarGate.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System.Threading.Tasks;

namespace BusinecityApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WebUserController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public WebUserController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetWebUserProfile()
        {
            var user = await _serviceUnitOfWork.WebUser.Value.GetWebUserProfile();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWebUserProfile(UserProfileRequestDTO userProfile)
        {
            var user = await _serviceUnitOfWork.WebUser.Value.UpdateWebUserProfile(userProfile);
            return Ok(user);
        }

    }
}
