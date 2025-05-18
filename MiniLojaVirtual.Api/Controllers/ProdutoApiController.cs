using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniLojaVirtual.Core.Data;
using MiniLojaVirtual.Core.Models;
using System.Security.Claims;

namespace MiniLojaVirtual.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProdutoApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get() =>
            Ok(await _context.Produtos.Include(p => p.Categoria).ToListAsync());

        [HttpGet("categoria/{categoriaId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByCategoria(int categoriaId)
        {
            return Ok(await _context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.CategoriaId == categoriaId)
                .ToListAsync());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            if (produto.Preco < 0)
                return BadRequest("Preço não pode ser negativo.");

            var categoriaExiste = await _context.Categorias.AnyAsync(c => c.Id == produto.CategoriaId);
            if (!categoriaExiste)
                return BadRequest("Categoria informada não existe.");

            produto.VendedorId = userId;
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] Produto produtoAtualizado)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return NotFound();

            if (produto.VendedorId != userId)
                return Forbid();

            produto.Nome = produtoAtualizado.Nome;
            produto.Descricao = produtoAtualizado.Descricao;
            produto.Preco = produtoAtualizado.Preco;
            produto.CategoriaId = produtoAtualizado.CategoriaId;
            produto.ImagemUrl = produtoAtualizado.ImagemUrl;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return NotFound();

            if (produto.VendedorId != userId)
                return Forbid();

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
