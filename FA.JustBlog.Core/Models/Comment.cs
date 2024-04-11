using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(400)]
        public string CommentHeader { get; set; }

        [Required]
        [StringLength(4000)]
        public string CommentText { get; set; }

        [Required]
        public DateTime CommentedTime { get; set; }

        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}
