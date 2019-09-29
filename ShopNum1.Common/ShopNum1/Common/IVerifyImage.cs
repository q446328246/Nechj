using System.Drawing;

namespace ShopNum1.Common
{
    public interface IVerifyImage
    {
        VerifyImageInfo GenerateImage(string code, int width, int height, Color bgcolor, int textcolor);
    }
}