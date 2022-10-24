using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public List<ArticleCategoryViewModel> List()
        {
            return _articleCategoryRepository.GetAll().Select(x => new ArticleCategoryViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                CreationDate = x.CreationDate.ToString(),
                IsDeleted = x.IsDeleted
            }).ToList();
        }
    }
}