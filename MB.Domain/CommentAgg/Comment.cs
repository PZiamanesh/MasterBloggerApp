using MB.Domain.ArticleAgg;

namespace MB.Domain.CommentAgg;

public class Comment
{
    public long Id { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string Message { get; private set; }
    public CommentStatus Status { get; private set; }
    public DateTime CreationDate { get; private set; }

    // Comment hasOne Article
    public long ArticleId { get; private set; }
    public Article Article { get; private set; }

    protected Comment()
    {
    }

    public Comment(string userName, string email, string message, long articleId)
    {
        UserName = userName;
        Email = email;
        Message = message;
        ArticleId = articleId;
        Status = CommentStatus.NewComment;
        CreationDate = DateTime.Now;
    }

    public void Confirm()
    {
        Status = CommentStatus.Confirmed;
    }
}


public enum CommentStatus
{
    NewComment,
    Confirmed,
    Canceled
}