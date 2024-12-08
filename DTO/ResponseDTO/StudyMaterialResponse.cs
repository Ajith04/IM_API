namespace ITEC_API.DTO.ResponseDTO
{
    public class StudyMaterialResponse
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Course { get; set; }
        public string BatchName { get; set; }
        public List<SMFileResponse> Files { get; set; }
    }
}
