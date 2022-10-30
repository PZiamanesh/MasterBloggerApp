namespace MB.Domain.ArticleAgg.Services;

public interface IArticleValidatorService
{
    void IsArticleTitleDuplicated(string title);
}