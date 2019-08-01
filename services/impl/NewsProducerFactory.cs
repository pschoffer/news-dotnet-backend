using Microsoft.Extensions.Logging;
using api.Models;
using System.Net.Http;

namespace api.Services.impl
{
    public class NewsProducerFactory : INewsProducerFactory
    {


        private readonly ILogger _logger;
        private readonly ILogger<NewsProducer> _childLogger;
        private readonly IHttpClientFactory _httpClientFactory;

        public NewsProducerFactory(ILogger<NewsProducerFactory> logger, ILogger<NewsProducer> childLogger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _childLogger = childLogger;
            _httpClientFactory = httpClientFactory;
        }

        public INewsProducer create(NewsSource source)
        {
            _logger.LogInformation("Creating Producer for {}", source.Id);
            return new NewsProducer(source, _childLogger, _httpClientFactory);
        }

    }
}
