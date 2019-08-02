using System;

namespace api.Models
{
    public class NewsItem
    {

        public NewsItem(string id)
        {
            Id = id;
        }
        public NewsItem(string id, string title, string description, string link, string sourceId, DateTime date, string imageUrl, string category)
        {
            Id = id;
            Title = title;
            Description = description;
            Link = link;
            SourceId = sourceId;
            Date = date;
            ImageUrl = imageUrl;
            Category = category;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string SourceId { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }


    }
}
