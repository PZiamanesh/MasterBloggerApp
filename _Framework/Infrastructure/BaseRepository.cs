using System.Linq.Expressions;
using _Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace _Framework.Infrastructure;

public class BaseRepository<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : DomainBase<TKey>
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public void Create(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public TEntity? Get(TKey id)
    {
        return _dbSet.Find(id);
    }

    public bool Exist(Expression<Func<TEntity, bool>> expression)
    {
        return _dbSet.Any(expression);
    }
}