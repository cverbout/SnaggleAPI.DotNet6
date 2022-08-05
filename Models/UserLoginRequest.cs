using System.ComponentModel.DataAnnotations;

namespace SnaggleAPI.Models
{
    public class UserLoginRequest
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]

        public string Password { get; set; } = string.Empty;

    }
}
