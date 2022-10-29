using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application;

public class ArticleApplication : IArticleApplication
{
    private readonly IArticleRepository _articleRepository;

    public ArticleApplication(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public List<ArticleViewModel> List()
    {
        return _articleRepository.GetAll();
    }

    public void CreateArticle(CreateNewArticle command)
    {
        var article = new Article(command.Title,
            command.ShortDescription,
            command.Image,
            command.Content,
            command.ArticleCategoryId);

        _articleRepository.Create(article);
    }

    public EditArticle GetArticle(long id)
    {
        Article article = _articleRepository.Get(id);
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
        var article = _articleRepository.Get(command.Id);
        article.Edit(command.Title,
            command.ShortDescription,
            command.Image,
            command.Content,
            command.ArticleCategoryId);

        _articleRepository.Save();
    }
}