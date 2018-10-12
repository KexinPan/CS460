using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class QueueUnderflowException: SystemException
    {

        public QueueUnderflowException() : base()
        {

        }

        public QueueUnderflowException(string message) : base(message)
        {
        }

    }
}
