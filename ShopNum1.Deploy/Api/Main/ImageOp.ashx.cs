using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Api.Main
{
    /// <summary>
    /// ImageOp 的摘要说明
    /// </summary>
    public class ImageOp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (ShopNum1.Common.Common.ReqStr("albumid") != "")
                {
                    var shopNum1_Image = new ShopNum1_Image();
                    var shopNum1_Image_Action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
                    //获取上传的文件数据
                    HttpPostedFile file = context.Request.Files["Filedata"];
                    Image image = Image.FromStream(file.InputStream); //从上传文件流中实例化Image类 
                    float w = image.Width; //获取上传文件的水平分辨率（以“像素/英寸”为单位）。 
                    float h = image.Height; //获取上传文件的垂直分辨率（以“像素/英寸”为单位）。 

                    string fileName = file.FileName;
                    string fileType = Path.GetExtension(fileName).ToLower();
                    string[] strArray = { ".jpg", ".png", ".jpge", ".gif", ".bmp" };
                    if (!ShopNum1.Common.Common.CheckImgType(strArray, fileType))
                    {
                        context.Response.Write("不支持格式！");
                        return;
                    }
                    if (file.ContentLength > 1024 * 1024)
                    {
                        context.Response.Write("error");
                        return;
                    }
                    //由于不同浏览器取出的FileName不同（有的是文件绝对路径，有的是只有文件名），故要进行处理
                    if (fileName.IndexOf(' ') > -1)
                    {
                        fileName = fileName.Substring(fileName.LastIndexOf(' ') + 1);
                    }
                    else if (fileName.IndexOf('/') > -1)
                    {
                        fileName = fileName.Substring(fileName.LastIndexOf('/') + 1);
                    }
                    //上传的目录
                    string uploadDir = "/ImgUpload/Main/" + DateTime.Now.ToString("yyyy_MM") + "/";
                    //上传的路径
                    //生成年月文件夹及日文件夹
                    if (Directory.Exists(context.Server.MapPath(uploadDir)) == false)
                    {
                        Directory.CreateDirectory(context.Server.MapPath(uploadDir));
                    }
                    var r = new Random();
                    string strNewFileName = DateTime.Now.ToString("yyyyMMddhhmmss") + r.Next(1, 9);
                    string strFileName = strNewFileName + fileType;
                    string uploadPath = uploadDir + strFileName;
                    if (!File.Exists(uploadPath))
                    {
                        try
                        {
                            string strCheck = ShopSettings.GetValue("IfSetWaterMark");

                            #region 判断是否生成水印图片

                            if (strCheck == "0")
                            {
                                file.SaveAs(HttpContext.Current.Server.MapPath(uploadPath));
                            }
                            else if (strCheck == "1") //生成文字水印
                            {
                                string o_webFilePath =
                                    HttpContext.Current.Server.MapPath("~/ImgUpload/Main/" +
                                                                       DateTime.Now.ToString("yyyy_MM") + "/txt_" +
                                                                       strFileName);
                                file.SaveAs(o_webFilePath);
                                //水印文字
                                string addText = ShopSettings.GetValue("WaterMarkWords");
                                //水印位置
                                int position = 5;
                                try
                                {
                                    position = Convert.ToInt32(ShopSettings.GetValue("WordsWaterMarkPosition"));
                                }
                                catch
                                {
                                }
                                //字体
                                string fontType = ShopSettings.GetValue("WaterMarkWordsFont");
                                //水印透明度
                                int FontMarkClarity = Convert.ToInt32(ShopSettings.GetValue("ImageWaterMarkClarity"));
                                if (FontMarkClarity < 60)
                                    FontMarkClarity = 60;
                                //字大小
                                float fontSize = Convert.ToSingle(ShopSettings.GetValue("WaterMarkWordsFontSize"));
                                //字的颜色
                                string fontColor = ShopSettings.GetValue("WaterMarkWordsColor");
                                ImageOperator.AddImageSignText(o_webFilePath, addText, position, fontColor, fontType,
                                                               fontSize);
                                //ImageOperator.CreateWater(o_webFilePath, o_webFilePath, addText, position, fontType, fontSize, fontColor);
                                //ImageOperator.TextWater(o_webFilePath, o_webFilePath, addText, Convert.ToInt32(FontMarkClarity), position, fontType,fontSize, fontColor);
                                uploadPath = "~/ImgUpload/Main/" + DateTime.Now.ToString("yyyy_MM") + "/txt_" + strFileName;
                            }
                            else if (strCheck == "2") //生成图片水印
                            {
                                //添加图片水印
                                string o_webFilePath =
                                    HttpContext.Current.Server.MapPath("~/ImgUpload/Main/" +
                                                                       DateTime.Now.ToString("yyyy_MM") + "/img_" +
                                                                       strFileName);
                                file.SaveAs(o_webFilePath);
                                //从ShopSettings.xml中读水印的图片地址
                                //水印图片地址
                                string waterSourcePath = ShopSettings.GetValue("WaterMarkOriginalImge");
                                waterSourcePath = HttpContext.Current.Server.MapPath(waterSourcePath); //水印的物理路径
                                //水印位置
                                int position = 5;
                                try
                                {
                                    position = Convert.ToInt32(ShopSettings.GetValue("WaterMarkImagePosition"));
                                }
                                catch
                                {
                                }
                                ImageOperator.AddImageSignPic(o_webFilePath, waterSourcePath, position, 100, 10);
                                uploadPath = "~/ImgUpload/Main/" + DateTime.Now.ToString("yyyy_MM") + "/img_" + strFileName;
                            }

                            #endregion
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    //保存文件
                    //string strSize=w.ToString()+h.ToString();
                    //file.SaveAs(context.Server.MapPath(uploadPath));
                    //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失
                    shopNum1_Image.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_Image.Guid = Guid.NewGuid();
                    shopNum1_Image.Name = fileName.Replace(fileType, "");
                    shopNum1_Image.ImageType = fileType;
                    shopNum1_Image.ImagePath = uploadPath;
                    shopNum1_Image.Description = (double)file.ContentLength + "|" + w + "×" + h;
                    shopNum1_Image.UseTimes = 0;
                    shopNum1_Image.CreateUser = GetMemLoginId();
                    shopNum1_Image.ModifyUser = GetMemLoginId();
                    shopNum1_Image.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_Image.IsDeleted = 0;
                    string typeid = ShopNum1.Common.Common.ReqStr("albumid");
                    typeid = typeid == "" || typeid == "0" ? "1" : typeid;
                    shopNum1_Image_Action.Add(shopNum1_Image, typeid);
                    context.Response.Write(ShopNum1.Common.Common.ReqStr("albumid"));
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("0|" + ShopNum1.Common.Common.ReqStr("albumid"));
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }

        /// <summary>
        ///   将datatable转换成json数组
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetJson(DataTable dt)
        {
            var sbJson = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                sbJson.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sbJson.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        sbJson.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + dt.Rows[i][j] + "\",");
                    }
                    sbJson.Remove(sbJson.Length - 1, 1);
                    sbJson.Append("},");
                }
                sbJson.Remove(sbJson.Length - 1, 1);
                sbJson.Append("]");
            }
            return sbJson.ToString();
        }

        //获取登录用户方法
        private string GetMemLoginId()
        {
            string name = "jely";
            if (HttpContext.Current.Request.Cookies["AdminLoginCookie"] != null)
            {
                HttpCookie cookieShopNum1MemberLogin = HttpContext.Current.Request.Cookies["AdminLoginCookie"];
                HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookieShopNum1MemberLogin);
                name = decodedCookieShopNum1MemberLogin.Values["LoginID"];
            }
            return name;
        }
    }
}