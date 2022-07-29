using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadedMergeSort
{
    class MultiThreadedMergeSort
    {
        public static List<Thread> threads = new List<Thread>();
        private HashSet<int> threadsID;
        public Int64[] mergeSort(Int64[] array, int minElements) {
            // to check how we are considre the min elements
            // link to wiki that show how it is the propriate way to use fork https://en.wikipedia.org/wiki/Fork%E2%80%93join_model
            this.mergeSortRecursive(array, 0, array.Length - 1,minElements);
            return array;
        }

        // Merge two subarrays L and M into arr
        public void merge(Int64[] arr, long p, long q, long r)
        {

            // Create L ← A[p..q] and M ← A[q+1..r]
            long n1 = q - p + 1;
            long n2 = r - q;
            
            // the new two subarray
            Int64[] L = new Int64[n1];
            Int64[] M = new Int64[n2];

            int i, j;
            for ( i = 0; i < n1; i++)
                L[i] = arr[p + i];
            for ( j = 0; j < n2; j++)
                M[j] = arr[q + 1 + j];

            // Maintain current index of sub-arrays and main array
            long k;
            i = 0;
            j = 0;
            k = p;

            // Until we reach either end of either L or M, pick larger among
            // elements L and M and place them in the correct position at A[p..r]
            while (i < n1 && j < n2)
            {
                if (L[i] <= M[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = M[j];
                    j++;
                }
                k++;
            }

            // When we run out of elements in either L or M,
            // pick up the remaining elements and put in A[p..r]
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = M[j];
                j++;
                k++;
            }
        }



        // Divide the array into two subarrays, sort them and merge them
        public void mergeSortRecursive(Int64[] arr, long l, long r, int minElements)
        {
            if (l < r)
            {
                if (r - l > minElements)
                {
                    // m is the point where the array is divided into two subarrays
                    long m = (l + r) / 2;

                    //fork()
                    Thread threadLeft = new Thread(() => mergeSortRecursive(arr, l, m, minElements));
                    //to add to the set to see how much thread worked in the end 
                    //threadsID.Add(threadLeft.ManagedThreadId);
                    threadLeft.Start();


                    Thread threadRight = new Thread(() => mergeSortRecursive(arr, m + 1, r, minElements));
                    //threadsID.Add(threadLeft.ManagedThreadId);
                    threadRight.Start();

                    //join
                    // Merge the sorted subarrays
                    threadLeft.Join();
                    threadRight.Join();

                    merge(arr, l, m, r);
                }
                else
                {
                    // m is the point where the array is divided into two subarrays
                    long m = (l + r) / 2;

                    mergeSortRecursive(arr, l, m, minElements);
                  
                    mergeSortRecursive(arr, m + 1, r, minElements);

                    merge(arr, l, m, r);
                }
                
                
               
            }
        }

        // Print the array after merge sort
        public void printArray(Int64[] array)
        {
            for (int i = 0; i < array.Length; ++i)
                Console.WriteLine(array[i] + " ");
            Console.WriteLine();
        }
        

        /*public int HowMuchThread()
        { // maybe need +1 for the main thread
            return this.threadsID.Count;
        }*/
    }


}
