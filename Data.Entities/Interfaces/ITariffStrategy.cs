using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Domain.Interfaces
{
    public abstract class ITariffStrategy
    {
        private float adult_percent = 1;
        private float student_percent = 0;
        private float children_percent = 0.5f;
        private float bike_percent = 0.25f;
        private float pet_percent = 0.25f;

        public float ComputePrice(Ticket ticket, List<Tuple<int, int, float>> tariffs)
        {
            float distance = ticket.Km;
            int adults = ticket.Adults;
            int children = ticket.Children;
            int students = ticket.Students;
            int bike = ticket.Bike;
            int pet = ticket.Pet;
            float price = tariffs.FirstOrDefault(o => o.Item1 <= distance && o.Item2 >= distance).Item3;
            float tariff =
                (adults * adult_percent +
                children * children_percent +
                students * student_percent +
                bike * bike_percent +
                pet * pet_percent)
                * price;

            return tariff;
        }
        public abstract string GetCategory();
        public abstract List<Tuple<int, int, float>> GetTariffs();
    }
}
