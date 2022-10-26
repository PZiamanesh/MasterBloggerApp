using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class RenameModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        [BindProperty] public RenameArticleCategory ArticleCategory { get; set; }

        public RenameModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
            ArticleCategory = _articleCategoryApplication.Get(id);
        }

        public RedirectToPageResult OnPost()
        {
            _articleCategoryApplication.Rename(ArticleCategory);
            return RedirectToPage("./List");
        }
    }
}