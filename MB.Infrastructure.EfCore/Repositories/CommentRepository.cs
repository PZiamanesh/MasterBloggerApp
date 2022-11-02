using _Framework.Infrastructure;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories;

public class CommentRepository : BaseRepository<long, Comment>, ICommentRepository
{
    private readonly MasterBlogDbContext _dbContext;

    public CommentRepository(MasterBlogDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Comment> GetList()
    {
        return _dbContext.Comments
            .Include(x => x.Article)
            .ToList();
    }
}