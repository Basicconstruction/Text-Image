using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Character_Image.Utils.ImageUtils.micro;

public class ImageTransform
{
    public static Image<Rgba32> Gray(string path)
    {
        using var originalImage = Image.Load<Rgba32>(path);
        var grayImage = originalImage.Clone();
        grayImage.Mutate(x => x.Grayscale());
        return grayImage;
    }
}