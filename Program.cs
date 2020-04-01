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

            using (var reader = new StreamReader(@"D:\Uni\Algorithms Task\unsorted_numbers.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    
                    listA.Add(int.Parse(line));
                    //Console.WriteLine(line + "     " + line[0]);
                }
            }

            int[] unsortedNumbers = listA.ToArray();
            int[] sortedNumbers = listA.ToArray();
            var array_size = unsortedNumbers.Length;

            InsertionSort(sortedNumbers, array_size);
            //ShellSort(unsortedNumbers, array_size);
            //Show_array_elements(sortedNumbers, unsortedNumbers, array_size);

            for (int i = 1; i < 10; i++)
            {
                int y = i * 1500;
                LinearSearch(unsortedNumbers, array_size, unsortedNumbers[y]);
            }

            for (int i = 1; i < 10; i++)
            {
                int y = i * 1500;
                LinearSearch(sortedNumbers, array_size, unsortedNumbers[y]);
            }

            for (int i = 1; i < 10; i++)
            {
                int y = i * 1500;
                BinarySearch(sortedNumbers, array_size, unsortedNumbers[y]);
            }

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }



        static void InsertionSort(int[] arr, int array_size)
        {
            int i, j;

            for (i = 0; i < array_size - 1; i++)
            {
                for(j = i + 1; j > 0; j--)
                {
                    if(arr[j - 1] > arr[j])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        static void ShellSort(int[] arr, int array_size)
        {
            int i, j, inc, temp;
            inc = 3;
            while (inc > 0)
            {
                for (i = 0; i < array_size; i++)
                {
                    j = i;
                    temp = arr[i];
                    while ((j >= inc) && (arr[j - inc] > temp))
                    {
                        arr[j] = arr[j - inc];
                        j = j - inc;
                    }
                    arr[j] = temp;
                }
                if (inc / 2 != 0)
                    inc = inc / 2;
                else if (inc == 1)
                    inc = 0;
                else
                    inc = 1;
            }
        }

        static void Show_array_elements(int[] arr, int[] arr2, int array_size)
        {
            int i;

            for(i = 0; i < array_size; i++)
            {
                Console.Write(arr[i] + " " + arr2[i]);
                Console.Write("\n");
            }

        }

        static void LinearSearch(int[] arr, int array_size, int searchedNum)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < array_size; i++)
            {
                if(arr[i] == searchedNum)
                {
                    Console.WriteLine("Searched Num: " + searchedNum + " found at position " + i);
                }
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedTicks;
            Console.WriteLine(elapsedMs);
        }

        static void BinarySearch(int[]sortedArr, int array_size, int searchedNum)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int min = 0;
            int max = array_size - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if(searchedNum == sortedArr[mid])
                {
                    Console.WriteLine("Searched Num: " + searchedNum + " found at position " + mid);
                    break;
                }
                else if(searchedNum < sortedArr[mid])
                {
                    max = mid - 1;
                } else
                {
                    min = mid + 1;
                }
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedTicks;
            Console.WriteLine(elapsedMs);
        }
    }
}
