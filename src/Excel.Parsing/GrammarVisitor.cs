using System.Collections.Generic;
using System.Diagnostics;
using Antlr4.Runtime.Misc;

namespace Excel.Parsing;

class GrammarVisitor : GrammarBaseVisitor<double>
{
    //таблиця ідентифікаторів (тут для прикладу)
    //в лабораторній роботі заміните на свою!!!!
    private IDictionary<string, double> tableIdentifier;

    public GrammarVisitor(IDictionary<string, double> table)
    {
        tableIdentifier = table;
    }

    public override double VisitCompileUnit(GrammarParser.CompileUnitContext context)
    {
        return Visit(context.expression());
    }

    public override double VisitNumberExpr(GrammarParser.NumberExprContext context)
    {
        var result = double.Parse(context.GetText());
        Debug.WriteLine(result);

        return result;
    }

    //IdentifierExpr
    public override double VisitIdentifierExpr(GrammarParser.IdentifierExprContext context)
    {
        var result = context.GetText();
        double value;
        //видобути значення змінної з таблиці
        if (tableIdentifier.TryGetValue(result.ToString(), out value))
        {
            return value;
        }
        else
        {
            return 0.0;
        }
    }

    public override double VisitParenthesizedExpr(GrammarParser.ParenthesizedExprContext context)
    {
        return Visit(context.expression());
    }

    public override double VisitExponentialExpr(GrammarParser.ExponentialExprContext context)
    {
        var left = WalkLeft(context);
        var right = WalkRight(context);

        Debug.WriteLine("{0} ^ {1}", left, right);
        return System.Math.Pow(left, right);
    }

    public override double VisitAdditiveExpr(GrammarParser.AdditiveExprContext context)
    {
        var left = WalkLeft(context);
        var right = WalkRight(context);

        if (context.operatorToken.Type == GrammarLexer.ADD)
        {
            Debug.WriteLine("{0} + {1}", left, right);
            return left + right;
        }
        else //GrammarLexer.SUBTRACT
        {
            Debug.WriteLine("{0} - {1}", left, right);
            return left - right;
        }
    }

    public override double VisitMultiplicativeExpr(GrammarParser.MultiplicativeExprContext context)
    {
        var left = WalkLeft(context);
        var right = WalkRight(context);

        if (context.operatorToken.Type == GrammarLexer.MULTIPLY)
        {
            Debug.WriteLine("{0} * {1}", left, right);
            return left * right;
        }
        else //GrammarLexer.DIVIDE
        {
            Debug.WriteLine("{0} / {1}", left, right);
            return left / right;
        }
    }

    public override double VisitLogicalNotExpr([NotNull] GrammarParser.LogicalNotExprContext context)
    {
        var expr = Visit(context.GetRuleContext<GrammarParser.ExpressionContext>(0));

        Debug.WriteLine($"NOT {expr}");
        return expr;
    }

    public override double VisitLogicalAndExpr([NotNull] GrammarParser.LogicalAndExprContext context)
    {
        var left = WalkLeft(context);
        var right = WalkRight(context);

    Debug.WriteLine($"{left} && {right}");
        return left * right;
    }

    public override double VisitLogicalOrExpr([NotNull] GrammarParser.LogicalOrExprContext context)
    {
        var left = WalkLeft(context);
        var right = WalkRight(context);

        Debug.WriteLine($"{left} || {right}");
        return left + right;
    }

    public override double VisitEqualityExpr([NotNull] GrammarParser.EqualityExprContext context)
    {
        var left = WalkLeft(context);
        var right = WalkRight(context);

        if (context.operatorToken.Type == GrammarLexer.EQUAL) {
            Debug.WriteLine($"{left} == {right}");
            return left == right ? 1 : 0;
        }
        Debug.WriteLine($"{left} <> {right}");
        return  left != right ? 1 : 0;
    }

    public override double VisitRelationalExpr([NotNull] GrammarParser.RelationalExprContext context)
    {
        var left = WalkLeft(context);
        var right = WalkRight(context);

        switch (context.operatorToken.Type) {
            case GrammarLexer.GREATER:
                Debug.WriteLine($"{left} > {right}");
                return left > right ? 1 : 0;
            case GrammarLexer.GREATER_EQUAL:
                Debug.WriteLine($"{left} >= {right}");
                return left >= right ? 1 : 0;
            case GrammarLexer.LESS:
                Debug.WriteLine($"{left} < {right}");
                return left < right ? 1 : 0;
            case GrammarLexer.LESS_EQUAL:
                Debug.WriteLine($"{left} <= {right}");
                return left <= right ? 1 : 0;
            default:
                return 0;
        }
    }

    private double WalkLeft(GrammarParser.ExpressionContext context)
    {
        return Visit(context.GetRuleContext<GrammarParser.ExpressionContext>(0));
    }

    private double WalkRight(GrammarParser.ExpressionContext context)
    {
        return Visit(context.GetRuleContext<GrammarParser.ExpressionContext>(1));
    }
}
