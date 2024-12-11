using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models.StudentModels
{
    public class Student
    {
        [Key]
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Intake { get; set; }

        public StudentBatchEnrollment StudentBatchEnrollment { get; set; }
        public StudentRegFeeEnrollment StudentRegFeeEnrollment { get; set; }
        public virtual ICollection<StudentCourseEnrollment> StudentCourseEnrollments { get; set; }
    }
}
