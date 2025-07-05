using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZapateriaAres.API.Data;
using ZapateriaAres.API.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZapateriaAres.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ZapateriaContext _context;

        public ProductosController(ZapateriaContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetProductos()
        {
            var productos = await _context.Productos
                .Select(p => new
                {
                    p.Id,
                    p.Nombre,
                    p.Descripcion,
                    p.Precio,
                    p.ImagenUrl,
                    p.CategoriaId
                })
                .ToListAsync();

            return productos;
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // GET: api/Productos/buscar?nombre=nike
        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<Producto>>> BuscarProductos(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return await _context.Productos
                    .Include(p => p.Categoria)
                    .ToListAsync();
            }

            return await _context.Productos
                .Include(p => p.Categoria)
                .Where(p => p.Nombre.Contains(nombre))
                .ToListAsync();
        }

        // GET: api/Productos/categoria/1
        [HttpGet("categoria/{categoriaId}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosPorCategoria(int categoriaId)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Where(p => p.CategoriaId == categoriaId)
                .ToListAsync();
        }

        // GET: api/Productos/filtrar?categoria=1&nombre=nike
        [HttpGet("filtrar")]
        public async Task<ActionResult<IEnumerable<Producto>>> FiltrarProductos(int? categoria, string? nombre)
        {
            var query = _context.Productos.Include(p => p.Categoria).AsQueryable();

            if (categoria.HasValue && categoria.Value > 0)
            {
                query = query.Where(p => p.CategoriaId == categoria.Value);
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(p => p.Nombre.Contains(nombre));
            }

            return await query.ToListAsync();
        }
    }
}