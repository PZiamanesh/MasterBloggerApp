namespace MB.Domain.ArticleCategoryAgg.Services;

class ArticleCategoryValidatorService : IArticleCategoryValidatorService
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;

    public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
    {
        _articleCategoryRepository = articleCategoryRepository;
    }

    public bool IsTitleExists(string title)
    {
        return _articleCategoryRepository.Exists(title)
            ? true
            : throw new InvalidOperationException("A record with this title already exists.");
    }
}