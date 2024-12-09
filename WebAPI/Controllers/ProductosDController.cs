using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPI.Data;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductosDController : ControllerBase
    {
        private readonly ProductosDbContext _context;

        public ProductosDController(ProductosDbContext context)
        {
            _context = context;
        }


        [HttpGet("GetProducts")]

        public async Task<ActionResult<IEnumerable<ProductoD>>> GetProductos() =>
            await _context.ProductosD.ToListAsync();


        [HttpGet("GetProductsById/{id}")]

        public async Task<ActionResult<ProductoD>> GetProducto(int id)
        {
            var producto = await _context.ProductosD.FindAsync (id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult> PostProducto(ProductoD producto)
        {
            _context.ProductosD.Add(producto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        [HttpPatch("UpdateProduct/{id}")]
        public async Task<ActionResult> PutProducto(int id, ProductoD producto)
        {
            
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult> DeleteProducto(int id)
        {
            var producto = await _context.ProductosD.FindAsync(id);
            if (producto == null) return NotFound();
            _context.ProductosD.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
