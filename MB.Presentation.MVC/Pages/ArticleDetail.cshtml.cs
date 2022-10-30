using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC.Pages;

public class ArticleDetailModel : PageModel
{
    private readonly IArticleQuery _articleQuery;
    public ArticleQueryView Article { get; set; }

    public ArticleDetailModel(IArticleQuery articleQuery)
    {
        _articleQuery = articleQuery;
    }

    public void OnGet(long id)
    {
        Article = _articleQuery.GetArticle(id);
    }
}