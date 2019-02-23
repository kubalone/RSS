using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSS.Web.Data;
using RSS.Web.Models.SchoolViewModels;

namespace RSS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext _context;
        public HomeController(SchoolContext context)
        {
            _context = context;
        }

        public async Task <IActionResult> About()
        {
            var data = from student in _context.Students
                       group student by student.EnrollmentDate into dateGroup
                       select new EnrollmentDateGroup()
                       {
                           EnrollmentDate = dateGroup.Key,
                           StudentCount = dateGroup.Count()
                       };
            return View(await data.AsNoTracking().ToListAsync());
        }
    }
}