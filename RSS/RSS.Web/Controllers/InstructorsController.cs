using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSS.Web.Data;
using Microsoft.EntityFrameworkCore;
using RSS.Web.Models.SchoolViewModels;
using RSS.Web.Models;

namespace RSS.Web.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly SchoolContext _context;
        public InstructorsController(SchoolContext context)
        {
            _context = context;
        }
        // GET: Instructors
        public async Task<IActionResult> Index(int? id, int? courseId)
        {
            var viewModel = new InstructorIndexData();
            viewModel.Instructors =await _context.Instructors
                .Include(p => p.OfficeAssignment)
                .Include(p => p.CourseAsignments)
                    .ThenInclude(p => p.Course)
                        .ThenInclude(p => p.Enrollments)
                            .ThenInclude(p => p.Studnet)
                .Include(p=>p.CourseAsignments)
                    .ThenInclude(p=>p.Course)
                        .ThenInclude(p=>p.Department)
                    .AsNoTracking()
                    .OrderBy(p => p.LastName)
                    .ToListAsync();

            if (id!=null)
            {
                ViewData["InstructorID"] = id.Value;
                Instructor instructor = viewModel.Instructors.Where(p => p.ID == id).Single();
                viewModel.Courses = instructor.CourseAsignments.Select(p => p.Course);
            }
            if (courseId!=null)
            {
                ViewData["CourseID"] = courseId.Value;
               
                Course course= viewModel.Courses.Where(p => p.CourseID == courseId).Single();
                viewModel.Enrollments = course.Enrollments;
            }
            return View(viewModel);
        }

        // GET: Instructors/Details/5
        public IActionResult Details(int id)
        {
          
            return View();
        }

        // GET: Instructors/Create
        public ActionResult Create()
        {
            var instructor = new Instructor();
            instructor.CourseAsignments = new List<CourseAsignment>();
            PopulateAssignedCourseData(instructor);
            return View();
        }

        // POST: Instructors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstMidName,HireDate,LastName,OfficeAssignment")]Instructor instructor, string[] selectedCourses)
        {
            if (selectedCourses!=null)
            {
                instructor.CourseAsignments = new List<CourseAsignment>();
                foreach (var item in selectedCourses)
                {
                    var courseToAdd = new CourseAsignment() { CourseID = int.Parse(item), InstructorID = instructor.ID };
                    instructor.CourseAsignments.Add(courseToAdd);
                }
                
            }
            if (ModelState.IsValid)
            {
                _context.Instructors.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateAssignedCourseData(instructor);
            return View(instructor);
        }

        // GET: Instructors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();

            }
            var instructor = await _context.Instructors
                .Include(p => p.OfficeAssignment)
                .Include(p=>p.CourseAsignments)
                    .ThenInclude(p=>p.Course)
                .SingleOrDefaultAsync(p => p.ID == id);
            PopulateAssignedCourseData(instructor);
            if (instructor==null)
            {
                return NotFound();
            }
            
            return View(instructor);
        }

        private void PopulateAssignedCourseData(Instructor instructor)
        {
            var allCourses = _context.Courses;
            var instructorCourses = new HashSet<int>(instructor.CourseAsignments.Select(p => p.CourseID));
            var viewModel = new List<AssignedCourseData>();
            foreach (var item in allCourses)
            {
                viewModel.Add(new AssignedCourseData()
                {
                    CourseID = item.CourseID,
                    Title = item.Title,
                    Assigned = instructorCourses.Contains(item.CourseID)
                });
            }
            ViewData["Courses"] = viewModel;
        }

        // POST: Instructors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Instructor instructor,string[] selectedCourses)
        {
            var original = await _context.Instructors
                .Include(p => p.OfficeAssignment)
                .Include(p=>p.CourseAsignments)
                    .ThenInclude(p=>p.Course)
                    .SingleOrDefaultAsync(p => p.ID == instructor.ID);
            if (original == null)
            {
                return NotFound();
            }
            try
            {
                 
                    if (String.IsNullOrEmpty(instructor.OfficeAssignment?.Location))
                    {
                        original.OfficeAssignment = null;
                    }
                
                  
                    original.ID = instructor.ID;
                    original.FirstMidName = instructor.FirstMidName;
                    original.LastName = instructor.LastName;
                if (original.OfficeAssignment==null)
                {
                  
                    original.OfficeAssignment = new OfficeAssignment()
                    {
                        Location = instructor.OfficeAssignment.Location
                    };
                  
                }
                else
                {
                    original.OfficeAssignment.Location = instructor.OfficeAssignment.Location;
                }
          
                original.HireDate = instructor.HireDate;
                     UpdateInstructorCourses(selectedCourses, original);

                await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
             

          
               
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists, " +
                "see your system administrator.");
            }
            //UpdateInstructorCourses(selectedCourses, original);
            PopulateAssignedCourseData(instructor);
            return View(instructor);
        }

        private void UpdateInstructorCourses(string[] selectedCourses, Instructor instructorToUpdate)
        {
            if (selectedCourses==null)
            {
                instructorToUpdate.CourseAsignments = new List<CourseAsignment>();
                return;
            }
            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>(instructorToUpdate.CourseAsignments.Select(p => p.Course.CourseID));
            foreach (var course in _context.Courses)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!instructorCourses.Contains(course.CourseID))
                    {
                        instructorToUpdate.CourseAsignments.Add(new CourseAsignment()
                        {
                            CourseID=course.CourseID,
                            InstructorID=instructorToUpdate.ID
                        });
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.CourseID))
                    {
                        CourseAsignment courseToRemove = instructorToUpdate.CourseAsignments.SingleOrDefault(p => p.CourseID == course.CourseID);
                        _context.CourseAssignments.Remove(courseToRemove);
                    }
                }
            }

        }

        // GET: Instructors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var instructor=await _context.Instructors
                 .Include(p => p.OfficeAssignment)
                .Include(p => p.CourseAsignments)
                    .ThenInclude(p => p.Course)
                    .SingleOrDefaultAsync(p => p.ID == id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var instructor = await _context.Instructors
                    .SingleOrDefaultAsync(p => p.ID == id);

            var departments = await _context.Departments.Where(p => p.InstructorID == id).ToListAsync();
            departments.ForEach(d => d.InstructorID =null);
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            
   
                return RedirectToAction(nameof(Index));
        
        }
    }
}