using ECommercePlatform.Data.Context;
using ECommercePlatform.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ECommerceDbContext _context;
        private readonly DbSet<TEntity> _entities;
        public Repository(ECommerceDbContext context)
        {
            _context = context;
            _entities =_context.Set<TEntity>();

        }
        public void Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            _entities.Add(entity);
            //_entities.SaveChanges();
        }

        public void Delete(TEntity entity, bool softDelete = true)
        {
            if (softDelete)
            {
                entity.ModifiedDate = DateTime.Now;
                entity.IsDeleted = true;
                _entities.Update(entity);
            }
            else
            {
                _entities.Remove(entity);
            }
            //_entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _entities.Find(id);
            Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.FirstOrDefault(predicate);
        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate is null ? _entities : _entities.Where(predicate);
        }

        public TEntity GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Update(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _entities.Update(entity);
            //_entities.SaveChanges();
        }
    }
}
