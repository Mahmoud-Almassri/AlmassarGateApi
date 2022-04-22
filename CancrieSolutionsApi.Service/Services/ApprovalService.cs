using AlmassarGateApi.Service.Interfaces;
using AutoMapper;
using Domains.DTO;
using Domains.Models;
using Domains.SearchModels;
using Repository.UnitOfWork;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlmassarGateApi.Service.Services
{
    public class ApprovalService : IApprovalService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private readonly LoggedInUserService _loggedInUserService;
        private IMapper _mapper;

        public ApprovalService(IRepositoryUnitOfWork repositoryUnitOfWork, IMapper mapper, LoggedInUserService loggedInUserService)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
            _loggedInUserService = loggedInUserService;
        }
        public dynamic AddEntity(dynamic entity)
        {
            Approval Approval = _mapper.Map<Approval>(entity);
            //if (_repositoryUnitOfWork.Approval.Value.Any(x => x.QuestionText == Approval.QuestionText))
            //{
            //    throw new ValidationException("Question Already exists");
            //}
            _repositoryUnitOfWork.Approval.Value.Add(Approval);
            return entity;
        }
        public Approval Update(Approval entity)
        {
            _repositoryUnitOfWork.Approval.Value.Update(entity);
            return entity;
        }

        public Approval Get(int Id)
        {
            Approval Approval = _repositoryUnitOfWork.Approval.Value.FirstOrDefault(x=>x.Id==Id,x=>x.Task,x=>x.Project);
            return Approval;
        }


        //public BaseListResponse<ApprovalDTO> GetList(ApprovalSearch ApprovalSearch)
        //{
        //    BaseListResponse<Approval> Approval = _repositoryUnitOfWork.Approval.Value.GetList(x =>
        //    (string.IsNullOrEmpty(ApprovalSearch.QuestionText) || x.QuestionText.Contains(ApprovalSearch.QuestionText)) &&
        //    (!ApprovalSearch.Status.HasValue || x.Status == ApprovalSearch.Status)
        //    , ApprovalSearch.PageSize, ApprovalSearch.PageNumber);
        //    var mappedApproval = _mapper.Map<List<ApprovalDTO>>(Approval.Entities);
        //    return new BaseListResponse<ApprovalDTO>
        //    {
        //        Entities = mappedApproval,
        //        TotalCount = Approval.TotalCount
        //    };
        //}

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.Approval.Value.Remove(Id);
            return true;
        }

        public IEnumerable<Approval> AddRange(IEnumerable<Approval> entities)
        {
            IEnumerable<Approval> Approval = _repositoryUnitOfWork.Approval.Value.AddRange(entities);
            return Approval;
        }


        public IEnumerable<Approval> GetAll()
        {
            return _repositoryUnitOfWork.Approval.Value.GetAll();
        }





        public IEnumerable<Approval> RemoveRange(IEnumerable<Approval> entities)
        {
            IEnumerable<Approval> Approval = _repositoryUnitOfWork.Approval.Value.RemoveRange(entities);
            return Approval;
        }

        public IEnumerable<Approval> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Approval> UpdateRange(IEnumerable<Approval> entities)
        {
            IEnumerable<Approval> Approval = _repositoryUnitOfWork.Approval.Value.UpdateRange(entities);
            return Approval;
        }

        public BaseListResponse<Approval> List(BaseSearch entity)
        {
            BaseListResponse<Approval> listResponse = _repositoryUnitOfWork.Approval.Value.GetList(x =>
                                                                                                        (string.IsNullOrEmpty(entity.Name)
                                                                                                        || x.Project.ClientName == entity.Name)
                                                                                                        , entity.PageSize
                                                                                                        , entity.PageNumber);
            return listResponse;
        }

        public Approval Add(Approval entity)
        {
            Approval Approval = _repositoryUnitOfWork.Approval.Value.Add(entity);
            return Approval;
        }

        public ApprovalDTO GetById(int Id)
        {
            var userId = _loggedInUserService.GetUserId();
            Approval Approval = _repositoryUnitOfWork.Approval.Value.FirstOrDefault(x => x.Id == Id, x => x.ModifiedBy, x => x.CreatedBy,x=>x.Project,x=>x.Project.ProjectFiles,x=>x.Task);
            IEnumerable<UserRoles> roles = _repositoryUnitOfWork.UserRoles.Value.Find(x => x.UserId == userId);
            foreach (var item in roles)
            {
                if (item.RoleId == Approval.Task.RoleId)
                {
                    ApprovalDTO ApprovalDTO = _mapper.Map<ApprovalDTO>(Approval);
                    return ApprovalDTO;
                }
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);       
        }

        public IEnumerable<ApprovalDTO> GetAllRecords()
        {
            IEnumerable<Approval> Approval = _repositoryUnitOfWork.Approval.Value.GetAll(x => x.ModifiedBy, x => x.CreatedBy);
            IEnumerable<ApprovalDTO> ApprovalDTO = _mapper.Map<List<ApprovalDTO>>(Approval);
            return ApprovalDTO;
        }

        //public ApprovalAddDTO UpdateEntity(ApprovalAddDTO entity)
        //{
        //    Approval Approval = _mapper.Map<Approval>(entity);
        //    if (_repositoryUnitOfWork.Approval.Value.Any(x => x.Id != Approval.Id && x.QuestionText == Approval.QuestionText))
        //    {
        //        throw new ValidationException("Account Type Already exists");
        //    }
        //    Approval updatedApproval = _repositoryUnitOfWork.Approval.Value.Update(Approval);
        //    return entity;
        //}
    }
}
