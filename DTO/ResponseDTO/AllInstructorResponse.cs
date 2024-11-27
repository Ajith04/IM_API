namespace ITEC_API.DTO.ResponseDTO
{
    public class AllInstructorResponse
    {
        public string InstructorName { get; set; }
        public string Description { get; set; }
        public byte[] Avatar { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
