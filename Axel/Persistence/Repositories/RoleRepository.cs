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
    internal sealed class RoleRepository : RepositoryBase<IdentityRole>, IRoleRepository
    {
        public RoleRepository(RepositoryDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IList<IdentityRole>> GetAllRolesAsync(CancellationToken cancellationToken = default)
        {
            return await FindAll()
               .OrderBy(role => role.Name)
               .ToListAsync(cancellationToken);
        }
        //public async Task<IdentityRole> GetRoleByIdAsync(string roleId, CancellationToken cancellationToken = default)
        //{
        //    return await FindByCondition(role => role.Id.Equals(roleId))
        //        .FirstOrDefaultAsync(cancellationToken);
        //}

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
