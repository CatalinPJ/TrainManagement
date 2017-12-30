using Data.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Entities.Tariff
{
    public class InterRegio2TariffStrategy : ITariffStrategy
    {
        private List<Tuple<int, int, float>> tariffs = new List<Tuple<int, int, float>>
        {
            new Tuple<int, int, float>(1, 10, 7.70f),
            new Tuple<int, int, float>(11, 20, 8.20f),
            new Tuple<int, int, float>(21, 30, 9.20f),
            new Tuple<int, int, float>(31, 40, 10.60f),
            new Tuple<int, int, float>(41, 50, 13.00f),
            new Tuple<int, int, float>(51, 60, 14.00f),
            new Tuple<int, int, float>(61, 70, 18.30f),
            new Tuple<int, int, float>(71, 80, 20.70f),
            new Tuple<int, int, float>(81, 90, 23.60f),
            new Tuple<int, int, float>(91, 100, 26.00f),
            new Tuple<int, int, float>(101, 120, 30.80f),
            new Tuple<int, int, float>(121, 140, 35.60f),
            new Tuple<int, int, float>(141, 160, 40.30f),
            new Tuple<int, int, float>(161, 180, 44.70f),
            new Tuple<int, int, float>(181, 200, 48.50f),
            new Tuple<int, int, float>(201, 250, 55.70f),
            new Tuple<int, int, float>(251, 300, 62.40f),
            new Tuple<int, int, float>(301, 350, 68.70f),
            new Tuple<int, int, float>(351, 400, 75.40f),
            new Tuple<int, int, float>(401, 500, 86.90f),
            new Tuple<int, int, float>(501, 600, 97.00f),
            new Tuple<int, int, float>(601,700, 107.00f),
            new Tuple<int, int, float>(701, 800, 116.20f),
            new Tuple<int, int, float>(801, 900, 124.80f),
            new Tuple<int, int, float>(901, 1000, 133.40f),
        };
        public override string GetCategory()
        {
            return "IR2";
        }
        public override List<Tuple<int, int, float>> GetTariffs()
        {
            return tariffs;
        }
    }
}
