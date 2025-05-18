using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniLojaVirtual.Core.Data;
using MiniLojaVirtual.Core.Models;

namespace MiniLojaVirtual.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriaApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Categorias.ToListAsync());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Nome))
                return BadRequest("Nome da categoria é obrigatório.");

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] Categoria categoriaAtualizada)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
                return NotFound();

            categoria.Nome = categoriaAtualizada.Nome;
            categoria.Descricao = categoriaAtualizada.Descricao;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
                return NotFound();

            var temProdutos = await _context.Produtos.AnyAsync(p => p.CategoriaId == id);
            if (temProdutos)
                return BadRequest("Não é possível excluir uma categoria que possui produtos vinculados.");

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
