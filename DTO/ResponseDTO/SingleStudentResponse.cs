namespace ITEC_API.DTO.ResponseDTO
{
    public class SingleStudentResponse
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Batch { get; set; }
        public string Intake { get; set; }
        public int BatchEnrollmentId { get; set; }

        public List<SingleStudentCourseLevelResponse> singleStudentCourseLevelResponses { get; set; }
    }
}
