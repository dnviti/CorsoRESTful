using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Context
{
    public class CorsoRESTDbContext : DbContext
    {
        public CorsoRESTDbContext(DbContextOptions<CorsoRESTDbContext> opt) : base(opt)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<ShopMovie> ShopMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Fluent API
            // Key Definitions
            modelBuilder
                .Entity<Movie>()
                .HasKey(p => p.Id);
            modelBuilder
                .Entity<Author>()
                .HasKey(p => p.Id);
            modelBuilder
                .Entity<Actor>()
                .HasKey(p => p.Id);
            modelBuilder
                .Entity<Shop>()
                .HasKey(p => p.Id);
            modelBuilder
                .Entity<ActorMovie>()
                .HasKey(p => new { p.ActorId, p.MovieId });
            modelBuilder
                .Entity<ShopMovie>()
                .HasKey(p => new { p.ShopId, p.MovieId });

            // Relation Definition
            modelBuilder
                .Entity<Movie>()
                .HasOne(p => p.Author)
                .WithMany(p => p.Movies);

            modelBuilder
                .Entity<Author>()
                .HasMany(p => p.Movies)
                .WithOne(p => p.Author);

            modelBuilder
                .Entity<Movie>()
                .HasMany(p => p.Actors)
                .WithMany(p => p.Movies)
                .UsingEntity(p => p.ToTable("ActorMovie"));

            modelBuilder
                .Entity<Movie>()
                .HasMany(p => p.Shops)
                .WithMany(p => p.Movies)
                .UsingEntity(p => p.ToTable("ShopMovie"));
            #endregion
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            //----- Give the ability to modify column values on the fly
            #region DefaultValuesForColumns
            var AddedEntities = ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Added)
                .ToList();

            AddedEntities.ForEach(e =>
            {
                try
                {
                    e.Property("UniqueIdentifier").CurrentValue = Guid.NewGuid();
                    e.Property("CreatedOn").CurrentValue = DateTime.Now;
                    e.Property("ModifiedOn").CurrentValue = DateTime.Now;
                }
                catch { }
            });

            var EditedEntities = ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Modified)
                .ToList();

            EditedEntities.ForEach(e =>
            {
                try
                {
                    e.Property("ModifiedOn").CurrentValue = DateTime.Now;
                }
                catch { }
            });
            #endregion
            //---------------------

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}
