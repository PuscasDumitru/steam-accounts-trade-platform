using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.DataTransferObjects;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using Services.Interfaces;

namespace Services.Implementation
{
    internal sealed class AccountService : IAccountService
    {
        readonly IRepositoryManager _repositoryManager;
        public AccountService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<AccountDto>> GetAllAccountsAsync(CancellationToken cancellationToken = default)
        {
            var accounts = await _repositoryManager.AccountRepository.GetAllAccountsAsync(cancellationToken);
            var accountsDto = accounts.Adapt<IEnumerable<AccountDto>>();

            return accountsDto;
        }
        public async Task<AccountDto> GetAccountByIdAsync(int accountId, CancellationToken cancellationToken)
        {
            var account = await _repositoryManager.AccountRepository.GetAccountByIdAsync(accountId, cancellationToken);
            var accountDto = account.Adapt<AccountDto>();

            return accountDto;
        }

        public async Task CreateAsync(AccountDto accountDto, CancellationToken cancellationToken = default)
        {
            var account = accountDto.Adapt<Account>();
            _repositoryManager.AccountRepository.Create(account);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

        }
        public async Task UpdateAsync(AccountDto accountDto, CancellationToken cancellationToken = default)
        {
            var account = accountDto.Adapt<Account>();
            _repositoryManager.AccountRepository.Update(account);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int accountId, CancellationToken cancellationToken = default)
        {
            var account = await _repositoryManager.AccountRepository.GetAccountByIdAsync(accountId, cancellationToken);
            _repositoryManager.AccountRepository.Delete(account);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
