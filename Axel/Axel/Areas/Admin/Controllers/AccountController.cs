using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence;
using Domain.Repositories;
using Domain.Services;
using System.Threading;

namespace Axel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public AccountController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var accounts = await _serviceManager.AccountService.GetAllAccountsAsync(cancellationToken);

            return View(accounts);
        }

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            
            var account = await _serviceManager.AccountService
                .GetAccountByIdAsync(id, cancellationToken);
            
            return View(account);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SteamLevel,SteamLink,BansCount,Price,YearCreated,DateTimeAdded")] Account account, CancellationToken cancellationToken)
        {
            var acc = await _serviceManager.AccountService.CreateAsync(account, cancellationToken);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var account = await _serviceManager.AccountService.GetAccountByIdAsync(id, cancellationToken);
            
            return View(account);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SteamLevel,SteamLink,BansCount,Price,YearCreated,DateTimeAdded")] Account account, 
            CancellationToken cancellationToken)
        {
            await _serviceManager.AccountService.UpdateAsync(account, cancellationToken);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var account = await _serviceManager.AccountService
                .GetAccountByIdAsync(id, cancellationToken);

            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Account account, CancellationToken cancellationToken)
        {
            await _serviceManager.AccountService.DeleteAsync(account, cancellationToken);

            return RedirectToAction(nameof(Index));
        }

    }
}