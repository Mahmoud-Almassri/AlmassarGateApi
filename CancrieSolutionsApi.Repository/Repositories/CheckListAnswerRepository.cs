using AlmassarGateApi.Repository.Interfaces;
using Domains.Models;
using Repository.Context;
using Repository.Repositories.Common;

namespace AlmassarGateApi.Repository.Repositories
{
    public class CheckListAnswerRepository : Repository<ChecklistAnswer>, ICheckListAnswerRepository
    {
        private AlmassarGateContext _context;
        public CheckListAnswerRepository(AlmassarGateContext context) : base(context)
        {
            _context = context;
        }
    }
}
