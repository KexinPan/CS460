using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    /// <summary>
    /// A Singly Linked FIFO Queue.  
    /// From Dale, Joyce and Weems "Object-Oriented Data Structures Using Java"
    /// Modified for CS 460 HW3, Convert Java to C#
    /// See QueueInterface.cs for documentation
    ///</summary>
    class LinkedQueue<T>
    {
        private Node<T> front;
        private Node<T> rear;

        public LinkedQueue()
        {

            front = null;
            rear = null;
        }


        public T push(T element)
        {
            if (element == null)
            {
                throw new NullReferenceException();
            }
            if (isEmpty())
            /// if it's an empty linkedlist, create a node and it's value is element
            {
                Node<T> tmp = new Node<T>(element, null);

                front = rear = tmp;

            }
            else
            {
                ///general case
                Node<T> tmp = new Node<T>(element, null);
                tmp.data = element;
                rear.next = tmp;
                rear = tmp;

            }
            return element;
        }
        public Boolean isEmpty()
        {

            if (front == null & rear == null)
            {
                return true;
            }
            else
                return false;

        }
        public T pop()
        {
            T tmp;
            if (isEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when pop was invoked.");
            }
            /// one item in queue
            else if (front == rear)
            {
                tmp = front.data;
                front = null;
                rear = null;
            }
            /// General case
            else
            {
                tmp = front.data;
                front = front.next;
            }
            return tmp;
        }
    }
}
