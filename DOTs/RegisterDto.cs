using System.ComponentModel.DataAnnotations;

namespace SuperheroAPI.DOTs
{
    public class RegisterDto
    {
        [Required]
        public String? Username { get; set; }
        [Required]
        [EmailAddress]
        public String? EmailAddress { get; set; }

        [Required]

        public string? Password { get; set; }
       }
}
