using System.Drawing;

namespace Character_Image.Models;

public class QuickCharacterDrawer: ICharacterDrawer
{

    public Image DrawOne(string path, GenerateConfig config)
    {
        using var image = Image.FromFile(path);
        using var bit = new Bitmap(image);
        using var res = new Bitmap(image.Width, image.Height);
        using var graphics = Graphics.FromImage(res);
        var lx = config.RectWidth;
        var ly = config.RectHeight;
        var rx = bit.Width / lx;
        var ry = bit.Height / ly;

        var font = new Font(new FontFamily("微软雅黑"), config.FontSize, FontStyle.Regular);
        var brush = new SolidBrush(Color.Black); // 假设文本颜色为黑色

        for (var i = 0; i < rx; i++)
        {
            for (var j = 0; j < ry; j++)
            {
                Color c;
                c = config.Gray ? 
                    AverageColor.GetAverageGray(bit, new Rectangle((int)(i * lx), (int)(j * ly), (int)lx, (int)ly)) : AverageColor.GetAverageColor(bit, new Rectangle((int)(i * lx), (int)(j * ly), (int)lx, (int)ly));
                brush.Color = c;
                var cs = Color.FromArgb(c.A, c.R/2, c.G/2, c.B/2);
                for (var k = 0; k < lx; k++)
                {
                    for (var g = 0; g < ly; g++)
                    {
                        var px = (int)(i * lx) + k;
                        px = px < res.Width ? px : res.Width - 1;
                        var py = (int)(j * ly) + g;
                        py = py < res.Height ? py : res.Height - 1;
                        res.SetPixel(px,py,cs);
                    }
                }
                graphics.DrawString(config.DrawText, font, brush, i * lx, j * ly);
                
            }
        }

        return new Bitmap(res);
    }
}