using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query;

public class ArticleQuery : IArticleQuery
{
    private readonly MasterBlogDbContext _dbContext;

    public ArticleQuery(MasterBlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<ArticleQueryView> GetArticles()
    {
        return _dbContext.Articles
            .Where(x=>x.IsDeleted == false)
            .Select(x => new ArticleQueryView()
            {
                Id = x.Id,
                Image = x.Image,
                CreationDate = x.CreationDate.ToString("yyyy MMMM dd"),
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                CategoryName = x.ArticleCategory.Title,
                CommentsCount = x.Comments.Count(x => x.Status == CommentStatus.Confirmed)
            })
            .ToList();
    }

    public ArticleQueryView? GetArticle(long id)
    {
        return _dbContext.Articles
            .Select(x => new ArticleQueryView()
            {
                Id = x.Id,
                Image = x.Image,
                CreationDate = x.CreationDate.ToString("yyyy MMMM dd"),
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                CategoryName = x.ArticleCategory.Title,
                Content = x.Content,
                CommentsCount = x.Comments.Count(x => x.Status == CommentStatus.Confirmed),
                Comments = x.Comments
                    .Where(x=>x.Status == CommentStatus.Confirmed)
                    .Select(x=> new CommentQueryView()
                {
                    Name = x.UserName,
                    CreationDate = x.CreationDate.ToString("D"),
                    Message = x.Message
                }).ToList()
            }).FirstOrDefault(x => x.Id == id);
    }
}