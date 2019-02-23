using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSS.Web.Models
{
    public class CourseAsignment
    {
        public int CourseID { get; set; }
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
