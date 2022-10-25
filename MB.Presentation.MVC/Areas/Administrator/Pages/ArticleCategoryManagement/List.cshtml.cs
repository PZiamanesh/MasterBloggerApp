using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC.Areas.Administrator.Pages.ArticleCategoryManagement;

public class ListModel : PageModel
{
    private readonly IArticleCategoryApplication _articleCategoryApplication;

    public List<ArticleCategoryViewModel> ArticleCategories { get; set; }

    public ListModel(IArticleCategoryApplication articleCategoryApplication)
    {
        _articleCategoryApplication = articleCategoryApplication;
    }

    public void OnGet()
    {
        ArticleCategories = _articleCategoryApplication.List();
    }
}