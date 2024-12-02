namespace AdventOfCode2024.Day1
{
    public class DayOne : IPuzzles
    {
        private string[] rawInput = File.ReadAllLines("day1\\input.txt");
        public void RunPartOne()
        {
            var input = rawInput;
            var inputLeft = input.Select(x => x.Substring(0, x.IndexOf(' ')));
            var inputRight = input.Select(x => x.Substring(x.IndexOf("   ") + 3, x.Length - x.IndexOf("   ") - 3));
            var inputLeftNumbers = GenerateIntArray(inputLeft);
            var inputRightNumbers = GenerateIntArray(inputRight);
            inputLeftNumbers = OrderList(inputLeftNumbers);
            inputRightNumbers = OrderList(inputRightNumbers);
            var result = CalculateDifference(inputLeftNumbers, inputRightNumbers);

            Console.WriteLine($"Result: {result}");


        }

        public void RunPartTwo()
        {
            var input = rawInput;
            var inputLeft = input.Select(x => x.Substring(0, x.IndexOf(' ')));
            var inputRight = input.Select(x => x.Substring(x.IndexOf("   ") + 3, x.Length - x.IndexOf("   ") - 3));
            var inputLeftNumbers = GenerateIntArray(inputLeft);
            var inputRightNumbers = GenerateIntArray(inputRight);
            inputLeftNumbers = OrderList(inputLeftNumbers);
            inputRightNumbers = OrderList(inputRightNumbers);
            var result = CalculateSimilarities(inputLeftNumbers, inputRightNumbers);

            Console.WriteLine($"Result: {result}");


        }

        private int[] GenerateIntArray(IEnumerable<string> input)
        {
            return input.Select(x => int.Parse(x)).ToArray();
        }

        private int[] OrderList(int[] input)
        {
            return input.Order().ToArray();
        }

        private int CalculateDifference(int[] left, int[] right)
        {
            var result = 0;

            for (int i = 0; i <= left.Length - 1; i++)
            {
                if (right[i] > left[i])
                {
                    result += right[i] - left[i];
                }
                if (right[i] < left[i])
                {
                    result += left[i] - right[i];
                }
            }
            return result;
        }

        private int CalculateSimilarities(int[] inputLeft, int[] inputRight)
        {
            var result = 0;
            foreach (var left in inputLeft)
            {
                var similarities = 0;
                foreach (var right in inputRight)
                {
                    if (left == right)
                    {
                        similarities++;
                    }
                }
                result += left * similarities;
            }
            return result;
        }
    }
}
