using ITEC_API.Models.StudentModels;
using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models.PaymentModels
{
    public class RegistrationFee
    {
        [Key]
       public int Id { get; set; }
        public decimal RegFee {  get; set; }
        public virtual ICollection<StudentRegFeeEnrollment> StudentRegFeeEnrollments { get; set; }
    }
}
