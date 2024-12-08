using System.ComponentModel.DataAnnotations.Schema;

namespace ITEC_API.DTO.RequestDTO
{
    public class SMRequest
    {
  
        public string Title { get; set; }
        public string LevelId { get; set; }
        public string BatchName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
