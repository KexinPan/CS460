using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class Program
    {

        static LinkedList<string> generateBinaryRepresentationList(int n)
        {
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();
            LinkedList<String> output = new LinkedList<String>();
            if (n < 1)
            {
                return output;
            }
            q.push(new StringBuilder("1"));
            while (n-- > 0)
            {
                StringBuilder sb = q.pop();
                output.AddLast(sb.ToString());
                StringBuilder sbc = new StringBuilder(sb.ToString());
                sb.Append('0');
                q.push(sb);
                sbc.Append('1');
                q.push(sbc);
            }
            return output;

        }
            static void Main(string[] args)
        {
            int n;
            if (args.Length < 1)
            {
                Console.WriteLine("Please invoke with the max value to print binary up to, like this:");
                Console.WriteLine("\tMain.exe 12");
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
            LinkedList<String> output = generateBinaryRepresentationList(n);
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
