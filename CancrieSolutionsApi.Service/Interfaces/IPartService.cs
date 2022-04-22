using AlmassarGateApi.Domain.DTO.AddDTO;
using AlmassarGateApi.Domain.DTO.LookupsDTO;
using AlmassarGateApi.Domain.Models;
using AlmassarGateApi.Domain.SearchModels;
using Domains.DTO;
using Domains.SearchModels;
using Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Service.Interfaces
{
    public interface IPartService : IService<Part, PartSearch>
    {
        BaseListResponse<PartDTO> GetList(PartSearch partSearch);
        PartAddDTO AddEntity(PartAddDTO entity);
        public PartDTO GetById(int Id);
        public IEnumerable<PartDTO> GetAllRecords();
        PartAddDTO UpdateEntity(PartAddDTO entity);
    }
}
