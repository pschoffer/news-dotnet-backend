
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

            _context.Add(new NewsSource("nt", "Norrköpingsnyheter", "https://www.nt.se/nyheter/norrkoping/rss/", "De senaste Norrköpingsnyheterna från nt.se"));
            _context.Add(new NewsSource("expressen", "Expressen: Nyheter", "https://feeds.expressen.se/nyheter/", "Sveriges bästa nyhetssajt med nyheter, sport och nöje!"));
            _context.Add(new NewsSource("svd", "SvD - Startsidan", "https://www.svd.se/?service=rss", "Startsidan från www.svd.se"));
            _context.SaveChanges();
        }
    }
}
