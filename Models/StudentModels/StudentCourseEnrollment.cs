using ITEC_API.Models.CourseModels;
using ITEC_API.Models.PaymentModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITEC_API.Models.StudentModels
{
    public class StudentCourseEnrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [ForeignKey ("Student")]
        public string StudentId { get; set; }

        [ForeignKey ("CourseLevel")]
        public string CourseId { get; set; }

        [ForeignKey ("Instructor")]
        public int InstructorId { get; set; }

        public decimal CourseFee { get; set; }
        public string Duration { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public Student Student { get; set; }
        public CourseLevel CourseLevel { get; set; }
        public Instructor Instructor { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }


    }
}
