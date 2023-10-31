using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using Grid = Microsoft.Maui.Controls.Grid;
using Calculator = Excel.Parsing.Calculator;
using Microsoft.Maui;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    private readonly IFileManager FileManager;

    private const int DefaultColumnsCount = 10;
    private const int DefaultRowsCount = 10;

    private bool isEdited = false;

    private Button selected;

    private IDictionary<string, IView> cells;

    public MainPage()
    {
        FileManager = new JsonFileManager();
        cells = new Dictionary<string, IView>();
        InitializeComponent();
        MakeNewGrid(DefaultRowsCount, DefaultColumnsCount);
        textInput.Unfocused += Entry_Unfocused;
    }

    private string GetColumnName(int colIndex)
    {
        var dividend = colIndex;
        var columnName = string.Empty;
        while (dividend > 0)
        {
            var modulo = (dividend - 1) % 26;
            columnName = Convert.ToChar(65 + modulo) + columnName;
            dividend = (dividend - modulo) / 26;
        }

        return columnName;
    }

    private string GetCellName(object element)
    {
        var col = Grid.GetColumn((View)element);
        var row = Grid.GetRow((View)element);
        
        return GetCellName(row, col);
    }

    private string GetCellName(int row, int column) {
        if (column < 1 || row < 1)
        {
            throw new Exception("Out of bounds");
        }

        return GetColumnName(column) + row.ToString();
    }

    private async void Entry_Unfocused(object sender, FocusEventArgs e)
    {
        var entry = (Entry)sender;
        var cellName = GetCellName(selected);

        if (entry.Text == Calculator.TableP.Cells[cellName].Expression)
        {
            return;
        }

        if (Calculator.TableP.EditCell(cellName, entry.Text))
        {
            isEdited = true;

            foreach (var name in Calculator.TableP.AffectedCells)
            {
                Refresh(name);
            }

            MoveFocus();
            return;
        }
    
        entry.Text = Calculator.TableP.Cells[cellName].Expression;
        await DisplayAlert("Помилка", "Введено недопустимий вираз", "OK");
    }

    private void MoveFocus()
    {
        var row = Grid.GetRow(selected) + 1;
        var column = Grid.GetColumn(selected);
        if (row >= grid.RowDefinitions.Count)
        {
            row = 1;
            column++;
        }

        if (column >= grid.ColumnDefinitions.Count)
        {
            column = 1;
        }

        cells[GetColumnName(column) + row.ToString()].Focus();
    }

    private void Refresh(string cellName)
    {
        var cell = (Button)cells[cellName];
        cell.Text = Calculator.TableP.Cells[cellName].GetText();
    }

    private void RefreshRecursively(string cellName)
    {
        Refresh(cellName);

        foreach (var name in Calculator.TableP.Cells[cellName].AppearsIn) {
            RefreshRecursively(name);
        }
    }

    private void Cell_Clicked(object sender, EventArgs e)
    {
        if (textInput.IsReadOnly)
        {
            textInput.IsReadOnly = false;
        }

        if (selected != null)
        {
            selected.BorderColor = new Color(0, 0, 0, 100);
        }

        selected = (Button)sender;
        selected.BorderColor = new Color(0, 0, 0);
        textInput.Text = Calculator.TableP.Cells[GetCellName(selected)].Expression;
        textInput.Focus();
    }

    private FileRepresentation ToFileRepresentation()
    {
        var table = new Dictionary<string, Excel.Parsing.Cell>();
        var representation = new FileRepresentation(grid.RowDefinitions.Count - 1, grid.ColumnDefinitions.Count - 1, table);
        for (int row = 1; row <= representation.CountRow; row++)
        {
            for (int column = 1; column <= representation.CountColumn; column++)
            {
                var name = GetColumnName(column) + row.ToString();
                var cell = Calculator.TableP.Cells[name];
                if (cell.Expression != "" || cell.AppearsIn.Count() > 0)
                {
                    Debug.WriteLine($"{name}: {cell.AppearsIn.Count}");
                    table[name] = cell;
                }
            }
        }

        return representation;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        await Save();
    }

    private async void SaveAsButton_Clicked(object sender, EventArgs e)
    {
        await SaveAs();
    }

    private void ClearCells()
    {
        for (int row = 1; row < grid.RowDefinitions.Count; row++)
        {
            for (int column = 1; column < grid.ColumnDefinitions.Count; column++)
            {
                var name = GetColumnName(column) + row.ToString();
                var button = (Button)cells[name];
                Calculator.TableP.Cells[name].Clear();
                button.Text = "";
            }
        }
    }

    private void MakeNewGrid(int RowsCount, int ColumnsCount)
    {
        while (RowsCount < grid.RowDefinitions.Count - 1)
        {
            DeleteRow();
        }

        while (ColumnsCount < grid.ColumnDefinitions.Count - 1)
        {
            DeleteColumn();
        }

        ClearCells();

        while (grid.RowDefinitions.Count <= RowsCount)
        {
            AddRow();
        }

        while (grid.ColumnDefinitions.Count <= ColumnsCount)
        {
            AddColumn();
        }

        isEdited = false;
    }

    private async void ReadButton_Clicked(object sender, EventArgs e)
    {
        var representation = await FileManager.Load();

        MakeNewGrid(representation.CountRow, representation.CountColumn);

        foreach (var pair in representation.Cells)
        {
            var cell = (Button)cells[pair.Key];
            Calculator.TableP.Cells[pair.Key] = pair.Value;
            cell.Text = pair.Value.GetText();
        }

        if (representation.CountRow > 0 && representation.CountColumn > 0)
        {
            cells["A1"].Focus();
        }
    }

    private async void ExitButton_Clicked(object sender, EventArgs e)
    {
        var answer = await DisplayAlert("Підтвердження", "Ви дійсно хочете вийти?",
            "Так", "Ні");
        if (!answer) return;

        if (isEdited)
        {
            answer = !await DisplayAlert("Незбережені зміни", "Ви не зберегли останні внесені зміни, бажаєте це виправити ?", "Так", "Ні");
        }

        var isSaved = false;
        while (!answer && !isSaved)
        {
            isSaved = await Save();
            if (isSaved) break;
            answer = !await DisplayAlert("Незбережені зміни", "Ви не зберегли останні внесені зміни, бажаєте це виправити ?", "Так", "Ні");
        }

        System.Environment.Exit(0);
    }

    private async Task<bool> Save()
    {
        try
        {
            await FileManager.Save(ToFileRepresentation());
            isEdited = false;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private async Task<bool> SaveAs()
    {
        try
        {
            await FileManager.SaveAs(ToFileRepresentation());
            isEdited = false;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private async void HelpButton_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Довідка", "Лабораторна робота 1. Студента Дмитра Остапенка. Варіант 57",
            "OK");
    }

    private void DeleteRowButton_Clicked(object sender, EventArgs e)
    {
        DeleteRow();
    }

    private void DeleteRow()
    {
        if (grid.RowDefinitions.Count > 1)
        {
            isEdited = true;
            var lastRowIndex = grid.RowDefinitions.Count - 1;
            grid.RowDefinitions.RemoveAt(lastRowIndex);
            grid.Children.Remove(cells[$"0{lastRowIndex}"]); // Remove label
            for (var col = 1; col <= grid.ColumnDefinitions.Count - 1; col++)
            {
                var cellName = GetColumnName(col) + lastRowIndex.ToString();
                DeleteCell(cellName);
            }
        }
    }

    private void DeleteCell(string cellName)
    {
        foreach (var name in Calculator.TableP.Cells[cellName].AppearsIn)
        {
            var cell = Calculator.TableP.Cells[name];
            if (cell.DependsOn.Contains(cellName))
            {
                cell.DependsOn.Clear();
                cell.Expression = "";
                RefreshRecursively(name);
            }
        }

        grid.Children.Remove(cells[cellName]);
        cells.Remove(cellName);
        Calculator.TableP.Cells.Remove(cellName);
    }

    private void DeleteColumn()
    {
        if (grid.ColumnDefinitions.Count > 1)
        {
            isEdited = true;
            var lastColumnIndex = grid.ColumnDefinitions.Count - 1;
            grid.ColumnDefinitions.RemoveAt(lastColumnIndex);
            grid.Children.Remove(cells[$"{GetColumnName(lastColumnIndex)}0"]); // Remove label
            for (var row = 1; row <= grid.RowDefinitions.Count - 1; row++)
            {
                var cellName = GetColumnName(lastColumnIndex) + row.ToString();
                DeleteCell(cellName);
            }
        }
    }

    private void DeleteColumnButton_Clicked(object sender, EventArgs e)
    {
        DeleteColumn();
    }

    private void AddRowButton_Clicked(object sender, EventArgs e)
    {
        AddRow();
    }

    private void AddRow()
    {
        isEdited = true;
        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
        var row = grid.RowDefinitions.Count - 1;

        var label = new Label
        {
            Text = row.ToString(),

            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        Grid.SetRow(label, row);
        Grid.SetColumn(label, 0);
        grid.Children.Add(label);
        cells[$"0{row}"] = label;

        for (var col = 1; col < grid.ColumnDefinitions.Count; col++)
        {
            Calculator.TableP.Cells.Add(GetColumnName(col) + row.ToString(), new Excel.Parsing.Cell());
            var button = CreateCell();

            Grid.SetRow(button, row);
            Grid.SetColumn(button, col);
            grid.Children.Add(button);
            cells[GetCellName(button)] = button;
        }
    }

    private void AddColumnButton_Clicked(object sender, EventArgs e)
    {
        isEdited = true;
        AddColumn();
    }

    private void AddColumn()
    {
        var newColumn = grid.ColumnDefinitions.Count;

        grid.ColumnDefinitions.Add(new ColumnDefinition());

        var label = new Label
        {
            Text = GetColumnName(newColumn),
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        Grid.SetRow(label, 0);
        Grid.SetColumn(label, newColumn);
        grid.Children.Add(label);
        cells[$"{GetColumnName(newColumn)}0"] = label;

        for (var row = 1; row < grid.RowDefinitions.Count; row++)
        {
            var button = CreateCell();
            Calculator.TableP.Cells.Add(GetColumnName(newColumn) + row.ToString(), new Excel.Parsing.Cell());

            Grid.SetRow(button, row);
            Grid.SetColumn(button, newColumn);
            grid.Children.Add(button);
            cells[GetCellName(button)] = button;
        }
    }

    private Button CreateCell()
    {
        var button = new Button
        {
            Text = "",
            BackgroundColor = new Color(255, 255, 255),
            TextColor = new Color(0, 0, 0),
            BorderColor = new Color(0, 0, 0, 100),
            CornerRadius = 0,
            BorderWidth = 3.0,


            VerticalOptions = LayoutOptions.Fill,
            HorizontalOptions = LayoutOptions.Fill
        };
        button.Clicked += Cell_Clicked;
        button.Focused += Cell_Clicked;

        return button;
    }
}
