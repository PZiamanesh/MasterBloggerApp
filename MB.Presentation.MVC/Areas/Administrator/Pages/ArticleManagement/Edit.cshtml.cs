using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.MVC.Areas.Administrator.Pages.ArticleManagement;

public class EditModel : PageModel
{
    private readonly IArticleApplication _articleApplication;
    private readonly IArticleCategoryApplication _articleCategoryApplication;
    [BindProperty] public EditArticle Article { get; set; }
    public List<SelectListItem> ArticleCategories { get; set; }

    public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
    {
        _articleApplication = articleApplication;
        _articleCategoryApplication = articleCategoryApplication;
    }

    public void OnGet(long id)
    {
        Article = _articleApplication.GetArticle(id);
        ArticleCategories = _articleCategoryApplication.List()
            .Select(x => new SelectListItem(x.Title, x.Id.ToString()))
            .ToList();
    }

    public RedirectToPageResult OnPost()
    {
        _articleApplication.EditArticle(Article);
        return RedirectToPage("./List");
    }
}