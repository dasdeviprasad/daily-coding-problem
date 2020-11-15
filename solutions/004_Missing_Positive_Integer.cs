using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingProblem
{
    /*
    Given an array of integers, find the first missing positive integer in linear time and constant space. 
    In other words, find the lowest positive integer that does not exist in the array. 
    The array can contain duplicates and negative numbers as well.
    For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.
    */
    public class Program
    {
        public static void Main(string[] args) 
        {
            int[] array = new int[] { 3, 4, -1, 1 };
            var missingNum = GetMissingNumber(array);

            Console.WriteLine("Missing Number: " + missingNum);
        }

        public static int GetMissingNumber(int[] array) 
        {
            // Segregate the array into +ve & -ve array.
            int i = 0;
            int j = array.Length - 1;
            while(i < j)
            {
                if(array[i] > 0 && array[j] <= 0) {
                    Swap(array, i, j);
                }

                if(array[i] <= 0) { i++; }
                if(array[j] > 0) { j--; }
            }

            // Till position i-1, all negative numbers are there.
            int[] positiveArray = array.Skip(i).Take(array.Length).ToArray();
            foreach(var item in positiveArray) {
                if(item <= positiveArray.Length) {
                    positiveArray[Math.Abs(item) - 1] = -(positiveArray[Math.Abs(item) - 1]);
                }
            }

            for(int idx = 0; i < positiveArray.Length; idx++) {
                if(positiveArray[idx] > 0) {
                    return idx + 1;
                }
            }

            return -1;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}