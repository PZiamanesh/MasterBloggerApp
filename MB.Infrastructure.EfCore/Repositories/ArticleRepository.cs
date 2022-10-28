using MB.Domain.ArticleAgg;

namespace MB.Infrastructure.EfCore.Repositories;

public class ArticleRepository : IArticleRepository
{
    private readonly MasterBlogDbContext _dbContext;

    public ArticleRepository(MasterBlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}