using System;
using System.Collections.Generic;
using System.Linq;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistance;

namespace Bussiness
{
    public class StationRepository : IStationRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public StationRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IReadOnlyList<Station> GetStations()
        {
            return _databaseContext.Stations.ToList();
        }

        public void CreateStation(Station station)
        {
            _databaseContext.Stations.Add(station);
            _databaseContext.SaveChanges();
        }

        public void DeleteStation(Guid stationId)
        {
            var station = GetStationById(stationId);
            _databaseContext.Stations.Remove(station);
            _databaseContext.SaveChanges();
        }

        public void EditStation(Station station)
        {
            _databaseContext.Stations.Update(station);
            _databaseContext.SaveChanges();
        }

        public Station GetStationById(Guid stationId)
        {
            return _databaseContext.Stations.FirstOrDefault(s => s.Id == stationId);
        }
    }
}