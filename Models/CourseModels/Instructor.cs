using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models.CourseModels
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string Description { get; set; }
        public byte[] Avatar { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public virtual ICollection<InstructorEnrollment> InstructorEnrollments { get; set; }
    }
}
