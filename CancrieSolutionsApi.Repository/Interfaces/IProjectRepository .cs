using AlmassarGateApi.Domain.SearchModels;
using Domains.DTO;
using Domains.Models;
using Repository.Interfaces.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<ProjectUpdateDTO> UpdateProject(ProjectUpdateDTO projectDto,int taskId);
    }
}
