using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models.ViewModels
{
    public class PostVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(255, ErrorMessage = "Title must be shorter than 256 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Short description is required.")]
        [StringLength(750, ErrorMessage = "Description must be shorter than 751 characters")]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Post content is required.")]
        [Display(Name = "Post Content")]
        public string PostContent { get; set; }

        [Required(ErrorMessage = "Url slug is required.")]
        [StringLength(255, ErrorMessage = "Url slug must be shorter than 256 characters")]
        [Display(Name = "Url Slug")]
        public string UrlSlug { get; set; }
        public bool Published { get; set; }

        [Required(ErrorMessage = "Posted on date is required.")]
        [Display(Name = "Posted On")]
        public DateTime PostedOn { get; set; }

        [Required(ErrorMessage = "Modified date is required.")]
        [Display(Name = "Modified")]
        public DateTime Modified { get; set; }

        [Required(ErrorMessage = "View count is required.")]
        [Display(Name = "View Count")]
        public int ViewCount { get; set; }

        [Required(ErrorMessage = "Rate count is required.")]
        [Display(Name = "Rate Count")]
        public int RateCount { get; set; }

        [Required(ErrorMessage = "Total rate is required.")]
        [Display(Name = "Total Rate")]
        public int TotalRate { get; set; }

        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public string? CategoryName { get; set; }

        public List<PostTagMap>? PostTagMaps { get; set; }
    }
}
