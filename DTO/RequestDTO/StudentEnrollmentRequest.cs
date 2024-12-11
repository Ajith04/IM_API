namespace ITEC_API.DTO.RequestDTO
{
    public class StudentEnrollmentRequest
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public int InstructorId { get; set; }
        public decimal CourseFee { get; set; }
        public string Duration { get; set; }
        
        public DateTime EnrollmentDate { get; set; }
    }
}
