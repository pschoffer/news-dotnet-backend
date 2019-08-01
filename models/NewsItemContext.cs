using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class NewsItemContext : DbContext
    {
        public NewsItemContext(DbContextOptions<NewsItemContext> options) : base(options) { }

        public DbSet<NewsItem> NewsItems { get; set; }

    }
}
