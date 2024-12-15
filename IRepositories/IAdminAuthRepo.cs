using ITEC_API.DTO.RequestDTO;
using ITEC_API.Models.AdminAuthModels;

namespace ITEC_API.IRepositories
{
    public interface IAdminAuthRepo
    {
        Task<List<Role>> getAllRoles();
        Task addAccount(Account account);
        Task<List<Account>> getAllAccounts();
        Task<Account> getAccountByMailId(string mailId);
        Task addPassword(Account account);
    }
}
