using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Clinique2000.Models;

namespace Clinique2000.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Clinique2000.Models.medecin> medecin { get; set; }
        public DbSet<Clinique2000.Models.patient> patient { get; set; }
        public DbSet<Clinique2000.Models.Post> Post { get; set; }
    }
}
