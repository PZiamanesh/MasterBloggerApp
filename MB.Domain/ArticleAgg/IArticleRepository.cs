using MB.Application.Contracts.Article;

namespace MB.Domain.ArticleAgg;

public interface IArticleRepository
{
    List<ArticleViewModel> GetAll();
    void Create(Article entity);
    Article Get(long id);
    void Save();
    bool IsArticleExist(string title);
}