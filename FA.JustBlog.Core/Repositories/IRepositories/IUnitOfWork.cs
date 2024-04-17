namespace FA.JustBlog.Core.Repositories.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ITagRepository TagRepository { get; }
        ICommentRepository CommentRepository { get; }
        IAuthenticationRepository AuthenticationRepository { get; }
        int Save();
    }
}
