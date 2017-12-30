using System;

namespace Presentation.DTOs
{
    public class TicketDTO
    {
        public Guid TrainId { get; set; }
        public string TrainCategory { get; set; }
        public string TrainNumber { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int Students { get; set;}
        public int Pet { get; set; }
        public string OriginStationName { get; set; }
        public string DestinationStationName { get; set; }
        public DateTime DepartureDate { get; set; }
        public long DepartureTime { get; set; }
        public long ArrivalTime { get; set; }
        public int Class { get; set; }
    }
}
