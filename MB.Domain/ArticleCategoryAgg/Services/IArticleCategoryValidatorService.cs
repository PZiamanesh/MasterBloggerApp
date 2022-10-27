namespace MB.Domain.ArticleCategoryAgg.Services;

public interface IArticleCategoryValidatorService
{
    void CheckTitleExistence(string title);
}