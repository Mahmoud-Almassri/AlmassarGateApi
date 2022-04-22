using AlmassarGateApi.Domain.SearchModels;
using Domains.Models;
using Repository.Interfaces.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = Domains.Models.Task;

namespace AlmassarGateApi.Repository.Interfaces
{
    public interface ITaskRepository : IRepository<Task>
    {
        bool CheckWithTasks(int[] ids);
        Task<bool> OpenTasks(int[] ids);
    }
}
