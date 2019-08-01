using Microsoft.Extensions.Logging;
using api.Models;

namespace api.Services.impl
{
    public class NewsProducerFactory : INewsProducerFactory
    {


        private readonly ILogger _logger;
        private readonly ILogger<NewsProducer> _childLogger;

        public NewsProducerFactory(ILogger<NewsProducerFactory> logger, ILogger<NewsProducer> childLogger)
        {
            _logger = logger;
            _childLogger = childLogger;
        }

        public INewsProducer create(NewsSource source)
        {
            _logger.LogInformation("Creating Producer for {}", source.Id);
            return new NewsProducer(source, _childLogger);
        }

    }
}
