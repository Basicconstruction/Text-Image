using Avalonia.Media.Imaging;
using ReactiveUI;

namespace Character_Image.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static
    private Bitmap? _display;

    public Bitmap? DisplayImage
    {
        get => _display;
        set => this.RaiseAndSetIfChanged(ref _display, value);
    }

    private float _fontSize = 5;

    public float FontSize
    {
        get => _fontSize;
        set => this.RaiseAndSetIfChanged(ref _fontSize, value);
    }

    private string _drawText = "林沐风";

    public string DrawText
    {
        get => _drawText;
        set => this.RaiseAndSetIfChanged(ref _drawText, value);
    }

    private int _zoom = 10;

    public int Zoom
    {
        get => _zoom;
        set => this.RaiseAndSetIfChanged(ref _zoom, value);
    }

    private string? _inputImage = "";

    public string? InputImage
    {
        get => _inputImage;
        set => this.RaiseAndSetIfChanged(ref _inputImage, value);
    }

}