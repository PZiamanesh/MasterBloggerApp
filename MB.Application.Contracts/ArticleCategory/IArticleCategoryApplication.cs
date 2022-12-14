namespace MB.Application.Contracts.ArticleCategory;

public interface IArticleCategoryApplication
{
    List<ArticleCategoryViewModel> List();
    void Create(CreateArticleCategory command);
    void Rename(RenameArticleCategory command);
    RenameArticleCategory Get(long id);
    void RemoveState(long id);
    void ActivateState(long id);
}