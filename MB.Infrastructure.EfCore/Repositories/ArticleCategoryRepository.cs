using MB.Domain.ArticleCategoryAgg;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.EfCore.Repositories;

public class ArticleCategoryRepository : IArticleCategoryRepository
{
    private readonly MasterBlogDbContext _dbContext;

    public ArticleCategoryRepository(MasterBlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<ArticleCategory> GetAll()
    {
        return _dbContext.ArticleCategories.ToList();
    }

    public void Create(ArticleCategory entity)
    {
        _dbContext.ArticleCategories.Add(entity);
        _dbContext.SaveChanges();
    }
}