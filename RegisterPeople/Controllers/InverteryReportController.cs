using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterPeople.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeople.Controllers
{
    /// <summary>
    /// salam
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryReportController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public InventoryReportController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet("inventory-report")]
        public async Task<IActionResult> GetInventoryReport()
        {
            var report = await _context.ProductGroups
                .Include(pg => pg.Products)
                .Select(pg => new
                {
                    GroupTitle = pg.ParentGroup,
                    Products = pg.Products.OrderBy(p => p.Price).ToList()
                })
                .ToListAsync();

            return Ok(report);
        }
    }
}

