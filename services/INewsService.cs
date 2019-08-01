using System.Threading.Tasks;

namespace api.Services
{
    public interface INewsService
    {
        Task LoadNews();
    }
}
