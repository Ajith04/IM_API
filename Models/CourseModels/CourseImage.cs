using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITEC_API.Models.CourseModels
{
    public class CourseImage
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey ("MainCourse")]
        public int MainCourseId { get; set; }
        public byte[] Thumbnails { get; set; }

        public MainCourse MainCourse { get; set; }
        
    }
}
