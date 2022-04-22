using AlmassarGateApi.Domain.DTO.AddDTO;
using AlmassarGateApi.Domain.DTO.LookupsDTO;
using AlmassarGateApi.Domain.SearchModels;
using Domains.DTO;
using Domains.Models;
using Domains.SearchModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlmassarGateApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public TaskController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpPost]
        [Authorize]
        public IActionResult GetList([FromBody] TaskSearch taskSearch)
        {
            BaseListResponse<Approval> tasksList = _serviceUnitOfWork.Task.Value.GetList(taskSearch);
            return Ok(tasksList);

        }
 
    }
}

