using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniLojaVirtual.Data;
using MiniLojaVirtual.DTOs.Produto;

namespace MiniLojaVirtual.Controllers.Api
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
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            var produtos = await _context.Produtos
                .Include(p => p.Categoria)
                .Select(p => new ProdutoDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    Preco = p.Preco,
                    ImagemUrl = p.ImagemUrl,
                    CategoriaNome = p.Categoria.Nome
                })
                .ToListAsync();

            return Ok(produtos);
        }

        [HttpGet("categoria/{categoriaId}")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetByCategoria(int categoriaId)
        {
            var produtos = await _context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.CategoriaId == categoriaId)
                .Select(p => new ProdutoDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    Preco = p.Preco,
                    ImagemUrl = p.ImagemUrl,
                    CategoriaNome = p.Categoria.Nome
                })
                .ToListAsync();

            return Ok(produtos);
        }
    }
}
