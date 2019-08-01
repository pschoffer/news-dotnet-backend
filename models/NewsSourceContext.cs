using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class NewsSourceContext : DbContext
    {
        public NewsSourceContext(DbContextOptions<NewsSourceContext> options) : base(options) { }

        public DbSet<NewsSource> NewsSources { get; set; }

    }
}
