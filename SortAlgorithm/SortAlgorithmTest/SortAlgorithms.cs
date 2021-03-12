using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAlgorithm.Model;
using System;
using System.Linq;

namespace SortAlgorithmTest
{
    [TestClass]
    public class SortAlgorithms
    {
        private int[] toTest;

        public void setup1()
        {
            toTest = new int[] { 3, 4, 7, 1, 8, 9, 5, 2, 6, 10 };
        }

        public void setup2()
        {
            toTest = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        }

        public void setup3()
        {
            toTest = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        }

        private Algorithms a = new Algorithms();

        [TestMethod]
        public void BubbleSortTest()
        {
            setup1();
            int[] orderedList = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            a.BubbleSort(toTest);

            Assert.IsTrue(Enumerable.SequenceEqual(toTest, orderedList));

            orderedList = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            setup2();
            a.BubbleSort(toTest);

            Assert.IsTrue(Enumerable.SequenceEqual(toTest, orderedList));

            orderedList = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            setup3();
            a.BubbleSort(toTest);

            Assert.IsTrue(Enumerable.SequenceEqual(toTest, orderedList));

            Random r = new Random();
            int[] randomInt = new int[10];
            for (int i = 0; i < randomInt.Length; i++)
            {
                randomInt[i] = r.Next(-50, 0);
            }

            int[] ordered = randomInt;

            Array.Sort(ordered);

            a.BubbleSort(randomInt);

            Assert.IsTrue(Enumerable.SequenceEqual(ordered, randomInt));
        }

        [TestMethod]
        public void MergeSortTest()
        {
            setup1();
            int[] orderedList = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            a.MergeSort(toTest, 0, toTest.Length - 1);

            Assert.IsTrue(Enumerable.SequenceEqual(toTest, orderedList));

            orderedList = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            setup2();
            a.MergeSort(toTest, 0, toTest.Length - 1);

            Assert.IsTrue(Enumerable.SequenceEqual(toTest, orderedList));

            orderedList = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            setup3();
            a.MergeSort(toTest, 0, toTest.Length - 1);

            Assert.IsTrue(Enumerable.SequenceEqual(toTest, orderedList));

            Random r = new Random();
            int[] randomInt = new int[10];
            for (int i = 0; i < randomInt.Length; i++)
            {
                randomInt[i] = r.Next(-50, 0);
            }

            int[] ordered = randomInt;

            Array.Sort(ordered);

            a.MergeSort(randomInt, 0, randomInt.Length - 1);

            Assert.IsTrue(Enumerable.SequenceEqual(ordered, randomInt));
        }
    }
}