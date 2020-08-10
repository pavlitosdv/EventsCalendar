using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventsCalendar.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Dataset> Datasets { get; set; }
        public DbSet<Snapshot> Snapshots { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}