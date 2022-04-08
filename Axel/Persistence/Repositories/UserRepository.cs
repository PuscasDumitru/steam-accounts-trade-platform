using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class UserRepository : RepositoryBase<IdentityUser>, IUserRepository
    {
        public UserRepository(RepositoryDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IList<IdentityUser>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            return await FindAll()
               .OrderBy(user => user.Email)
               .ToListAsync(cancellationToken);
        }
        public async Task<IdentityUser> GetUserByIdAsync(string userId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(user => user.Id.Equals(userId))
                .FirstOrDefaultAsync(cancellationToken);
        }

        //public async Task CreateRole(string roleName, RoleManager<IdentityRole> roleManager)
        //{
        //    await roleManager.CreateAsync(new IdentityRole(roleName));
        //}
        //public override void Update(IdentityRole role)
        //{
        //    base.Update(role);
        //}
        //public override void Delete(IdentityRole role)
        //{
        //    base.Delete(role);
        //}
    }
}
