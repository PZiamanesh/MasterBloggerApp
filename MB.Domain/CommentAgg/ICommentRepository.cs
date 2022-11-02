using _Framework.Infrastructure;

namespace MB.Domain.CommentAgg;

public interface ICommentRepository : IRepository<long, Comment>
{
    IEnumerable<Comment> GetList();
}