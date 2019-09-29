using System.Drawing;
using System.Drawing.Imaging;

namespace ShopNum1.Common
{
    public class VerifyImageInfo
    {
        private string contentType = "image/pjpeg";
        private ImageFormat imageFormat = ImageFormat.Jpeg;

        public string ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }

        public Bitmap Image { get; set; }

        public ImageFormat ImageFormat
        {
            get { return imageFormat; }
            set { imageFormat = value; }
        }
    }
}