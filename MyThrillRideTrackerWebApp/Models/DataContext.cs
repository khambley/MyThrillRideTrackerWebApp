using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyThrillRideTrackerWebApp.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<ImageFileName> ImageFileNames { get; set; }
        public DbSet<Park> Parks { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Visit> Visits { get; set; }

    }
}
