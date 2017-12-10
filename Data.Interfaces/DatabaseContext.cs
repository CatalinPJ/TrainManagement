using Data.Domain.Entities;
using Data.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistance
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        /*public DbSet<Train> Trains { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteNode> RouteNodes { get; set; }*/
        public DbSet<Data.Domain.Entities.Ticket> Tickets { get; set; }
    }
}
