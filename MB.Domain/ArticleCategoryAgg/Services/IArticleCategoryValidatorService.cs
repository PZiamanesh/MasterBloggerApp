namespace MB.Domain.ArticleCategoryAgg.Services;

public interface IArticleCategoryValidatorService
{
    bool IsTitleExists(string title);
}