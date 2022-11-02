using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application;

public class CommentApplication : ICommentApplication
{
    private readonly ICommentRepository _commentRepository;

    public CommentApplication(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public void AddComment(AddComment command)
    {
        var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
        _commentRepository.CreateComment(comment);
    }

    public List<CommentViewModel> GetComments()
    {
        var comments = _commentRepository.GetAll();
        return comments.Select(x => new CommentViewModel()
        {
            Id = x.Id,
            Name = x.UserName,
            Email = x.Email,
            Message = x.Message,
            Article = x.Article.Title,
            Status = (int)x.Status,
            CreationDate = x.CreationDate.ToString()
        }).ToList();
    }

    public void Confirm(long id)
    {
        var comment = _commentRepository.Get(id);
        comment.Confirm();
        _commentRepository.Save();
    }

    public void Cancel(long id)
    {
        var comment = _commentRepository.Get(id);
        comment.Cancel();
        _commentRepository.Save();
    }
}