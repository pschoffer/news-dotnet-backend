namespace api.Models
{
    public class NewsSource
    {

        public NewsSource(string id, string title, string newsUrl, string description)
        {
            Id = id;
            Title = title;
            NewsUrl = newsUrl;
            Description = description;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string NewsUrl { get; set; }
        public string Description { get; set; }
    }
}
