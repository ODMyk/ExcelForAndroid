using System;
using Excel.Parsing;

namespace ConsoleApp1;

class ConsoleCalculator
{
    static void Main()
    {
        string expression;
        do
        {
            Console.Write("> ");
            expression = Console.ReadLine() ?? "exit";
            if (expression.Equals("exit"))
            {
                break;
            }
            Console.WriteLine($"Result: {Calculator.Evaluate(expression)}");
        } while (true);
    }
}
