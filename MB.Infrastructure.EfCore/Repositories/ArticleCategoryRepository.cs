using _Framework.Infrastructure;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EfCore.Repositories;

public class ArticleCategoryRepository : BaseRepository<long,ArticleCategory>, IArticleCategoryRepository
{
    private readonly MasterBlogDbContext _dbContext;

    public ArticleCategoryRepository(MasterBlogDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}