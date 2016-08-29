using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDemo
{
    
    static class Sort
    {
        #region merge sort
        /// <summary>
        /// merge sort
        /// </summary>
        /// <param name="array"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        internal static void MergeSort(this int[] array, int i, int j)
        {
            // TODO Auto-generated method stub
            int mid = 0;
            if (i < j)
            {
                mid = (i + j) / 2;
                // Console.WriteLine("mid="+mid);
                MergeSort(array, i, mid);
                MergeSort(array, mid + 1, j);

                merge(array, i, mid, j);
            }
        }
        private static void merge(int[] arr, int i, int mid, int j)
        {
            Console.Write("Left part:");
            printArray(arr, i, mid);
            Console.Write(" Right part:");
            printArray(arr, mid + 1, j);
            Console.WriteLine();

            int[] temp = new int[arr.Length];
            int l = i;
            int r = j;
            int m = mid + 1;
            int k = l;

            while (l <= mid && m <= r)
            {
                if (arr[l] <= arr[m])
                {
                    temp[k++] = arr[l++];
                }
                else
                {
                    temp[k++] = arr[m++];
                }

            }
            while (l <= mid)
                temp[k++] = arr[l++];
            while (m <= r)
            {
                //Console.WriteLine("m="+m);
                temp[k++] = arr[m++];
            }

            for (int i1 = i; i1 <= j; i1++)
            {
                arr[i1] = temp[i1];
            }
            Console.Write("After Merge:");
            printArray(arr, i, j);
            Console.WriteLine();

        }
        private static void printArray(int[] arr, int i, int j)
        {
            Console.Write("[ ");
            for (int start = i; start <= j; start++)
                Console.Write(arr[start] + " ");
            Console.Write("]");
        }
        #endregion

        #region quick sort
        /// <summary>
        /// quick sort
        /// </summary>
        /// <param name="array"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        internal static void QuickSort(this int[] array, int i, int j)
        {
            if (i < j)
            {
                int pos = partition(array, i, j);
                QuickSort(array, i, pos - 1);
                QuickSort(array, pos + 1, j);
            }   
        }
        private static int partition(int[] arr, int i, int j)
        {
            int pivot = arr[j];
            int small = i - 1;
            for (int k = i; k < j; k++)
            {
                if (arr[k] <= pivot)
                {
                    small++;
                    swap(arr, k, small);
                }
            }
            swap(arr, j, small + 1);
            Console.WriteLine("Pivot= " + arr[small + 1]);
            Console.WriteLine(String.Join(" ", arr));
            return small + 1;
        }
        private static void swap(int[] arr, int k, int small)
        {
            int temp;
            temp = arr[k];
            arr[k] = arr[small];
            arr[small] = temp;
        }
        #endregion
    }
}
