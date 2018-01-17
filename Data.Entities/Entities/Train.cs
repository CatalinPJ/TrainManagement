using System;
using System.Collections.Generic;

namespace Data.Domain.Entities
{
    public class Train
    {
        public Train()
        {
            Id = Guid.NewGuid();
            RouteNodes = new List<RouteNode>();
            Wagons = new List<Wagon> { new Wagon() { Class = 1 }, new Wagon() { Class = 2 } };
        }

        public Guid Id { get; set; }
        public string Category { get; set; }
        public int CumulatedKm { get; set; }
        public string OfficialNumber { get; set; } // from CFR
        public int Length { get; set; }
        public int OperatorCode { get; set; }
        public int OwnerCode { get; set; }
        public int Rank { get; set; }
        public int Weight { get; set; }
        public int OriginStationCode { get; set; }
        public int DestinationStationCode { get; set; }
        public string OriginStationName { get; set; }
        public string DestinationStationName { get; set; }
        public long DepartureTime { get; set; }
        public long ArrivalTime { get; set; }
        public List<RouteNode> RouteNodes { get; set; }
        public List<Wagon> Wagons { get; set; }
    }
}
