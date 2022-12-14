using _Framework.Domain;
using MB.Domain.ArticleAgg;

namespace MB.Domain.CommentAgg;

public class Comment : DomainBase<long>
{
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string Message { get; private set; }
    public int Status { get; private set; }

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
    }

    public void Confirm()
    {
        Status = CommentStatus.Confirmed;
    }

    public void Cancel()
    {
        Status = CommentStatus.Canceled;
    }
}


public static class CommentStatus
{
    public static int NewComment => 0;
    public static int Confirmed => 1;
    public static int Canceled => 2;
}