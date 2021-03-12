using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortAlgorithm.Model
{
    public class Manager
    {
        private Dictionary<int, int> lenghts;
        private Algorithms st;

        public Manager()
        {
            st = new Algorithms();
            lenghts = new Dictionary<int, int>
            {
                {1, 100},
                {2, 1000},
                {3, 10000}
            };
        }

        public void MergeSortExperiment()
        {
            List<String> data = new List<string>();

            int language = 2;
            int algorithm = 2;

            for (int j = 1; j < 4; j++)// i is the arrayLeght
            {
                for (int k = 1; k < 4; k++) //k is the arrayState
                {
                    int[] array = GenerateArray(j, k);

                    for (int i = 0; i < 100; i++)
                    {
                        var sw = new Stopwatch();
                        
                        long kbAtExecution = GC.GetTotalMemory(false) / 1024;

                        sw.Start();
                        // do stuff that uses memory here 
                        st.MergeSort(array, 0, (array.Length) - 1);
                        sw.Stop();

                        long kbAfter1 = GC.GetTotalMemory(false) / 1024;
                        long kbAfter2 = GC.GetTotalMemory(true) / 1024;

                        Console.WriteLine(kbAtExecution + " Started with this kb.");
                        Console.WriteLine(kbAfter1 + " After the test.");
                        Console.WriteLine(kbAfter1 - kbAtExecution + " Amt. Added.");
                        Console.WriteLine(kbAfter2 + " Amt. After Collection");
                        Console.WriteLine(kbAfter2 - kbAfter1 + " Amt. Collected by GC.");

                        var ts = sw.ElapsedMilliseconds;

                        string info = algorithm + "," + language + "," + j + "," + k + "," + ts;
                        data.Add(info);

                        Console.WriteLine("info: " + info);

                    }
                }
            }

            WriteData(data);
        }

        public void BubbleSortExperiment()
        {
            List<String> data = new List<string>();

            int language = 2;
            int algorithm = 1;

            for (int j = 1; j < 4; j++)// i is the array Size (10^2, 10^3, 10^4)
            {
                for (int k = 1; k < 4; k++) //k is the array State(random,descendent,ascendent)
                {
                    int[] array = GenerateArray(j, k);

                    for (int i = 0; i < 100; i++)
                    {
                        Stopwatch sw = new Stopwatch();

                        long kbAtExecution = GC.GetTotalMemory(false) / 1024;

                        sw.Start();
 
                        // do stuff that uses memory here 
                       
                        st.BubbleSort(array);
                        sw.Stop();

                        long kbAfter1 = GC.GetTotalMemory(false) / 1024;
                        long kbAfter2 = GC.GetTotalMemory(true) / 1024;

                        Console.WriteLine(kbAtExecution + " Started with this kb.");
                        Console.WriteLine(kbAfter1 + " After the test.");
                        Console.WriteLine(kbAfter1 - kbAtExecution + " Amt. Added.");
                        Console.WriteLine(kbAfter2 + " Amt. After Collection");
                        Console.WriteLine(kbAfter2 - kbAfter1 + " Amt. Collected by GC.");
                        var ts = sw.ElapsedMilliseconds;

                        string info = algorithm + "," + language + "," + j + "," + k + "," + ts;

                        Console.WriteLine("info: " + info);
                        data.Add(info);
                    }
                }
            }

            WriteData(data);
        }

        public int[] GenerateArray(int lenght, int status)
        {

            int size = lenghts[lenght];
            int[] array = new int[size];
            Random random = new Random();

            int max = int.MaxValue;
            int min = 0;

            switch (status)
            {
                case 2:
                    // orden descendiente
                    for(int i = 0; i < size; i++)
                    {
                        array[i] = size - i;
                    }
                    break;
                case 3:
                    //orden ascendente;
                    for (int i = 0; i < size; i++)
                    {
                        array[i] = i + 1; 
                    }
                    break;
                default:
                    //aleatorio
                    for (int i = 0; i < size; i++)
                    {
                        array[i] = random.Next(min,max);
                    }
                    break;
            }
            return array;
        }

        public void WriteData(List<string> data)
        {
        }
    }
}