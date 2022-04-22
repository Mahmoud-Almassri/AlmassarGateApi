using AlmassarGate.Domain.DTO.AddDTO;
using AlmassarGate.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System;

namespace BusinecityApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public LookupController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet]
        public IActionResult GetLookupsByParent(EntitiesEnum parentId)
        {
            return Ok(_serviceUnitOfWork.Lookup.Value.GetLookupsByParent(parentId));
        }

       
    }
}
