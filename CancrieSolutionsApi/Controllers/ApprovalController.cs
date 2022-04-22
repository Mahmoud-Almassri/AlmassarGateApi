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
    public class ApprovalController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public ApprovalController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet("{Id}")]
        [Authorize]
        public IActionResult GetById(int Id)
        {
            try
            {
                ApprovalDTO Approval = _serviceUnitOfWork.Approval.Value.GetById(Id);
                return Ok(Approval);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (System.Web.Http.HttpResponseException e)
            {
                return Unauthorized();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllItems()
        {
            try
            {
                IEnumerable<ApprovalDTO> Approval = _serviceUnitOfWork.Approval.Value.GetAllRecords();
                return Ok(Approval);
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
                _serviceUnitOfWork.Approval.Value.Remove(Id);
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
