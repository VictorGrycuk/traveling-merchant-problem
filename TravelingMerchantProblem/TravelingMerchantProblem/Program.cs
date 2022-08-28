using System;

namespace TravelingMerchantProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Map();
            map.GenerateNodes(10);

            PrintMultiplePaths(map);
        }

        private static void PrintMultiplePaths(Map map)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var paths = map.GetMultipleNearestNeighborPaths();
            watch.Stop();

            foreach (Path path in paths)
            {
                Console.WriteLine(path.GetPath());
                Console.WriteLine("total distance: " + path.GetTotalDistance());
                Console.WriteLine();
            }

            Console.WriteLine($"Calculated in { watch.ElapsedMilliseconds }ms");

            Console.ReadLine();
        }
    }
}
