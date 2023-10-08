using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterPeople.Data;
using RegisterPeople.Models;

namespace RegisterPeople.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public StockController(ProductDbContext context)
        {
            _context = context;
        }
        [HttpPut("{id}/increase-stock")]
        public async Task<IActionResult> IncreaseStock(int id, [FromBody] int number)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

                if (product == null)
                {
                    return NotFound($"محصول با شناسه {id} یافت نشد.");
                }

               
                product.Stock += number;

                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok($"موجودی محصول با شناسه {id} با مقدار {number} افزایش یافت.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطا: {ex.Message}");
            }
        }

        [HttpPut("{id}/decrease-stock")]
        public async Task<IActionResult> DecreaseStock(int id, [FromBody] int number)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

                if (product == null)
                {
                    return NotFound($"محصول با شناسه {id} یافت نشد.");
                }

                if (product.Stock < number)
                {
                    return BadRequest($"موجودی محصول با شناسه {id} کافی نیست.");
                }

                
                product.Stock -= number;

                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok($"موجودی محصول با شناسه {id} با مقدار {number} کاهش یافت.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"خطا: {ex.Message}");
            }
        }
    }
}



