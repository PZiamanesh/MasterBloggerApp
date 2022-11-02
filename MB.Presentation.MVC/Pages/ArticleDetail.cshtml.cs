using MB.Application.Contracts.Comment;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC.Pages;

public class ArticleDetailModel : PageModel
{
    private readonly IArticleQuery _articleQuery;
    private readonly ICommentApplication _commentApplication;
    public ArticleQueryView Article { get; set; }

    public ArticleDetailModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
    {
        _articleQuery = articleQuery;
        _commentApplication = commentApplication;
    }

    public void OnGet(long id)
    {
        Article = _articleQuery.GetArticle(id);
    }

    public RedirectToPageResult OnPost(AddComment command)
    {
        _commentApplication.AddComment(command);
        TempData["CommentSuccess"] = "Done!";
        return RedirectToPage("./ArticleDetail", new { Id = command.ArticleId });
    }
}