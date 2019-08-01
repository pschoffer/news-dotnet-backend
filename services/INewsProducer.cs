using api.Models;

namespace api.Services
{
    public interface INewsProducer
    {
        NewsItem[] produceNews();
    }
}
