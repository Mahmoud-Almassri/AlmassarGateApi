using AlmassarGateApi.Domain.SearchModels;
using AlmassarGateApi.Service.Interfaces;
using AutoMapper;
using Domains.DTO;
using Domains.Models;
using Domains.SearchModels;
using Repository.UnitOfWork;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Task = Domains.Models.Task;

namespace AlmassarGateApi.Service.Services
{
    public class TaskService : ITaskService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly LoggedInUserService _loggedInUserService;
        private IMapper _mapper;

        public TaskService(IRepositoryUnitOfWork repositoryUnitOfWork, IMapper mapper, LoggedInUserService loggedInUserService)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
            _loggedInUserService = loggedInUserService;
        }
        public Task AddEntity(Task entity)
        {
            Task Task = _mapper.Map<Task>(entity);
            _repositoryUnitOfWork.Task.Value.Add(Task);
            return entity;
        }
        public Task Update(Task entity)
        {
            _repositoryUnitOfWork.Task.Value.Update(entity);
            return entity;
        }

        public Task Get(int Id)
        {
            Task Task = _repositoryUnitOfWork.Task.Value.Get(Id);
            return Task;
        }
        public bool CheckWithTasks(int[] ids)
        {
            return _repositoryUnitOfWork.Task.Value.CheckWithTasks(ids);
        }

        //public BaseListResponse<TaskDTO> GetList(TaskSearch TaskSearch)
        //{
        //    BaseListResponse<Task> Task = _repositoryUnitOfWork.Task.Value.GetList(x =>
        //    (string.IsNullOrEmpty(TaskSearch.QuestionText) || x.QuestionText.Contains(TaskSearch.QuestionText)) &&
        //    (!TaskSearch.Status.HasValue || x.Status == TaskSearch.Status)
        //    , TaskSearch.PageSize, TaskSearch.PageNumber);
        //    var mappedTask = _mapper.Map<List<TaskDTO>>(Task.Entities);
        //    return new BaseListResponse<TaskDTO>
        //    {
        //        Entities = mappedTask,
        //        TotalCount = Task.TotalCount
        //    };
        //}

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.Task.Value.Remove(Id);
            return true;
        }

        public IEnumerable<Task> AddRange(IEnumerable<Task> entities)
        {
            IEnumerable<Task> Task = _repositoryUnitOfWork.Task.Value.AddRange(entities);
            return Task;
        }


        public BaseListResponse<Approval> GetList(TaskSearch taskSearch)
        {
            var userId = _loggedInUserService.GetUserId();
            List<long> roleIds=new List<long>();
            IEnumerable<UserRoles> roles = _repositoryUnitOfWork.UserRoles.Value.Find(x => x.UserId == userId);
            foreach (var item in roles)
            {
                roleIds.Add(item.RoleId);
            }
            return _repositoryUnitOfWork.Approval.Value.GetList(x =>
                                                       (string.IsNullOrEmpty(taskSearch.TaskTitle) || x.Task.Title.Contains(taskSearch.TaskTitle)) && roleIds.Any(p => p == x.Task.RoleId) 
                                                       , taskSearch.PageSize
                                                       , taskSearch.PageNumber
                                                       , x => x.Project, x => x.ModifiedBy, x=>x.Task);

        }





        public IEnumerable<Task> RemoveRange(IEnumerable<Task> entities)
        {
            IEnumerable<Task> Task = _repositoryUnitOfWork.Task.Value.RemoveRange(entities);
            return Task;
        }

        public IEnumerable<Task> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Task> UpdateRange(IEnumerable<Task> entities)
        {
            IEnumerable<Task> Task = _repositoryUnitOfWork.Task.Value.UpdateRange(entities);
            return Task;
        }



        public Task Add(Task entity)
        {
            Task Task = _repositoryUnitOfWork.Task.Value.Add(entity);
            return Task;
        }

        public BaseListResponse<Task> List(BaseSearch entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetAll()
        {
            throw new NotImplementedException();
        }




            //public TaskAddDTO UpdateEntity(TaskAddDTO entity)
            //{
            //    Task Task = _mapper.Map<Task>(entity);
            //    if (_repositoryUnitOfWork.Task.Value.Any(x => x.Id != Task.Id && x.QuestionText == Task.QuestionText))
            //    {
            //        throw new ValidationException("Account Type Already exists");
            //    }
            //    Task updatedTask = _repositoryUnitOfWork.Task.Value.Update(Task);
            //    return entity;
            //}
        }
}
