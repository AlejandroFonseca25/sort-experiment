using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SortAlgorithm.Model;
using System.Collections.Generic;

namespace SortAlgorithmTest
{

    [TestClass]
    public class SortAlgorithms
    {
        private int[] toTest;

        public void setup1() {

           toTest = new int[] { 3,4,7,1,8,9,5,2,6,10 };

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
           int[] orderedList = new int[] { 1,2,3,4,5,6,7,8,9,10 };
           a.BubbleSort(toTest);
        
           Assert.AreEqual(toTest.ToString(), orderedList.ToString());

            setup2();
            a.BubbleSort(toTest);

            Assert.AreEqual(toTest.ToString(), orderedList.ToString());

            setup3();
            a.BubbleSort(toTest);

            Assert.AreEqual(toTest.ToString(), orderedList.ToString());
        }

        [TestMethod]
        public void MergeSortTest()
        {

            setup1();
            int[] orderedList = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            a.MergeSort(toTest, 0, 9);

            Assert.AreEqual(toTest.ToString(), orderedList.ToString());

            setup2();
            a.MergeSort(toTest, 0, 7);

            Assert.AreEqual(toTest.ToString(), orderedList.ToString());

            setup3();
            a.MergeSort(toTest, 0, 9);

            Assert.AreEqual(toTest.ToString(), orderedList.ToString());
        }
    }
}
