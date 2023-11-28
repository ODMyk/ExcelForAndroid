namespace MauiApp1;
using System.Text.Json.Serialization;
public struct FileRepresentation
{
    [JsonInclude]
    public int CountRow;

    [JsonInclude]
    public int CountColumn;

    [JsonInclude]
    public IDictionary<string, Excel.Parsing.Cell> Cells;

    public FileRepresentation(int rows, int columns, IDictionary<string, Excel.Parsing.Cell> cells)
    {
        CountColumn = columns;
        CountRow = rows;
        Cells = cells;
    }
}

public interface IFileManager
{
    public Task Save(FileRepresentation representation);

    public Task SaveAs(FileRepresentation representation);
    public Task<FileRepresentation> Load();
}