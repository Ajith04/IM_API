using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models.CourseModels
{
    public class MainCourse
    {
        [Key]
        public int MainCourseId { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<CourseLevel> CourseLevels { get; set; }
        public virtual ICollection<CourseImage> CourseImages { get; set; }
        public virtual ICollection<CategoryEnrollment> CategoryEnrollments { get; set; }
    }
}
