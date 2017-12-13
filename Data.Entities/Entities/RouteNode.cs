using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Domain.Entities
{
    public class RouteNode
    {
        public RouteNode()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        [ForeignKey("Route")]
        public Guid RouteId { get; set; }
        public string Name { get; set; }
        public int OfficialCode { get; set; } // from CFR
        public int DestinationStationCode { get; set; }
        public int OriginStationCode { get; set; }
        public string DestinationStationName { get; set; }
        public string OriginStationName { get; set; }
        public int Km { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Standing { get; set; }  // in seconds
    }
}
