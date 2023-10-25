using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel.Parsing;
public static class Calculator
{
    public static Table TableP { get; }

    static Calculator() {
        TableP = new();
    }
    public static bool Evaluate(string expression)
    {
        var lexer = new GrammarLexer(new AntlrInputStream(expression));
        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(new ThrowExceptionErrorListener());

        var tokens = new CommonTokenStream(lexer);
        var parser = new GrammarParser(tokens);

        var tree = parser.compileUnit();

        var visitor = new GrammarVisitor();

        return visitor.Visit(tree);
    }
}
