namespace ITEC_API.DTO.ResponseDTO
{
    public class PaymentEnrollmentResponse
    {
        public int EnrollmentId { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal CourseFee { get; set; }
        public decimal PayableAmount { get; set; }
    }
}
