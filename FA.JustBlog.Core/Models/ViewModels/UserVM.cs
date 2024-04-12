using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models.ViewModels
{
    public class UserVM
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        public int? Age { get; set; }

        [MaxLength(750, ErrorMessage = "About must be less than 751 characters")]
        public string? About { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public List<string>? Roles { get; set; }
    }
}
