using deila.backend.Entities;
using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IO;

namespace deila.backend.Contexts
{
    public class DeilaDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Basis> Basiss { get; set; } = null!;

        public DeilaDbContext(DbContextOptions<DeilaDbContext> options) : base(options)
        {
            // Production first time to populate need to add this
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
            /*
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open("Contexts/article_seeding_data.xlsx", FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader;

                reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);

                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };

                var dataSet = reader.AsDataSet(conf);

                var dataTable = dataSet.Tables[0];

                foreach (DataRow dr in dataTable.Rows)
                    {
                        modelBuilder.Entity<Article>()
                        .HasData(
                       new Article()
                       {
                           Id = int.Parse(dr["ID"].ToString()),
                           Title = dr["Title"].ToString(),
                           Content = dr["Content"].ToString(),
                           BasisId = int.Parse(dr["Basis"].ToString()),
                           Origin = dr["Origin"].ToString(),
                           Sentiment = bool.Parse(dr["Sentiment"].ToString())
                       });
                    }
            }
            base.OnModelCreating(modelBuilder);
            */
        }
    }
}