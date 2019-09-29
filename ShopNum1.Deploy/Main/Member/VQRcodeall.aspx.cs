using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ShopNum1.QRCode.Codec;
using System.Drawing.Imaging;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Member
{
    public partial class VQRcodeall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string strPage = this.Page.Request.QueryString["Recommend"];

          
            string url = "http://" + ShopSettings.siteDomain + "/Main/MemberRegister.aspx?recommendid=" + strPage + "";
              
            System.Drawing.Image img = GetDimensionalCode(url);
            //Image1.ImageUrl = img;


            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            img.Save(ms, ImageFormat.Jpeg);
            Response.ClearContent();
            Response.ContentType = "image/Jpeg";
            Response.BinaryWrite(ms.ToArray());

        }




        //笔者这里将它封装成了一个方法，方便使用：
        /// <summary>
        /// 根据链接获取二维码
        /// </summary>
        /// <param name="link">链接</param>
        /// <returns>返回二维码图片</returns>
        private Bitmap GetDimensionalCode(string link)
        {
            Bitmap bmp = null;
            try
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 4;
                //int version = Convert.ToInt16(cboVersion.Text);
                qrCodeEncoder.QRCodeVersion = 7;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                bmp = qrCodeEncoder.Encode(link);
            }
            catch
            {
                //MessageBox.Show("Invalid version !");
            }
            return bmp;
        }
    }
}