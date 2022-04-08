
using Axel.Areas.Superuser.ViewModels;
using Domain.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class RoleController : Controller
    {
        readonly IServiceManager _serviceManager;
        public RoleController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken) =>
            View(await _serviceManager.RoleService.GetAllRolesAsync(cancellationToken));


        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, CancellationToken cancellationToken)
        {
            await _serviceManager.RoleService.CreateAsync(name, cancellationToken);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            await _serviceManager.RoleService.DeleteAsync(id, cancellationToken);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UserList(CancellationToken cancellationToken) =>
            View(await _serviceManager.UserService.GetAllUsersAsync(cancellationToken));

        [HttpGet]
        public async Task<IActionResult> Edit(string userId, CancellationToken cancellationToken)
        {
            var model = await _serviceManager.RoleService.GetUpdateModelAsync(userId, cancellationToken);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string userId, List<string> roles, CancellationToken cancellationToken)
        {
            await _serviceManager.RoleService.UpdateAsync(userId, roles, cancellationToken);

            return RedirectToAction("UserList");

        }
    }
}
