using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.DataTransferObjects;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using Services.Interfaces;

namespace Services.Implementation
{
    internal sealed class AnnouncementService : IAnnouncementService
    {
        readonly IRepositoryManager _repositoryManager;
        public AnnouncementService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<AnnouncementDto>> GetAllAnnouncementsAsync(CancellationToken cancellationToken = default)
        {
            var announcements = await _repositoryManager.AnnouncementRepository.GetAllAnnouncementsAsync(cancellationToken);
            var announcementsDto = announcements.Adapt<IEnumerable<AnnouncementDto>>();

            return announcementsDto;
        }

        public async Task<AnnouncementDto> GetAnnouncementByIdAsync(int id, CancellationToken cancellationToken)
        {
            var announcement = await _repositoryManager.AnnouncementRepository.GetAnnouncementByIdAsync(id, cancellationToken);
            var announcementDto = announcement.Adapt<AnnouncementDto>();

            return announcementDto;
        }

        public async Task<AnnouncementDto> GetAnnouncementByAccountIdAsync(int accountId, CancellationToken cancellationToken)
        {
            var announcement = await _repositoryManager.AnnouncementRepository.GetAnnouncementByAccountIdAsync(accountId, cancellationToken);
            var announcementDto = announcement.Adapt<AnnouncementDto>();

            return announcementDto;
        }

        public async Task CreateAsync(AnnouncementDto announcementDto, CancellationToken cancellationToken = default)
        {
            var account = await _repositoryManager.AccountRepository.GetAccountByIdAsync(announcementDto.AccId, cancellationToken);

            var announcement = new Announcement
            {
                Id = announcementDto.Id,
                Title = announcementDto.Title,
                Description = announcementDto.Description,
                Account = account,
                HtmlContent = announcementDto.HtmlContent,
                AccId = announcementDto.AccId
            };
            
            _repositoryManager.AnnouncementRepository.Create(announcement);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

        }
        public async Task UpdateAsync(AnnouncementDto announcementDto, CancellationToken cancellationToken = default)
        {
            var announcement = announcementDto.Adapt<Announcement>();
            _repositoryManager.AnnouncementRepository.Update(announcement);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}