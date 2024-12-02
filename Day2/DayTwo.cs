namespace AdventOfCode2024.Day2
{
    internal class DayTwo : IPuzzles
    {
        private string[] rawInput = File.ReadAllLines("day2\\input.txt");
        public void RunPartOne()
        {
            var result = 0;
            var input = rawInput;
            foreach (var line in input)
            {
                var numbers = line.Split(' ').Select(x => int.Parse(x.ToString())).ToArray();
                bool? isAscending = null;
                var startNumber = 0;
                for (var i = 0; i < numbers.Length; i++)
                {
                    if (startNumber == 0)
                    {
                        startNumber = numbers[i];
                        continue;
                    }
                    if (!isAscending.HasValue)
                    {
                        if (startNumber >= numbers[i] - 3 && startNumber < numbers[i])
                        {
                            isAscending = false;
                            startNumber = numbers[i];
                            continue;
                        }
                        else if (startNumber <= numbers[i] + 3 && startNumber > numbers[i])
                        {
                            isAscending = true;
                            startNumber = numbers[i];
                            continue;
                        }
                        else break;
                    }
                    if (isAscending.Value)
                    {
                        if (startNumber <= numbers[i] + 3 && startNumber > numbers[i])
                        {
                            if (i == numbers.Length - 1)
                            {
                                result += 1;
                                continue;
                            }
                            startNumber = numbers[i];
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (startNumber >= numbers[i] - 3 && startNumber < numbers[i])
                        {
                            if (i == numbers.Length - 1)
                            {
                                result += 1;
                                continue;
                            }
                            startNumber = numbers[i];
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            Console.Write("Result " + result);
        }

        public void RunPartTwo()
        {
            var safeCount = 0;
            foreach (var line in rawInput)
            {

                var report = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                if (GetReports(report))
                {
                    safeCount++;
                }
                else
                {
                    for (int i = 0; i < report.Count; i++)
                    {
                        var reportCopy = report.ToList();
                        reportCopy.RemoveAt(i);
                        if (GetReports(reportCopy))
                        {
                            safeCount++;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(safeCount);
        }

        private bool GetReports(List<int> report)
        {
            if (report.Count < 2)
            {
                return true;
            }

            var firstReport = report[1] - report[0];

            if (firstReport == 0 || Math.Abs(firstReport) > 3)
            {
                return false;
            }

            var expectedReport = firstReport / Math.Abs(firstReport);
            var expectedReport2 = firstReport / firstReport;

            if (expectedReport != expectedReport2)
            {

            }

            for (int i = 1; i < report.Count - 1; i++)
            {
                var difference = report[i + 1] - report[i];
                if (difference == 0 || Math.Abs(difference) > 3)
                {
                    return false;
                }

                var actualReport = difference / Math.Abs(difference);
                if (actualReport != expectedReport)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
