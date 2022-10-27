using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application;

public class ArticleCategoryApplication : IArticleCategoryApplication
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;
    private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;

    public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)
    {
        _articleCategoryRepository = articleCategoryRepository;
        _articleCategoryValidatorService = articleCategoryValidatorService;
    }

    public List<ArticleCategoryViewModel> List()
    {
        return _articleCategoryRepository.GetAll().Select(x => new ArticleCategoryViewModel()
        {
            Id = x.Id,
            Title = x.Title,
            CreationDate = x.CreationDate.ToString(),
            IsDeleted = x.IsDeleted
        }).ToList();
    }

    public void Create(CreateArticleCategory command)
    {
        var articleCategory = new ArticleCategory(command.Title, _articleCategoryValidatorService);
        _articleCategoryRepository.Add(articleCategory);
    }

    public void Rename(RenameArticleCategory command)
    {
        var articleCategory = _articleCategoryRepository.Get(command.Id);
        articleCategory.Edit(command.Title);
        _articleCategoryRepository.Save();
    }

    public RenameArticleCategory Get(long id)
    {
        var articleCategory = _articleCategoryRepository.Get(id);
        return new RenameArticleCategory()
            { Id = articleCategory.Id, Title = articleCategory.Title };
    }

    public void RemoveState(long id)
    {
        var articleCategory = _articleCategoryRepository.Get(id);
        articleCategory.Delete();
        _articleCategoryRepository.Save();
    }

    public void ActivateState(long id)
    {
        var articleCategory = _articleCategoryRepository.Get(id);
        articleCategory.Activate();
        _articleCategoryRepository.Save();
    }
}