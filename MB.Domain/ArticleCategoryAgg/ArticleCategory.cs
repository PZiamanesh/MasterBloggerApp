using _Framework.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg;

public class ArticleCategory : DomainBase<long>
{
    public string? Title { get; private set; }
    public bool IsDeleted { get; private set; }

    // ArticleCategory hasMany articles
    public List<Article> Articles { get; private set; }

    protected ArticleCategory()
    {
    }

    public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
    {
        GuardAgainstEmptyTitle(title);
        validatorService.CheckTitleExistence(title);

        IsDeleted = false;
        Articles = new List<Article>();
    }

    public void Edit(string title)
    {
        GuardAgainstEmptyTitle(title);
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void Activate()
    {
        IsDeleted = false;
    }

    private void GuardAgainstEmptyTitle(string title)
    {
        this.Title = string.IsNullOrWhiteSpace(title)
            ? throw new ArgumentNullException(title, "ArticleCategory has no title.")
            : title;
    }
}