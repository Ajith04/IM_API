using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITEC_API.Models.CourseModels
{
    public class CategoryEnrollment
    {
        [Key]
        public int CategoryEnrollmentId { get; set; }

        [ForeignKey ("MainCourse")]
        public int MainCourseId { get; set; }

        [ForeignKey ("Category")]
        public int CategoryId { get; set; }

        public MainCourse MainCourse { get; set; }
        public Category Category { get; set; }

    }
}
