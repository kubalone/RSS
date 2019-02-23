
using RSS.Service.URLService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RPS.Controllers
{

  
    public class HomeController : Controller
    {
        private readonly IURLService iURLService;
        public HomeController(IURLService iURLService)
        {
            this.iURLService = iURLService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public async Task<ActionResult> TestRPS()
        {
            var lista = await iURLService.DajKanaly(4);
            return View(lista);
        }
    }
}