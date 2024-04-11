using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FA.JustBlog.Core.Data
{
    public class JustBlogContextFactory : IDesignTimeDbContextFactory<JustBlogContext>
    {
        public JustBlogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<JustBlogContext>();
            optionsBuilder.UseSqlServer("Server=LAPHAO\\MSSQLSERVER04;Database=JustBlogDb;Trusted_Connection=True;TrustServerCertificate=True");
            return new JustBlogContext(optionsBuilder.Options);
        }
    }
}
