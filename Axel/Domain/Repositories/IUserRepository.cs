using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository : IRepositoryBase<IdentityUser>
    {
        Task<IList<IdentityUser>> GetAllUsersAsync(CancellationToken cancellationToken = default);
        Task<IdentityUser> GetUserByIdAsync(string userId, CancellationToken cancellationToken = default);

    }
}
