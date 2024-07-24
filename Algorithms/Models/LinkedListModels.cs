namespace Algorithms.Models
{
    public class SinglyLinkedListNode
    {
        public int Data;
        public SinglyLinkedListNode Next;

        public SinglyLinkedListNode()
        {
        }
        public SinglyLinkedListNode(int nodeData)
        {
            Data = nodeData;
        }
        public SinglyLinkedListNode(int nodeData, SinglyLinkedListNode n)
        {
            Data = nodeData;
            Next = n;
        }
    }

    public class SinglyLinkedList
    {
        public SinglyLinkedListNode Head;
        public SinglyLinkedListNode Tail;

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }

            Tail = node;
        }
    }

    public class DoublyLinkedListNode
    {
        public int Data;
        public DoublyLinkedListNode Next;
        public DoublyLinkedListNode Prev;

        public DoublyLinkedListNode(int nodeData)
        {
            Data = nodeData;
            Next = null;
            Prev = null;
        }
    }

    public class DoublyLinkedList
    {
        public DoublyLinkedListNode Head;
        public DoublyLinkedListNode Tail;

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        public void InsertNode(int nodeData)
        {
            DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
            }

            Tail = node;
        }
    }
}
