using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using CodeHollow.FeedReader;
using Ninject;
using Ninject.Modules;
using RSS.DAL.Context;
using RSS.Data.Model;
using RSS.Service.RssReader.Interface;
using RSS.Service.RssReader.Service;
using RSS.Service.RSSservice.Interfaces;
using RSS.Service.RSSservice.Services;
using RSS.Service.URLService.Interfaces;
using RSS.Service.URLService.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    [MemoryDiagnoser]
    //[ClrJob, CoreJob]
    //[SimpleJob(RunStrategy.ColdStart, targetCount: 5), SimpleJob(RunStrategy.ColdStart, targetCount: 5)]
    //[MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class BenchmarkTest
    {
        //private ApplicationDbContext context;
        public BenchmarkTest()
        {

            kernel.Bind<IURLService>().To<URLService>();
            kernel.Bind<IRssFeedService>().To<RssFeedService>();
            kernel.Bind<IRSSservice>().To<RSSservice>();
            //this.context = context;

        }
         StandardKernel kernel = new StandardKernel();

        //public List<RssFeed> DajKanaly()
        //{

        //    var kanaly =  context.RSSFeeds.Where(p => p.URLID == 4).ToList();
        //    return kanaly;
        //}



        [Benchmark]
        public void AddToDatabase()
        {

            IURLService form = kernel.Get<IURLService>();
            var kanaly = form.DajKanaly(4);
           
           


        }
        //[Benchmark(OperationsPerInvoke = 10_000)]

    }

    class Program
    {
       
        static void Main(string[] args)
        {
            StandardKernel kernel = new StandardKernel();

            kernel.Bind<IURLService>().To<URLService>();
            kernel.Bind<IRssFeedService>().To<RssFeedService>();
            kernel.Bind<IRSSservice>().To<RSSservice>();
            IURLService form = kernel.Get<IURLService>();
            var kanaly = form.DajKanaly(4);
            Console.WriteLine(kanaly);
            var summary = BenchmarkRunner.Run<BenchmarkTest>();

            Console.ReadKey();
        }
    }
}
