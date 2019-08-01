using Microsoft.Extensions.Logging;
using api.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace api.Services.impl
{
    public class NewsProducer : INewsProducer
    {


        private readonly ILogger _logger;
        private readonly NewsSource _source;

        private readonly IHttpClientFactory _httpClientFactory;

        public NewsProducer(NewsSource newsSource, ILogger<NewsProducer> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _source = newsSource;
            _httpClientFactory = httpClientFactory;
        }


        private async Task<string> fetchDataFromSource()
        {
            _logger.LogInformation("[{}] Fetching data", _source.Id);

            var httpClient = _httpClientFactory.CreateClient();
            return await httpClient.GetStringAsync(_source.NewsUrl);
        }
        public async Task<NewsItem[]> produceNews()
        {
            _logger.LogInformation("[{}] Starting to produce news", _source.Id);

            string rawInput = await fetchDataFromSource();

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
