using System;

namespace Data.Domain.Entities
{
    public class RouteNode : Station
    {
        public new Guid Id { get; set; }
        public int DestinationStationCode { get; set; }
        public int OriginStationCode { get; set; }
        public string DestinationStationName { get; set; }
        public string OriginStationName { get; set; }
        public int Km { get; set; }
        DateTime DepartureTime { get; set; }
        DateTime ArrivalTime { get; set; }
        public int Standing { get; set; }  // in seconds
    }
}
