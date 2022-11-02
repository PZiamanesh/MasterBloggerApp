using System.Globalization;
using _Framework.Infrastructure;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application;

public class ArticleCategoryApplication : IArticleCategoryApplication
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;
    private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;
    private readonly IUnitOfWork _unitOfWork;

    public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService, IUnitOfWork unitOfWork)
    {
        _articleCategoryRepository = articleCategoryRepository;
        _articleCategoryValidatorService = articleCategoryValidatorService;
        _unitOfWork = unitOfWork;
    }

    public List<ArticleCategoryViewModel> List()
    {
        return _articleCategoryRepository.GetAll().Select(x => new ArticleCategoryViewModel()
        {
            Id = x.Id,
            Title = x.Title ?? "N/A",
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            IsDeleted = x.IsDeleted
        }).ToList(); ;
    }

    public void Create(CreateArticleCategory command)
    {
        _unitOfWork.BeginTrans();

        var articleCategory = new ArticleCategory(command.Title!, _articleCategoryValidatorService);
        _articleCategoryRepository.Create(articleCategory);
        _unitOfWork.CommitTrans();
    }

    public void Rename(RenameArticleCategory command)
    {
        _unitOfWork.BeginTrans();

        var articleCategory = _articleCategoryRepository.Get(command.Id);
        articleCategory.Edit(command.Title ?? "_Not Specified at Edit");
        _unitOfWork.CommitTrans();
    }

    public RenameArticleCategory Get(long id)
    {
        var articleCategory = _articleCategoryRepository.Get(id);
        return new RenameArticleCategory()
            { Id = articleCategory.Id, Title = articleCategory.Title };
    }

    public void RemoveState(long id)
    {
        _unitOfWork.BeginTrans();

        var articleCategory = _articleCategoryRepository.Get(id);
        articleCategory.Delete();
        _unitOfWork.CommitTrans();
    }

    public void ActivateState(long id)
    {
        _unitOfWork.BeginTrans();

        var articleCategory = _articleCategoryRepository.Get(id);
        articleCategory.Activate();
        _unitOfWork.CommitTrans();
    }
}