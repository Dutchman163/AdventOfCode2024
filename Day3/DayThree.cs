using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day3
{
    internal class DayThree : IPuzzles
    {
        private string[] rawInput = File.ReadAllLines("day3\\input.txt");

        public void RunPartOne()
        {
            var input = CheckForMul(rawInput);
            var result = 0;
            foreach (var part in input)
            {
                result += part.Item1 * part.Item2;
            }
            Console.WriteLine(result);
        }

        public void RunPartTwo()
        {
            var input = string.Concat(rawInput);
            var dos = Regex.Matches(input, "do\\(\\)");
            var donts = Regex.Matches(input, "don\\'t\\(\\)");
            var listOfDonts = new List<int>();
            listOfDonts.AddRange(donts.Select(x => x.Index));
            var listOfDos = new List<int>();
            listOfDos.AddRange(dos.Select(x => x.Index));

            var inputs = new List<string>();
            var listofNumbers = new List<Tuple<int, int>>();

            for (var i = 0; i < listOfDos.Count; i++)
            {
                for (var j = 0; j < listOfDonts.Count; j++)
                {
                    if (listOfDos[i] > listOfDonts[j])
                    {
                        continue;
                    }
                    if (listOfDonts[j] > listOfDos[i])
                    {
                        if (listofNumbers.Count > 0 && listofNumbers.Last().Item2 == listOfDonts[j])
                        {
                            break;
                        }
                        inputs.Add(input.Substring(listOfDos[i], listOfDonts[j] - listOfDos[i]));
                        listofNumbers.Add(Tuple.Create(listOfDos[i], listOfDonts[j]));

                        break;
                    }
                }
            }
            inputs.Add(input.Substring(0, listOfDos[0]));

            var inputForResult = CheckForMul(inputs.ToArray());
            var result = 0;
            foreach (var part in inputForResult)
            {
                result += part.Item1 * part.Item2;
            }
        }

        private List<Tuple<int, int>> CheckForMul(string[] input)
        {
            var result = new List<Tuple<int, int>>();
            foreach (var inputItem in input)
            {
                MatchCollection matches = Regex.Matches(inputItem, "mul\\(\\d+,\\s*\\d+\\)");
                foreach (Match match in matches)
                {
                    // Haal de nummers uit de capturing groups
                    string firstNumber = match.ToString().Substring(match.ToString().IndexOf('(') + 1, match.ToString().IndexOf(',') - match.ToString().IndexOf('(') - 1);
                    string secondNumber = match.ToString().Substring(match.ToString().IndexOf(',') + 1, match.ToString().IndexOf(')') - match.ToString().IndexOf(',') - 1);
                    result.Add(Tuple.Create(int.Parse(firstNumber), int.Parse(secondNumber)));
                }
            }
            return result;
        }
    }
}
