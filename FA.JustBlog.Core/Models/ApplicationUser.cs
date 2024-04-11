using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        [MaxLength(750)]
        public string? About { get; set; }
    }
}
