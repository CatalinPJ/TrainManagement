using System;

namespace Data.Domain.Entities
{
    public class Station
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int OfficialCode { get; set; } // from CFR
    }
}
