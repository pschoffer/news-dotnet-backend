
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using api.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace api.Services.impl
{
    public class NewsService : INewsService
    {


        private readonly ILogger _logger;
        private readonly NewsSourceContext _sourceContext;
        private readonly IServiceProvider _serviceProvider;
        private readonly INewsProducerFactory _producerFactory;


        public NewsService(NewsSourceContext sourceContext,
                            IServiceProvider serviceProvider,
                            ILogger<NewsService> logger,
                            INewsProducerFactory producerFactory)
        {
            _sourceContext = sourceContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
            _producerFactory = producerFactory;
        }

        public async Task LoadNews()
        {
            _logger.LogInformation("Loading News.");

            var sources = _sourceContext.NewsSources;
            List<Task> tasks = new List<Task>();
            foreach (var source in sources)
            {
                var producer = _producerFactory.create(source);
                tasks.Add(populateNews(producer));
            }

            await Task.WhenAll(tasks);
        }

        private async Task populateNews(INewsProducer producer)
        {
            var news = await producer.produceNews();

            var context = _serviceProvider.GetRequiredService<NewsItemContext>();
            context.AddRange(news);
            context.SaveChanges();
        }



        public async Task<NewsItem[]> getAllNews()
        {
            var context = _serviceProvider.GetRequiredService<NewsItemContext>();


            var list = await context.NewsItems
            .OrderByDescending(item => item.Date)
            .ToListAsync();

            return list.ToArray();
        }

        public Task<NewsItem[]> getNews(string sourceId)
        {
            return null;
        }
    }
}
