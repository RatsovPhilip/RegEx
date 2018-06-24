using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<nameOfCity>[A-Z]{2})(?<tempreture>[0-9]+\.[0-9]+)(?<weather>[A-Za-z]+)\|";

            Regex regex = new Regex(pattern);

            Dictionary<string, KeyValuePair<double, string>> extractData = new Dictionary<string, KeyValuePair<double, string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                var temp = regex.Matches(input);

                foreach (Match match in regex.Matches(input))
                {
                    string currentCity = match.Groups["nameOfCity"].Value;
                    double currentTempreture = double.Parse(match.Groups["tempreture"].Value);
                    string currentWeather = match.Groups["weather"].Value;

                    if (extractData.ContainsKey(currentCity))
                    {
                        extractData[currentCity] = new KeyValuePair<double, string>(currentTempreture,currentWeather);

                    }
                    else
                    {
                        extractData.Add(currentCity, new KeyValuePair<double, string>(currentTempreture,currentWeather));

                    }
                }
            }

            foreach (var city in extractData.OrderBy(x=>x.Value.Key))
            {

                {
                    Console.WriteLine($"{city.Key} => {city.Value.Key} => {city.Value.Value}");
                }
            }
        }
    }
}
