using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingProblem
{
    /*
    A builder is looking to build a row of N houses that can be of K different colors.
    He has a goal of minimizing cost while ensuring that no two neighboring houses are of the same color.
    Given an N by K matrix where the nth row and kth column represents the cost to build the nth house with kth color,
    return the minimum cost which achieves this goal
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