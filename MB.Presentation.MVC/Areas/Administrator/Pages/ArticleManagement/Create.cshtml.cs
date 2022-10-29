using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MB.Presentation.MVC.Areas.Administrator.Pages.ArticleManagement;

public class CreateModel : PageModel
{
    private readonly IArticleCategoryApplication _articleCategoryApplication;
    private readonly IArticleApplication _articleApplication;

    public List<SelectListItem> ArticleCategories { get; set; }
    [BindProperty] public CreateNewArticle Article { get; set; }

    public CreateModel(IArticleCategoryApplication articleCategoryApplication,
        IArticleApplication articleApplication)
    {
        _articleCategoryApplication = articleCategoryApplication;
        _articleApplication = articleApplication;
    }

    public void OnGet()
    {
        ArticleCategories = _articleCategoryApplication.List()
            .Select(x => new SelectListItem(x.Title, (x.Id).ToString()))
            .ToList();
    }

    public RedirectToPageResult OnPost()
    {
        _articleApplication.CreateArticle(Article);
        return RedirectToPage("./List");
    }
}