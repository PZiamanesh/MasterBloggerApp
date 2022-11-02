using _Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application;

public class CommentApplication : ICommentApplication
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CommentApplication(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
    {
        _commentRepository = commentRepository;
        _unitOfWork = unitOfWork;
    }

    public void AddComment(AddComment command)
    {
        _unitOfWork.BeginTrans();

        var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
        _commentRepository.Create(comment);
        _unitOfWork.CommitTrans();
    }

    public IEnumerable<CommentViewModel> GetComments()
    {
        var comments = _commentRepository.GetList();
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
        _unitOfWork.BeginTrans();

        var comment = _commentRepository.Get(id);
        comment.Confirm();
        _unitOfWork.CommitTrans();
    }

    public void Cancel(long id)
    {
        _unitOfWork.BeginTrans();

        var comment = _commentRepository.Get(id);
        comment.Cancel();
        _unitOfWork.CommitTrans();
    }
}