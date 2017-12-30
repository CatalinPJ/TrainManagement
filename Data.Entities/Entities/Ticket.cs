using System;
namespace Data.Domain.Entities
{
    public class Ticket
    {
        public Ticket()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid TrainId { get; set; }
        public string TrainCategory { get; set; }
        public int Class { get; set; }
        public string TrainNumber { get; set; }
        public string OriginStationName { get; set; }
        public string DestinationStationName { get; set; }
        public Guid UserId { get; set; }
        public DateTime DepartureDate { get; set; }
        public long DepartureTime { get; set; }
        public long ArrivalTime { get; set; }
        public int Duration { get; set; }
        public int Km { get; set; }
        public int Adults { get; set; }  
        public int Children { get; set; }
        public int Students { get; set; }
        public int Pet { get; set; }
        public int Bike { get; set; }
        public int Car { get; set; }
        public int Seat { get; set; }
        public int Price { get; set; }
    }
}
