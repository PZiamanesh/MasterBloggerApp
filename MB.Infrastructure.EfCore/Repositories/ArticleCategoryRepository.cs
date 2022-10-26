using MB.Domain.ArticleCategoryAgg;

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
        return _dbContext.ArticleCategories.OrderByDescending(x => x.Id).ToList();
    }

    public void Add(ArticleCategory entity)
    {
        _dbContext.Add(entity);
        Save();
    }

    public ArticleCategory Get(long id)
    {
        return _dbContext.ArticleCategories.Find(id);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}