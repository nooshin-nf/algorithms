using Algorithms.Models;

namespace Algorithms
{
    internal static class BinarySearchTree
    {

        private static List<Node> _nodes = new List<Node>();

        public static List<Node> KDistanceNodes(Node root, int k)
        {
            if (root == null)
                return _nodes;

            if (k == 0)
                _nodes.Add(root);

            KDistanceNodes(root.Left, k - 1);
            KDistanceNodes(root.Right, k - 1);
            return _nodes;
        }
    }
}
