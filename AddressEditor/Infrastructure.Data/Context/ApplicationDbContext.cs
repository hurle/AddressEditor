using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Address>(entity => 
            {
                entity.ToTable("Address", schema: "SalesLT");
                entity.HasKey(x => x.AddressId);
                entity.Property(x => x.City).HasColumnName("City");
                entity.Property(x => x.StateProvince).HasColumnName("StateProvince");
                entity.Property(x => x.AddressLine1).HasColumnName("AddressLine1");
                entity.Property(x => x.AddressLine2).HasColumnName("AddressLine2");
                entity.Property(x => x.CountryRegion).HasColumnName("CountryRegion");
                entity.Property(x => x.PostalCode).HasColumnName("PostalCode");
                entity.Property(x => x.RowGuid).HasColumnName("RowGuid");
                entity.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate");
            });
        }
    }
}
