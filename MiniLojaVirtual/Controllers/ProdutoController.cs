using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniLojaVirtual.Core;
using MiniLojaVirtual.Data;

namespace MiniLojaVirtual.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _environment;

        public ProdutoController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _environment = environment;
        }

        private async Task EnsureVendedorExisteAsync(string userId)
        {
            if (!_context.Vendedores.Any(v => v.Id == userId))
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                if (user != null)
                {
                    var vendedor = new Vendedor
                    {
                        Id = userId,
                        Nome = user.UserName ?? "Usuário",
                        Email = user.Email,
                        Telefone = ""
                    };
                    _context.Vendedores.Add(vendedor);
                    await _context.SaveChangesAsync(); // salva antes de usar como FK
                }
            }
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var produtos = await _context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.VendedorId == userId)
                .ToListAsync();
            return View(produtos);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categorias = new SelectList(await _context.Categorias.ToListAsync(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto, IFormFile imagem)
        {
            var userId = _userManager.GetUserId(User);

            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = new SelectList(await _context.Categorias.ToListAsync(), "Id", "Nome");
                return View(produto);
            }

            if (imagem != null && imagem.Length > 0)
            {
                var uploadDir = Path.Combine(_environment.WebRootPath, "imagens");
                Directory.CreateDirectory(uploadDir);
                var filePath = Path.Combine(uploadDir, imagem.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imagem.CopyToAsync(fileStream);
                }

                produto.ImagemUrl = "/imagens/" + imagem.FileName;
            }

            await EnsureVendedorExisteAsync(userId);

            produto.VendedorId = userId;

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var userId = _userManager.GetUserId(User);
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null || produto.VendedorId != userId)
                return NotFound();

            ViewBag.Categorias = new SelectList(await _context.Categorias.ToListAsync(), "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto, IFormFile imagem)
        {
            var userId = _userManager.GetUserId(User);
            if (id != produto.Id || produto.VendedorId != userId)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = new SelectList(await _context.Categorias.ToListAsync(), "Id", "Nome", produto.CategoriaId);
                return View(produto);
            }

            if (imagem != null && imagem.Length > 0)
            {
                var uploadDir = Path.Combine(_environment.WebRootPath, "imagens");
                Directory.CreateDirectory(uploadDir);
                var filePath = Path.Combine(uploadDir, imagem.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imagem.CopyToAsync(fileStream);
                }

                produto.ImagemUrl = "/imagens/" + imagem.FileName;
            }

            _context.Update(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = _userManager.GetUserId(User);
            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id && p.VendedorId == userId);

            if (produto == null)
                return NotFound();

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
