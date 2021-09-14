using Microsoft.EntityFrameworkCore;
using RestauranteSaborDoBrasil.Domain.Core.Providers;
using System.Linq;

namespace RestauranteSaborDoBrasil.Infra.Data.Context
{
    public class ReadingDbContext : DbContext
    {
        protected const int DEFAULT_VARCHAR_LENGHT = 2000;
        private readonly DbSettings _dbSettings;

        public ReadingDbContext(DbContextOptions<ReadingDbContext> options, DbSettings dbSettings)
            : base(options)
        {
            _dbSettings = dbSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_dbSettings.ReadingConnectionString);

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Model.GetEntityTypes().ToList().ForEach(entityType =>
            {
                entityType.SetTableName(entityType.DisplayName());

                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);

                entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(string))
                    .Select(p => modelBuilder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name))
                    .ToList()
                    .ForEach(property =>
                    {
                        property.IsUnicode(false);
                        property.HasMaxLength(DEFAULT_VARCHAR_LENGHT);
                    });
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReadingDbContext).Assembly);
        }
    }
}
