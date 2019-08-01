using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class NewsSourceContext : DbContext
    {
        public NewsSourceContext(DbContextOptions<NewsSourceContext> options) : base(options) { }

        public DbSet<NewsSource> NewsSources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsSource>().HasData(
                new NewsSource("test", "test", "google.com", "desc"),
                new NewsSource("test2", "test2", "google2.com", "desc2")
            );
        }
    }
}
