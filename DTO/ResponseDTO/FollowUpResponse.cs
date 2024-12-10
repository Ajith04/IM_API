namespace ITEC_API.DTO.ResponseDTO
{
    public class FollowUpResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Courses { get; set; }
        public string Mobile { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
