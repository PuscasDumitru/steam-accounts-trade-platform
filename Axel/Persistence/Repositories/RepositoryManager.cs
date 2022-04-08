using System;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        readonly Lazy<IAnnouncementRepository> _lazyAnnouncementRepository;
        readonly Lazy<IAccountRepository> _lazyAccountRepository;
        readonly Lazy<IRoleRepository> _lazyRoleRepository;
        readonly Lazy<IUserRepository> _lazyUserRepository;
        readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _lazyAnnouncementRepository = new Lazy<IAnnouncementRepository>(() => new AnnouncementRepository(dbContext));
            _lazyAccountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(dbContext));
            _lazyRoleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(dbContext));
            _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }

        public IAnnouncementRepository AnnouncementRepository => _lazyAnnouncementRepository.Value;
        public IAccountRepository AccountRepository => _lazyAccountRepository.Value;
        public IRoleRepository RoleRepository => _lazyRoleRepository.Value;
        public IUserRepository UserRepository => _lazyUserRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}