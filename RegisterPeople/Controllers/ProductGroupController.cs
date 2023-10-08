using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterPeople.Data;
using RegisterPeople.Models;

namespace RegisterPeople.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGroupController : ControllerBase
    {
        private readonly ProductDbContext _context;
        
        public ProductGroupController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<ProductGroup>> CreateProductGroup(ProductGroup productGroup)
        {
            _context.ProductGroups.Add(productGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductGroup", new { id = productGroup.Id }, productGroup);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductGroup>>> GetProductGroups()
        {
            var productGroups = await _context.ProductGroups.ToListAsync();
            return Ok(productGroups);
        }

        [HttpGet("ByGroupId/{groupId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByGroupId(int groupId)
        {
            var products = await _context.Products.Where(p => p.ProductGroupId == groupId).ToListAsync();

            if (products == null || products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductGroup(int id, ProductGroup productGroup)
        {
            if (id != productGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(productGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductGroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ProductGroupExists(int id)
        {
            return _context.ProductGroups.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductGroup(int id)
        {
            var productGroup = await _context.ProductGroups.FindAsync(id);
            if (productGroup == null)
            {
                return NotFound();
            }

            _context.ProductGroups.Remove(productGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }






    }
}
