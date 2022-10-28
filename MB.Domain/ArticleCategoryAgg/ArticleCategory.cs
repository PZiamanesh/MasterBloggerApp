using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg;

public class ArticleCategory
{
    public long Id { get; private set; }
    public string? Title { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreationDate { get; private set; }

    // Reference relations
    public List<Article> Articles { get; private set; }

    protected ArticleCategory()
    {
    }

    public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
    {
        GuardAgainstEmptyTitle(title);
        validatorService.CheckTitleExistence(title);

        IsDeleted = false;
        CreationDate = DateTime.Now;
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