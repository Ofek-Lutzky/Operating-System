using System;

namespace MultiThreadedMergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64[] array = { 2,6, 5, 12, 10, 9, 1,78,324,231,8,54 };

            MultiThreadedMergeSort ob = new MultiThreadedMergeSort();
            array = ob.mergeSort(array, 2);

            Console.WriteLine("Sorted array:");
            ob.printArray(array);
            //Console.WriteLine(ob.HowMuchThread());
        }
    }
}
