namespace ITEC_API.DTO.RequestDTO
{
    public class AddCourseLevelRequest
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string LevelName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Duration { get; set; }
        public decimal CourseFee { get; set; }
        public string Description { get; set; }
    }
}
