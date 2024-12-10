using ITEC_API.Models.CourseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITEC_API.Models.StudentModels
{
    public class StudentBatchEnrollment
    {
        [Key]
        public int BatchEnrollmentId { get; set; }

        [ForeignKey ("Student")]
        public string StudentId { get; set; }

        [ForeignKey ("Batch")]
        public int BatchId { get; set;}

        public Student Student { get; set; }
        public Batch Batch { get; set; }
    }
}
