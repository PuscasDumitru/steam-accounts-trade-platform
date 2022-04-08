
using Axel.Areas.Superuser.ViewModels;
using Domain.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Axel.Areas.Superuser.Controllers
{

    [Area("Superuser")]
    [Authorize(Roles = "superuser")]
    public class UserController : Controller
    {
        readonly IServiceManager _serviceManager;
        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken) => 
            View(await _serviceManager.UserService.GetAllUsersAsync(cancellationToken));
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreationDto model, CancellationToken cancellationToken)
        {
            await _serviceManager.UserService.CreateAsync(model, cancellationToken);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id, CancellationToken cancellationToken)
        {
            var model = await _serviceManager.UserService.GetUpdateModelAsync(id, cancellationToken);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserUpdateDto model, CancellationToken cancellationToken)
        {
            await _serviceManager.UserService.UpdateAsync(model, cancellationToken);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            await _serviceManager.UserService.DeleteAsync(id, cancellationToken);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword(string id, CancellationToken cancellationToken)
        {
            var model = await _serviceManager.UserService.GetUserPasswordChangeModelAsync(id, cancellationToken);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(UserPasswordChangeDto model, CancellationToken cancellationToken)
        {
            await _serviceManager.UserService.ChangeUserPasswordAsync(model, cancellationToken);

            return RedirectToAction("Index");
        }
    }
}
