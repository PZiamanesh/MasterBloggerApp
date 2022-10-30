namespace MB.Application.Contracts.Article;

public interface IArticleApplication
{
    List<ArticleViewModel> List();
    void CreateArticle(CreateNewArticle command);
    EditArticle GetArticle(long id);
    void EditArticle(EditArticle command);
    void RemoveArticle(long id);
    void ActivateArticle(long id);
}