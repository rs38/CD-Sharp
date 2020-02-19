using Microsoft.EntityFrameworkCore;


namespace BMW.Models
{
    public class BMWContext : DbContext
    {

        public BMWContext(DbContextOptions<BMWContext> options) : base(options)
        {
        }
        public DbSet<AppState> AppStates { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Vehiclestatus> Status { get; set; }
        public DbSet<Lasttrip> LastTrips { get; set; }
        public DbSet<Alltrips> AllTripsList { get; set; }
        public DbSet<SoCInfo> SoCInfos { get; set; }

    }


}



