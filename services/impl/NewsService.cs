
using Microsoft.Extensions.Logging;
using api.Models;
using System;

namespace api.Services.impl
{
    public class NewsService : INewsService
    {


        private readonly ILogger _logger;
        private readonly NewsSourceContext _sourceContext;
        private readonly NewsItemContext _newsContext;
        private readonly INewsProducerFactory _producerFactory;

        public NewsService(NewsSourceContext sourceContext,
                            NewsItemContext newsContext,
                            ILogger<NewsService> logger,
                            INewsProducerFactory producerFactory)
        {
            _sourceContext = sourceContext;
            _newsContext = newsContext;
            _logger = logger;
            _producerFactory = producerFactory;
        }

        public void LoadNews()
        {
            _logger.LogInformation("Loading News.");

            var sources = _sourceContext.NewsSources;
            foreach (var source in sources)
            {
                var producer = _producerFactory.create(source);
                var news = producer.produceNews();

                _newsContext.AddRange(news);
            }
            _newsContext.SaveChanges();
        }
    }
}
