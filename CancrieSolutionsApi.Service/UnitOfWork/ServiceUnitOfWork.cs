using AutoMapper;
using AlmassarGate.Domain.Models;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repository.UnitOfWork;
using Service.Interfaces;
using Service.Interfaces.Common;
using Service.Services;
using Service.Services.Common;
using System;
using Repository.Context;
using Domains.Models;
using AlmassarGateApi.Service.Interfaces;
using AlmassarGateApi.Service.Services;
using AlmassarGateApi.Service.Services.Common;

namespace Service.UnitOfWork
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly LoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public Lazy<IApplicationExceptionsService> ApplicationExceptions { get; set; }
        public Lazy<IAuthService> Auth { get; set; }
        public Lazy<IUserService> User { get; set; }
        public Lazy<IWebUserService> WebUser { get; set; }
        public Lazy<IAppSettingsService> AppSettings { get; set; }
        public Lazy<IContactUsService> ContactUs { get; set; }
        public Lazy<ICheckListQuestionService> CheckListQuestion { get; set; }
        public Lazy<IPartService> Part { get; set; }
        public Lazy<IApprovalService> Approval { get; set; }
        public Lazy<ILookupService> Lookup { get; set; }
        public Lazy<IProjectService> Project { get; set; }
        public Lazy<IActionService> Action { get; set; }
        public Lazy<ITaskService> Task { get; set; }
        public Lazy<INotificationsService> Notification { get; set; }

        public ServiceUnitOfWork(AlmassarGateContext context,
                                UserManager<ApplicationUser> userManager,
                                IHttpContextAccessor httpContextAccessor,
                                SignInManager<ApplicationUser> signInManager,
                                IWebHostEnvironment webHostEnvironment,
                                IConfiguration configuration,
                                IMapper mapper)
        {
            _repositoryUnitOfWork = new RepositoryUnitOfWork(context, mapper);
            _loggedInUserService = new LoggedInUserService(httpContextAccessor);
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            ApplicationExceptions = new Lazy<IApplicationExceptionsService>(() => new ApplicationExceptionsService(_repositoryUnitOfWork));
            Auth = new Lazy<IAuthService>(() => new AuthService(configuration, userManager, _repositoryUnitOfWork, signInManager, _loggedInUserService));
            User = new Lazy<IUserService>(() => new UserService(userManager, _repositoryUnitOfWork, _loggedInUserService, _mapper));
            WebUser = new Lazy<IWebUserService>(() => new WebUserService(userManager, _repositoryUnitOfWork, _loggedInUserService, _mapper));
            ContactUs = new Lazy<IContactUsService>(() => new ContactUsService(_repositoryUnitOfWork));
            AppSettings = new Lazy<IAppSettingsService>(() => new AppSettingsService(_repositoryUnitOfWork, _mapper));
            CheckListQuestion = new Lazy<ICheckListQuestionService>(() => new CheckListQuestionService(_repositoryUnitOfWork, _mapper));
            Part = new Lazy<IPartService>(() => new PartService(_repositoryUnitOfWork, _mapper));
            Approval = new Lazy<IApprovalService>(() => new ApprovalService(_repositoryUnitOfWork, _mapper, _loggedInUserService));
            Lookup = new Lazy<ILookupService>(() => new LookupService(_repositoryUnitOfWork, _mapper));
            Action = new Lazy<IActionService>(() => new ActionService(_repositoryUnitOfWork, _mapper));
            Project = new Lazy<IProjectService>(() => new ProjectService(_repositoryUnitOfWork, _mapper, webHostEnvironment));
            Task = new Lazy<ITaskService>(() => new TaskService(_repositoryUnitOfWork, _mapper, _loggedInUserService));
            Notification = new Lazy<INotificationsService>(() => new NotificationsService(userManager));
        }

        public void Dispose() { }
    }
}
