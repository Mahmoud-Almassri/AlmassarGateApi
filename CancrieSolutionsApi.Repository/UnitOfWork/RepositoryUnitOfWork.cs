using AlmassarGateApi.Domain.Models;
using AlmassarGateApi.Repository.Interfaces;
using AlmassarGateApi.Repository.Repositories;
using AutoMapper;
using Domain;
using Repository.Context;
using Repository.Interfaces;
using Repository.Interfaces.Common;
using Repository.Repositories;
using Repository.Repositories.Common;
using System;

namespace Repository.UnitOfWork
{
    public class RepositoryUnitOfWork : IRepositoryUnitOfWork
    {
        private AlmassarGateContext _context;
        private IMapper _mapper;
       
        public Lazy<IApplicationExceptionsRepository> ApplicationExceptions { get; set; }
        public Lazy<IUserRoleRepository> UserRoles { get; set; }
        public Lazy<IRoleRepository>  RoleRepository { get; set; }
        public Lazy<IContactUsRepository>  ContactUs { get; set; }
        public Lazy<IAppSettingsRepository>  AppSettings { get; set; }
        public Lazy<ICheckListQuestionRepository> CheckListQuestion { get; set; }
        public Lazy<IPartRepository> Part { get; set; }
        public Lazy<IApprovalRepository> Approval { get; set; }
        public Lazy<ILookupsRepository> Lookups { get; set; }
        public Lazy<IProjectRepository> Project { get; set; }
        public Lazy<IActionRepository> Action { get; set; }
        public Lazy<ITaskRepository> Task { get; set; }
        public Lazy<IProjectFileRepository> ProjectFile { get; set; }

        public Lazy<ICheckListAnswerRepository> CheckListAnswer { get; set; }


        public RepositoryUnitOfWork(AlmassarGateContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            ApplicationExceptions = new Lazy<IApplicationExceptionsRepository>(() => new ApplicationExceptionsRepository(_context));
            UserRoles = new Lazy<IUserRoleRepository>(() => new UserRoleRepository(_context,_mapper));
            RoleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(_context));
            ContactUs = new Lazy<IContactUsRepository>(() => new ContactUsRepository(_context));
            AppSettings = new Lazy<IAppSettingsRepository>(() => new AppSettingsRepository(_context));
            CheckListQuestion = new Lazy<ICheckListQuestionRepository>(() => new CheckListQuestionRepository(_context));
            CheckListAnswer = new Lazy<ICheckListAnswerRepository>(() => new CheckListAnswerRepository(_context));
            Part = new Lazy<IPartRepository>(() => new PartRepository(_context));
            Approval = new Lazy<IApprovalRepository>(() => new ApprovalRepository(_context));
            Lookups = new Lazy<ILookupsRepository>(() => new LookupsRepository(_context));
            Project = new Lazy<IProjectRepository>(() => new ProjectRepository(_context));
            Action = new Lazy<IActionRepository>(() => new ActionRepository(_context));
            Task = new Lazy<ITaskRepository>(() => new TaskRepository(_context));
            ProjectFile = new Lazy<IProjectFileRepository>(() => new ProjectFileRepository(_context));
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
