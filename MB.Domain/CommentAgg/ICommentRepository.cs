namespace MB.Domain.CommentAgg;

public interface ICommentRepository
{
    void CreateComment(Comment comment);
    List<Comment> GetAll();
    Comment Get(long id);
    void Save();
}