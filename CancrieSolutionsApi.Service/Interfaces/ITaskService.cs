using AlmassarGateApi.Domain.SearchModels;
using Domains.DTO;
using Domains.Models;
using Domains.SearchModels;
using Service.Interfaces.Common;
using System.Collections.Generic;
using Task = Domains.Models.Task;

namespace AlmassarGateApi.Service.Interfaces
{
    public interface ITaskService : IService<Task, BaseSearch>
    {
        bool CheckWithTasks(int[] ids);
        BaseListResponse<Approval> GetList(TaskSearch taskSearch);
    }
}
