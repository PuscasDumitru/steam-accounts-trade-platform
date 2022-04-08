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
    public interface IUserService
    {
        Task<IList<IdentityUser>> GetAllUsersAsync(CancellationToken cancellationToken = default);
        Task<IdentityUser> GetUserByIdAsync(string userId, CancellationToken cancellationToken);
        Task<UserUpdateDto> GetUpdateModelAsync(string userId, CancellationToken cancellationToken);
        Task<UserPasswordChangeDto> GetUserPasswordChangeModelAsync(string userId, CancellationToken cancellationToken);
        Task ChangeUserPasswordAsync(UserPasswordChangeDto userPasswordChangeDto, CancellationToken cancellationToken = default);
        Task CreateAsync(UserCreationDto userCreationDto, CancellationToken cancellationToken = default);
        Task UpdateAsync(UserUpdateDto userUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(string userId, CancellationToken cancellationToken = default);
    }
}
