using Data.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Domain.Entities.Tariff
{
    public class Regio1TariffStrategy : ITariffStrategy
    {
        private List<Tuple<int, int, float>> tariffs = new List<Tuple<int, int, float>>
        {
            new Tuple<int, int, float>(1, 10, 3.90f),
            new Tuple<int, int, float>(11, 20, 5.30f),
            new Tuple<int, int, float>(21, 30, 7.70f),
            new Tuple<int, int, float>(31, 40, 9.20f),
            new Tuple<int, int, float>(41, 50, 12.00f),
            new Tuple<int, int, float>(51, 60, 12.50f),
            new Tuple<int, int, float>(61, 70, 14.90f),
            new Tuple<int, int, float>(71, 80, 16.80f),
            new Tuple<int, int, float>(81, 90, 18.80f),
            new Tuple<int, int, float>(91, 100, 21.20f),
            new Tuple<int, int, float>(101, 120, 25.100f),
            new Tuple<int, int, float>(121, 140, 29.30f),
            new Tuple<int, int, float>(141, 160, 32.70f),
            new Tuple<int, int, float>(161, 180, 37.50f),
            new Tuple<int, int, float>(181, 200, 41.30f),
            new Tuple<int, int, float>(201, 250, 47.50f),
            new Tuple<int, int, float>(251, 300, 55.20f),
            new Tuple<int, int, float>(301, 350, 62.90f),
            new Tuple<int, int, float>(351, 400, 73.00f),
            new Tuple<int, int, float>(401, 500, 88.30f),
            new Tuple<int, int, float>(501, 600, 107.50f),
            new Tuple<int, int, float>(601, 700, 126.70f),
            new Tuple<int, int, float>(701, 800, 145.90f),
            new Tuple<int, int, float>(801, 900, 165.10f),
            new Tuple<int, int, float>(901, 1000, 184.30f),
        };

        public override string GetCategory()
        {
            return "R1";
        }

        public override List<Tuple<int, int, float>> GetTariffs()
        {
            return tariffs;
        }
    }
}
