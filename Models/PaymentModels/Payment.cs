using ITEC_API.Models.StudentModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITEC_API.Models.PaymentModels
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [ForeignKey ("StudentCourseEnrollment")]
        public int EnrollmentId { get; set; }

        public decimal PaidAmount { get; set; }
        public DateTime PaidDate { get; set; }

        public StudentCourseEnrollment studentCourseEnrollment { get; set; }
    }
}
