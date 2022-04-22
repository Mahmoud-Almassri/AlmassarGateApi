using AlmassarGateApi.Repository.Interfaces;
using Repository.Interfaces;
using Repository.Interfaces.Common;
using Repository.Repositories;
using System;

namespace Repository.UnitOfWork
{
    public interface IRepositoryUnitOfWork : IDisposable
    {
        Lazy<IApplicationExceptionsRepository> ApplicationExceptions { get; set; }
        Lazy<IUserRoleRepository> UserRoles { get; set; }
        Lazy<IRoleRepository> RoleRepository { get; set; }
        Lazy<IContactUsRepository> ContactUs { get; set; }
        Lazy<IAppSettingsRepository> AppSettings { get; set; }
        Lazy<ICheckListQuestionRepository> CheckListQuestion { get; set; }
        Lazy<ICheckListAnswerRepository> CheckListAnswer { get; set; }

        Lazy<IPartRepository> Part { get; set; }

        Lazy<IApprovalRepository> Approval { get; set; }
        Lazy<ILookupsRepository> Lookups { get; set; }
        Lazy<IProjectRepository> Project { get; set; }
        Lazy<IActionRepository> Action { get; set; }
        Lazy<ITaskRepository> Task { get; set; }
        Lazy<IProjectFileRepository> ProjectFile { get; set; }



    }
}
