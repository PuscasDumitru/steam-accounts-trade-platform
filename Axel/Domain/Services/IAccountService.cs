using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Domain.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync(CancellationToken cancellationToken = default);
        Task<Account> GetAccountByIdAsync(int accountId, CancellationToken cancellationToken);
        Task<Account> CreateAsync(Account account, CancellationToken cancellationToken = default);
        Task UpdateAsync(Account account, CancellationToken cancellationToken = default);
        Task DeleteAsync(Account account, CancellationToken cancellationToken = default);
    }
}