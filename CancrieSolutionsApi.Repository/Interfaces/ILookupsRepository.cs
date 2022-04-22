using AlmassarGate.Domain.Enums;
using AlmassarGate.Domain.Models.Common;
using Repository.Interfaces.Common;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface ILookupsRepository : IRepository<Lookup>
    {
        IList<Lookup> GetLookupsByParent(EntitiesEnum parentId);
    }
}
