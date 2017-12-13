using System;

namespace Data.Domain.Entities
{
    public class Station
    {
        public Station()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int OfficialCode { get; set; } // from CFR
        public static Station Create(string name, int officialCode)
        {
            var instance = new Station
            {
                Name = name,
                OfficialCode = officialCode
            };
            return instance;
        }
    }
}
