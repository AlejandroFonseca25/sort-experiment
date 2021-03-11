﻿using System;
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
                        var timeOne = sw.ElapsedMilliseconds;
                        st.MergeSort(array, 0, (array.Length) - 1);
                        var timeTwo = sw.ElapsedMilliseconds;

                        sw.Stop();
                        var timeElapsed = timeTwo - timeOne;

                        string info = algorithm + "," + language + "," + j + "," + k;
                        data.Add(info);
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
                        sw.Start();
                        st.BubbleSort(array);
                        sw.Stop();
                        TimeSpan ts = sw.Elapsed;
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);

                        string info = algorithm + "," + language + "," + j + "," + k + "," + elapsedTime;
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

            for (int i = 0; i < size; i++)
            {
                int number = random.Next(min, max);
                array[i] = number;

                if (status == 2)//orden descendiente
                {
                    max = (number + max) / 2;
                }
                else if (status == 3)// orden ascendiente
                {
                    min = (min + number) / 2;
                }
            }

            return array;
        }

        public void WriteData(List<string> data)
        {
        }
    }
}