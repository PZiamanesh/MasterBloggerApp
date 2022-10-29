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
}