using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class AnnouncementRepository : RepositoryBase<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(RepositoryDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync(CancellationToken cancellationToken = default)
        {
            return await FindAll()
               .ToListAsync(cancellationToken);
        }
        public async Task<Announcement> GetAnnouncementByAccountIdAsync(int accountId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(annon => annon.Account.Id.Equals(accountId))
                .FirstOrDefaultAsync(cancellationToken);
        }

        public override void Create(Announcement announcement)
        {
            base.Create(announcement);
        }
        public override void Update(Announcement announcement)
        {
            base.Update(announcement);
        }
    }

}
