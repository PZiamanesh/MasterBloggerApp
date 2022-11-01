using MB.Domain.CommentAgg;

namespace MB.Infrastructure.EfCore.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly MasterBlogDbContext _dbContext;

    public CommentRepository(MasterBlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}