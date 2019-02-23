using CodeHollow.FeedReader;
using RSS.Service.RssReader.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSS.Service.RssReader.Service
{
    public class RssFeedService : IRssFeedService
    {
        public Feed GetFeed(string urlLink)
        {
#pragma warning disable CS0618 // Typ lub składowa jest przestarzała
            Feed feed =  FeedReader.Read(urlLink);
#pragma warning restore CS0618 // Typ lub składowa jest przestarzała
            return feed;
        }
    }
}
