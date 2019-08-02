using System.Threading.Tasks;
using api.Models;

namespace api.Services
{
    public interface INewsService
    {
        Task LoadNews();

        Task<NewsItem[]> getAllNews();

        Task<NewsItem[]> getNews(string sourceId);
    }
}
