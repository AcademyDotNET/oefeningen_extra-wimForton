using System;

namespace SortingApplication
{
    enum SortingAlgorithm
    {
        BubbleSort,
        ShakerSort,
        QuickSort
    }
    class SortingAlgorithmProgram
    {
        static void Main(string[] args)
        {
            int[] array = { 88, 12, 55, 105, 48, 84, 66, 35, 57, 89, 74, 106, 200, 541, 1, 9, 7, 55, 405, 13 };
            int[] array2 = { 88, 12, 55, 105, 48, 84, 66, 35, 57, 89, 74, 106, 200, 541, 1, 9, 7, 55, 405, 13 };
            int[] array3 = { 88, 12, 55, 105, 48, 84, 66, 35, 57, 89, 74, 106, 200, 541, 1, 9, 7, 55, 405, 13 };

            var myShakerSortStrategy = new ShakerSort();
            var myBubbleSortStrategy = new BubbleSort();
            var myQuickSortStrategy = new QuickSort();

            var mySorter = new Sorter(myBubbleSortStrategy);
            mySorter.Sort(array);
            WriteArray.Write(array);
            mySorter.Strategy = myQuickSortStrategy;
            mySorter.Sort(array2);
            WriteArray.Write(array2);
            mySorter.Strategy = myShakerSortStrategy;
            mySorter.Sort(array3);
            WriteArray.Write(array3);
        }
    }
}
