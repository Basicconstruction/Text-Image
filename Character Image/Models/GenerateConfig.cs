using System.ComponentModel.DataAnnotations;

namespace Character_Image.Models;

public class GenerateConfig
{
    //方框相对于字体大小的倍数
    private const float RectXRate = 5.68f;
    private const float RectYRate = 2.3667f;
    // x,y 分别代表x方向和y方向切割分成的部分的数目
    // 表示经过切割将会有x * y个子图片
    [Range(1,20)]
    public int X
    {
        get;
        set;
    }
    [Range(1,20)]
    public int Y
    {
        get;
        set;
    }
    // 表示放大的倍数
    [Range(1,20)]
    public int Zoom
    {
        get;
        set;
    }

    public float FontSize
    {
        get;
        set;
    } = 6;

    public string DrawText
    {
        get;
        set;
    } = "林沐风";

    public float RectWidth => FontSize * RectXRate * (1.0f * DrawText.Length / 3);
    public float RectHeight => FontSize * RectYRate * (1.0f * DrawText.Length / 3);

    public bool Gray
    {
        get;
        set;
    } = false;
    public override string ToString() {
        return "GenerateConfig{" +
               "X=" + X +
               ", Y=" + Y +
               ", Zoom=" + Zoom +
               ", FontSize=" + FontSize +
               ", DrawText='" + DrawText + '\'' +
               ", RectWidth=" + RectWidth +
               ", RectHeight=" + RectHeight +
               '}';
    }
}