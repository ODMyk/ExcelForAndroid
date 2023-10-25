using System.Text.Json;
using System.Text;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;

namespace MauiApp1;

class JsonFileManager : IFileManager
{
    private IFileSaver Saver;

    private IFilePicker Loader;

    private FileResult openedFile;

    public JsonFileManager() {
        Saver = FileSaver.Default;
        Loader = FilePicker.Default;
    }

    public async Task Save(FileRepresentation representation)
    {
        // var status = await Permissions.RequestAsync<Permissions.StorageWrite>();

        // if (status != PermissionStatus.Granted) {
        //     return;
        // }

        if (openedFile == null) {
            await SaveAs(representation);
            return;
        }

        using var fileStream = File.OpenWrite(openedFile.FullPath);
        await JsonSerializer.SerializeAsync<FileRepresentation>(fileStream, representation);
    }

    public async Task SaveAs(FileRepresentation representation) {
        var text = JsonSerializer.Serialize<FileRepresentation>(representation);
        using var stream = new MemoryStream(Encoding.Default.GetBytes(text));
        openedFile = new FileResult((await Saver.SaveAsync("NewTable.json", stream, new CancellationTokenSource().Token)).FilePath);
    }

    public async Task<FileRepresentation> Load()
    {
        openedFile = await Loader.PickAsync();
        using var fileStream = await openedFile.OpenReadAsync();
        return await JsonSerializer.DeserializeAsync<FileRepresentation>(fileStream);
    }
}