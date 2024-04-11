using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Repositories.IRepositories;

namespace FA.JustBlog.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogContext _context;
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;
        private ICategoryRepository _categoryRepository;
        private ICommentRepository _commentRepository;

        public UnitOfWork(JustBlogContext context)
        {
            _context = context;
        }

        public IPostRepository PostRepository
        {
            get
            {
                return _postRepository ??= new PostRepository(_context);
            }
        }

        public ITagRepository TagRepository
        {
            get
            {
                return _tagRepository ??= new TagRepository(_context);
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository ??= new CategoryRepository(_context);
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                return _commentRepository ??= new CommentRepository(_context);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
