using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
    [Index(nameof(UrlSlug), IsUnique = true)]
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string UrlSlug { get; set; }

        [Required]
        [StringLength(1024)]
        public string Description { get; set; }

        public IList<Post>? Posts { get; set; }
    }
}
