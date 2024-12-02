using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITEC_API.Models.PaymentModels
{
    public class ExpenseReceipt
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey ("Expense")]
        public int ExpenseId { get; set; }
        public byte[] Receipt { get; set; }
        public Expense Expense { get; set; }
    }
}
