using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    /// <summary>
    /// Singly linked node class.
    /// </summary>
    class Node<T>
    {
        private T data;
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        private Node<T> next;
        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        public Node(T Data, Node<T> Next)
        {
            this.data = Data;
            this.next = Next;
        }
    }
}
