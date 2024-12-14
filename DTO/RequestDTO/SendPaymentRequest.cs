namespace ITEC_API.DTO.RequestDTO
{
    public class SendPaymentRequest
    {
        public int EnrollmentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime date { get; set; }
    }
}
