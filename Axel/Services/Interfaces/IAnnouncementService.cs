using Domain.DataTransferObjects;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Services.Interfaces
{
    public interface IAnnouncementService
    {
        Task<IEnumerable<AnnouncementDto>> GetAllAnnouncementsAsync(CancellationToken cancellationToken = default);
        Task<AnnouncementDto> GetAnnouncementByAccountIdAsync(int accountId, CancellationToken cancellationToken = default);
        Task<AnnouncementDto> GetAnnouncementByIdAsync(int id, CancellationToken cancellationToken = default);
        Task CreateAsync(AnnouncementDto announcementDto, CancellationToken cancellationToken = default);
        Task UpdateAsync(AnnouncementDto announcementDto, CancellationToken cancellationToken = default);
    }
}