namespace MB.Domain.CommentAgg;

public interface ICommentRepository
{
    void CreateComment(Comment comment);
    List<Comment> GetAll();
    void Save();
}