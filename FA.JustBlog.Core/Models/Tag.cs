using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
    [Index(nameof(UrlSlug), IsUnique = true)]
    public class Tag
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

        [Required]
        public int Count { get; set; }
        public IList<PostTagMap>? PostTagMaps { get; set; }
    }
}
