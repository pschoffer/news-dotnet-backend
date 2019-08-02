using Microsoft.Extensions.Logging;
using api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;
using System.Text;

namespace api.Services.impl
{
    public class NewsProducer : INewsProducer
    {


        private readonly ILogger _logger;
        private readonly NewsSource _source;
        private readonly IHttpClientFactory _httpClientFactory;

        private long nextId;

        public NewsProducer(NewsSource newsSource, ILogger<NewsProducer> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _source = newsSource;
            _httpClientFactory = httpClientFactory;

            nextId = 1;
        }


        private async Task<string> fetchDataFromSource()
        {
            _logger.LogInformation("[{}] Fetching data", _source.Id);

            var httpClient = _httpClientFactory.CreateClient();
            return await httpClient.GetStringAsync(_source.NewsUrl);
        }

        private string generateId()
        {
            return _source.Id + "_" + nextId++;
        }


        private void updateNewsItemWithSourceDescription(NewsItem newsItem, string rawDescription)
        {
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml("<html>" + rawDescription + "</html>");

            var imgNodes = html.DocumentNode.Descendants("img");

            using (IEnumerator<HtmlNode> imgNodesEnumerator = imgNodes.GetEnumerator())
            {
                if (imgNodesEnumerator.MoveNext())
                {
                    newsItem.ImageUrl = imgNodesEnumerator.Current.Attributes["src"].Value;
                }
            }

            var textNodes = html.DocumentNode.Descendants("p");
            StringBuilder sb = new StringBuilder();
            using (IEnumerator<HtmlNode> textEnumerator = textNodes.GetEnumerator())
            {
                while (textEnumerator.MoveNext())
                {
                    sb.Append(textEnumerator.Current.OuterHtml);
                }
            }
            newsItem.Description = sb.ToString();
        }
        private NewsItem mapXmlNodeItem(XmlElement node)
        {

            NewsItem newsItem = new NewsItem(generateId());
            newsItem.SourceId = _source.Id;
            foreach (XmlElement child in node.ChildNodes)
            {
                switch (child.Name)
                {
                    case "title":
                        newsItem.Title = child.InnerText;
                        break;
                    case "link":
                        newsItem.Link = child.InnerText;
                        break;
                    case "description":
                        updateNewsItemWithSourceDescription(newsItem, child.InnerText);
                        break;
                    case "category":
                        newsItem.Category = child.InnerText;
                        break;
                    case "pubDate":
                        newsItem.Date = DateTime.Parse(child.InnerText);
                        break;
                }
            }

            return newsItem;
        }

        private NewsItem[] parseInput(string input)
        {

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(input);

            var itemNodes = doc.GetElementsByTagName("item");
            List<NewsItem> newsItems = new List<NewsItem>();
            foreach (XmlElement itemNode in itemNodes)
            {
                newsItems.Add(mapXmlNodeItem(itemNode));
            }

            return newsItems.ToArray(); ;
        }
        public async Task<NewsItem[]> produceNews()
        {
            _logger.LogInformation("[{}] Starting to produce news", _source.Id);

            string rawInput = await fetchDataFromSource();

            return parseInput(rawInput);
        }

    }
}
