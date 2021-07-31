using System.ComponentModel.DataAnnotations;

namespace JwtExample.Models
{
    public record UserModel([Required]string UserName, [Required]string Password);
    
}
