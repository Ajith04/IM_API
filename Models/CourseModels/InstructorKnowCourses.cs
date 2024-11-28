using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITEC_API.Models.CourseModels
{
    public class InstructorKnowCourses
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey ("Instructor")]
        public int InstructorId { get; set; }

        [ForeignKey ("CourseName")]
        public int CourseNameId { get; set; }

        public Instructor Instructor { get; set; }
        public CourseName CourseName { get; set; }
    }
}
