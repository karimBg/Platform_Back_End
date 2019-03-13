using BackEndAuthProj.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAuthProj.Data
{
    public class AppDbContext : IdentityDbContext<UserDb>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Internship> Internships { get; set; }
        public DbSet<GeneralInfo> Infos { get; set; }

    }
}
