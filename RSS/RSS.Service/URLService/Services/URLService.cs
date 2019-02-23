using BenchmarkDotNet.Attributes;
using CodeHollow.FeedReader;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RSS.DAL.Context;
using RSS.Data.Model;
using RSS.Service.JSON;
using RSS.Service.RssReader.Interface;
using RSS.Service.RSSservice.Interfaces;
using RSS.Service.URLService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RSS.Service.URLService.Services
{
    public class URLService : IURLService
    {
        private readonly IRssFeedService sydicationRepository;
        private readonly IRSSservice rssRepository;
        private readonly ApplicationDbContext context;


        public URLService(ApplicationDbContext context, IRssFeedService sydicationRepository, IRSSservice rssRepository)
         
        {
            this.context = context;
            this.sydicationRepository = sydicationRepository;
            this.rssRepository = rssRepository;
        }

        public async Task <bool> CheckExistRSSFeedByString(string urlLink)
        {

            var isExist =await context.URLS.AnyAsync(p => p.Link == urlLink);
            return isExist;

        }
        public async Task<List<RssFeed>> DajKanaly(int id)
        {

            var kanaly = await context.RSSFeeds.Where(p => p.URLID == id).AsNoTracking().ToListAsync();
            return kanaly;
        }

        public async Task<string> AddURLToDatabase(string urlLink)
        {
            bool status = false;
            string validateMessage = "";
            if (await CheckExistRSSFeedByString(urlLink) == false)
            {
                try
                {
                    //kanały rss dla danego linku
                    var feed = sydicationRepository.GetFeed(urlLink);
                    //Dane dla danego kanału
                    var feedURL = GetFeedURL(feed, urlLink);
                    //dodawanie kanału do kontekstu
                    await Insert(feedURL);
                    //rss dla danego kanału
                    var feedRSSlist = rssRepository.FeedListForURL(feed, feedURL);
                    //dodanie listy rss do kontekstu
                    await rssRepository.Insert(feedRSSlist, context);
                    //zapisanie zmian do bazy
                    await SaveChanges();
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                    validateMessage = "Podano zły format linku";
                }
            }
            else
            {
                status = false;
                validateMessage = "Już zasubskrybowano kanał";
            }

            var jsonObjData = new JSONData()
            {
                Status = status,
                ValidateMessage = validateMessage
            };

            string json = JsonConvert.SerializeObject(jsonObjData, Formatting.Indented);
            return json;

        }

        public async Task<URL> GetLinkByString(string RSSURL)
        {
            var link = await context.URLS.Where(p => p.Link == RSSURL).AsNoTracking().FirstOrDefaultAsync();
            return link;
        }

        public async Task<URL> GetURLById(int id)
        {
            var url = await context.URLS.Where(c => c.ID == id).AsNoTracking().FirstOrDefaultAsync();
            return url;
        }

        public async Task<URL> GetURLByIdWithIncludeRss(int id)
        {

            var url = await context.URLS.Where(c => c.ID == id).Include(p => p.RSSFeeds).AsNoTracking().FirstOrDefaultAsync();
            return url;

        }

        public async Task Insert(URL url)
        {
            await context.URLS.AddAsync(url);


        }
        public void Delete(URL url)
        {
            context.URLS.Remove(url);

        }
        public async Task SaveChanges()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    // Update the values of the entity that failed to save from the store
                    ex.Entries.Single().Reload();
                }

            } while (saveFailed);
        }
      
        public URL GetFeedURL(Feed feed, string urlLink)
        {
            var feedURL = new URL()
            {
                Link = urlLink,
                Title = feed.Title,
                Description = feed.Description
            };
            return feedURL;
        }



        public async Task<string> DeleteURLfromDatabase(int id)
        {
            bool status = false;
            string validateMessage = "";
            try
            {
                var listOfRssToDelete = await GetURLByIdWithIncludeRss(id);
                if (listOfRssToDelete != null)
                {
                    Delete(listOfRssToDelete);
                    await SaveChanges();
                    status = true;
                }
                else
                {
                    validateMessage = "Nie można usunąć listy";
                }

            }
            catch (Exception)
            {
                validateMessage = "Nie można usunąć listy";
                status = false;
            }
            var jsonObjData = new JSONData()
            {
                Status = status,
                ValidateMessage = validateMessage
            };

            string json = JsonConvert.SerializeObject(jsonObjData, Formatting.Indented);
            return json;
        }
    }
}


