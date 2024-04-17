using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace FA.JustBlog.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;
        private ICategoryRepository _categoryRepository;
        private ICommentRepository _commentRepository;
        private IAuthenticationRepository _authenticationRepository;

        public UnitOfWork(JustBlogContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
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

        public IAuthenticationRepository AuthenticationRepository
        {
            get
            {
                return _authenticationRepository ??= new AuthenticationRepository(_context, _userManager, _roleManager, _configuration);
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
