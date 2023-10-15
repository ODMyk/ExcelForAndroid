using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel.Parsing;
public static class Calculator
{
    static IDictionary<string, double> table = new Dictionary<string, double>();

    public static double Evaluate(string expression)
    {
        var lexer = new GrammarLexer(new AntlrInputStream(expression));
        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(new ThrowExceptionErrorListener());

        var tokens = new CommonTokenStream(lexer);
        var parser = new GrammarParser(tokens);

        var tree = parser.compileUnit();

        var visitor = new GrammarVisitor(table);

        return visitor.Visit(tree);
    }
}
