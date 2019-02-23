using CodeHollow.FeedReader;
using RSS.DAL.Context;
using RSS.Data.Model;
using RSS.Service.RSSservice.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RSS.Service.RSSservice.Services
{
    public class RSSservice : IRSSservice
    {

        public IEnumerable<RssFeed> FeedListForURL(Feed feed, URL feedURL)
        {
            var feedListForURL = new List<RssFeed>();
            foreach (var item in feed.Items)
            {
                feedListForURL.Add(new RssFeed()
                {
                    URLID = feedURL.ID,
                    Title = item.Title,
                    Description = Regex.Replace(item.Description, @"<[^>]*>|&quot;", String.Empty),
                    PubDate = item.PublishingDate,
                    IsRead = false,
                });
            }
            return feedListForURL;
        }

        public async Task Insert(IEnumerable<RssFeed> rssFeeds, ApplicationDbContext context)
        {
            await context.RSSFeeds.AddRangeAsync(rssFeeds);
        }

      


    }
}


