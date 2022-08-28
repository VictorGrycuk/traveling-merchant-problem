using System.Collections.Generic;
using System.Linq;

namespace TravelingMerchantProblem
{
    class Map
    {
        
        private readonly List<Node> nodes = new List<Node>();

        public void AddNode(Node node)
        {
            nodes.Add(node);

            for (int i = 0; i < nodes.Count - 1; i++)
            {
                var distance = GetRandomDistance();
                nodes[i].AddKnownNode(node, distance);
                node.AddKnownNode(nodes[i], distance);
            }
        }

        public Path GetNearestNeighborPath(Node initialNode) => new Path(initialNode.GetNearestNighbor(new List<Node>() { initialNode }));

        public List<Path> GetMultipleNearestNeighborPaths()
        {
            var paths = new List<Path>();
            foreach (Node node in nodes)
            {
                var path = GetNearestNeighborPath(node);
                paths.Add(path);
            }

            return paths.OrderBy(x => x.GetTotalDistance()).ToList();
        }

        public void GenerateNodes(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                AddNode(new Node("Node " + (char)(65 + i)));
            }
        }

        private int GetRandomDistance() => RNG.GetNewNumber(1, 1000);
    }
}
