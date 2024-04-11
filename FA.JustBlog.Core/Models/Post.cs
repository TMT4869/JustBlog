using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    [Index(nameof(UrlSlug), IsUnique = true)]
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(750)]
        [Column("Short Description")]
        public string ShortDescription { get; set; }

        [Column("Post Content")]
        public string PostContent { get; set; }

        [Required]
        [StringLength(255)]
        public string UrlSlug { get; set; }
        public bool Published { get; set; }

        [Column("Posted On")]
        [Required]
        public DateTime PostedOn { get; set; }
        [Required]
        public DateTime Modified { get; set; }

        [Required]
        public int ViewCount { get; set; }
        [Required]
        public int RateCount { get; set; }
        [Required]
        public int TotalRate { get; set; }

        [NotMapped]
        public decimal Rate
        {
            get
            {
                if (RateCount == 0)
                {
                    return 0;
                }
                return (decimal)TotalRate / RateCount;
            }
            set { }
        }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public IList<PostTagMap>? PostTagMaps { get; set; }
        public IList<Comment>? Comments { get; set; }
    }
}
