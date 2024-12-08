namespace ITEC_API.DTO.RequestDTO
{
    public class UpdateInstructorRequest
    {
        public IFormFile Avatar { get; set; }
        public string Description { get; set; }
        public string Mobile {  get; set; }
        public string Email { get; set; }
        public List<string> KnownCourses { get; set; }
    }
}
