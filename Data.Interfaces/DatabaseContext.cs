using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistance
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Data.Domain.Entities.Train> Trains { get; set; }
        public DbSet<Data.Domain.Entities.RouteNode> RouteNodes { get; set; }
        public DbSet<Data.Domain.Entities.Station> Stations { get; set; }
        public DbSet<Data.Domain.Entities.Ticket> Tickets { get; set; }
        public DbSet<Data.Domain.Entities.Notification> Notifications { get; set; }
    }
}
