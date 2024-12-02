namespace ITEC_API.DTO.ResponseDTO
{
    public class AssignInstructorResponse
    {
        public int EnrollmentId { get; set; }
        public string InstructorName { get; set; }
        public byte[] Avatar { get; set; }
        public List<InstructorKnowCourseResponse> InstructorKnowCourses { get; set; }
    }
}
