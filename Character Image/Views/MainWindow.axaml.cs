using System;
using System.Drawing;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Character_Image.Models;
using Character_Image.Utils.ImageUtils.micro;
using Character_Image.Utils.Selector;
using Character_Image.ViewModels;
using Bitmap = Avalonia.Media.Imaging.Bitmap;
using Image = Avalonia.Controls.Image;

namespace Character_Image.Views;

public partial class MainWindow : Window
{
    public MainWindowViewModel Data => (MainWindowViewModel)DataContext!;
    public MainWindow()
    {
        InitializeComponent();
    }
    private async void Drawer_OnClick(object? sender, RoutedEventArgs e)
    {
        var config = new GenerateConfig()
        {
            Zoom = 10,
            X = 20,
            Y = 20,
            FontSize = Data.FontSize,
            DrawText = Data.DrawText
        };
        var drawer = new QuickCharacterDrawer(); 
        var onePath = Data.InputImage;
        if (onePath == null) return;
        var filePure = Path.GetFileNameWithoutExtension(onePath);
        var parent = Path.GetDirectoryName(Data.InputImage);
        var zoomPath = $"{parent}\\{filePure}-{Data.Zoom}x.png";
        var image = System.Drawing.Image.FromFile(onePath);
        var zoom = ImageScale.ResizeImage(image, image.Width * Data.Zoom, image.Height * Data.Zoom);
        zoom.Save(zoomPath);
        Console.WriteLine($"finish zoom {zoomPath}");
        var result = drawer.DrawOne(zoomPath,config);
        var outPath = $"{parent}\\{filePure}-{config.DrawText}.png";
        result.Save(outPath);
        Data.DisplayImage = new Bitmap(outPath);
        Console.WriteLine("结束");
    }

    private async void Selector_OnClick(object? sender, RoutedEventArgs e)
    {
        var filePure = Path.GetFileNameWithoutExtension(Data.InputImage);
        var outPath = $"{filePure}-{Data.DrawText}.png";
        var path = await SelectorUtils.ChooseFileToSave(this, outPath);
        if(Data.DisplayImage==null) return;
        if(path==null) return;
        path = Uri.UnescapeDataString(path);
        Data.DisplayImage.Save(path);
    }

    private async void FileSelector_OnClick(object? sender, RoutedEventArgs e)
    {
        var path = await SelectorUtils.ChooseFile(this, "选择文件");
        if(path==null) return;
        path = Uri.UnescapeDataString(path);
        Data.InputImage = path;
    }

    private void Light_OnClick(object? sender, RoutedEventArgs e)
    {
        var path = $"C:\\Users\\betha\\Desktop\\代码管理\\Character Image\\Character Image\\Resources\\girl-林沐风.png";
        var bitmap = new System.Drawing.Bitmap(path);
        for (int x = 0; x < bitmap.Width; x++)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                // 获取像素颜色
                var color = bitmap.GetPixel(x, y);
                double h, s, v;
                ColorUtils.ColorToHSV(color,out h,out s,out v);
                v *= 2;
                v = v >= 1 ? 1 : v;
                var c2 = ColorUtils.ColorFromHSV(h,s,v);
                bitmap.SetPixel(x, y, c2);
            }
        }
        bitmap.Save("C:\\Users\\betha\\Desktop\\代码管理\\Character Image\\Character Image\\Resources\\girl-林沐风-light.png");
        Console.WriteLine("finish");
    }
}