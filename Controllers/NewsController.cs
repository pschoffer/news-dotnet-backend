using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;
using api.Services;
namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _service;
        private readonly ILogger _logger;

        public NewsController(INewsService service, ILogger<NewsController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsItem>>> GetAllNewsItems()
        {
            _logger.LogInformation("Getting all the news");
            return await _service.getAllNews();
        }

        [HttpGet("{sourceId}")]
        public async Task<ActionResult<IEnumerable<NewsItem>>> GetNewsItems(string sourceId)
        {
            _logger.LogInformation("Getting news for {}", sourceId);
            return await _service.getNews(sourceId);
        }

    }
}
