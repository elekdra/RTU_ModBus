
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using testBackend.Models;

namespace testBackend.Data
{


    public class DeviceDetailsContext : DbContext
    {
        public DeviceDetailsContext(DbContextOptions<DeviceDetailsContext> options) : base(options)
        {
        }
        public DbSet<DeviceTypeModel> CPSHeaders { get; set; }
        public DbSet<DeviceDetailsModel> CPSDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceDetailsModel>()
                .HasKey(c => new { c.deviceId });
            modelBuilder.Entity<DeviceTypeModel>()
           .HasKey(c => new { c.deviceId });
        }
        public IList<DeviceDetailsModel> getCPSDetails(int id)
        {

            return null;
        }

    }
}
