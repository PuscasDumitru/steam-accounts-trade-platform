using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    internal sealed class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public AccountRepository(RepositoryDbContext repositoryContext)
           : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Account>> GetAllAccountsAsync(CancellationToken cancellationToken = default)
        {
            return await FindAll()
               .OrderBy(acc => acc.SteamLink)
               .ToListAsync(cancellationToken);
        }
        public async Task<Account> GetAccountByIdAsync(int accountId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(acc => acc.Id.Equals(accountId))
                .FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<Account> GetAccountWithDetailsAsync(int accountId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(acc => acc.Id.Equals(accountId))
                .Include(ac => ac.AccountGames)
                .FirstOrDefaultAsync(cancellationToken);
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
