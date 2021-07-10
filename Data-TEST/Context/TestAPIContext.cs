using Data_TEST.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data_TEST.Context
{
    public class TestAPIContext : DbContext
    {
        public TestAPIContext(DbContextOptions<TestAPIContext> opt) : base(opt)
        {

        }

        // qui va la lista dei models
        public DbSet<Item> Items { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        // per definire relazioni e chiavi primarie

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Fluent API
            // per definire chiavi primarie
            modelBuilder
                .Entity<Item>()
                .HasKey(e => e.Id);
            modelBuilder
                .Entity<Warehouse>()
                .HasKey(e => e.Id);

            // per chiave esterna
            modelBuilder
                .Entity<Warehouse>()
                .HasMany(e => e.Items)
                .WithOne(e => e.Warehouse);
            #endregion
        }

        // nel caso in cui si volessero personalizzare i dati prima della commit si usa questo 
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}