using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories.IRepositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        Tag GetTagByUrlSlug(string urlSlug);
    }
}
