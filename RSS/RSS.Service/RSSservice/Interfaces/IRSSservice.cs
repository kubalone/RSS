using CodeHollow.FeedReader;
using RSS.DAL.Context;
using RSS.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSS.Service.RSSservice.Interfaces
{
    public interface IRSSservice
    {
        IEnumerable<RssFeed> FeedListForURL(Feed feed, URL feedURL);
        Task Insert(IEnumerable<RssFeed> rssFeeds, ApplicationDbContext context);
    }
}
