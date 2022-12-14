using _Framework.Domain;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.CommentAgg;

namespace MB.Domain.ArticleAgg;

public class Article : DomainBase<long>
{
    public string? Title { get; private set; }
    public string? ShortDescription { get; private set; }
    public string? Image { get; private set; }
    public string? Content { get; private set; }
    public bool IsDeleted { get; private set; }

    // Article hasOne articleCategory
    public long ArticleCategoryId { get; private set; }
    public ArticleCategory ArticleCategory { get; private set; }

    // Article hasMany comments
    public ICollection<Comment> Comments { get; private set; }

    protected Article()
    {
    }

    public Article(string title,
        string shortDescription,
        string image,
        string content,
        long articleCategoryId,
        IArticleValidatorService articleValidator)
    {
        Validate(title, articleCategoryId);
        articleValidator.IsArticleTitleDuplicated(title);

        ShortDescription = shortDescription;
        Image = image;
        Content = content;
        IsDeleted = false;
        Comments = new List<Comment>();
    }

    private void Validate(string title, long articleCategoryId)
    {
        Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentNullException() : title;

        ArticleCategoryId = articleCategoryId == 0 ? throw new ArgumentOutOfRangeException() : articleCategoryId;
    }

    public void Edit(string title, string shortDescription, string image, string content, long categoryId)
    {
        Title = title;
        ShortDescription = shortDescription;
        Image = image;
        Content = content;
        ArticleCategoryId = categoryId;
    }

    public void Remove()
    {
        IsDeleted = true;
    }

    public void Activate()
    {
        IsDeleted = false;
    }
}