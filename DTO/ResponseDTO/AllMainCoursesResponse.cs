using ITEC_API.Models.CourseModels;

namespace ITEC_API.DTO.ResponseDTO
{
    public class AllMainCoursesResponse
    {
        public string CourseName { get; set; }
        public byte[] Thumbnail { get; set; }
        public ICollection<CategoryResponse> Categories { get; set; }
        public ICollection<CourseLevelsResponse> CourseLevel { get; set; }
    }
}
