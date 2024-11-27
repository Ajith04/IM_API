using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITEC_API.Models.CourseModels
{
    public class LevelEnrollment
    {
        [Key]
        public int LevelEnrollmentId { get; set; }

        [ForeignKey ("CourseLevel")]
        public string CourseId { get; set; }

        [ForeignKey ("Level")]
        public int LevelId { get; set; }

        public CourseLevel CourseLevel { get; set; }
        public Level Level { get; set; }
    }
}
