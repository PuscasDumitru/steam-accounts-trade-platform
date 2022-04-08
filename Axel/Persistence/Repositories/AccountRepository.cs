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
        public AccountRepository(RepositoryDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Account>> GetAllAccountsAsync(CancellationToken cancellationToken = default)
        {
            return await (from acc in RepositoryContext.Account
                          join announcement in RepositoryContext.Announcement
                          on acc.Id equals announcement.Account.Id
                          into gj
                          from subContent in gj.DefaultIfEmpty()
                          select new Account
                          {
                              Id = acc.Id,
                              SteamLevel = acc.SteamLevel,
                              SteamLink = acc.SteamLink,
                              BansCount = acc.BansCount,
                              Price = acc.Price,
                              YearCreated = acc.YearCreated,
                              DateTimeAdded = acc.DateTimeAdded,
                              AnnouncementId = (subContent != null) ? subContent.Id : 0
                          }).ToListAsync(cancellationToken);
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
        public override void Create(Account account)
        {
            base.Create(account);
        }
        public override void Update(Account account)
        {
            base.Update(account);
        }
        public override void Delete(Account account)
        {
            base.Delete(account);
        }
    }
}
