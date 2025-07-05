using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZapateriaAres.API.Data;
using ZapateriaAres.API.Models;

namespace ZapateriaAres.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ZapateriaContext _context;

        public CategoriasController(ZapateriaContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            var categorias = await _context.Categorias
                .Select(c => new
                {
                    c.Id,
                    c.Nombre,
                    c.Descripcion,
                    Productos = c.Productos.Select(p => new
                    {
                        p.Id,
                        p.Nombre,
                        p.Descripcion,
                        p.Precio,
                        p.ImagenUrl,
                        p.CategoriaId
                    })
                })
                .ToListAsync();
            return Ok(categorias);
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias
                .Select(c => new
                {
                    c.Id,
                    c.Nombre,
                    c.Descripcion,
                    Productos = c.Productos.Select(p => new
                    {
                        p.Id,
                        p.Nombre,
                        p.Descripcion,
                        p.Precio,
                        p.ImagenUrl,
                        p.CategoriaId
                    })
                })
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }
    }
}