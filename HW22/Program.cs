namespace HW22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            double a = StringToDouble(Console.ReadLine());
        }
        public static double StringToDouble(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("Строка не может быть пустой или null");

            int sign = 1;
            int dotIndex = -1;
            double intPart = 0.0;
            double decimalPart = 0.0;

            for (int i = 0; i < str.Length; i++)
            {
                char symbol = str[i];

                if (symbol == '-')
                {
                    if (i != 0)
                        throw new ArgumentException("Строка содержит недопустимые символы");

                    sign = -1;
                }
                else if (symbol == '.')
                {
                    if (dotIndex != -1)
                        throw new ArgumentException("Строка содержит недопустимые символы");

                    dotIndex = i;
                }
                else if (!char.IsDigit(symbol))
                    throw new ArgumentException("Строка содержит недопустимые символы");
            }

            if (dotIndex == -1)
            {
                for (int i = str.Length - 1; i >= (sign == -1 ? 1 : 0); i--)
                {
                    char symbol = str[i];
                    int digit = symbol - '0';
                    intPart += digit * Math.Pow(10, str.Length - i - 1);
                }

                return intPart * sign;
            }

            for (int i = dotIndex - 1; i >= (sign == -1 ? 1 : 0); i--)
            {
                char symbol = str[i];
                int digit = symbol - '0';
                intPart += digit * Math.Pow(10, dotIndex - i - 1);
            }

            for (int i = dotIndex + 1; i < str.Length; i++)
            {
                char symbol = str[i];
                int digit = symbol - '0';
                decimalPart += digit * Math.Pow(10, dotIndex - i);
            }

            return (intPart + decimalPart) * sign;
        }
    }
}