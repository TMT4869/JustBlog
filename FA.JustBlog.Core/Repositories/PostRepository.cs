using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly JustBlogContext _context;
        public PostRepository(JustBlogContext context) : base(context)
        {
            _context = context;
        }

        public new Post Find(int id)
        {
            return _context.Posts.Include(p => p.Category).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).FirstOrDefault(p => p.Id == id);
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            return _context.Posts.FirstOrDefault(p => p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug == urlSlug);
        }

        public IList<Post> GetPublishedPosts()
        {
            return _context.Posts.Include(p => p.Category).Where(p => p.Published).ToList();
        }

        public IList<Post> GetUnpublishedPosts()
        {
            return _context.Posts.Include(p => p.Category).Where(p => !p.Published).ToList();
        }

        public IList<Post> GetLatestPost(int size)
        {
            return _context.Posts.OrderByDescending(p => p.PostedOn).Take(size).ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return _context.Posts.Where(p => p.PostedOn.Month == monthYear.Month && p.PostedOn.Year == monthYear.Year).ToList();
        }

        public int CountPostsForCategory(string category)
        {
            return _context.Posts.Count(p => p.Category.Name == category);
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            return _context.Posts.Include(p => p.Category).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).Where(p => p.Category.Name == category).ToList();
        }

        public int CountPostsForTag(string tag)
        {
            return _context.PostTagMaps.Count(ptm => ptm.Tag.Name == tag);
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            return _context.Posts.Include(p => p.Category).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).Where(p => p.PostTagMaps.Any(ptm => ptm.Tag.Name == tag)).ToList();
        }

        public IList<Post> GetMostViewedPost(int size)
        {
            return _context.Posts.OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }

        public IList<Post> GetHighestPosts(int size)
        {
            return _context.Posts.OrderByDescending(p => p.Rate).Take(size).ToList();
        }
    }
}
