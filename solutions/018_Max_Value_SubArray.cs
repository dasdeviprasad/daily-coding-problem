using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingProblem
{
    /*
    This problem was asked by Google.
    Given an array of integers and a number k, where 1 <= k <= length of the array, compute the maximum values of each subarray of length k.
    For example, given array = [10, 5, 2, 7, 8, 7] and k = 3, we should get: [10, 7, 8, 8], since:
    ```
    10 = max(10, 5, 2)
    7 = max(5, 2, 7)
    8 = max(2, 7, 8)
    8 = max(7, 8, 7)
    ```
    Do this in O(n) time and O(k) space. You can modify the input array in-place and you do not need to store the results. You can simply print them out as you compute them.
    */
    public class Program
    {
        public static void Main(string[] args) 
        {
            int k = 3;
            int[] array = new int[] {10, 5, 2, 7, 8, 7};

            var subarray = FindMaxValueSubArray(array, k);

            Console.WriteLine("Max value subarray of [" + string.Join(", ", array) + "] & k = " + k + " is: [" + string.Join(", ", subarray) + "].");
        }

        public static int[] FindMaxValueSubArray(int[] array, int k) 
        {
            if(array.Length == 0) { return new int[]{0}; }

            var queue = new List<int>();
            var output = new int[array.Length - k + 1];
            int idx = 0;

            for(int i = 0; i < array.Length; i++)
            {
                if(queue.Count > 0 && queue[0] == i-k) {
                    queue.RemoveAt(0);
                }

                while(queue.Count > 0 && array[i] > array[queue[queue.Count-1]]) {
                    queue.RemoveAt(queue.Count-1);
                }

                queue.Add(i);

                if(i >= k - 1) {
                    output[idx++] = array[queue[0]];
                }
            }

            return output;
        }
    }
}