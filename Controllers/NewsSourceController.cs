using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public NewsSourceController(NewsSourceContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsSource>>> GetNewsSources()
        {
            return await _context.NewsSources.ToListAsync();
        }

    }
}
