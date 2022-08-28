using System.Collections.Generic;
using System.Linq;

namespace TravelingMerchantProblem
{
    class Path
    {
        private readonly List<Node> nodes;

        public Path(List<Node> nodes) => this.nodes = nodes;

        public string GetPath() => string.Join(" -> ", nodes.Select(x => x.Name));

        public int GetTotalDistance()
        {
            var totalDistance = 0;
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                totalDistance += nodes[i].GetKnownDistance(nodes[i + 1]);
            }

            return totalDistance;
        }
    }
}
