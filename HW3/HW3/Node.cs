﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class Node<T>
    {
        public T data;
        public Node<T> next;

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;

        }
    }
}
