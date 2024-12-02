namespace ITEC_API.DTO.RequestDTO
{
    public class ExpenseRequest
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public List<IFormFile> Receipt { get; set; }
        public string Description { get; set; }
    }
}
