namespace ITEC_API.DTO.ResponseDTO
{
    public class PaymentHistoryResponse
    {
        public string CourseName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date {  get; set; }
    }
}
