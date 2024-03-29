﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence;
using Domain.Repositories;
using Services.Interfaces;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Domain.DataTransferObjects;

namespace Axel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin, superuser")]
    public class AccountController : Controller
    {
        readonly IServiceManager _serviceManager;
        readonly RepositoryDbContext _context;
        public AccountController(IServiceManager serviceManager, RepositoryDbContext context)
        {
            _serviceManager = serviceManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var accounts = await _serviceManager.AccountService.GetAllAccountsAsync(cancellationToken);

            return View(accounts);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {

            var account = await _serviceManager.AccountService
                .GetAccountByIdAsync(id, cancellationToken);

            return View(account);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountDto accountDto, CancellationToken cancellationToken)
        {
            await _serviceManager.AccountService.CreateAsync(accountDto, cancellationToken);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var account = await _serviceManager.AccountService.GetAccountByIdAsync(id, cancellationToken);

            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AccountDto accountDto, CancellationToken cancellationToken)
        {
            await _serviceManager.AccountService.UpdateAsync(accountDto, cancellationToken);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var account = await _serviceManager.AccountService
                .GetAccountByIdAsync(id, cancellationToken);

            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            await _serviceManager.AccountService.DeleteAsync(id, cancellationToken);

            return RedirectToAction(nameof(Index));
        }

    }
}