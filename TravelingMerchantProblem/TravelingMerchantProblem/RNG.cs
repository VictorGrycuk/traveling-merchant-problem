using System;

namespace TravelingMerchantProblem
{
    static class RNG
    {
        private static readonly Random rng = new Random();
        public static int GetNewNumber(int lowest, int highest) => rng.Next(lowest, highest);
    }
}
