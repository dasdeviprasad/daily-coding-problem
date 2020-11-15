using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingProblem
{
    /*
    This problem was asked by Airbnb.
    Given a list of integers, write a function that returns the largest sum of non-adjacent numbers. Numbers can be 0 or negative.
    For example, [2, 4, 6, 8] should return 12, since we pick 4 and 8. [5, 1, 1, 5] should return 10, since we pick 5 and 5.
    */
    public class Program
    {
        public static void Main(string[] args) 
        {
            int[] array = new int[] {2, 4, 6, 8};
            int[] array2 = new int[] {5, 1, 1, 5};
            var sum = GetNonAdjacentSum(array);
            var sum2 = GetNonAdjacentSum(array2);

            Console.WriteLine("Largest non-adjacent sum of [" + string.Join(", ", array) + "]: " + sum);
            Console.WriteLine("Largest non-adjacent sum of [" + string.Join(", ", array2) + "]: " + sum2);
        }

        public static int GetNonAdjacentSum(int[] array) 
        {
            int[] sum = new int[array.Length];
            sum[0] = array[0];
            sum[1] = Math.Max(array[0], array[1]);

            for(int i = 2; i < array.Length; i++) {
                int temp = Math.Max(array[i], array[i] + sum[i-2]);
                sum[i] = Math.Max(temp, sum[i-1]);
            }

            return sum[array.Length - 1];
        }
    }
}