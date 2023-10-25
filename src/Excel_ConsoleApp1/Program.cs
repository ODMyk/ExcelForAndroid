using System;
using Excel.Parsing;
using System.Collections.Generic;

namespace ConsoleApp1;

class ConsoleCalculator
{
    static ConsoleCalculator() {
        Cell.Table.Add("A1", new Cell.Cell("1+1"));
    }
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
            Console.WriteLine($"Result: {Cell.Evaluate(expression)}");
        } while (true);
    }
}
