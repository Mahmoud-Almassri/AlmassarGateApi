using AlmassarGate.Domain.DTO.AddDTO;
using AlmassarGate.Domain.Enums;
using AlmassarGate.Domain.Models;
using AlmassarGate.Domain.Models.Common;
using Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface ILookupService : IService<Lookup>
    {
        List<LookupDTO> GetLookupsByParent(EntitiesEnum parentId);
        LookupDTO AddEntity(LookupDTO entity);
    }
}
