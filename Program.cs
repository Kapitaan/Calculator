using System;

class Calculator
{
    static void Main(string[] args)
    {
        bool continueCalculate = true;

        while (continueCalculate == true)
        {
            try
            {
                Console.WriteLine("Enter the first number, please");
                double num1 = GetNumber();

                Console.WriteLine("Eneter the kind of operation, please");
                char operation = GetOperation();

                Console.WriteLine("Enter the second number, please");
                double num2 = GetNumber();

                double result = Calculate(num1, num2, operation);
                Console.WriteLine($"{num1} {operation} {num2} = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            finally
            {
                Console.WriteLine("Do you wanna take the operation again? (write yes/no)");
                continueCalculate = Console.ReadLine().ToLower() == "yes";
                Console.WriteLine();
            }
        }

        static double GetNumber()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double number))
                {
                    return number;
                }
                Console.WriteLine("Invalid input. Please enter a number");
            }
        }
        static char GetOperation()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Length == 1 && "+-*/".Contains(input))
                {
                    return input[0];
                }
                Console.WriteLine("Invalid operaton.Please enter +,-,* or /");
            }
        }
        static double Calculate(double num1, double num2, char operation)
        {
            return operation switch
            {
                '+' => num1 + num2,
                '-' => num1 - num2,
                '*' => num1 * num2,
                '/' => num2 != 0 ? num1 / num2 : throw new DivideByZeroException("Divide by zero is no allowed"),
                _ => throw new InvalidOperationException("Unknown operation")

            };

        }

    }
}