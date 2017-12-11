using System;
using System.Collections.Generic;
namespace Data.Domain.Entities
{
    public class Route
    {

        public Route()
        {
            Id = Guid.NewGuid();
            RouteNodes = new List<RouteNode>();
        }

        public Guid Id { get; set; }
        public int OriginStationCode { get; set; }
        public int DestinationStationCode { get; set; }
        public string Type { get; set; }
        public List<RouteNode> RouteNodes { get; set; }

    }
}