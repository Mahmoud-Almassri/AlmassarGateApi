using AlmassarGate.Domain.DTO.AddDTO;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System;

namespace BusinecityApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppSettingsController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public AppSettingsController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet]
        public IActionResult GetAppSettings()
        {
            return Ok(_serviceUnitOfWork.AppSettings.Value.GetAppSettings());
        }

        [HttpPost]
        public IActionResult Update(AppSettingsAddUpdateDTO addUpdateDTO)
        {
            try
            {
                return Ok(_serviceUnitOfWork.AppSettings.Value.UpdateEntity(addUpdateDTO));

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
