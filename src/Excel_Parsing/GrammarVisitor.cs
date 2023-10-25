using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Antlr4.Runtime.Misc;

namespace Excel.Parsing;

class GrammarVisitor : GrammarBaseVisitor<bool>
{
    public override bool VisitCompileUnit(GrammarParser.CompileUnitContext context)
    {
        return Visit(context.expression());
    }

    public override bool VisitNumberExpr(GrammarParser.NumberExprContext context)
    {
        var result = double.Parse(context.GetText());
        Debug.WriteLine(result);

        return result != 0.0;
    }

    public override bool VisitBooleanExpr(GrammarParser.BooleanExprContext context)
    {
        var result = bool.Parse(context.GetText());
        Debug.WriteLine(result);

        return result;
    }

    //IdentifierExpr
    public override bool VisitIdentifierExpr(GrammarParser.IdentifierExprContext context)
    {
        var result = context.GetText();
        var editedCellName = Calculator.TableP.EvaluatingCell;
        var resultCell = Calculator.TableP.Cells[result];
        Calculator.TableP.Cells[editedCellName].DependsOn.Add(result);
        if (Calculator.TableP.HasCyclicDependency(result))
        {
            throw new System.Exception("Invalid Expression");
        }

        if (!resultCell.AppearsIn.Contains(editedCellName))
        {
            resultCell.AppearsIn.Add(editedCellName);
        }

        return resultCell.Value;
    }

    public override bool VisitParenthesizedExpr(GrammarParser.ParenthesizedExprContext context)
    {
        return Visit(context.expression());
    }

    public override bool VisitAdditiveExpr(GrammarParser.AdditiveExprContext context)
    {
        var left = WalkLeft(context);
        var right = WalkRight(context);

        if (context.operatorToken.Type == GrammarLexer.ADD)
        {
            Debug.WriteLine("{0} + {1}", left, right);
            return left || right;
        }
        else //GrammarLexer.SUBTRACT
        {
            Debug.WriteLine("{0} - {1}", left, right);
            return left ^ right;
        }
    }

    public override bool VisitMultiplicativeExpr(GrammarParser.MultiplicativeExprContext context)
    {
        var left = WalkLeft(context);
        var right = WalkRight(context);

        if (context.operatorToken.Type == GrammarLexer.MULTIPLY)
        {
            Debug.WriteLine("{0} * {1}", left, right);
            return left && right;
        }
        else //GrammarLexer.DIVIDE
        {
            Debug.WriteLine("{0} / {1}", left, right);
            return left;
        }
    }

    public override bool VisitLogicalNotExpr([NotNull] GrammarParser.LogicalNotExprContext context)
    {
        var expr = Visit(context.GetRuleContext<GrammarParser.ExpressionContext>(0));

        Debug.WriteLine($"NOT {expr}");
        return !expr;
    }

    public override bool VisitLogicalAndExpr([NotNull] GrammarParser.LogicalAndExprContext context)
    {
        var left = WalkLeft(context);
        var right = WalkRight(context);

        Debug.WriteLine($"{left} && {right}");
        return left && right;
    }

    public override bool VisitLogicalOrExpr([NotNull] GrammarParser.LogicalOrExprContext context)
    {
        var left = WalkLeft(context);
        var right = WalkRight(context);

        Debug.WriteLine($"{left} || {right}");
        return left || right;
    }

    public override bool VisitEqualityExpr([NotNull] GrammarParser.EqualityExprContext context)
    {
        var left = WalkLeft(context);
        var right = WalkRight(context);

        if (context.operatorToken.Type == GrammarLexer.EQUAL)
        {
            Debug.WriteLine($"{left} == {right}");
            return left == right;
        }
        Debug.WriteLine($"{left} <> {right}");
        return left != right;
    }

    public override bool VisitRelationalExpr([NotNull] GrammarParser.RelationalExprContext context)
    {
        var left = WalkLeft(context);
        var right = WalkRight(context);

        switch (context.operatorToken.Type)
        {
            case GrammarLexer.GREATER:
                Debug.WriteLine($"{left} > {right}");
                return left && !right;
            case GrammarLexer.GREATER_EQUAL:
                Debug.WriteLine($"{left} >= {right}");
                return left;
            case GrammarLexer.LESS:
                Debug.WriteLine($"{left} < {right}");
                return !left && right;
            case GrammarLexer.LESS_EQUAL:
                Debug.WriteLine($"{left} <= {right}");
                return right;
            default:
                return false;
        }
    }

    private bool WalkLeft(GrammarParser.ExpressionContext context)
    {
        return Visit(context.GetRuleContext<GrammarParser.ExpressionContext>(0));
    }

    private bool WalkRight(GrammarParser.ExpressionContext context)
    {
        return Visit(context.GetRuleContext<GrammarParser.ExpressionContext>(1));
    }
}
