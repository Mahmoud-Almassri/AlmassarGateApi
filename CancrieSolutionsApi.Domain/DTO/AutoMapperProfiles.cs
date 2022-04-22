using AutoMapper;
using AlmassarGate.Domain.DTO.AddDTO;
using AlmassarGate.Domain.Models;
using Domains.Models;
using AlmassarGateApi.Domain.DTO.AddDTO;
using Domains.SearchModels;
using AlmassarGateApi.Domain.DTO.LookupsDTO;
using Domains.DTO;
using System.Linq;
using System;
using AlmassarGate.Domain.Models.Common;
using System.Collections.Generic;
using AlmassarGateApi.Domain.Models;
using Action = Domains.Models.Action;
using AlmassarGateApi.Domain.DTO;

namespace AlmassarGate.Domain.DTO
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ApplicationUser, UserProfileRequestDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserProfileResponseDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserRequestDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserResponseDTO>().ReverseMap();
            CreateMap<Roles, RoleDTO>().ReverseMap();
            CreateMap<UserRoles, UserRolesDTO>().ReverseMap();
            CreateMap<AppSettings, AppSettingsAddUpdateDTO>().ReverseMap();
            CreateMap<AppSettings, AppSettingsAddUpdateDTO>().ReverseMap();
            CreateMap<ChecklistQuestion, CheckListQuestionAddDTO>().ReverseMap();
            CreateMap<CheckListQuestionDTO, ChecklistQuestion>().ReverseMap();
            CreateMap<Part, PartAddDTO>().ReverseMap();
            CreateMap<PartDTO, Part>().ReverseMap();
            CreateMap<Approval, ApprovalDTO>().ReverseMap();
            CreateMap<Project, ProjectAddDTO>().ReverseMap();
            CreateMap<Project, ProjectListDTO>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<Lookup, LookupDTO>().ReverseMap();
            CreateMap<ProjectFiles, ProjectFilesDTO>().ReverseMap();
            CreateMap<Action, ActionDTO>()
                .ForMember(dest => dest.CreatedBy,
                            opt => opt.MapFrom(src => src.CreatedBy.FullName))
                .ForMember(dest=>dest.TaskName,src=>src.MapFrom(x=>x.Approval.Task.Title))
                .ReverseMap();
            CreateMap<Task, TaskDTO>()
                 .AfterMap((src, dest) => dest.ReadOnlyControls =FetchNumbers(src.ReadOnlyControls).ToList())
                 .AfterMap((src, dest) => dest.RequiredControls = FetchNumbers(src.RequiredControls).ToList())
                 .AfterMap((src, dest) => dest.CheckWithTasks = FetchNumbers(src.CheckWithTasks).ToList())
                 .AfterMap((src, dest) => dest.NextTaskIds = FetchNumbers(src.NextTaskIds).ToList())
                 .AfterMap((src, dest) => dest.PrevTaskIds = FetchNumbers(src.PrevTaskIds).ToList())
                 .AfterMap((src, dest) => dest.ReadOnlyControlsNumbers = Array.ConvertAll(FetchNumbers(src.ReadOnlyControls).ToArray(), s => int.Parse(s)).ToList())
                 .AfterMap((src, dest) => dest.RequiredControlsNumbers = Array.ConvertAll(FetchNumbers(src.RequiredControls).ToArray(), s => int.Parse(s)).ToList())
                 .AfterMap((src, dest) => dest.CheckWithTasksNumbers = Array.ConvertAll(FetchNumbers(src.CheckWithTasks).ToArray(), s => int.Parse(s)).ToList())
                 .ReverseMap();

        }
      public static string[] FetchNumbers(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Array.Empty<string>();
            }
            else
            {
                return value.Split(',');
            }
        }
    }
}
