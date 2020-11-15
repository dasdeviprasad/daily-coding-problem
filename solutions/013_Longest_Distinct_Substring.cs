using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingProblem
{
    /*
    This problem was asked by Amazon.
    Given an integer k and a string s, find the length of the longest substring that contains at most k distinct characters.
    For example, given s = "abcba" and k = 2, the longest substring with k distinct characters is "bcb".
    */
    public class Program
    {
        public static void Main(string[] args) 
        {
            string s = "abcba";
            int k = 2;
            var substring = FindLongestsubstring(s, k);

            Console.WriteLine("Longest substring with '" + k + "' distinct chars is: " + substring);
        }

        public static string FindLongestsubstring(string s, int k) 
        {
            string substring = string.Empty;
            Dictionary<char, int> dict = new Dictionary<char, int>();

            int i = 0;
            for(int j = 0; j < s.Length; j++) {
                if(dict.ContainsKey(s[j]) || dict.Count < k) {
                    if(!dict.ContainsKey(s[j])) {
                        dict.Add(s[j], 0);
                    }

                    dict[s[j]] += 1;
                    
                    var temp = new string(s.ToCharArray(), i, j-i+1);
                    substring = substring.Length < temp.Length ? temp : substring;
                } else { 
                    // Try removing items from the substrign and see where it ll fit.
                    while(dict.Count >= k) {
                        if(dict[s[i]] == 1) {
                            dict.Remove(s[i]);
                        } else {
                            dict[s[i]] -= 1;
                        }
                        i++;
                    }
                    j--;
                }
            }

            return substring;
        }
    }
}