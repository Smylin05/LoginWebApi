using System.ComponentModel.DataAnnotations;

namespace LoginWebApi.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public int IsActive { get; set; } = 1;

        public DateTime CreatedOn { get; set; } =DateTime.Now;


    }
}
