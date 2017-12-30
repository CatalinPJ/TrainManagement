using Data.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Entities.Tariff
{
    public class InterRegio1TariffStrategy : ITariffStrategy
    {
        private List<Tuple<int, int, float>> tariffs = new List<Tuple<int, int, float>>
        {
            new Tuple<int, int, float>(1, 10, 10.60f),
            new Tuple<int, int, float>(11, 20, 12.50f),
            new Tuple<int, int, float>(21, 30, 14.40f),
            new Tuple<int, int, float>(31, 40, 16.80f),
            new Tuple<int, int, float>(41, 50, 20.20f),
            new Tuple<int, int, float>(51, 60, 22.10f),
            new Tuple<int, int, float>(61, 70, 27.90f),
            new Tuple<int, int, float>(71, 80, 31.70f),
            new Tuple<int, int, float>(81, 90, 35.10f),
            new Tuple<int, int, float>(91, 100, 38.90f),
            new Tuple<int, int, float>(101, 120, 46.10f),
            new Tuple<int, int, float>(121, 140, 52.80f),
            new Tuple<int, int, float>(141, 160, 59.50f),
            new Tuple<int, int, float>(161, 180, 66.30f),
            new Tuple<int, int, float>(181, 200, 72.50f),
            new Tuple<int, int, float>(201, 250, 84.50f),
            new Tuple<int, int, float>(251, 300, 95.50f),
            new Tuple<int, int, float>(301, 350, 105.60f),
            new Tuple<int, int, float>(350, 400, 117.60f),
            new Tuple<int, int, float>(401, 500, 136.30f),
            new Tuple<int, int, float>(501, 600, 150.70f),
            new Tuple<int, int, float>(601, 700, 163.20f),
            new Tuple<int, int, float>(701, 800, 174.20f),
            new Tuple<int, int, float>(801, 900, 183.80f),
            new Tuple<int, int, float>(901, 1000, 192.90f)
        };

        public override string GetCategory()
        {
            return "IR1";
        }

        public override List<Tuple<int, int, float>> GetTariffs()
        {
            return tariffs;
        }
    }
}
