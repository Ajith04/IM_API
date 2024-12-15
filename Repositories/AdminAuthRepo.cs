using ITEC_API.Database;
using ITEC_API.DTO.RequestDTO;
using ITEC_API.IRepositories;
using ITEC_API.Models.AdminAuthModels;
using Microsoft.EntityFrameworkCore;

namespace ITEC_API.Repositories
{
    public class AdminAuthRepo : IAdminAuthRepo
    {
        private readonly ITECDbContext _itecDbContext;

        public AdminAuthRepo(ITECDbContext itecDbContext)
        {
            _itecDbContext = itecDbContext;
        }

        public async Task<List<Role>> getAllRoles()
        {
            var roles = await _itecDbContext.Roles.ToListAsync();
            return roles;
        }

        public async Task addAccount(Account account)
        {
            await _itecDbContext.Accounts.AddAsync(account);
            await _itecDbContext.SaveChangesAsync();
        }

        public async Task<List<Account>> getAllAccounts()
        {
            var allAccounts = await _itecDbContext.Accounts.ToListAsync();
            return allAccounts;
        }

        public async Task<Account> getAccountByMailId(string mailId)
        {
            var singleAccount = await _itecDbContext.Accounts.SingleOrDefaultAsync(r => r.MailId ==  mailId);
            return singleAccount;
        }

        public async Task addPassword(Account account)
        {
            _itecDbContext.Accounts.Update(account);
            await _itecDbContext.SaveChangesAsync();
        }

    }
}
