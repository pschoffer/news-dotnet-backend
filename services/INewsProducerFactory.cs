using api.Models;

namespace api.Services
{
    public interface INewsProducerFactory
    {
        INewsProducer create(NewsSource source);
    }
}
