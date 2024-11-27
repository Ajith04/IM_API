using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models.CourseModels
{
    public class InstructorEnrollment
    {

        [Key]
        public int EnrollmentId { get; set; }
        public string CourseId { get; set; }
        public virtual CourseLevel CourseLevel { get; set; }
        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
