using AlmassarGate.Domain.Enums;
using AlmassarGateApi.Domain.SearchModels;
using AlmassarGateApi.Repository.Interfaces;
using Domains.DTO;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Repositories.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = Domains.Models.Task;

namespace AlmassarGateApi.Repository.Repositories
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        private AlmassarGateContext _context;
        public TaskRepository(AlmassarGateContext context) : base(context)
        {
            _context = context;
        }
        public bool CheckWithTasks(int[] ids)
        {
            List<Task> tasks = _context.Tasks.Where(x => ids.Any(i => i == x.Id)).ToList();
            if (tasks.Any(x => x.Status != BaseStatus.Closed))
            {
                return true;
            }
            return false;
        }
        public async Task<bool> OpenTasks(int[] ids)
        {
            List<Task> tasks = _context.Tasks.Where(x => ids.Any(i => i == x.Id)).ToList();
            foreach (var task in tasks)
            {
                task.Status = BaseStatus.Opened;
            }
            await _context.SaveChangesAsync();
            return true;
        }
        //public List<Approval> GetList(TaskSearch taskSearch, int userId)
        //{
        //    return  _context.Approvals.Where(t => t.Task.RoleId == userId).ToList();

        //}
    }
}
