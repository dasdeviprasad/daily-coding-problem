using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingProblem
{
    /*
    This problem was asked by Amazon.
    There exists a staircase with N steps, and you can climb up either 1 or 2 steps at a time. Given N, write a function that returns the number of unique ways you can climb the staircase. The order of the steps matters.
    For example, if N is 4, then there are 5 unique ways:
    1, 1, 1, 1
    2, 1, 1
    1, 2, 1
    1, 1, 2
    2, 2
    What if, instead of being able to climb 1 or 2 steps at a time, you could climb any number from a set of positive integers X? For example, if X = {1, 3, 5}, you could climb 1, 3, or 5 steps at a time.
    */
    public class Program
    {
        public static void Main(string[] args) 
        {
            int steps = 4;
            int[] combinations = new int[] {1, 2};

            var sum = FindCombinations(combinations, steps);

            Console.WriteLine("Number of ways to climb '" + steps + "' staircases with [" + string.Join(",", combinations) + "]: " + sum);
        }

        public static int FindCombinations(int[] combinations, int steps) 
        {
            if(steps == 0) { return 1; }

            int sum = 0;
            foreach(var com in combinations) {
                if(steps >= com) {
                    sum += FindCombinations(combinations, steps-com);
                }
            }

            return sum;
        }
    }
}