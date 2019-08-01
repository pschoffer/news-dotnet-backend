
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

        public NewsService(NewsSourceContext sourceContext, NewsItemContext newsContext, ILogger<NewsService> logger)
        {
            _sourceContext = sourceContext;
            _newsContext = newsContext;
            _logger = logger;
        }

        public void LoadNews()
        {
            _logger.LogInformation("Loading News.");

            _newsContext.Add(new NewsItem("id",
                "title",
                "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown",
                "dada",
                "svd",
                DateTime.Now,
                null,
                null));
            _newsContext.SaveChanges();
        }
    }
}
