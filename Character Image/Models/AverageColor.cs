using System;
using System.Drawing;

namespace Character_Image.Models;

public class AverageColor
{
    public static Color GetAverageColor(Bitmap image, Rectangle rect)
    {

        var alphaSum = 0;
        var redSum = 0;
        var greenSum = 0;
        var blueSum = 0;

        // 遍历矩形区域的每个像素，并将颜色值相加
        for (var y = 0; y < rect.Height; y++)
        {
            for (var x = 0; x < rect.Width; x++)
            {
                var px = rect.X + x > image.Width - 1?image.Width-1:rect.X+x;
                var py = rect.Y + y > image.Height - 1 ? image.Height - 1 : rect.Y + y;
                var pixelColor = image.GetPixel(px,py);
                alphaSum += pixelColor.A;
                redSum += pixelColor.R;
                greenSum += pixelColor.G;
                blueSum += pixelColor.B;
            }
        }

        // 计算平均颜色
        var pixelCount = rect.Width * rect.Height;
        var averageAlpha = alphaSum / pixelCount;
        var averageRed = redSum / pixelCount;
        var averageGreen = greenSum / pixelCount;
        var averageBlue = blueSum / pixelCount;
        // copy.Dispose();
        return Color.FromArgb(averageAlpha,averageRed, averageGreen, averageBlue);
    }

    public static Color GetAverageGray(Bitmap image, Rectangle rect)
    {
        var graySum = 0;

        // 遍历矩形区域的每个像素，并将颜色值相加
        for (var y = 0; y < rect.Height; y++)
        {
            for (var x = 0; x < rect.Width; x++)
            {
                var px = rect.X + x > image.Width - 1?image.Width-1:rect.X+x;
                var py = rect.Y + y > image.Height - 1 ? image.Height - 1 : rect.Y + y;
                var pixelColor = image.GetPixel(px,py);
                graySum += pixelColor.R; // 使用灰度值作为颜色值
            }
        }

        // 计算平均灰度值
        var pixelCount = rect.Width * rect.Height;
        var averageGray = graySum / pixelCount;
        return Color.FromArgb(averageGray, averageGray, averageGray);
    }
}