using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MiniLojaVirtual.Core.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(255)]
        public string Descricao { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O estoque deve ser zero ou maior.")]
        public int Estoque { get; set; }

        [ValidateNever]
        public string ImagemUrl { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [ValidateNever]
        public Categoria Categoria { get; set; }

        [ValidateNever]
        public string VendedorId { get; set; }
    }
}
