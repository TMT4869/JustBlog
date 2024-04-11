using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models.ViewModels
{
    public class CommentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Comment name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Comment header is required.")]
        [StringLength(400)]
        [Display(Name = "Comment Header")]
        public string CommentHeader { get; set; }

        [Required(ErrorMessage = "Comment text is required.")]
        [StringLength(4000)]
        [Display(Name = "Comment Text")]
        public string CommentText { get; set; }

        [Required(ErrorMessage = "Commented time is required.")]
        [Display(Name = "Commented Time")]
        public DateTime CommentedTime { get; set; }

        [Required(ErrorMessage = "Post is required.")]
        public int PostId { get; set; }

        [Display(Name = "Post")]
        public string? PostTitle { get; set; }
    }
}
