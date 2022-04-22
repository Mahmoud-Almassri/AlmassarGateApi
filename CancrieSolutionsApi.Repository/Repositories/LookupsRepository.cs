using AlmassarGate.Domain.Enums;
using AlmassarGate.Domain.Models;
using AlmassarGate.Domain.Models.Common;
using Repository.Context;
using Repository.Interfaces;
using Repository.Repositories.Common;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
    public class LookupsRepository : Repository<Lookup>, ILookupsRepository
    {
        private AlmassarGateContext _context;

        public LookupsRepository(AlmassarGateContext context) : base(context)
        {
            _context = context;
        }

        public IList<Lookup> GetLookupsByParent(EntitiesEnum parentId)
        {
            List<Lookup> lookups = _context.Lookups.Where(x=>x.ParentId==parentId).ToList();
            return lookups;
        }
    }
}
