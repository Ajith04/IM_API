using ITEC_API.Models.PaymentModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITEC_API.Models.StudentModels
{
    public class StudentRegFeeEnrollment
    {
        [Key]
        public int RegFeeEnrollmentId { get; set; }

        [ForeignKey ("Student")]
        public string StudentId { get; set; }

        [ForeignKey("RegistrationFee")]
        public int RegFeeId { get; set; }
        public Student Student { get; set; }
        public RegistrationFee RegistrationFee { get; set; }
    }
}
