using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Application;

public class ArticleCategoryApplication : IArticleCategoryApplication
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;

    public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
    {
        _articleCategoryRepository = articleCategoryRepository;
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
        var articleCategory = new ArticleCategory(command.Title);
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
}