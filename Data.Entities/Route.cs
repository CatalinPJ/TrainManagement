﻿using System;
using System.Collections.Generic;
namespace Data.Entities
{
    class Route
    {
        public Guid Id { get; set; }
        public int OriginStationCode { get; set; }
        public int DestinationStationCode { get; set; }
        public string Type { get; set; }
        List<Station> Nodes { get; set; }

    }
}
