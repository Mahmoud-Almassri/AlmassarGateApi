using AlmassarGate.Domain.Models;
using Domains.DTO;
using Domains.SearchModels;
using Repository.UnitOfWork;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class ContactUsService : IContactUsService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        public ContactUsService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }

        public ContactUs Add(ContactUs entity)
        {

            ContactUs contact = _repositoryUnitOfWork.ContactUs.Value.Add(entity);

            return contact;
        }

        public IEnumerable<ContactUs> AddRange(IEnumerable<ContactUs> entities)
        {
            throw new NotImplementedException();
        }

        public ContactUs Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContactUs> GetAll()
        {
            throw new NotImplementedException();
        }

        public ContactUs Remove(ContactUs entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContactUs> RemoveRange(IEnumerable<ContactUs> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContactUs> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public ContactUs Update(ContactUs entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContactUs> UpdateRange(IEnumerable<ContactUs> entities)
        {
            throw new NotImplementedException();
        }

        public BaseListResponse<ContactUs> GetList(BaseSearch baseSearch)
        {
            BaseListResponse<ContactUs> ContactUs = _repositoryUnitOfWork.ContactUs.Value.GetList(x =>
                                                                                             (string.IsNullOrEmpty(baseSearch.Name)
                                                                                             || x.Name.Contains(baseSearch.Name))
                                                                                             , baseSearch.PageSize
                                                                                             , baseSearch.PageNumber
                                                                                             , x => x.CreatedBy
                                                                                             , x => x.ModifiedBy);
            return new BaseListResponse<ContactUs>
            {
                Entities = ContactUs.Entities,
                TotalCount = ContactUs.TotalCount
            };
        }
    }
}
