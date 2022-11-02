using _Framework.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;

namespace MB.Application;

public class ArticleApplication : IArticleApplication
{
    private readonly IArticleRepository _articleRepository;
    private readonly IArticleValidatorService _articleValidatorService;
    private readonly IUnitOfWork _unitOfWork;

    public ArticleApplication(IArticleRepository articleRepository, IArticleValidatorService articleValidatorService, IUnitOfWork unitOfWork)
    {
        _articleRepository = articleRepository;
        _articleValidatorService = articleValidatorService;
        _unitOfWork = unitOfWork;
    }

    public List<ArticleViewModel> List()
    {
        return _articleRepository.GetList();
    }

    public void CreateArticle(CreateNewArticle command)
    {
        _unitOfWork.BeginTrans();

        var article = new Article(command.Title,
            command.ShortDescription,
            command.Image,
            command.Content,
            command.ArticleCategoryId,
            _articleValidatorService);

        _articleRepository.Create(article);

        _unitOfWork.CommitTrans();
    }

    public EditArticle GetArticle(long id)
    {
        Article? article = _articleRepository.Get(id);

        return new EditArticle()
        {
            Id = article.Id,
            Title = article.Title,
            ShortDescription = article.ShortDescription,
            Image = article.Image,
            Content = article.Content,
            ArticleCategoryId = article.ArticleCategoryId
        };
    }

    public void EditArticle(EditArticle command)
    {
        _unitOfWork.BeginTrans();

        var article = _articleRepository.Get(command.Id);
        article.Edit(command.Title,
            command.ShortDescription,
            command.Image,
            command.Content,
            command.ArticleCategoryId);

        _unitOfWork.CommitTrans();
    }

    public void RemoveArticle(long id)
    {
        _unitOfWork.BeginTrans();

        var article = _articleRepository.Get(id);
        article.Remove();

        _unitOfWork.CommitTrans();
    }

    public void ActivateArticle(long id)
    {
        _unitOfWork.BeginTrans();

        var article = _articleRepository.Get(id);
        article.Activate();

        _unitOfWork.CommitTrans();
    }
}