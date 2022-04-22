using Domains.DTO;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository.Interfaces.Common
{
    public interface IRepository<IEntity> where IEntity : class
    {
        IEntity Get(int Id);
        IEnumerable<IEntity> GetAll(params Expression<Func<IEntity, object>>[] navigationProperties);
        IEntity Add(IEntity entity);
        IEnumerable<IEntity> AddRange(IEnumerable<IEntity> entities);
        IEntity Update(IEntity entity, bool disableAttach = false);
        IEnumerable<IEntity> UpdateRange(IEnumerable<IEntity> Entities);
        bool Remove(int Id);
        IEnumerable<IEntity> RemoveRange(IEnumerable<IEntity> entities);
        BaseListResponse<IEntity> GetList(Expression<Func<IEntity, bool>> predicate, int PageSize, int PageNumber, params Expression<Func<IEntity, object>>[] navigationProperties);
        IEnumerable<IEntity> Find(Expression<Func<IEntity, bool>> where, params Expression<Func<IEntity, object>>[] navigationProperties);
        IEntity FirstOrDefault(Expression<Func<IEntity, bool>> where, params Expression<Func<IEntity, object>>[] navigationProperties);
        IEntity FirstOrDefault(Expression<Func<IEntity, bool>> where);
        bool Any(Expression<Func<IEntity, bool>> where);
        void SaveChanges();
        IDbContextTransaction BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        IEnumerable<IEntity> GetAllWithoutFilters();
    }
}