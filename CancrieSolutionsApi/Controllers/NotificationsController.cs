using AlmassarGateApi.Domain.DTO;
using AlmassarGateApi.Domain.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlmassarGateApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public NotificationsController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        [HttpGet]
        public IActionResult SendEmail(string Email, string Subject, string Body)
        {
            try
            {
               var res = _serviceUnitOfWork.Notification.Value.SendEmail(Email, Subject, Body);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> PushNotification([FromBody] PushNotificationDTO pushNotificationDTO)
        {
            try
            {
                PushNotification notificationModel = new PushNotification();
                notificationModel.Title = pushNotificationDTO.Title;
                notificationModel.Body = pushNotificationDTO.Body;
                return Ok(await _serviceUnitOfWork.Notification.Value.SendNotificationToUsersAsync(notificationModel));
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
