using Domain.DataTransferObjects;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Implementation
{
    internal sealed class RoleService : IRoleService
    {
        readonly IRepositoryManager _repositoryManager;
        readonly RoleManager<IdentityRole> _roleManager;
        readonly UserManager<IdentityUser> _userManager;

        public RoleService(IRepositoryManager repositoryManager, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _repositoryManager = repositoryManager;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IList<IdentityRole>> GetAllRolesAsync(CancellationToken cancellationToken = default)
        {
            var roles = await _repositoryManager.RoleRepository.GetAllRolesAsync(cancellationToken);

            return roles;
        }
        public async Task<IList<string>> GetUserRolesAsync(string userId, CancellationToken cancellationToken)
        {
            var userRoles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(userId));

            return userRoles;
        }

        public async Task CreateAsync(string roleName, CancellationToken cancellationToken = default)
        {
            await _roleManager.CreateAsync(new IdentityRole(roleName));
        }

        public async Task UpdateAsync(string userId, List<string> roles, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var userRoles = await _userManager.GetRolesAsync(user);
            var addedRoles = roles.Except(userRoles);
            var removedRoles = userRoles.Except(roles);

            await _userManager.AddToRolesAsync(user, addedRoles);
            await _userManager.RemoveFromRolesAsync(user, removedRoles);
        }

        public async Task<UserRoleUpdateDto> GetUpdateModelAsync(string userId, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = await GetAllRolesAsync(cancellationToken);

            var model = new UserRoleUpdateDto
            {
                UserId = user.Id,
                UserEmail = user.Email,
                UserRoles = userRoles,
                AllRoles = allRoles
            };

            return model;
        }

        public async Task DeleteAsync(string roleId, CancellationToken cancellationToken = default)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            await _roleManager.DeleteAsync(role);
        }
    }
}
