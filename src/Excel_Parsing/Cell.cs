using System.Collections.Generic;

namespace Excel.Parsing;

public class Cell
{
    public string Expression { get; set; }

    public bool Value { get; set; }

    public IList<string> AppearsIn { get; set; }

    public IList<string> DependsOn { get; set; }

    public Cell() : this("") { }

    public Cell(string expression)
    {
        AppearsIn = new List<string>();
        DependsOn = new List<string>();
        Expression = expression;
        Value = false;
    }

    public string GetText()
    {
        return Expression == "" ? "" : Value.ToString();
    }

    public void Clear()
    {
        Expression = "";
        DependsOn.Clear();
        AppearsIn.Clear();
        Value = false;
    }
}
