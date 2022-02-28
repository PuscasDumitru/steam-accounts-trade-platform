using Entities;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await FindAll()
               .OrderBy(acc => acc.SteamLink)
               .ToListAsync();
        }
        public async Task<Account> GetAccountByIdAsync(int accountId)
        {
            return await FindByCondition(acc => acc.Id.Equals(accountId))
                .FirstOrDefaultAsync();
        }
        public async Task<Account> GetAccountWithDetailsAsync(int accountId)
        {
            return await FindByCondition(acc => acc.Id.Equals(accountId))
                .Include(ac => ac.AccountGames)
                .FirstOrDefaultAsync();
        }
        public void CreateAccount(Account account)
        {
            Create(account);
        }
        public void UpdateAccount(Account account)
        {
            Update(account);
        }
        public void DeleteAccount(Account account)
        {
            Delete(account);
        }
    }
}
