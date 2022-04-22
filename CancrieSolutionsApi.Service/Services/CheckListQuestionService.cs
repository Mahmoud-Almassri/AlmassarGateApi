using AlmassarGateApi.Service.Interfaces;
using AutoMapper;
using Domains.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AlmassarGateApi.Domain.DTO.LookupsDTO;
using AlmassarGateApi.Domain.DTO.AddDTO;
using System.ComponentModel.DataAnnotations;
using Domains.DTO;
using Domains.SearchModels;
using AlmassarGateApi.Domain.SearchModels;

namespace AlmassarGateApi.Service.Services
{
    public class CheckListQuestionService : ICheckListQuestionService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private IMapper _mapper;

        public CheckListQuestionService(IRepositoryUnitOfWork repositoryUnitOfWork, IMapper mapper)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
        }
        public CheckListQuestionAddDTO AddEntity(CheckListQuestionAddDTO entity)
        {
            ChecklistQuestion CheckListQuestion = _mapper.Map<ChecklistQuestion>(entity);
            if (_repositoryUnitOfWork.CheckListQuestion.Value.Any(x => x.QuestionText == CheckListQuestion.QuestionText))
            {
                throw new ValidationException("Question Already exists");
            }
            _repositoryUnitOfWork.CheckListQuestion.Value.Add(CheckListQuestion);
            return entity;
}
        public ChecklistQuestion Update(ChecklistQuestion entity)
        {
            _repositoryUnitOfWork.CheckListQuestion.Value.Update(entity);
            return entity;
        }

        public ChecklistQuestion Get(int Id)
        {
            ChecklistQuestion CheckListQuestion = _repositoryUnitOfWork.CheckListQuestion.Value.Get(Id);
            return CheckListQuestion;
        }

       
        public BaseListResponse<CheckListQuestionDTO> GetList(CheckListQuestionSearch checkListQuestionSearch)
       {
            BaseListResponse<ChecklistQuestion> CheckListQuestion = _repositoryUnitOfWork.CheckListQuestion.Value.GetList(x =>
            (string.IsNullOrEmpty(checkListQuestionSearch.QuestionText) || x.QuestionText.Contains(checkListQuestionSearch.QuestionText)) &&
            (!checkListQuestionSearch.Status.HasValue || x.Status== checkListQuestionSearch.Status) 
            , checkListQuestionSearch.PageSize, checkListQuestionSearch.PageNumber);
            var mappedCheckListQuestion = _mapper.Map<List<CheckListQuestionDTO>>(CheckListQuestion.Entities);
            return new BaseListResponse<CheckListQuestionDTO> {
            Entities=mappedCheckListQuestion,
            TotalCount= CheckListQuestion.TotalCount
            };
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.CheckListQuestion.Value.Remove(Id);
            return true;
        }

        public IEnumerable<ChecklistQuestion> AddRange(IEnumerable<ChecklistQuestion> entities)
        {
            IEnumerable<ChecklistQuestion> CheckListQuestion = _repositoryUnitOfWork.CheckListQuestion.Value.AddRange(entities);
            return CheckListQuestion;
        }


        public IEnumerable<ChecklistQuestion> GetAll()
        {
            return _repositoryUnitOfWork.CheckListQuestion.Value.GetAll();
        }

        public IEnumerable<ChecklistQuestion> RemoveRange(IEnumerable<ChecklistQuestion> entities)
        {
            IEnumerable<ChecklistQuestion> CheckListQuestion = _repositoryUnitOfWork.CheckListQuestion.Value.RemoveRange(entities);
            return CheckListQuestion;
        }

        public IEnumerable<ChecklistQuestion> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<ChecklistQuestion> UpdateRange(IEnumerable<ChecklistQuestion> entities)
        {
            IEnumerable<ChecklistQuestion> CheckListQuestion = _repositoryUnitOfWork.CheckListQuestion.Value.UpdateRange(entities);
            return CheckListQuestion;
        }

        public BaseListResponse<ChecklistQuestion> List(BaseSearch entity)
        {
            BaseListResponse<ChecklistQuestion> listResponse = _repositoryUnitOfWork.CheckListQuestion.Value.GetList(x=>
                                                                                                        (string.IsNullOrEmpty(entity.Name) 
                                                                                                        || x.QuestionText == entity.Name)
                                                                                                        ,entity.PageSize
                                                                                                        ,entity.PageNumber);
            return listResponse;
        }

        public ChecklistQuestion Add(ChecklistQuestion entity)
        {
            ChecklistQuestion ChecklistQuestion = _repositoryUnitOfWork.CheckListQuestion.Value.Add(entity);
            return ChecklistQuestion;
        }

        public CheckListQuestionDTO GetById(int Id)
        {
            ChecklistQuestion CheckListQuestion = _repositoryUnitOfWork.CheckListQuestion.Value.FirstOrDefault(x => x.Id == Id, x => x.ModifiedBy, x => x.CreatedBy);
            CheckListQuestionDTO CheckListQuestionDTO = _mapper.Map<CheckListQuestionDTO>(CheckListQuestion);
            return CheckListQuestionDTO;
        }

        public IEnumerable<CheckListQuestionDTO> GetAllRecords()
        {
            IEnumerable<ChecklistQuestion> CheckListQuestion = _repositoryUnitOfWork.CheckListQuestion.Value.GetAll(x => x.ModifiedBy, x => x.CreatedBy);
            IEnumerable<CheckListQuestionDTO> CheckListQuestionDTO = _mapper.Map<List<CheckListQuestionDTO>>(CheckListQuestion);
            return CheckListQuestionDTO;
        }
        public IEnumerable<CheckListQuestionDTO> GetAllRecordsWithAnswers()
        {
            IEnumerable<ChecklistQuestion> CheckListQuestion = _repositoryUnitOfWork.CheckListQuestion.Value.GetAll(x => x.ModifiedBy, x => x.CreatedBy);
            IEnumerable<CheckListQuestionDTO> CheckListQuestionDTO = _mapper.Map<List<CheckListQuestionDTO>>(CheckListQuestion);
            foreach (CheckListQuestionDTO question in CheckListQuestionDTO)
            {
                ChecklistAnswer checklistAnswer = _repositoryUnitOfWork.CheckListAnswer.Value.FirstOrDefault(x => x.ChecklistQuestionId == question.Id);
                if (checklistAnswer != null)
                {
                    question.AnswerId = checklistAnswer.Id;
                    question.AnswerValue = checklistAnswer.Answer;
                }
            }
            return CheckListQuestionDTO;
        }

        public CheckListQuestionAddDTO UpdateEntity(CheckListQuestionAddDTO entity)
        {
            ChecklistQuestion CheckListQuestion = _mapper.Map<ChecklistQuestion>(entity);
            if (_repositoryUnitOfWork.CheckListQuestion.Value.Any(x => x.Id != CheckListQuestion.Id && x.QuestionText == CheckListQuestion.QuestionText))
            {
                throw new ValidationException("Account Type Already exists");
            }
            ChecklistQuestion updatedCheckListQuestion = _repositoryUnitOfWork.CheckListQuestion.Value.Update(CheckListQuestion);
            return entity;
        }
    }
}
