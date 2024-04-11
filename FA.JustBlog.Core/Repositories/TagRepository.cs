using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.IRepositories;

namespace FA.JustBlog.Core.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        private readonly JustBlogContext _context;
        public TagRepository(JustBlogContext context) : base(context)
        {
            _context = context;
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return _context.Tags.FirstOrDefault(t => t.UrlSlug == urlSlug);
        }
    }
}
