namespace ITEC_API.DTO.ResponseDTO
{
    public class EditCourseLevelResponse
    {
        public string CourseName { get; set; }
        public byte[] Thumbnail { get; set; }
        public string LevelId { get; set; }
        public string LevelName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Duration { get; set; }
        public decimal CourseFee { get; set; }
        public string Description { get; set; }
    }
}
