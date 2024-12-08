using ITEC_API.Models.StudyMaterialsModels;
using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models.CourseModels
{
    public class Batch
    {
        [Key]
        public int BatchId { get; set; }
        public string BatchName { get; set; }

        public virtual ICollection<StudyMaterial> StudyMaterials { get; set; }
    }
}
