using System.ComponentModel.DataAnnotations;

namespace api.DTO.Account
{
    public class NewUserDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string Token { get; set; }
    };
}