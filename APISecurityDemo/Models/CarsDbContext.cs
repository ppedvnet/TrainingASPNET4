using System.Data.Entity;

namespace APISecurityDemo.Models
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext() : base("name=CarRentalDBConnectionString")
        {
        }

        public virtual DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            base.OnModelCreating(modelBuilder);
        }
    }
}