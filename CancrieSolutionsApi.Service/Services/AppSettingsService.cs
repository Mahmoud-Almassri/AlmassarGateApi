using AutoMapper;
using AlmassarGate.Domain.DTO.AddDTO;
using AlmassarGate.Domain.Models;
using Repository.UnitOfWork;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class AppSettingsService : IAppSettingsService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private IMapper _mapper;
        public AppSettingsService(IRepositoryUnitOfWork repositoryUnitOfWork , IMapper mapper)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
        }

        public AppSettings Add(AppSettings entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppSettings> AddRange(IEnumerable<AppSettings> entities)
        {
            throw new NotImplementedException();
        }

        public AppSettings Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppSettings> GetAll()
        {
            throw new NotImplementedException();
        }

        public AppSettings GetAppSettings()
        {
            AppSettings appSettings = _repositoryUnitOfWork.AppSettings.Value.FirstOrDefault(x=>true);
            return appSettings;
        }

        public AppSettings Remove(AppSettings entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppSettings> RemoveRange(IEnumerable<AppSettings> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppSettings> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public AppSettings Update(AppSettings entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppSettings> UpdateRange(IEnumerable<AppSettings> entities)
        {
            throw new NotImplementedException();
        }
        public AppSettingsAddUpdateDTO UpdateEntity(AppSettingsAddUpdateDTO entity)
        {
            AppSettings app = _mapper.Map<AppSettings>(entity);
            AppSettings UpdatedAppSettings = _repositoryUnitOfWork.AppSettings.Value.Update(app);
            return entity;
        }
    }
}
