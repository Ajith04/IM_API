using ITEC_API.Models.StudentModels;
using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models.CourseModels
{
    public class CourseName
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<InstructorKnowCourses> InstructorKnowCourses { get; set; }
        public virtual ICollection<FollowUpEnrollment> FollowUpEnrollments { get; set; }
    }
}
