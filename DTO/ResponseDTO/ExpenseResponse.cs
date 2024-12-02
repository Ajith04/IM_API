namespace ITEC_API.DTO.ResponseDTO
{
    public class ExpenseResponse
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public ICollection<ExpenseReceiptResponse> Receipts { get; set; }
    }
}
