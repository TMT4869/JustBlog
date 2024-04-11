using System.Text;
using System.Text.RegularExpressions;

namespace FA.JustBlog.Core.Utility
{
    public static class UrlSlugGenerate
    {
        public static string GenerateSlug(string input)
        {
            string slug = RemoveAccent(input).ToLower().Trim();
            // Remove characters that are not letters, numbers, hyphens, or underscores
            slug = Regex.Replace(slug, @"[^a-z0-9\-_\s]", "");
            // Replace spaces and hyphens with a single hyphen
            slug = Regex.Replace(slug, @"\s+", "-");
            // Remove consecutive hyphens
            slug = Regex.Replace(slug, @"\-{2,}", "-");
            // Remove leading and trailing hyphens
            slug = slug.Trim('-');
            return slug;
        }

        private static string RemoveAccent(string txt)
        {
            byte[] bytes = Encoding.GetEncoding(0).GetBytes(txt);
            return Encoding.ASCII.GetString(bytes);
        }
    }
}
