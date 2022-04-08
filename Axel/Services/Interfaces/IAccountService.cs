using Domain.DataTransferObjects;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAllAccountsAsync(CancellationToken cancellationToken = default);
        Task<AccountDto> GetAccountByIdAsync(int accountId, CancellationToken cancellationToken);
        Task CreateAsync(AccountDto accountDto, CancellationToken cancellationToken = default);
        Task UpdateAsync(AccountDto accountDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(int accountId, CancellationToken cancellationToken = default);
    }
}