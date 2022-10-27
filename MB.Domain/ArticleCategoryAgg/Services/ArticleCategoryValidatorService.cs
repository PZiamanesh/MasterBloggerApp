namespace MB.Domain.ArticleCategoryAgg.Services;

public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;

    public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
    {
        _articleCategoryRepository = articleCategoryRepository;
    }

    public void CheckTitleExistence(string title)
    {
        if (!_articleCategoryRepository.Exists(title))
        {
            throw new InvalidOperationException();
        }
    }
}