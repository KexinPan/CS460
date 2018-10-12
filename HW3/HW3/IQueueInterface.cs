using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    interface IQueueInterface<T>
    {
        T push(T element);

        T pop();

        Boolean isEmpty();

    }
}
