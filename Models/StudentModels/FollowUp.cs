namespace ITEC_API.Models.StudentModels
{
    public class FollowUp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FollowUpEnrollment> FollowUpEnrollments { get; set; }

    }
}
