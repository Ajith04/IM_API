namespace ITEC_API.DTO.ResponseDTO
{
    public class StudentCourseLevelResponse
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string LevelName { get; set; }
        public string Duration { get; set; }
        public decimal CourseFee { get; set; }
        public string Instructor {  get; set; }
        public DateTime EnrolledDate { get; set; }

            
    }
}
