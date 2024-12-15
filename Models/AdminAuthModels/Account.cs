using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITEC_API.Models.AdminAuthModels
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string MailId { get; set; }
        public string Password { get; set; }

        [ForeignKey ("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
