using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistance
{
    public interface IDatabaseContext
    {
        int SaveChanges();
        DbSet<Data.Domain.Entities.Ticket> Tickets { get; set; }
        DbSet<Data.Domain.Entities.Train> Trains { get; set; }
        DbSet<Data.Domain.Entities.Station> Stations { get; set; }
        DbSet<Data.Domain.Entities.RouteNode> RouteNodes { get; set; }
        DbSet<Data.Domain.Entities.Route> Routes { get; set; }
    }
}
