using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models.CourseModels
{
    public class Level
    {
        [Key]
        public int LevelId { get; set; }
        public string LevelName { get; set; }

        public virtual ICollection<LevelEnrollment> LevelEnrollments { get; set; }
    }
}
