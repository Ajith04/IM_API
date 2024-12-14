namespace ITEC_API.DTO.ResponseDTO
{
    public class PaymentStudentResponse
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }

        public List<PaymentEnrollmentResponse> EnrolledCourses { get; set; }
    }
}
