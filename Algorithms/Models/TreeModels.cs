namespace Algorithms.Models
{
    public class Tree
    {
        public Node Root;

        public Tree(int nodeData)
        {
            if (Root == null)
                Root = new Node(nodeData);
        }
        public void InsertNode(int nodeData)
        {
            var node = new Node(nodeData);
            var current = Root;
            var last = current;
            while (current != null)
            {
                last = current;
                if (nodeData > Root.Value)
                    current = current.Right;
                else current = current.Left;
            }
            if (nodeData > last.Value)
                last.Right = node;
            else last.Left = node;
        }
    }

    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Value = value;
        }
    }
}
