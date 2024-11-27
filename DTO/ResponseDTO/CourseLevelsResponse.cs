namespace ITEC_API.DTO.ResponseDTO
{
    public class CourseLevelsResponse
    {
        public string CourseId { get; set; }
        public string LevelName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Duration { get; set; }
        public decimal CourseFee { get; set; }
        public string Description { get; set; }
        public ICollection<InstructorResponse> InstructorResponses { get; set; }
    }
}
