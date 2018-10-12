using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    /// <summary>
    /// A FIFO queue interface. This ADT is suitable for a singly linked queue.
    /// </summary>
    interface IQueueInterface<T>
    {
        /// <summary>
        /// Add an element to the rear of the queue.
        /// </summary>
        /// <returns>
        /// the element that was enqueued.
        /// </returns>
        T push(T element);

        ///<summary>
        ///Remove and return the front element.
        ///</summary>
        /// <exception cref="QueueUnderflowException">
        /// Thrown if the queue is empty.
        /// </exception>
        T pop();

        /// <summary>
        ///Test if the queue is empty
        /// </summary>
        /// <return>
        /// return true if the queue is empty; otherwise false
        ///</return>
        Boolean isEmpty();

    }
}
