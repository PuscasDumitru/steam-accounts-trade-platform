using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence;
using System.Net.Http;
using Services.Interfaces;
using Domain.DataTransferObjects;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        readonly RepositoryDbContext _context;
        readonly HttpClient _httpClient;
        readonly IServiceManager _serviceManager;
        public AnnouncementController(RepositoryDbContext context, HttpClient httpClient, IServiceManager serviceManager)
        {
            _context = context;
            _httpClient = httpClient;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IEnumerable<AnnouncementDto>> GetAllAnnouncements()
        {
            var announcements = await _serviceManager.AnnouncementService.GetAllAnnouncementsAsync();
            return announcements;//await _context.Announcement.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnnouncementDto>> GetAnnouncement(int id)
        {
            var announcement = await _serviceManager.AnnouncementService.GetAnnouncementByIdAsync(id);
            
            if (announcement == null)
            {
                return NotFound();
            }

            return announcement;
        }

    }
}
