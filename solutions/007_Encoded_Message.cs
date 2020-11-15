using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingProblem
{
    /*
    This problem was asked by Facebook.
    Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.
    For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.
    You can assume that the messages are decodable. For example, '001' is not allowed.
    */
    public class Program
    {
        public static void Main(string[] args) 
        {
            string message = "1234";
            var encodingCount = FindTotalEncodings(message.ToCharArray(), 0);

            Console.WriteLine("Number of encoding possible for [" + message + "]: " + encodingCount);
        }

        public static int FindTotalEncodings(char[] message, int start) 
        {
            int total  = 0;

            if(start == message.Length -1 || start == message.Length ) { return 1; }

            if(message[start] > '0') {
                total = FindTotalEncodings(message, start + 1);
            }

            if(message[start] == '1' || (message[start] == '2' && message[start+1] < '7')) {
                total += FindTotalEncodings(message, start + 2);
            }

            return total;
        }
    }
}