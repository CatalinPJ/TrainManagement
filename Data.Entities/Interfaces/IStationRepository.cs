using System;
using System.Collections.Generic;
using Data.Domain.Entities;

namespace Data.Domain.Interfaces
{
    public interface IStationRepository
    {
        IReadOnlyList<Station> GetStations();
        void CreateStation(Station station);
        void DeleteStation(Guid stationId);
        void EditStation(Station station);
        Station GetStationById(Guid stationId);
    }
}