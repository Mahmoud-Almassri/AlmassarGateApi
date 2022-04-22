using AlmassarGateApi.Domain.DTO.AddDTO;
using AlmassarGateApi.Domain.DTO.LookupsDTO;
using AlmassarGateApi.Domain.Models;
using AlmassarGateApi.Domain.SearchModels;
using AlmassarGateApi.Service.Interfaces;
using AutoMapper;
using Domains.DTO;
using Domains.SearchModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Service.Services
{
    public class PartService : IPartService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private IMapper _mapper;

        public PartService(IRepositoryUnitOfWork repositoryUnitOfWork, IMapper mapper)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
        }
        public PartAddDTO AddEntity(PartAddDTO entity)
        {
            Part part = _mapper.Map<Part>(entity);
            if (_repositoryUnitOfWork.Part.Value.Any(x => x.PartName == part.PartName))
            {
                throw new ValidationException("Question Already exists");
            }
            _repositoryUnitOfWork.Part.Value.Add(part);
            return entity;
        }
        public Part Update(Part entity)
        {
            _repositoryUnitOfWork.Part.Value.Update(entity);
            return entity;
        }

        public Part Get(int Id)
        {
            Part part = _repositoryUnitOfWork.Part.Value.Get(Id);
            return part;
        }


        public BaseListResponse<PartDTO> GetList(PartSearch partSearch)
        {
            BaseListResponse<Part> part = _repositoryUnitOfWork.Part.Value.GetList(x =>
            (string.IsNullOrEmpty(partSearch.PartName) || x.PartName.Contains(partSearch.PartName))
            , partSearch.PageSize, partSearch.PageNumber);
            var mappedPart = _mapper.Map<List<PartDTO>>(part.Entities);
            return new BaseListResponse<PartDTO>
            {
                Entities = mappedPart,
                TotalCount = part.TotalCount
            };
        }

        public bool Remove(int Id)
        {
            _repositoryUnitOfWork.Part.Value.Remove(Id);
            return true;
        }

        public IEnumerable<Part> AddRange(IEnumerable<Part> entities)
        {
            IEnumerable<Part> part = _repositoryUnitOfWork.Part.Value.AddRange(entities);
            return part;
        }


        public IEnumerable<Part> GetAll()
        {
            return _repositoryUnitOfWork.Part.Value.GetAll();
        }

        public IEnumerable<Part> RemoveRange(IEnumerable<Part> entities)
        {
            IEnumerable<Part> part = _repositoryUnitOfWork.Part.Value.RemoveRange(entities);
            return part;
        }

        public IEnumerable<Part> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Part> UpdateRange(IEnumerable<Part> entities)
        {
            IEnumerable<Part> part = _repositoryUnitOfWork.Part.Value.UpdateRange(entities);
            return part;
        }

        public BaseListResponse<Part> List(PartSearch entity)
        {
            BaseListResponse<Part> listResponse = _repositoryUnitOfWork.Part.Value.GetList(x =>
                                                                                                        (string.IsNullOrEmpty(entity.PartName)
                                                                                                        || x.PartName == entity.PartName)
                                                                                                        , entity.PageSize
                                                                                                        , entity.PageNumber);
            return listResponse;
        }

        public Part Add(Part entity)
        {
            Part ChecklistQuestion = _repositoryUnitOfWork.Part.Value.Add(entity);
            return ChecklistQuestion;
        }

        public PartDTO GetById(int Id)
        {
            Part part = _repositoryUnitOfWork.Part.Value.FirstOrDefault(x => x.Id == Id, x => x.ModifiedBy, x => x.CreatedBy);
            PartDTO partDTO = _mapper.Map<PartDTO>(part);
            return partDTO;
        }

        public IEnumerable<PartDTO> GetAllRecords()
        {
            IEnumerable<Part> part = _repositoryUnitOfWork.Part.Value.GetAll(x => x.ModifiedBy, x => x.CreatedBy);
            IEnumerable<PartDTO> partDTO = _mapper.Map<List<PartDTO>>(part);
            return partDTO;
        }

        public PartAddDTO UpdateEntity(PartAddDTO entity)
        {
            Part part = _mapper.Map<Part>(entity);
            if (_repositoryUnitOfWork.Part.Value.Any(x => x.Id != part.Id && x.PartName == part.PartName))
            {
                throw new ValidationException("Account Type Already exists");
            }
            Part updatedPart = _repositoryUnitOfWork.Part.Value.Update(part);
            return entity;
        }

    }
}
