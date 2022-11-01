namespace MB.Application.Contracts.Comment;

public interface ICommentApplication
{
    void AddComment(AddComment command);
    List<CommentViewModel> GetComments();
}