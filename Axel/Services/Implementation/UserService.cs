using Domain.DataTransferObjects;
using Domain.Repositories;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Implementation
{
    internal sealed class UserService : IUserService
    {
        readonly IRepositoryManager _repositoryManager;
        readonly UserManager<IdentityUser> _userManager;

        public UserService(IRepositoryManager repositoryManager, UserManager<IdentityUser> userManager)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
        }

        public async Task<IList<IdentityUser>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            var users = await _repositoryManager.UserRepository.GetAllUsersAsync(cancellationToken);

            return users;
        }
        public async Task<IdentityUser> GetUserByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user;
        }

        public async Task<UserPasswordChangeDto> GetUserPasswordChangeModelAsync(string id, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(id);
            var model = user.Adapt<UserPasswordChangeDto>();

            return model;
        }

        public async Task ChangeUserPasswordAsync(UserPasswordChangeDto userPasswordChangeDto, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(userPasswordChangeDto.Id);
            await _userManager.ChangePasswordAsync(user, userPasswordChangeDto.OldPassword, userPasswordChangeDto.NewPassword);
        }

        public async Task CreateAsync(UserCreationDto userCreationDto, CancellationToken cancellationToken = default)
        {
            //var user = userCreationDto.Adapt<IdentityUser>();

            var user = new IdentityUser { Email = userCreationDto.Email, UserName = userCreationDto.Email };

            await _userManager.CreateAsync(user, userCreationDto.Password);
        }

        public async Task UpdateAsync(UserUpdateDto userUpdateDto, CancellationToken cancellationToken = default)
        {
            //var user = userUpdateDto.Adapt<IdentityUser>();

            var user = await _userManager.FindByIdAsync(userUpdateDto.Id);
            user.Email = userUpdateDto.Email;
            user.UserName = userUpdateDto.Email;

            await _userManager.UpdateAsync(user);
        }

        public async Task<UserUpdateDto> GetUpdateModelAsync(string id, CancellationToken cancellation = default)
        {
            var user = await _userManager.FindByIdAsync(id);
            var model = user.Adapt<UserUpdateDto>();

            return model;
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
        }
    }
}
