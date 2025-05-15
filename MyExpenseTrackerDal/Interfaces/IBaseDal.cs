using System.Linq.Expressions;
using MyExpenseTrackerEntity.Base;

namespace MyExpenseTrackerDal.Interfaces
{
    public interface IBaseDal<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(List<Expression<Func<TEntity, bool>>>? predicates);
        IEnumerable<TEntity> GetAll(List<string> includes);
        IEnumerable<TEntity> GetAll(List<Expression<Func<TEntity, bool>>>? predicates, List<string> includes);
        TEntity? GetById(Guid id);
        TEntity? GetById(Guid id, List<string> includes);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
    }
}