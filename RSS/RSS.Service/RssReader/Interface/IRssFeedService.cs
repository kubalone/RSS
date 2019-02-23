using CodeHollow.FeedReader;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSS.Service.RssReader.Interface
{
    public interface IRssFeedService
    {
        Feed GetFeed(string urlLink);
    }
}
