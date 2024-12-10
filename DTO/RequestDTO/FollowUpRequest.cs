namespace ITEC_API.DTO.RequestDTO
{
    public class FollowUpRequest
    {
        public string Name { get; set; }
        public string Mobile {  get; set; }
        public List<String> Courses { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        
    }
}
