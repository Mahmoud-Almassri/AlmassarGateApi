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
    public class Part : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public Part(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet("{Id}")]
        [Authorize]
        public IActionResult GetById(int Id)
        {
            try
            {
                PartDTO Part = _serviceUnitOfWork.Part.Value.GetById(Id);
                return Ok(Part);
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

        [HttpGet]
        [Authorize]
        public IActionResult GetAllItems()
        {
            try
            {
                IEnumerable<PartDTO> Part = _serviceUnitOfWork.Part.Value.GetAllRecords();
                return Ok(Part);
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

        [HttpPost]
        [Authorize]
        public IActionResult GetList([FromBody] PartSearch partSearch)
        {
            try
            {
                BaseListResponse<PartDTO> Part = _serviceUnitOfWork.Part.Value.GetList(partSearch);
                return Ok(Part);
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

        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] PartAddDTO Part)
        {
            try
            {
                _serviceUnitOfWork.Part.Value.AddEntity(Part);
                return Ok(Part);
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

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody] PartAddDTO Part)
        {
            try
            {
                _serviceUnitOfWork.Part.Value.UpdateEntity(Part);
                return Ok(Part);
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
                _serviceUnitOfWork.Part.Value.Remove(Id);
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
