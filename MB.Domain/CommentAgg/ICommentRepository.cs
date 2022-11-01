namespace MB.Domain.CommentAgg;

public interface ICommentRepository
{
    void CreateComment(Comment comment);
    void Save();
}