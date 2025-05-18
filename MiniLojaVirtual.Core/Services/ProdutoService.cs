using MiniLojaVirtual.Core.Models;
using System;

namespace MiniLojaVirtual.Core.Services
{
    public class ProdutoService
    {
        public void ValidarProduto(Produto produto)
        {
            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new Exception("Nome do produto é obrigatório.");
            if (produto.Preco <= 0)
                throw new Exception("Preço deve ser maior que zero.");
        }
    }
}
