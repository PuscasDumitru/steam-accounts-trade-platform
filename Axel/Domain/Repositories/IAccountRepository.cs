using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync(CancellationToken cancellationToken = default);
        Task<Account> GetAccountByIdAsync(int accountId, CancellationToken cancellationToken = default);
        Task<Account> GetAccountWithDetailsAsync(int accountId, CancellationToken cancellationToken = default);
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(Account account);
    }
}
