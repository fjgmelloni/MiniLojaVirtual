using System.ComponentModel.DataAnnotations;

namespace MiniLojaVirtual.DTOs.Login
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
