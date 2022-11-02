using System.Globalization;
using _Framework.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories;

public class ArticleRepository : BaseRepository<long, Article>, IArticleRepository
{
    private readonly MasterBlogDbContext _dbContext;

    public ArticleRepository(MasterBlogDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public List<ArticleViewModel> GetList()
    {
        return _dbContext.Articles
            .Include(x=>x.ArticleCategory)
            .Select(x => new ArticleViewModel()
        {
            Id = x.Id,
            Title = x.Title,
            ArticleCategory = x.ArticleCategory.Title,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            IsDeleted = x.IsDeleted
        }).ToList();
    }
}