using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleAgg.Services;

public class ArticleValidatorService : IArticleValidatorService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleValidatorService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public void IsArticleTitleDuplicated(string title)
    {
        if (_articleRepository.Exist(x=>x.Title == title))
            throw new DuplicatedRecordException("A record with this title already exist.");
    }
}