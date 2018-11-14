using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Original by Sumit Ghosh "An Interesting Method to Generate Binary Numbers from 1 to n"
/// at https://www.geeksforgeeks.org/interesting-method-generate-binary-numbers-1-n/
/// Adapted for CS 460 HW3.  This simple example demonstrates the rather powerful application of Breadth-First Search to enumeration of states problems.
/// There are easier ways to generate a list of binary values, but this technique is very general and a good one to remember for other uses.
/// </summary>
namespace HW3
{
    ///<summary>
    ///Print the binary representation of all numbers from 1 up to n.
    /// This is accomplished by using a FIFO queue to perform a level 
    /// order (i.e. BFS) traversal of a virtual binary tree that 
    /// looks like this:
    ///                1
    ///             /       \
    ///            10       11
    ///           /  \     /  \
    ///        100  101  110  111
    ///         etc.
    /// and then storing each "value" in a list as it is "visited".
    ///</summary>
    class Program
    {
        
        static LinkedList<string> GenerateBinaryRepresentationList(int n)
        {
            ///<value> 
            ///Create an empty queue of strings with which to perform the traversal
            ///</value>
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();
            ///<value> 
            ///A list for returning the binary values
            ///</value>
            LinkedList<String> output = new LinkedList<String>();
            if (n < 1)
            {
                ///<return>
                /// binary representation of negative values is not supported return an empty list
                ///</return>
                return output;
            }
            /// Enqueue the first binary number.  Use a dynamic string to avoid string concat
            q.Push(new StringBuilder("1"));

            /// BFS 
            while (n-- > 0)
            {
                /// print the front of queue 
                StringBuilder sb = q.Pop();
                output.AddLast(sb.ToString());

                /// Make a copy
                StringBuilder sbc = new StringBuilder(sb.ToString());
                /// Left child
                sb.Append('0');
                q.Push(sb);
                /// Right child
                sbc.Append('1');
                q.Push(sbc);
            }
            return output;

        }
        ///<summary>
        /// Driver program to test above function 
        ///</summary>
        static void Main(string[] args)
        {
            int n;
            if (args.Length < 1)
            {
                Console.WriteLine("Please invoke with the max value to print binary up to, like this:");
                Console.WriteLine("\tHW3.exe 12");
                return;
            }
            try
            {  /// convert string to int
                n = System.Convert.ToInt32(args[0]);
            }
            catch (FormatException e)
            {
                Console.WriteLine("I'm sorry, I can't understand the number: " + args[0]);
                return;
            }
            LinkedList<String> output = GenerateBinaryRepresentationList(n);
            ///<summary>
            ///Print it right justified.  Longest string is the last one.
            ///Print enough spaces to move it over the correct distance
            ///</summary>
            int maxLength = output.Last.Value.Length;
            foreach (String s in output)
            {
                for (int i = 0; i < maxLength - s.Length; ++i)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(s);
            }
        }
    }
}
