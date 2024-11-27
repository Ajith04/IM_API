using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models.CourseModels
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<CategoryEnrollment> CategoryEnrollments { get; set; }
    }
}
