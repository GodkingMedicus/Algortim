using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listA = new List<int>();

            using (var reader = new StreamReader(@"C:\Users\Jayde\Desktop\Uni\Weekly Tasks\Algorithms Task\unsorted_numbers.csv"))
            {
                //int[] intarray = new int[];
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    listA.Add(line[0]);
                }
            }

            listA.ForEach(Console.WriteLine);

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();

        }
    }
}
