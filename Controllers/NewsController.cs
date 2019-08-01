using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsItemContext _context;
        private readonly ILogger _logger;

        public NewsController(NewsItemContext context, ILogger<NewsController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsItem>>> GetNewsItems()
        {
            _logger.LogInformation("Getting all the news");
            return await _context.NewsItems.ToListAsync();
        }

    }
}
