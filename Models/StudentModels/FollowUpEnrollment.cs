using ITEC_API.Models.CourseModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITEC_API.Models.StudentModels
{
    public class FollowUpEnrollment
    {
        public int Id { get; set; }

        [ForeignKey ("CourseName")]
        public int CourseNameID { get; set; }

        [ForeignKey ("FollowUp")]
        public int FollowUpId { get; set; }

        public CourseName CourseName { get; set; }
        public FollowUp FollowUp { get; set; }
    }
}
