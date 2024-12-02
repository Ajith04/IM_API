using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models.CourseModels
{
    public class Batch
    {
        [Key]
        public int BatchId { get; set; }
        public string BatchName { get; set; }
    }
}
