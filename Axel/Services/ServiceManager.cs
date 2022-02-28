using System;
using Domain.Repositories;
using Domain.Services;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        //private readonly Lazy<IContentService> _lazyContentService;
        private readonly Lazy<IAccountService> _lazyAccountService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            //_lazyOwnerService = new Lazy<IContentService>(() => new ContentService(repositoryManager));
            _lazyAccountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager));
        }

        //public IContentService ContentService => _lazyContentService.Value;
        public IAccountService AccountService => _lazyAccountService.Value;
    }
}
