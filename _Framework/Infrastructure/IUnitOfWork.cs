namespace _Framework.Infrastructure;

public interface IUnitOfWork
{
    void BeginTrans();
    void CommitTrans();
    void RollbackTrans();
}