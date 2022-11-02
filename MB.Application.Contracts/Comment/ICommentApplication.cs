namespace MB.Application.Contracts.Comment;

public interface ICommentApplication
{
    void AddComment(AddComment command);
    IEnumerable<CommentViewModel> GetComments();
    void Confirm(long id);
    void Cancel(long id);
}