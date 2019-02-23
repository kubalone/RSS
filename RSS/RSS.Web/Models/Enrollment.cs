using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RSS.Web.Models
{
    public enum Grade
    {
        A,B,C,D,E,F
    }
    public class Enrollment
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }
        public Student Studnet { get; set; }
        public Course Course { get; set; }
    }
}
