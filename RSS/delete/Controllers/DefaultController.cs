using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSS.Service.RssReader.Interface;
using RSS.Service.RSSservice.Interfaces;
using RSS.Service.URLService.Interfaces;

namespace delete.Controllers
{
    public class DefaultController : Controller
    {
        private IURLService service;
        private IRSSservice rSSservice;
        private IRssFeedService rssFeedService;
        public DefaultController(IURLService service, IRSSservice rSSservice, IRssFeedService rssFeedService)
        {
            this.service = service;
            this.rSSservice = rSSservice;
            this.rssFeedService = rssFeedService;

        }
        
        public async Task<IActionResult> Index()
        {
            var result =  await service.DajKanaly(4);
            return View(result);
        }
    }
}