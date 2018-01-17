using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistance
{
    public interface IDatabaseContext
    {
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet<Data.Domain.Entities.Ticket> Tickets { get; set; }
        DbSet<Data.Domain.Entities.Train> Trains { get; set; }
        DbSet<Data.Domain.Entities.Station> Stations { get; set; }
        DbSet<Data.Domain.Entities.RouteNode> RouteNodes { get; set; }
        DbSet<Data.Domain.Entities.Notification> Notifications { get; set; }
        DbSet<Data.Domain.Entities.Payment> Payments { get; set; }
        DbSet<Data.Domain.Entities.Wagon> Wagons { get; set; }
        DbSet<Data.Domain.Entities.News> News { get; set; }
    }
}
