using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EfCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore
{
    public class MasterBlogDbContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        public MasterBlogDbContext(DbContextOptions<MasterBlogDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
