﻿using System;
namespace Data.Domain.Entities
{
    public class Ticket
    {
        public Ticket()
        {

        }
        public Guid Id { get; set; }
        public Guid TrainId { get; set; }
        public Guid UserId { get; set; }
        public Guid OriginStationId { get; set; }
        public Guid DestinationStationId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Duration { get; set; }
        public int Km { get; set; }
        public string Type { get; set; }  //adult/ children/ student
        public int Pet { get; set; }
        public int Bike { get; set; }
        public int Car { get; set; }
        public int Seat { get; set; }
        public int Price { get; set; }
    }
}