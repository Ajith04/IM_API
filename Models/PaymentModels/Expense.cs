using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models.PaymentModels
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount {  get; set; }
        public string Description { get; set; }
        public ICollection<ExpenseReceipt> ExpenseReceipts { get; set; }
    }
}
