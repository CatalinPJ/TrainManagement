using System;
using System.Collections.Generic;
using System.Text;
using Data.Domain.Entities.Tariff;
using Data.Domain.Interfaces;
using System.Linq;
using Data.Domain.Entities;

namespace Services
{
    public class PriceComputer
    {
        static ITariffStrategy[] strategies = new ITariffStrategy[]
        {
            new Regio1TariffStrategy(),
            new Regio2TariffStrategy(),
            new InterRegio1TariffStrategy(),
            new InterRegio2TariffStrategy()
        };

        public float GetPrice(Ticket ticket)
        {
            ITariffStrategy strategy = strategies.FirstOrDefault(o => o.GetCategory() == ticket.TrainCategory + ticket.Class.ToString());
            if (strategy != null)
                return strategy.ComputePrice(ticket, strategy.GetTariffs());
            return -1;
        }
    }
}
