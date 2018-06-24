using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numsLength = Console.ReadLine().Split();

            string mSkip = numsLength[0];
            string nTake = numsLength[1];

            string textInput = Console.ReadLine();

            Regex regex = new Regex(@"\|<(?<text>\w+)");

            var matches = regex.Matches(textInput);

            string[] allMatches = new string[matches.Count];
            int index = 0;

            foreach (Match match in matches)
            {
                string currText = match.Groups["text"].Value;
                var output = currText.Skip(int.Parse(mSkip)).Take(int.Parse(nTake)).ToArray();
                string currentResult = string.Join("", output);
                allMatches[index++] = currentResult;

            }

            Console.WriteLine(string.Join(", ",allMatches));


        }
    }
}
