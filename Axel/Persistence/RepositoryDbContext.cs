using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class RepositoryDbContext : IdentityDbContext
    {

        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=J76PYD3\\SQLEXPRESS;Database=AxelDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<AccountGame> AccountGame { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Announcement> Announcement { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<GameCategory> GameCategory { get; set; }
        public DbSet<Screenshot> Screenshot { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Seed(_userManager, _roleManager);
        //}

    }
}
