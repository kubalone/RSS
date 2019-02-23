using CodeHollow.FeedReader;
using RSS.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RSS.Service.URLService.Interfaces
{
    public interface IURLService
    {
        //zwracanie obiektu url po id - szybkie ladowanie
        Task<URL> GetURLByIdWithIncludeRss(int id);
        //zwracanie obiektu url po id - lazy loading
        Task<URL> GetURLById(int id);
        //Metoda zwracająca obiekt URL, gotowy do zapisania do bazy danych
        URL GetFeedURL(Feed feed, string urlLink);
        //meotda zwracająca obiekt url wg podanego stringa
        Task<URL> GetLinkByString(string RSSURL);
        //dodawanie URL do bazy
        Task<string> AddURLToDatabase(string urlLink);
        //usuwanie z bazy
         Task<string> DeleteURLfromDatabase(int id);
        //zapisywanie do bazy
        Task Insert(URL url);
        //usuwanie kanału
        void Delete(URL url);
        //sprawdz czy kanal o określonym url zawiera się w bazie
        Task<bool> CheckExistRSSFeedByString(string urlLink);


        Task<List<RssFeed>> DajKanaly(int id);
    }
}
