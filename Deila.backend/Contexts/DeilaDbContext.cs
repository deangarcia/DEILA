using deila.backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace deila.backend.Contexts
{
    public class DeilaDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Basis> Basiss { get; set; } = null!;

        public DeilaDbContext(DbContextOptions<DeilaDbContext> options) : base(options)
        {
            //Database.EnsureCreated(); 
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // Update timestamps for entities that inherit BaseEntity
                if (entry.Entity is BaseEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.UpdatedOn = utcNow;

                            // Set CreatedOn property as "don't touch" as it's not supposed to change
                            entry.Property("CreatedOn").IsModified = false;
                            break;

                        case EntityState.Added:
                            trackable.CreatedOn = utcNow;
                            trackable.UpdatedOn = utcNow;
                            break;
                    }
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basis>()
                 .HasData(
                new Basis()
                {
                    Id = 1,
                    Category = "Gender",
                    Incidents = 0
                },
                new Basis()
                {
                    Id = 2,
                    Category = "Race",
                    Incidents = 0
                },
                new Basis()
                {
                    Id = 3,
                    Category = "Disability",
                    Incidents = 0
                },
                new Basis()
                {
                    Id = 4,
                    Category = "Other",
                    Incidents = 0
                });

            base.OnModelCreating(modelBuilder);

           
        }
    }
}
