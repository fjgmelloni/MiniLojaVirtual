﻿namespace MiniLojaVirtual.DTOs.Produto
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public string CategoriaNome { get; set; }
    }
}
