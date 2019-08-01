
using Microsoft.Extensions.Logging;
using api.Models;

namespace api.Services.impl
{
    public class NewsSourceService : INewsSourceService
    {


        private readonly ILogger _logger;
        private readonly NewsSourceContext _context;

        public NewsSourceService(NewsSourceContext context, ILogger<NewsSourceService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void initNewsSources()
        {
            _logger.LogInformation("Initializing News Sources to hard codded data.");

            _context.Add(new NewsSource("test", "test", "google.com", "desc"));
            _context.Add(new NewsSource("test2", "test2", "google2.com", "desc2"));
            _context.SaveChanges();
        }
    }
}
