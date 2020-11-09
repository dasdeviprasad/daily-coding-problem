using System;
using System.Collections.Generic;

namespace DailyCodingProblem
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            int[] array = new int[] { 10, 15, 3, 7 };
            var sumExist = IsSumExist(array, target: 17);

            Console.WriteLine("Sum Exists: " + sumExist);
        }

        public static bool IsSumExist(int[] array, int target) 
        {
            var hash = new HashSet<int>();
            for(int i = 0; i < array.Length; i++) {
                int diff = target - array[i];
                if(hash.Contains(diff)) {
                    return true;
                }

                hash.Add(array[i]);
            }

            return false;
        }
    }
}