using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Domain.Entities;
using Domain.Repositories;
using Domain.Services;

namespace Services
{
    internal sealed class AccountService : IAccountService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AccountService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<Account>> GetAllAccountsAsync(CancellationToken cancellationToken = default)
        {
            var accounts = await _repositoryManager.AccountRepository.GetAllAccountsAsync(cancellationToken);

            return accounts;
        }
        public async Task<Account> GetAccountByIdAsync(int accountId, CancellationToken cancellationToken)
        {
            var account = await _repositoryManager.AccountRepository.GetAccountByIdAsync(accountId, cancellationToken);

            return account;
        }

        public async Task<Account> CreateAsync(Account account, CancellationToken cancellationToken = default)
        {
            _repositoryManager.AccountRepository.CreateAccount(account);
             await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return account;
        }
        public async Task UpdateAsync(Account account, CancellationToken cancellationToken = default)
        {
            _repositoryManager.AccountRepository.UpdateAccount(account);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Account account, CancellationToken cancellationToken = default)
        {
            _repositoryManager.AccountRepository.DeleteAccount(account);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
