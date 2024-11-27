namespace ITEC_API.DTO.RequestDTO
{
    public class MainCourseRequest
    {
        public string CourseName { get; set; }
        public List<string> Categories { get; set; }
        public List<IFormFile> Thumbnails { get; set; }
    }
}
