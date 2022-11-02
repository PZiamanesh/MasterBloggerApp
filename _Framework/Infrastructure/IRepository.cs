using System.Linq.Expressions;
using _Framework.Domain;

namespace _Framework.Infrastructure;

public interface IRepository<in TKey, TEntity> where TEntity : DomainBase<TKey>
{
    void Create(TEntity entity);
    IEnumerable<TEntity> GetAll();
    TEntity? Get(TKey id);
    bool Exist(Expression<Func<TEntity, bool>> expression);
}