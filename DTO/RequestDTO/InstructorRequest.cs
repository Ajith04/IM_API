namespace ITEC_API.DTO.RequestDTO
{
    public class InstructorRequest
    {
        public string InstructorName { get; set; }
        public string Description { get; set; }
        public IFormFile Avatar { get; set; }
        public List<String> CourseNames { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
