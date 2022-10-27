using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg;

public class ArticleCategory
{
    public long Id { get; private set; }
    public string? Title { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreationDate { get; private set; }

    public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
    {
        validatorService.IsTitleExists(title);
        GuardAgainstEmptyTitle(title);
        IsDeleted = false;
        CreationDate = DateTime.Now;
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
        this.Title = string.IsNullOrEmpty(title) ? throw new ArgumentNullException(): title;
    }
}