using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly MasterBlogDbContext _dbContext;

    public CommentRepository(MasterBlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateComment(Comment comment)
    {
        _dbContext.Comments.Add(comment);
        Save();
    }

    public List<Comment> GetAll()
    {
        return _dbContext.Comments.Include(x=>x.Article).ToList();
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}