//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/dmyko/Documents/Programming/dotnet/ExcelForAndroid/src/Excel_Parsing/Grammar.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="GrammarParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
// [System.CLSCompliant(false)]
public interface IGrammarVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.compileUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompileUnit([NotNull] GrammarParser.CompileUnitContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>MultiplicativeExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiplicativeExpr([NotNull] GrammarParser.MultiplicativeExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>LogicalOrExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalOrExpr([NotNull] GrammarParser.LogicalOrExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>EqualityExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEqualityExpr([NotNull] GrammarParser.EqualityExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>AdditiveExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdditiveExpr([NotNull] GrammarParser.AdditiveExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>NumberExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumberExpr([NotNull] GrammarParser.NumberExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>IdentifierExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierExpr([NotNull] GrammarParser.IdentifierExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>LogicalNotExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalNotExpr([NotNull] GrammarParser.LogicalNotExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ParenthesizedExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenthesizedExpr([NotNull] GrammarParser.ParenthesizedExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>RelationalExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRelationalExpr([NotNull] GrammarParser.RelationalExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>LogicalAndExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalAndExpr([NotNull] GrammarParser.LogicalAndExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BooleanExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBooleanExpr([NotNull] GrammarParser.BooleanExprContext context);
}
