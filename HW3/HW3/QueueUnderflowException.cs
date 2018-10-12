using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    /// <summary>
    /// A custom unchecked exception to represent situations where an illegal operation was performed on an empty queue.
    /// </summary>
    class QueueUnderflowException : SystemException
    {

        public QueueUnderflowException() : base()
        {

        }

        public QueueUnderflowException(string message) : base(message)
        {
        }

    }
}
