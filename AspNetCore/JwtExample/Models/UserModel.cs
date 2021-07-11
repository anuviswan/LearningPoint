using System.ComponentModel.DataAnnotations;

namespace JwtExample.Models
{
    public record UserModel([property:Required]string UserName,[property:Required]string Password)
    {
    }
}
