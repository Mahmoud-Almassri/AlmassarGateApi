using AlmassarGateApi.Domain.DTO.AddDTO;
using AlmassarGateApi.Domain.DTO.LookupsDTO;
using AlmassarGateApi.Domain.SearchModels;
using Domains.DTO;
using Domains.Models;
using Domains.SearchModels;
using Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Service.Interfaces
{
    public interface IApprovalService : IService<Approval, BaseSearch>
    {
        //BaseListResponse<ApprovalDTO> GetList(ApprovalSearch ApprovalSearch);
        //ApprovalAddDTO AddEntity(ApprovalAddDTO entity);
        public ApprovalDTO GetById(int Id);
        public IEnumerable<ApprovalDTO> GetAllRecords();
        //ApprovalAddDTO UpdateEntity(ApprovalAddDTO entity);
    }
}
