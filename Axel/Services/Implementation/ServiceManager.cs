using System;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces;

namespace Services.Implementation
{
    public sealed class ServiceManager : IServiceManager
    {
        readonly Lazy<IAnnouncementService> _lazyAnnouncementService;
        readonly Lazy<IAccountService> _lazyAccountService;
        readonly Lazy<IRoleService> _lazyRoleService;
        readonly Lazy<IUserService> _lazyUserService;

        public ServiceManager(IRepositoryManager repositoryManager, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _lazyAnnouncementService = new Lazy<IAnnouncementService>(() => new AnnouncementService(repositoryManager));
            _lazyAccountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager));
            _lazyRoleService = new Lazy<IRoleService>(() => new RoleService(repositoryManager, roleManager, userManager));
            _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager, userManager));
        }

        public IAnnouncementService AnnouncementService => _lazyAnnouncementService.Value;
        public IAccountService AccountService => _lazyAccountService.Value;
        public IRoleService RoleService => _lazyRoleService.Value;
        public IUserService UserService => _lazyUserService.Value;

    }
}
