using MB.Application;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EfCore;
using MB.Infrastructure.EfCore.Repositories;
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
    }
}