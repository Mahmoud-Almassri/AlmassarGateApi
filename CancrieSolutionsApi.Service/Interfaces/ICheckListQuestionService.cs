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
    public interface ICheckListQuestionService : IService<ChecklistQuestion, BaseSearch>
    {
        BaseListResponse<CheckListQuestionDTO> GetList(CheckListQuestionSearch checkListQuestionSearch);
        CheckListQuestionAddDTO AddEntity(CheckListQuestionAddDTO entity);
        public CheckListQuestionDTO GetById(int Id);
        public IEnumerable<CheckListQuestionDTO> GetAllRecords();
        CheckListQuestionAddDTO UpdateEntity(CheckListQuestionAddDTO entity);
        IEnumerable<CheckListQuestionDTO> GetAllRecordsWithAnswers();
    }
}
