using AlmassarGate.Domain.DTO.AddDTO;
using AlmassarGate.Domain.Enums;
using AlmassarGate.Domain.Models.Common;
using AutoMapper;
using Repository.UnitOfWork;
using Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class LookupService : ILookupService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private IMapper _mapper;
        public LookupService(IRepositoryUnitOfWork repositoryUnitOfWork, IMapper mapper)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
        }

        public Lookup Add(Lookup entity)
        {
            throw new NotImplementedException();
        }
        public LookupDTO AddEntity(LookupDTO entity)
        {
            Lookup lookup = _mapper.Map<Lookup>(entity);
            _repositoryUnitOfWork.Lookups.Value.Add(lookup);
            return entity;
        }

        public IEnumerable<Lookup> AddRange(IEnumerable<Lookup> entities)
        {
            throw new NotImplementedException();
        }

        public Lookup Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lookup> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<LookupDTO> GetLookupsByParent(EntitiesEnum parentId)
        {
            List<LookupDTO> lookups = _mapper.Map<List<LookupDTO>>(_repositoryUnitOfWork.Lookups.Value.GetLookupsByParent(parentId));
            return lookups;
        }

        public Lookup Remove(Lookup entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lookup> RemoveRange(IEnumerable<Lookup> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lookup> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public Lookup Update(Lookup entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lookup> UpdateRange(IEnumerable<Lookup> entities)
        {
            throw new NotImplementedException();
        }

    }
}
