using AlmassarGateApi.Service.Interfaces;
using Service.Interfaces;
using Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.UnitOfWork
{
    public interface IServiceUnitOfWork : IDisposable
    {
        Lazy<IApplicationExceptionsService> ApplicationExceptions { get; set; }
        Lazy<IAuthService> Auth { get; set; }
        Lazy<IUserService> User { get; set; }
        Lazy<IWebUserService> WebUser { get; set; }
        Lazy<IContactUsService> ContactUs { get; set; }
        Lazy<IAppSettingsService> AppSettings { get; set; }
        Lazy<ICheckListQuestionService> CheckListQuestion { get; set; }
        Lazy<IPartService> Part { get; set; }
        Lazy<IApprovalService> Approval { get; set; }
        Lazy<ILookupService> Lookup { get; set; }
        Lazy<IProjectService> Project { get; set; }
        Lazy<IActionService> Action { get; set; }
        Lazy<ITaskService> Task { get; set; }
        Lazy<INotificationsService> Notification { get; set; }

    }
}
