using Domain;
using AlmassarGate.Domain.Models.Common;
using Repository.Repositories.Common;
using Repository.Context;
using AlmassarGateApi.Repository.Interfaces;
using Domains.Models;

namespace AlmassarGateApi.Repository.Repositories
{
    public class CheckListQuestionRepository : Repository<ChecklistQuestion>, ICheckListQuestionRepository
    {
        private AlmassarGateContext _context;
        public CheckListQuestionRepository(AlmassarGateContext context) : base(context)
        {
            _context = context;
        }
    }
}
