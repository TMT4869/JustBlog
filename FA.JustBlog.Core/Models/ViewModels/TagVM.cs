using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models.ViewModels
{
    public class TagVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tag name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url slug is required.")]
        [StringLength(255)]
        [Display(Name = "Url Slug")]
        public string UrlSlug { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1024)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Count is required.")]
        public int Count { get; set; }
    }
}
