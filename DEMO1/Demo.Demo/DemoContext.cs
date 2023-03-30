using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Demo
{
    public class DemoContext : DbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public DemoContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(b => b.Tickets)
                .WithOne(t => t.Customer);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Ticket> tickets { get; set; }
    }
}