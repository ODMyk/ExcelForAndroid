using System.Collections.Generic;
using System;
using System.Linq;

namespace Excel.Parsing;

public class Table
{
    public IDictionary<string, Cell> Cells { get; }

    public string EvaluatingCell { get; set; }

    public IList<string> AffectedCells { get; }

    public Table() : this(new Dictionary<string, Cell>()) { }

    public Table(IDictionary<string, Cell> table)
    {
        Cells = table;
        EvaluatingCell = "";
        AffectedCells = new List<string>();
    }

    private void Refresh(string cellName)
    {
        // Uses Depth-First walkthrough
        var cell = Cells[cellName];
        cell.DependsOn.Clear();
        EvaluatingCell = cellName;
        cell.Value = Calculator.Evaluate(cell.Expression);
        if (!AffectedCells.Contains(cellName))
        {
            AffectedCells.Add(cellName);
        }
    }

    public void RefreshRecursively(string cellName)
    {
        var cell = Cells[cellName];
        Refresh(cellName);

        for (int i = 0; i < cell.AppearsIn.Count; i++)
        {
            var observer = Cells[cell.AppearsIn[i]];
            if (observer.DependsOn.Contains(cellName))
            {
                RefreshRecursively(cell.AppearsIn[i]);
            }
            else
            {
                cell.AppearsIn.RemoveAt(i--);
            }
        }
    }

    public bool HasCyclicDependency(string dependentCellName)
    {
        // Returns true, if cellName appears to be dependent from itself. Uses Depth-First walkthrough
        return dependentCellName == EvaluatingCell || Cells[dependentCellName].DependsOn.Any(HasCyclicDependency);
    }

    public bool EditCell(string cellName, string expression)
    {
        // Returns true if expression is valid
        var cell = Cells[cellName];
        if (cell == null)
        {
            return false;
        }
        var oldExpression = cell.Expression;

        var oldDependencies = new List<string>();

        foreach (var dependencyName in cell.DependsOn)
        {
            oldDependencies.Add(dependencyName);
        }

        Cells[cellName].Expression = expression;
        AffectedCells.Clear();
        try
        {
            RefreshRecursively(cellName);
        }
        catch (Exception)
        {
            cell.Expression = oldExpression;
            cell.DependsOn = oldDependencies;
            return false;
        }
        return true;
    }
}