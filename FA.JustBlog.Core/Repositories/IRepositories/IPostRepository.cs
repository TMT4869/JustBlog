using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories.IRepositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Post FindPost(int year, int month, string urlSlug);
        IList<Post> GetPublishedPosts();
        IList<Post> GetUnpublishedPosts();
        IList<Post> GetLatestPost(int size);
        IList<Post> GetPostsByMonth(DateTime monthYear);
        int CountPostsForCategory(string category);
        IList<Post> GetPostsByCategory(string category);
        int CountPostsForTag(string tag);
        IList<Post> GetPostsByTag(string tag);
        IList<Post> GetMostViewedPost(int size);
        IList<Post> GetHighestPosts(int size);
    }
}
