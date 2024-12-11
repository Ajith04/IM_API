namespace ITEC_API.DTO.ResponseDTO
{
    public class CourseForStudentResponse
    {
        public string MainCourseName { get; set; }

        public List<CourseLevelForStudentResponse> CourseLevels { get; set; }
    }
}
