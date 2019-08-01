using api.Models;
using System.Threading.Tasks;

namespace api.Services
{
    public interface INewsProducer
    {
        Task<NewsItem[]> produceNews();
    }
}
