using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
