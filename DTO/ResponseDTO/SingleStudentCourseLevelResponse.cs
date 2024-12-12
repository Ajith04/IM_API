using Microsoft.EntityFrameworkCore.Storage.Json;

namespace ITEC_API.DTO.ResponseDTO
{
    public class SingleStudentCourseLevelResponse
    {
        public int CourseEnrollmentId { get; set; }
        public byte[] CourseImage { get; set; }
        public string CourseName { get; set; }
        public string LevelName { get; set; }
        public string InstructorName { get; set; }

    }
}
