using Data.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Entities.Tariff
{
    public class Regio2TariffStrategy : ITariffStrategy
    {
        public static List<Tuple<int, int, float>> tariffs = new List<Tuple<int, int, float>>
        {
            new Tuple<int, int, float>(1, 10, 3.40f),
            new Tuple<int, int, float>(11, 20, 3.90f),
            new Tuple<int, int, float>(21, 30, 4.40f),
            new Tuple<int, int, float>(31, 40, 5.30f),
            new Tuple<int, int, float>(41, 50, 6.80f),
            new Tuple<int, int, float>(51, 60, 7.20f),
            new Tuple<int, int, float>(71, 80, 10.60f),
            new Tuple<int, int, float>(81, 90, 12.00f),
            new Tuple<int, int, float>(91, 100, 13.00f),
            new Tuple<int, int, float>(101, 120, 15.40f),
            new Tuple<int, int, float>(121, 140, 18.30f),
            new Tuple<int, int, float>(141, 160, 20.70f),
            new Tuple<int, int, float>(161, 180, 24.00f),
            new Tuple<int, int, float>(181, 200, 25.50f),
            new Tuple<int, int, float>(201, 250, 29.30f),
            new Tuple<int, int, float>(251, 300, 34.60f),
            new Tuple<int, int, float>(301, 350, 40.30f),
            new Tuple<int, int, float>(351, 400, 45.60f),
            new Tuple<int, int, float>(401, 500, 55.20f),
            new Tuple<int, int, float>(501, 600, 66.80f),
            new Tuple<int, int, float>(601, 700, 78.40f),
            new Tuple<int, int, float>(701, 800, 90.00f),
            new Tuple<int, int, float>(801, 900, 101.60f),
            new Tuple<int, int, float>(900, 1000, 113.20f)
        };

        public override string GetCategory()
        {
            return "R2";
        }

        public override List<Tuple<int, int, float>> GetTariffs()
        {
            return tariffs;
        }
    }
}