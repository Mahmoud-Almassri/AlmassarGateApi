using AlmassarGateApi.Domain.DTO.AddDTO;
using AlmassarGateApi.Domain.DTO.LookupsDTO;
using AlmassarGateApi.Domain.SearchModels;
using Domains.DTO;
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
    public class ActionController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public ActionController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        //[HttpGet("{Id}")]
        //[Authorize]
        //public IActionResult GetById(int Id)
        //{
        //    try
        //    {
        //        ActionDTO Action = _serviceUnitOfWork.Action.Value.GetById(Id);
        //        return Ok(Action);
        //    }
        //    catch (ValidationException e)
        //    {
        //        return BadRequest(e);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        //[HttpGet]
        //[Authorize]
        //public IActionResult GetAllItems()
        //{
        //    try
        //    {
        //        IEnumerable<ActionDTO> Action = _serviceUnitOfWork.Action.Value.GetAllRecords();
        //        return Ok(Action);
        //    }
        //    catch (ValidationException e)
        //    {
        //        return BadRequest(e);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //} 
        [HttpGet]
        [Authorize]
        public IActionResult GetActionsByProjectId(int projectId)
        {
            try
            {
                List<ActionDTO> Action = _serviceUnitOfWork.Action.Value.GetActionsByProjectId(projectId);
                return Ok(Action);
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

        

       

      

        [HttpGet("{Id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _serviceUnitOfWork.Action.Value.Remove(Id);
                return Ok(true);
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
    }
}
