using System.Collections.Generic;
using System.Drawing;

namespace Character_Image.Utils.ImageUtils.micro;

public class ImageScale
{
    public static Image ResizeImage(Image image, int width, int height)
    {
        var result = new Bitmap(width, height);
        using var graphics = Graphics.FromImage(result);
        graphics.DrawImage(image, 0, 0, width, height);
        return result;
    }

    // 切割图片
    public static Image CropImage(Image image, int x, int y, int width, int height)
    {
        var cropArea = new Rectangle(x, y, width, height);
        var result = new Bitmap(cropArea.Width, cropArea.Height);
        using var graphics = Graphics.FromImage(result);
        graphics.DrawImage(image, 
            new Rectangle(0, 0, result.Width, result.Height), 
            cropArea, 
            GraphicsUnit.Pixel);
        return result;
    }

    public static List<Image> Part(Image image, int x, int y)
    {
        // Console.WriteLine(image.Width);
        var x_len = image.Width / x;
        var y_len = image.Height / y;
        var images = new List<Image>();
        for (var i = 0; i < x; i++)
        {
            for (var j = 0; j < y; j++)
            {
                // Console.WriteLine($"x: {x_len*i} y: {y_len*j} width: {x_len} height: {y_len}");
                images.Add(CropImage(image,x_len*i,y_len*j,x_len,y_len));
            }
        }

        return images;
    }
}