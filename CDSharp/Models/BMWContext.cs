using Microsoft.EntityFrameworkCore;


namespace BMW.Models
{
    public class BMWContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = BMW2; Integrated Security = True; MultipleActiveResultSets = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avgcombinedconsumption>()
                .HasNoKey();

            modelBuilder.Entity<Avgelectricconsumption>()
               .HasNoKey();

            modelBuilder.Entity<Position>()
              .HasNoKey();

            modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.vin);
        }   


        public DbSet<AppState> AppStates { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Vehiclestatus> Status { get; set; }
        public DbSet<Lasttrip> LastTrips { get; set; }
        public DbSet<Alltrips> AllTripsList { get; set; }
        public DbSet<SoCInfo> SoCInfos { get; set; }

    }


}



