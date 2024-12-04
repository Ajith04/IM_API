using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models.PaymentModels
{
    public class RegistrationFee
    {
        [Key]
       public int Id { get; set; }
        public decimal RegFee {  get; set; }
    }
}
