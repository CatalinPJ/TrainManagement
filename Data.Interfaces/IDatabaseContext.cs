using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistance
{
    public interface IDatabaseContext
    {
        int SaveChanges();
        DbSet<Data.Domain.Entities.Ticket> Tickets { get; set; }
        DbSet<Train> Trains { get; set; }
        DbSet<Station> Stations { get; set; }
        /*DbSet<Route> Routes { get; set; }
        DbSet<RouteNode> RouteNodes { get; set; }*/
    }
}
