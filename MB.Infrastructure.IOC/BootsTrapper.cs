using _Framework.Infrastructure;
using MB.Application;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Application.Contracts.Comment;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore;
using MB.Infrastructure.EfCore.Repositories;
using MB.Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.IOC;

public class BootsTrapper
{
    public static void ConfigureService(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<MasterBlogDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });

        services.AddScoped<IArticleCategoryApplication, ArticleCategoryApplication>();
        services.AddScoped<IArticleCategoryRepository, ArticleCategoryRepository>();
        services.AddScoped<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();

        services.AddScoped<IArticleApplication, ArticleApplication>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IArticleValidatorService, ArticleValidatorService>();

        services.AddScoped<IArticleQuery, ArticleQuery>();

        services.AddScoped<ICommentApplication, CommentApplication>();
        services.AddScoped<ICommentRepository, CommentRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}