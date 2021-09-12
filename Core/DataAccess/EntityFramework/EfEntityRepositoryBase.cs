using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private protected readonly DbContext _dbContex;

        public EfEntityRepositoryBase(DbContext dbContex)
        {
            _dbContex = dbContex ?? throw new ArgumentNullException(nameof(dbContex));
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _dbContex.Set<TEntity>().SingleOrDefault(filter);
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _dbContex.Set<TEntity>().ToList()
                : _dbContex.Set<TEntity>().Where(filter).ToList();
        }

        public void Add(TEntity entity)
        {
            var addedEntity = _dbContex.Entry(entity);
            addedEntity.State = EntityState.Added;
            _dbContex.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var deletedEntity = _dbContex.Entry(entity);
            deletedEntity.State = EntityState.Modified;
            _dbContex.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            var updatedEntity = _dbContex.Entry(entity);
            updatedEntity.State = EntityState.Deleted;
            _dbContex.SaveChanges();

        }
    }
}
