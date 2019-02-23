using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSS.Web.Data;
using RSS.Web.Models;

namespace RSS.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index(string sortOrder, string searchString, int page = 1)
        {
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var students = from s in _context.Students select s;
            if (searchString!=null)
            {
                students = students.Where(s => s.LastName.Contains(searchString)
                  || s.FirstMidName.Contains(searchString));
            }
            
            switch (sortOrder)
            {
                case "name_desc":
                    students=students.OrderByDescending(p => p.LastName);
                    break;
                case "Date":
                    students=students.OrderBy(p => p.EnrollmentDate);
                    break;
                case "date_desc":
                    students=students.OrderByDescending(p => p.EnrollmentDate);
                    break;
                default:
                    students=students.OrderBy(p => p.LastName);
                    break;
            }
            return View(await students.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (student==null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentDate,FirstMidName,LastName")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {

                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");
            }
            return View(student);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id==null)
            {
                NotFound();
            }
            var student = await _context.Students.SingleOrDefaultAsync(p => p.ID == id);
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ID,EnrollmentDate,FirstMidName,LastName")] Student student)
        {
            if (id!=student.ID)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {

                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
                }
            }
            return View(student);
        }
        [HttpGet]
        public async Task<IActionResult>Delete(int?id, bool? saveChangesError = false)
        {
            if (id==null)
            {
                return NotFound();
            }
            var student = await _context.Students.AsNoTracking().SingleOrDefaultAsync(p => p.ID == id);
            if (student==null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                "Delete failed. Try again, and if the problem persists " +
                "see your system administrator.";
            }
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult>Delete(int id)
        {
            var student = await _context.Students.AsNoTracking().SingleOrDefaultAsync(p => p.ID == id);
            if (student==null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {

                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}