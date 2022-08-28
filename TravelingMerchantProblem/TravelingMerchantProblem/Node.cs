using System.Collections.Generic;
using System.Linq;

namespace TravelingMerchantProblem
{
    class Node
    {
        public readonly string Name;
        private readonly Dictionary<Node, int> knownNodes = new Dictionary<Node, int>();

        public Node(string name) => Name = name;

        public void AddKnownNode(Node node, int distance) => knownNodes.Add(node, distance);

        public int GetKnownDistance(Node node) => knownNodes[node];

        public List<Node> GetNearestNighbor(List<Node> nodes)
        {
            var nn = knownNodes.OrderBy(x => x.Value).ToList();

            foreach (var node in nn)
            {
                if (!nodes.Contains(node.Key))
                {
                    nodes.Add(node.Key);
                    return node.Key.GetNearestNighbor(nodes);
                }
            }

            // Se agrega el primer nodo para cerrar el loop del camino
            if (nodes.Count > 1) nodes.Add(nodes[0]);

            return nodes;
        }
    }
}
