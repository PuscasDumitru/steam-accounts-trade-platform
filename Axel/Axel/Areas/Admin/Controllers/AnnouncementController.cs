using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence;
using Microsoft.AspNetCore.Authorization;
using Services.Interfaces;
using Domain.DataTransferObjects;
using System.Threading;
using Mapster;

namespace Axel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin, superuser")]
    public class AnnouncementController : Controller
    {
        readonly IServiceManager _serviceManager;
    
        public AnnouncementController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }    
        
        [HttpGet]
        public IActionResult Create(int accountId, CancellationToken cancellationToken)
        {
            ViewBag.image = new[] {
                "Replace", "Align", "Caption", "Remove", "InsertLink", "OpenImageLink", "-",
                "EditImageLink", "RemoveImageLink", "Display", "AltText", "Dimension"
            };

            ViewBag.tools = new[] {
                "Bold", "Italic", "Underline", "StrikeThrough",
                "FontName", "FontSize", "FontColor", "BackgroundColor",
                "LowerCase", "UpperCase", "|",
                "Formats", "Alignments", "OrderedList", "UnorderedList",
                "Outdent", "Indent", "|",
                "CreateLink", "Image", "CreateTable", "|", "ClearFormat", "Print",
                "SourceCode", "FullScreen", "|", "Undo", "Redo"
            };

            var announcementDto = new AnnouncementDto { AccId = accountId };

            return View(announcementDto);
        }

        [HttpPost]
        public async Task Create([FromBody]AnnouncementDto announcementDto)
        {
            await _serviceManager.AnnouncementService.CreateAsync(announcementDto);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int accountId, CancellationToken cancellationToken)
        {
            ViewBag.image = new[] {
                "Replace", "Align", "Caption", "Remove", "InsertLink", "OpenImageLink", "-",
                "EditImageLink", "RemoveImageLink", "Display", "AltText", "Dimension"
            };

            ViewBag.tools = new[] {
                "Bold", "Italic", "Underline", "StrikeThrough",
                "FontName", "FontSize", "FontColor", "BackgroundColor",
                "LowerCase", "UpperCase", "|",
                "Formats", "Alignments", "OrderedList", "UnorderedList",
                "Outdent", "Indent", "|",
                "CreateLink", "Image", "CreateTable", "|", "ClearFormat", "Print",
                "SourceCode", "FullScreen", "|", "Undo", "Redo"
            };

            var announcementDto = await _serviceManager.AnnouncementService.GetAnnouncementByAccountIdAsync(accountId, cancellationToken);

            return View(announcementDto);
        }

        [HttpPost]
        public async Task Edit([FromBody]AnnouncementDto announcementDto, CancellationToken cancellationToken)
        {
            await _serviceManager.AnnouncementService.UpdateAsync(announcementDto, cancellationToken);
        }
    }
}
