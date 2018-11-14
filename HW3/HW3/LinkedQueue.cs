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
    class LinkedQueue<T>: IQueueInterface<T>
    {
        private Node<T> front;
        private Node<T> rear;

        public LinkedQueue()
        {

            front = null;
            rear = null;
        }


        public T Push(T element)
        {
            if (element == null)
            {
                throw new NullReferenceException();
            }
            if (IsEmpty())
            /// if it's an empty linkedlist, create a node and it's value is element
            {
                Node<T> tmp = new Node<T>(element, null);

                front = rear = tmp;

            }
            else
            {
                ///general case
                Node<T> tmp = new Node<T>(element, null);
                rear.Next = tmp;
                rear = tmp;

            }
            return element;
        }
        public Boolean IsEmpty()
        {

            if (front == null & rear == null)
            {
                return true;
            }
            else
                return false;

        }
        public T Pop()
        {
            T tmp;
            if (IsEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when pop was invoked.");
            }
            /// one item in queue
            else if (front == rear)
            {
                tmp = front.Data;
                front = null;
                rear = null;
            }
            /// General case
            else
            {
                tmp = front.Data;
                front = front.Next;
            }
            return tmp;
        }
    }
}
