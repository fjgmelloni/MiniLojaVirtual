using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MiniLojaVirtual.Core
{
    public class Categoria
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Nome { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }

        [ValidateNever]
        public ICollection<Produto> Produtos { get; set; }
    }
}
