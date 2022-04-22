using AlmassarGateApi.Domain.Models.Common;
using AlmassarGateApi.Domain.Utilities;
using AlmassarGateApi.Service.Interfaces;
using Domains.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin.Messaging;

namespace AlmassarGateApi.Service.Services.Common
{
    public class NotificationsService : INotificationsService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public NotificationsService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> SendEmail(string Email, string Subject, string Body)
        {
            try
            {
                string subject = Subject;
                string body = @"<div>
                            <p>Dear " + Email + @",</p>
                            <p>" + Body + @".</p>
                            <p>Best Regards.</p><br/>
                            <p>AlMassarGate.</p><br/>
                            </div>";
                SendNotification.SendEmails(Email, subject, body);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public async Task<bool> SendNotificationToUsersAsync(PushNotification notificationModel)
        {
            List<ApplicationUser> admins = _userManager.Users.Where(x => x.UserRoles.Any(y => y.RoleId == 3)).ToList();
            foreach (var user in admins)
            {
                if (!string.IsNullOrEmpty(user.RegId))
                {
                    notificationModel.DeviceToken = user.RegId;
                    await SendPushNotification(notificationModel);
                }
            }
            return true;
        }
        private async Task<bool> SendPushNotification(PushNotification notificationModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(notificationModel.DeviceToken))
                {
                    var message = new Message()
                    {
                        Notification = new Notification()
                        {
                            Title = notificationModel.Title,
                            Body = notificationModel.Body
                        },
                        Token = notificationModel.DeviceToken
                    };

                    string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
                }
                return true;
            }
            catch (System.Exception)
            {
                return true;
            }

        }
    }
}
