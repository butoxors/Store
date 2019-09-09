using Domain.Abstract;
using Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppIdentityDbContext context;
        private readonly DbSet<TEntity> dbSet;

        public Repository(AppIdentityDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        /// <summary>
        /// Get object
        /// </summary>
        /// <param name="filter">User filter</param>
        /// <param name="orderBy">Oser order</param>
        /// <param name="includeProperties">Some properties</param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Get object from Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public virtual TEntity Get(object id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Add object to DB
        /// </summary>
        /// <param name="entity">object</param>
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        /// <summary>
        /// Delete from DB
        /// </summary>
        /// <param name="id">Id</param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        /// <summary>
        /// Delete from DB
        /// </summary>
        /// <param name="entityToDelete">Object</param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        /// <summary>
        /// Update object
        /// </summary>
        /// <param name="entityToUpdate">Object</param>
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
