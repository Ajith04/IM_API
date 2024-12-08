using ITEC_API.Models.StudyMaterialsModels;
using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models.CourseModels
{
    public class CourseLevel
    {
        [Key]
        public string CourseId { get; set; }
        public int MainCourseId { get; set; }
        public virtual MainCourse MainCourse { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Duration { get; set; }
        public decimal CourseFee { get; set; }
        public string Description { get; set; }

        public virtual ICollection<InstructorEnrollment> InstructorEnrollments { get; set; }
        public virtual LevelEnrollment LevelEnrollment { get; set;}

        public virtual ICollection<StudyMaterial> StudyMaterials { get; set; }
    }
}
