using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;

namespace Character_Image.Utils.Selector;

public static class SelectorUtils
{
    public static async Task<string?> ChooseFileToSave(ContentControl userControl,string initName,string extension = "png")
    {
        var topLevel = TopLevel.GetTopLevel(userControl);
        var choose = await topLevel!.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions()
        {
            SuggestedFileName = initName,
            DefaultExtension = extension
        });
        return choose?.Path.AbsolutePath;

    }
    public static async Task<string?> ChooseFile(ContentControl userControl,string title,IReadOnlyList<FilePickerFileType>? types = null)
    {
        var topLevel = TopLevel.GetTopLevel(userControl);

        // 启动异步操作以打开对话框。
        var files = await topLevel!.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = title,
            AllowMultiple = false,
            FileTypeFilter = types
        });

        return files.Count >= 1 ? files[0].Path.AbsolutePath : null;
    } 
}