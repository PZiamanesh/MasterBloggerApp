using MB.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC.Areas.Administrator.Pages.CommentManagement;

public class ListModel : PageModel
{
    private readonly ICommentApplication _commentApplication;
    public IEnumerable<CommentViewModel> Comments { get; set; }

    public ListModel(ICommentApplication commentApplication)
    {
        _commentApplication = commentApplication;
    }

    public void OnGet()
    {
       Comments = _commentApplication.GetComments();
    }

    public RedirectToPageResult OnPostConfirm(long id)
    {
        _commentApplication.Confirm(id);
        return RedirectToPage("./List");
    }

    public RedirectToPageResult OnPostCancel(long id)
    {
        _commentApplication.Cancel(id);
        return RedirectToPage("./List");
    }
}