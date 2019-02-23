using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RSS.Web.Data;
using RSS.Web.Models;

namespace RSS.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;
        public CoursesController(SchoolContext context)
        {
            _context = context;
        }
        // GET: Courses
        public async Task<IActionResult>Index()
        {
            var courses = _context.Courses.Include(p => p.Department).AsNoTracking();
            return View(await courses.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var course = await _context.Courses
                .Include(p => p.Department)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.CourseID == id);
            if (course==null)
            {
                return NotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create([Bind("CourseID", "Title", "Credits", "DepartmentID")]Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(course);
        }

        // POST: Courses/Create

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var course =await _context.Courses.AsNoTracking().SingleOrDefaultAsync(p => p.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }
            PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(course);
       
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("CourseID", "Title", "Credits", "DepartmentID")] Course course)
        {
        
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Courses.Update(course);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
               

                
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists, " +
                "see your system administrator.");
            }
           
            
          PopulateDepartmentsDropDownList(course.DepartmentID);
          return View(course);
    }

        private void PopulateDepartmentsDropDownList(object selectedDepartmet=null)
        {
            var department = from d in _context.Departments
                             orderby d.Name
                             select d;
            ViewBag.DepartmentID = new SelectList(department.AsNoTracking(), "DepartmentID", "Name", selectedDepartmet);
        }

        // GET: Courses/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var course = await _context.Courses
                .Include(p => p.Department)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.CourseID == id);
            if (course==null)
            {
                return NotFound();
            }
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses
              //.Include(p => p.Department)
              .AsNoTracking()
              .SingleOrDefaultAsync(p => p.CourseID == id);
            if (course == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
               
                    //_context.Entry(course).State = EntityState.Modified;
                    _context.Courses.Remove(course);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
               



            }
            catch (DbUpdateException /* ex */)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }


           
            //return View(course);
        }


    }
}