using AlmassarGateApi.Domain.DTO.AddDTO;
using Domains.DTO;
using Domains.Models;
using Service.Interfaces.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IProjectService : IService<Project>
    {
        ProjectAddDTO AddEntity(ProjectAddDTO entity);
        Task<bool> UpdateProject(ProjectUpdateDTO entity);
        BaseListResponse<ProjectListDTO> GetList(ProjectSearchDTO baseSearch);
        ProjectDTO GetById(int Id);
        bool DeleteFile(int fileId);
        bool AddFile(ProjectFilesAddDTO file);
        bool SubmitQcForm(SubmitQcFormDTO entity);
    }
}
