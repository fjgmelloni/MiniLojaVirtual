using System.ComponentModel.DataAnnotations;

namespace MiniLojaVirtual.Core
{
    public class Vendedor
    {
        public string Id { get; set; }

        [MaxLength(255)]
        public string Nome { get; set; }

        [MaxLength(255)]
        public string Telefone { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
