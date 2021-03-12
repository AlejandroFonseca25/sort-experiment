using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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
                        
                        long kbAtExecution = GC.GetTotalMemory(true) / 1024;

                        sw.Start();
                        // do stuff that uses memory here 
                        st.MergeSort(array, 0, (array.Length) - 1);
                        sw.Stop();

                        long kbAfter1 = GC.GetTotalMemory(true) / 1024;
                        long memoryUsed = kbAfter1 - kbAtExecution;

                        var ts = sw.ElapsedMilliseconds;

                        string info = algorithm + "," + language + "," + j + "," + k + "," + ts + ","+memoryUsed;
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

                        long kbAtExecution = GC.GetTotalMemory(true) / 1024;

                        sw.Start();
                        st.BubbleSort(array);
                        sw.Stop();

                        long kbAfter1 = GC.GetTotalMemory(true) / 1024;
                        long memoryUsed = kbAfter1 - kbAtExecution;

                        var ts = sw.ElapsedMilliseconds;

                        string info = algorithm + "," + language + "," + j + "," + k + "," + ts+ "," + memoryUsed;

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
            var file = @"C:\Users\prestamo\Documents\GitHub\sort-experiment\SortAlgorithm\SortAlgorithm\Data\Output.csv";
            using (var stream = File.CreateText(file))
            {
                foreach (string current in data)
                {
                    string[] array = current.Split(',');

                    string algorithm = array[0];
                    string language = array[1];
                    string arraySize = array[2];
                    string status = array[3];
                    string time = array[4];
                    string memory = array[5];

                    string csvRow = string.Format("{0},{1},{2},{3},{4},{5}", algorithm,language,arraySize,status,time,memory);

                    stream.WriteLine(csvRow);
                }
            }
        }
    }
}