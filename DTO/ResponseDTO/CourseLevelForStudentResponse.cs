namespace ITEC_API.DTO.ResponseDTO
{
    public class CourseLevelForStudentResponse
    {
        public string LevelId { get; set; }
        public string LevelName { get; set; }
        public decimal CourseFee { get; set; }
        public string Duration { get; set; }
        public List<byte[]> CourseImages { get; set; }
        public List<InstructorForStudentCourseResponse> Instructors { get; set; }
    }
}
