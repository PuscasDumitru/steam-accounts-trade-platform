using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Repositories
{
    public interface IRoleRepository : IRepositoryBase<IdentityRole>
    {
        Task<IList<IdentityRole>> GetAllRolesAsync(CancellationToken cancellationToken = default);
        //Task<IdentityRole> GetRoleByIdAsync(string roleId, CancellationToken cancellationToken = default);

    }
}
 