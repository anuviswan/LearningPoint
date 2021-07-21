using System.ComponentModel.DataAnnotations;

namespace JwtExample.Models
{
    public record UserModel
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
