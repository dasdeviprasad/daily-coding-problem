using System;
using System.Collections.Generic;

namespace DailyCodingProblem
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            var productArray = FindProductArray(array);

            Console.WriteLine("Output >> " + string.Join(" | ", productArray));
        }

        public static int[] FindProductArray(int[] array) 
        {
            var output = new int[array.Length];
            var leftProduct = new int[array.Length];
            var rightProduct = new int[array.Length];

            int left = 1;
            int right = 1;
            for(int i = 0; i < array.Length; i++) {
                left *= array[i];
                right *= array[array.Length - i - 1];

                leftProduct[i] = left;
                rightProduct[array.Length - i - 1] = right;
            }

            for(int i = 0; i < output.Length; i++) {
                if(i == 0) {
                    output[i] = rightProduct[i+1];
                    continue;
                }

                if(i == output.Length - 1) {
                    output[i] = leftProduct[i-1];
                    continue;
                }

                output[i] = leftProduct[i-1] * rightProduct[i+1];
            }

            return output;
        }
    }
}