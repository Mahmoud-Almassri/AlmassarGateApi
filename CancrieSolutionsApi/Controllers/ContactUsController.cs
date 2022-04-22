using AlmassarGate.Domain.Models;
using Domains.DTO;
using Domains.SearchModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Common;
using Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinecityApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        private readonly EmailSender emailSender;
        public ContactUsController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
            emailSender = new EmailSender();
        }


        [HttpPost]
        public IActionResult Create(ContactUs contactUs)
        {
            try
            {
                ContactUs result = _serviceUnitOfWork.ContactUs.Value.Add(contactUs);
                emailSender.SendReminderEmail();
                return Ok(result);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public IActionResult GetList(BaseSearch baseSearch)
        {
            try
            {
                BaseListResponse<ContactUs> ContactUs = _serviceUnitOfWork.ContactUs.Value.GetList(baseSearch);
                return Ok(ContactUs);
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
