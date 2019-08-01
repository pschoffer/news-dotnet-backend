using Microsoft.Extensions.Logging;
using api.Models;
using System;

namespace api.Services.impl
{
    public class NewsProducer : INewsProducer
    {


        private readonly ILogger _logger;
        private readonly NewsSource _source;

        public NewsProducer(NewsSource newsSource, ILogger<NewsProducer> logger)
        {
            _logger = logger;
            _source = newsSource;
        }

        public NewsItem[] produceNews()
        {
            _logger.LogInformation("[{}] Starting to produce news", _source.Id);
            return new NewsItem[] {
                new NewsItem(_source.Id + "id",
                "title",
                "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown",
                "dada",
                "svd",
                DateTime.Now,
                null,
                null),
                new NewsItem(_source.Id + "id2",
                "title",
                "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown",
                "dada",
                "svd",
                DateTime.Now,
                null,
                null)
            };
        }

    }
}
