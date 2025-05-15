

using Microsoft.EntityFrameworkCore;
using MyExpenseTrackerDal.Context;
using MyExpenseTrackerDal.Interfaces;
using MyExpenseTrackerEntity.Base;
using System.Linq.Expressions;

namespace MyExpenseTrackerDal.Repositories.Base
{
    public abstract class BaseCrudDal<TEntity> : IBaseDal<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;

        protected BaseCrudDal(AppDbContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetAll(null, null);
        }

        public virtual IEnumerable<TEntity> GetAll(List<Expression<Func<TEntity, bool>>>? predicates)
        {
            return GetAll(predicates, null);
        }

        public virtual IEnumerable<TEntity> GetAll(List<string> includes)
        {
            return GetAll(null, includes);
        }

        public virtual IEnumerable<TEntity> GetAll(List<Expression<Func<TEntity, bool>>>? predicates, List<string>? includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (predicates != null)
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate);
                }
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.ToList();
        }

        public virtual TEntity? GetById(Guid id)
        {
            return GetById(id, null);
        }

        public virtual TEntity? GetById(Guid id, List<string>? includes)
        {
            return GetAll(new List<Expression<Func<TEntity, bool>>>
            {
                x => x.Id == id
            }, includes).FirstOrDefault();
        }

        public virtual void Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(Guid id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}