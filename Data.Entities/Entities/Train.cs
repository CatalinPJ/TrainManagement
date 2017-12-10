using System;

namespace Data.Domain.Entities
{
    public class Train
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public int CumulatedKm { get; set; }
        public string OfficialNumber { get; set; } // from CFR
        public int Length { get; set; }
        public int OperatorCode { get; set; }
        public int OwnerCode { get; set; }
        public int Rank { get; set; }
        public int Weight { get; set; }
    }
}
