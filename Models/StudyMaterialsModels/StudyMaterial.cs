using ITEC_API.Models.CourseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITEC_API.Models.StudyMaterialsModels
{
    public class StudyMaterial
    {
        [Key]
        public int StudyMaterialId { get; set; }
        public string Title { get; set; }
        [ForeignKey ("CourseLevel")]
        public string LevelId { get; set; }

        [ForeignKey ("Batch")]
        public int BatchId { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }

        public CourseLevel CourseLevel { get; set; }
        public Batch Batch { get; set; }
        public ICollection<StudyMaterialFile> Files { get; set; }
       
    }
}
