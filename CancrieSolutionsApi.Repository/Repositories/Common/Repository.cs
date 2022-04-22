using AlmassarGate.Domain.Models.Common;
using Domains.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Context;
using Repository.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Repositories.Common
{
    public class Repository<IEntity> : IRepository<IEntity> where IEntity : BaseModel, new()
    {
        #region [Context]
        protected AlmassarGateContext Context;
        #endregion

        private int? UserId = null;
        AppConfiguration appConfiguration = new AppConfiguration();

        public Repository(AlmassarGateContext context)
        {
            UserId = appConfiguration.GetUserId();
            Context = context;
        }

        #region Get
        public IEntity Get(int Id)
        {
            IEntity result = Context.Set<IEntity>().AsNoTracking().FirstOrDefault(entity => entity.Id == Id);
            return result;
        }

        #endregion

        #region GetAll
        public IEnumerable<IEntity> GetAll(params Expression<Func<IEntity, object>>[] navigationProperties)
        {
            IQueryable<IEntity> dbQuery = Context.Set<IEntity>();

            foreach (Expression<Func<IEntity, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<IEntity, object>(navigationProperty);
            }

            return dbQuery.AsNoTracking();
        }

        #endregion
        
        #region GetAll Without Filters
        public IEnumerable<IEntity> GetAllWithoutFilters()
        {
            IQueryable<IEntity> dbQuery = Context.Set<IEntity>();
            return dbQuery.AsNoTracking();
        }

        #endregion

        #region FirstOrDefault
        public IEntity FirstOrDefault(Expression<Func<IEntity, bool>> where, params Expression<Func<IEntity, object>>[] navigationProperties)
        {
            IQueryable<IEntity> dbQuery = Context.Set<IEntity>();

            foreach (Expression<Func<IEntity, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<IEntity, object>(navigationProperty);
            }

            return dbQuery.Where(where).FirstOrDefault();
        }
        #endregion

        #region Find
        public IEnumerable<IEntity> Find(Expression<Func<IEntity, bool>> predicate, params Expression<Func<IEntity, object>>[] navigationProperties)
        {
            IQueryable<IEntity> dbQuery = Context.Set<IEntity>();

            foreach (Expression<Func<IEntity, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<IEntity, object>(navigationProperty);
            }

            return dbQuery.Where(predicate).AsNoTracking();
        }
        #endregion

        #region GetList
        public BaseListResponse<IEntity> GetList(Expression<Func<IEntity, bool>> predicate, int PageSize, int PageNumber, params Expression<Func<IEntity, object>>[] navigationProperties)
        {

            IQueryable<IEntity> dbQuery = Context.Set<IEntity>();

            foreach (Expression<Func<IEntity, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<IEntity, object>(navigationProperty);
            }

            return new BaseListResponse<IEntity>
            {
                TotalCount = dbQuery.Count(predicate),
                Entities = dbQuery.Where(predicate).Skip(appConfiguration.PageSize * (PageNumber - 1)).Take(appConfiguration.PageSize).ToList()
            };
        }
        #endregion

        #region Add
        public IEntity Add(IEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedById = UserId;
            Context.Set<IEntity>().Add(entity);
            SaveChanges();
            Context.Entry(entity).GetDatabaseValues();
            return entity;
        }
        #endregion

        #region AddRnage
        public IEnumerable<IEntity> AddRange(IEnumerable<IEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedById = UserId;
            }
            Context.ChangeTracker.Entries<IEntity>();
            Context.Set<IEntity>().AddRange(entities);
            SaveChanges();
            return entities;
        }
        #endregion

        #region Update
        public IEntity Update(IEntity entity, bool disableAttach = false)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedById = UserId;
            Context.Set<IEntity>().Update(entity);
            Context.Entry(entity).State = EntityState.Modified;
            SaveChanges();
            return entity;
        }
        #endregion

        #region UpdateRange
        public IEnumerable<IEntity> UpdateRange(IEnumerable<IEntity> Entities)
        {
            Context.Set<IEntity>().UpdateRange(Entities);
            SaveChanges();
            return Entities;
        }
        #endregion

        #region Remove
        public IEntity Remove(IEntity entity)
        {
            Context.Set<IEntity>().Remove(entity);
            SaveChanges();
            return entity;
        }
        #endregion

        #region RemoveRange
        public IEnumerable<IEntity> RemoveRange(IEnumerable<IEntity> entities)
        {
            Context.Set<IEntity>().RemoveRange(entities);
            SaveChanges();
            return entities;
        }
        #endregion

        #region SaveChanges
        public void SaveChanges()
        {
            Context.SaveChanges();
        }
        #endregion

        #region BeginTransaction
        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }
        #endregion

        #region CommitTransaction
        public void CommitTransaction()
        {
            Context.Database.CommitTransaction();
        }
        #endregion

        #region RollbackTransaction
        public void RollbackTransaction()
        {
            Context.Database.RollbackTransaction();
        }

        #endregion

        /*public bool Any(Expression<Func<IEntity, bool>> where)
        {
            return Context.Set<IEntity>().Any(where);
        }*/

        public int Count(Expression<Func<IEntity, bool>> where)
        {
            return Context.Set<IEntity>().Where(where).Count();
        }


        /*IEnumerable<IEntity> IRepository<IEntity>.GetAll()
        {
            throw new NotImplementedException();
        }*/



        /*IEnumerable<IEntity> IRepository<IEntity>.AddRange(IEnumerable<IEntity> entities)
        {
            throw new NotImplementedException();
        }*/

        /*IEntity IRepository<IEntity>.Update(IEntity entity, bool disableAttach)
        {
            throw new NotImplementedException();
        }*/

        /* IEnumerable<IEntity> IRepository<IEntity>.UpdateRange(IEnumerable<IEntity> Entities)
         {
             throw new NotImplementedException();
         }*/

        bool IRepository<IEntity>.Remove(int Id)
        {
            IEntity entityToDelete = Context.Set<IEntity>().Find(Id);
            Context.Set<IEntity>().Remove(entityToDelete);
            Context.SaveChanges();
            return true;

        }

        /*IEnumerable<IEntity> IRepository<IEntity>.RemoveRange(IEnumerable<IEntity> entities)
        {
            throw new NotImplementedException();
        }*/



        IEnumerable<IEntity> IRepository<IEntity>.Find(Expression<Func<IEntity, bool>> where, params Expression<Func<IEntity, object>>[] navigationProperties)
        {
            IQueryable<IEntity> dbQuery = Context.Set<IEntity>();

            foreach (Expression<Func<IEntity, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<IEntity, object>(navigationProperty);
            }

            return dbQuery.Where(where).AsNoTracking();
        }

        /*IEntity IRepository<IEntity>.FirstOrDefault(Expression<Func<IEntity, bool>> where, params Expression<Func<IEntity, object>>[] navigationProperties)
        {
            IQueryable<IEntity> dbQuery = Context.Set<IEntity>();

            foreach (Expression<Func<IEntity, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<IEntity, object>(navigationProperty);
            }

            return dbQuery.Where(where).FirstOrDefault();
        }*/

        IEntity IRepository<IEntity>.FirstOrDefault(Expression<Func<IEntity, bool>> where)
        {
            IQueryable<IEntity> dbQuery = Context.Set<IEntity>();

            return dbQuery.Where(where).AsNoTracking().FirstOrDefault();
        }

        bool IRepository<IEntity>.Any(Expression<Func<IEntity, bool>> where)
        {
            return Context.Set<IEntity>().Any(where);
        }

        void IRepository<IEntity>.SaveChanges()
        {
            throw new NotImplementedException();
        }

        IDbContextTransaction IRepository<IEntity>.BeginTransaction()
        {
            throw new NotImplementedException();
        }

        void IRepository<IEntity>.CommitTransaction()
        {
            throw new NotImplementedException();
        }

        void IRepository<IEntity>.RollbackTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
