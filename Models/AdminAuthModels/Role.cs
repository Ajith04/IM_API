using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models.AdminAuthModels
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
