using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITEC_API.Models.StudyMaterialsModels
{
    public class StudyMaterialFile
    {
        [Key]
        public int FileId { get; set; }

        [ForeignKey ("StudyMaterial")]
        public int StudyMaterialId { get; set; }
        public byte[] File { get; set; }

        public StudyMaterial StudyMaterial { get; set; }
    }
}
