using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Domain.Services
{
    public interface IContentService
    {
        Task<IEnumerable<Content>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Content> GetByIdAsync(int contentId, CancellationToken cancellationToken = default);
        Task<Content> CreateAsync(Content content, CancellationToken cancellationToken = default);
        Task UpdateAsync(Content content, CancellationToken cancellationToken = default);
        Task DeleteAsync(int contentId, CancellationToken cancellationToken = default);
    }
}