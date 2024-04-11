using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly JustBlogContext _context;
        public CommentRepository(JustBlogContext context) : base(context)
        {
            _context = context;
        }

        public new Comment Find(int id)
        {
            return _context.Comments.Include(c => c.Post).FirstOrDefault(c => c.Id == id);
        }

        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var comment = new Comment
            {
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody,
                CommentedTime = DateTime.Now,
                PostId = postId
            };
            _context.Comments.Add(comment);
        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            return _context.Comments.Where(c => c.PostId == postId).ToList();
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            return _context.Comments.Include(c => c.Post).Where(c => c.PostId == post.Id).ToList();
        }
    }
}
