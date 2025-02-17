﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace FA.JustBlog.CustomHelper
{
    public static class CustomHelper
    {
        public static TagBuilder TagLink(this IHtmlHelper helper, string url, string linkText)
        {
            var a = new TagBuilder("a");
            a.Attributes.Add("href", url);
            a.Attributes.Add("class", "mx-2 p-1 text-white bg-black");

            a.Attributes.Add("style", "text-decoration: underline;");

            a.InnerHtml.Append(linkText);
            return a;
        }

        public static TagBuilder CategoryLink(this IHtmlHelper helper, string url, string linkText)
        {
            var a = new TagBuilder("a");
            a.Attributes.Add("href", url);

            a.Attributes.Add("style", "text-decoration: underline");
            a.InnerHtml.Append(linkText);
            return a;
        }

        public static string ToFriendlyDate(this DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;

            if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                return $"{timeSpan.Minutes} minutes ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                return $"today at {dateTime:hh:mm tt}";
            }
            else if (timeSpan <= TimeSpan.FromDays(2))
            {
                return $"yesterday at {dateTime:hh:mm tt}";
            }
            else
            {
                return dateTime.ToString();
            }
        }
    }
}
