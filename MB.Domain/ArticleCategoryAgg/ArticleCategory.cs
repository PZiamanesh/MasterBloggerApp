namespace MB.Domain.ArticleCategoryAgg;

public class ArticleCategory
{
    public long Id { get; private set; }
    public string Title { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreationDate { get; private set; }

    public ArticleCategory(string title)
    {
        Title = title;
        IsDeleted = false;
        CreationDate = DateTime.Now;
    }

    public void Edit(string title)
    {
        if (string.IsNullOrEmpty(title))
        {
            this.Title = "N/A";
        }
        else
        {
            this.Title = title;
        }
    }
}