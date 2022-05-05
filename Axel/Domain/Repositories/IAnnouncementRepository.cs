using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAnnouncementRepository : IRepositoryBase<Announcement>
    {
        Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync(CancellationToken cancellationToken = default);
        Task<Announcement> GetAnnouncementByAccountIdAsync(int accountId, CancellationToken cancellationToken = default);
        Task<Announcement> GetAnnouncementByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
