using System.Drawing;

namespace Character_Image.Models;

public interface ICharacterDrawer
{
    Image DrawOne(string path, GenerateConfig config);
}