using System.ComponentModel.DataAnnotations;

namespace SuperheroAPI.DOTs
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
