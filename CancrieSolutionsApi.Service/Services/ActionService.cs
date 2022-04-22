using AlmassarGateApi.Service.Interfaces;
using AutoMapper;
using Domains.DTO;
using Domains.SearchModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using Action = Domains.Models.Action;

namespace AlmassarGateApi.Service.Services
{
    public class ActionService : IActionService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private IMapper _mapper;

        public ActionService(IRepositoryUnitOfWork repositoryUnitOfWork, IMapper mapper)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
        }
        public Action AddEntity(Action entity)
        {
            Action Action = _mapper.Map<Action>(entity);
            _repositoryUnitOfWork.Action.Value.Add(Action);
            return entity;
        }
        public Action Update(Action entity)
        {
            _repositoryUnitOfWork.Action.Value.Update(entity);
            return entity;
        }

        public Action Get(int Id)
        {
            Action Action = _repositoryUnitOfWork.Action.Value.Get(Id);
            return Action;
        }


        //public BaseListResponse<ActionDTO> GetList(ActionSearch ActionSearch)
        //{
        //    BaseListResponse<Action> Action = _repositoryUnitOfWork.Action.Value.GetList(x =>
        //    (string.IsNullOrEmpty(ActionSearch.QuestionText) || x.QuestionText.Contains(ActionSearch.QuestionText)) &&
        //    (!ActionSearch.Status.HasValue || x.Status == ActionSearch.Status)
        //    , ActionSearch.PageSize, ActionSearch.PageNumber);
        //    var mappedAction = _mapper.Map<List<ActionDTO>>(Action.Entities);
        //    return new BaseListResponse<ActionDTO>
        //    {
        //        Entities = mappedAction,
        //        TotalCount = Action.TotalCount
        //    };
        //}

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.Action.Value.Remove(Id);
            return true;
        }

        public IEnumerable<Action> AddRange(IEnumerable<Action> entities)
        {
            IEnumerable<Action> Action = _repositoryUnitOfWork.Action.Value.AddRange(entities);
            return Action;
        }


        public IEnumerable<Action> GetAll()
        {
            return _repositoryUnitOfWork.Action.Value.GetAll();
        }
        public List<ActionDTO> GetActionsByProjectId(int projectId)
        {
            IEnumerable<Action> actionsList = _repositoryUnitOfWork.Action.Value.GetAll(x => x.CreatedBy,x=>x.Approval,x=>x.Approval.Task).OrderByDescending(x=>x.CreatedDate).Where(x=>x.Approval.ProjectId==projectId);
            List<ActionDTO> actions = _mapper.Map<List<ActionDTO>>(actionsList);
            return actions;
        }





        public IEnumerable<Action> RemoveRange(IEnumerable<Action> entities)
        {
            IEnumerable<Action> Action = _repositoryUnitOfWork.Action.Value.RemoveRange(entities);
            return Action;
        }

        public IEnumerable<Action> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Action> UpdateRange(IEnumerable<Action> entities)
        {
            IEnumerable<Action> Action = _repositoryUnitOfWork.Action.Value.UpdateRange(entities);
            return Action;
        }



        public Action Add(Action entity)
        {
            Action Action = _repositoryUnitOfWork.Action.Value.Add(entity);
            return Action;
        }

        public BaseListResponse<Action> List(BaseSearch entity)
        {
            throw new NotImplementedException();
        }





        //public ActionAddDTO UpdateEntity(ActionAddDTO entity)
        //{
        //    Action Action = _mapper.Map<Action>(entity);
        //    if (_repositoryUnitOfWork.Action.Value.Any(x => x.Id != Action.Id && x.QuestionText == Action.QuestionText))
        //    {
        //        throw new ValidationException("Account Type Already exists");
        //    }
        //    Action updatedAction = _repositoryUnitOfWork.Action.Value.Update(Action);
        //    return entity;
        //}
    }
}
