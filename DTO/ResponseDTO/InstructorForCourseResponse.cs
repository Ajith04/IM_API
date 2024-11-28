namespace ITEC_API.DTO.ResponseDTO
{
    public class InstructorForCourseResponse
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public byte[] Avatar { get; set; }

        public ICollection<InstructorCourseNameResponse> instructorCourseNameResponses { get; set; }
    }
}
