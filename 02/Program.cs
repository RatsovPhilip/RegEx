using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string pattern = $"([\\w\\s\\-,]*[^\\.!\\s\\?])(\\s[{word}]+\\s)([\\w\\s\\-,]*[^\\.!\\s\\?])*";

            string[] input = Console.ReadLine().Split('!', '.', '?');

            Regex regex = new Regex(pattern);

            for (int i = 0; i < input.Length; i++)
            {
                var succses = regex.IsMatch(input[i]);
                if (succses)
                {
                    Console.WriteLine(input[i].Trim());
                }
            }

        }
    }
}
