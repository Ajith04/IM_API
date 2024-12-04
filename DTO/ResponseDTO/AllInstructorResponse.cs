namespace ITEC_API.DTO.ResponseDTO
{
    public class AllInstructorResponse
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string Description { get; set; }
        public byte[] Avatar { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public List<InstructorKnowCourseResponse> instructorKnowCourseResponses { get; set; }
        public List<InstructorAssignedCourseResponse> instructorAssignedCourseResponses { get; set; }
    }
}
