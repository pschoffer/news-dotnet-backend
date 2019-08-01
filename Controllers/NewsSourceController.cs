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
    public class NewsSourceController : ControllerBase
    {
        private readonly NewsSourceContext _context;
        private readonly ILogger _logger;

        public NewsSourceController(NewsSourceContext context, ILogger<NewsSourceController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsSource>>> GetNewsSources()
        {
            _logger.LogInformation("Getting News sources");
            return await _context.NewsSources.ToListAsync();
        }

    }
}
