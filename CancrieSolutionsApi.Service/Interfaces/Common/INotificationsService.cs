using AlmassarGateApi.Domain.Models.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Service.Interfaces
{
    public interface INotificationsService 
    {
        Task<bool> SendEmail(string Email, string Subject, string Body);
        Task<bool> SendNotificationToUsersAsync(PushNotification notificationModel);
    }
}
