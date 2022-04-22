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
    public class CheckListQuestion : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public CheckListQuestion(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet("{Id}")]
        [Authorize]
        public IActionResult GetById(int Id)
        {
            try
            {
                CheckListQuestionDTO CheckListQuestion = _serviceUnitOfWork.CheckListQuestion.Value.GetById(Id);
                return Ok(CheckListQuestion);
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
                IEnumerable<CheckListQuestionDTO> CheckListQuestion = _serviceUnitOfWork.CheckListQuestion.Value.GetAllRecords();
                return Ok(CheckListQuestion);
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
        public IActionResult GetAllRecordsWithAnswers()
        {
            try
            {
                IEnumerable<CheckListQuestionDTO> CheckListQuestion = _serviceUnitOfWork.CheckListQuestion.Value.GetAllRecordsWithAnswers();
                return Ok(CheckListQuestion);
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
        public IActionResult GetList([FromBody] CheckListQuestionSearch checkListQuestionSearch)
        {
            try
            {
                BaseListResponse<CheckListQuestionDTO> CheckListQuestion = _serviceUnitOfWork.CheckListQuestion.Value.GetList(checkListQuestionSearch);
                return Ok(CheckListQuestion);
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
        public IActionResult Create([FromBody] CheckListQuestionAddDTO CheckQuestionList)
        {
            try
            {
                _serviceUnitOfWork.CheckListQuestion.Value.AddEntity(CheckQuestionList);
                return Ok(CheckQuestionList);
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
        public IActionResult Update([FromBody] CheckListQuestionAddDTO CheckQuestionList)
        {
            try
            {
                _serviceUnitOfWork.CheckListQuestion.Value.UpdateEntity(CheckQuestionList);
                return Ok(CheckQuestionList);
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
                _serviceUnitOfWork.CheckListQuestion.Value.Remove(Id);
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
