using AlmassarGateApi.Repository.Interfaces;
using Domains.Models;
using Repository.Context;
using Repository.Repositories.Common;

namespace AlmassarGateApi.Repository.Repositories
{
    public class ActionRepository : Repository<Action>, IActionRepository
    {
        private AlmassarGateContext _context;
        public ActionRepository(AlmassarGateContext context) : base(context)
        {
            _context = context;
        }
    }
}
