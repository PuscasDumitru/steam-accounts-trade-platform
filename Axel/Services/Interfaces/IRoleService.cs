using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.DataTransferObjects;

namespace Services.Interfaces
{
    public interface IRoleService
    {
        Task<IList<IdentityRole>> GetAllRolesAsync(CancellationToken cancellationToken = default);
        Task<IList<string>> GetUserRolesAsync(string userId, CancellationToken cancellationToken);
        Task<UserRoleUpdateDto> GetUpdateModelAsync(string userId, CancellationToken cancellationToken);
        Task CreateAsync(string roleName, CancellationToken cancellationToken = default);
        Task UpdateAsync(string userId, List<string> roles, CancellationToken cancellationToken = default);
        Task DeleteAsync(string roleId, CancellationToken cancellationToken = default);
    }
}
