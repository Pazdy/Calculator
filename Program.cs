namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string formula = Console.ReadLine();
            find_indexes(formula);
        }
        static int Sum(int first, int second)
        {
            return first + second;
        }
        static int Sub(int first, int second)
        {
            return first - second;
        }
        static int Div(int first, int second)
        {
            return first / second;
        }
        static int Mul(int first, int second)
        {
            return first * second;
        }
        static void find_indexes(string input)
        {
            input = input.Replace(" ", "");
            //var sum = input.Split('+','-','/', '*','(',')');
            //sum = sum.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var foundIndexes = new List<int>();
            var operations = new List<char>();

            for (int i = 0; i < input.Length; i++)
                if (input[i] == '+' || input[i] == '-' || input[i] == '*' || input[i] == '/')
                {
                    foundIndexes.Add(i);
                    if (!operations.Contains(input[i]))
                        operations.Add(input[i]);
                }
            calculation_order(operations, foundIndexes, input);

            //Console.WriteLine(input.Substring(2, 3));
        }
        static void calculation_order(List<char> operations, List<int> indexes, string input)
        {
            if(operations.Contains('*'))
            {
                int index = input.IndexOf('*');
                int startIndex = input.IndexOf(input[indexes.IndexOf(index)]) + 1;
                int length = input.IndexOf(input[indexes.IndexOf(index)]);
                string first = input.Substring(startIndex, length);
                Console.WriteLine(length);
            }
        }
    }
}