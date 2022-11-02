using _Framework.Infrastructure;

namespace MB.Infrastructure.EfCore;

public class UnitOfWork : IUnitOfWork
{
    private readonly MasterBlogDbContext _dbContext;

    public UnitOfWork(MasterBlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void BeginTrans()
    {
        _dbContext.Database.BeginTransaction();
    }

    public void CommitTrans()
    {
        _dbContext.SaveChanges();
        _dbContext.Database.CommitTransaction();
    }

    public void RollbackTrans()
    {
        _dbContext.Database.RollbackTransaction();
    }
}