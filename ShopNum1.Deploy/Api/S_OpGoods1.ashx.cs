using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;


namespace ShopNum1.Deploy.Api
{
    /// <summary>
    /// S_OpGoods1 的摘要说明
    /// </summary>
    public class S_OpGoods1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            string strFileName = string.Empty;
            HttpFileCollection _upfile = context.Request.Files;
            var sb = new StringBuilder();
            for (int i = 0; i < _upfile.Count; i++)
            {
                if (ShopNum1.Common.Common.ReqStr("filename") != "" && _upfile[i].FileName == ShopNum1.Common.Common.ReqStr("filename"))
                {
                    context.Response.Write(fileSaveAs(_upfile[i], ShopNum1.Common.Common.ReqStr("opspec")));
                    break;
                }
            }
            if (context.Request.QueryString["type"] != null)
            {
                string strType = context.Request.QueryString["type"];
                if (strType == "0")
                {
                    var shopNum1_Brand_Action = new ShopNum1_Brand_Action();
                    DataTable dt = shopNum1_Brand_Action.dt_Select_BrandByCid(ShopNum1.Common.Common.ReqStr("brand_cid"));
                    context.Response.Write(GetJson(dt));
                }
                else if (strType == "1")
                {
                    string strId = context.Request.QueryString["id"];
                    var shopPc_Action =
                        (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
                    try
                    {
                        DataTable dt_Type = shopPc_Action.GetCategory(strId);
                        context.Response.Write(GetJson(dt_Type));
                    }
                    catch
                    {
                        context.Response.Write("error");
                    }
                }
                else if (strType == "2")
                {
                    string strKey = HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("keyword"));
                    var shopPc_Action =
                        (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
                    try
                    {
                        DataTable dt_Pc = shopPc_Action.GetThreeType(strKey, "");
                        context.Response.Write(GetJson(dt_Pc));
                    }
                    catch
                    {
                        context.Response.Write("error");
                    }
                }
                else if (strType == "3")
                {
                    string strC = context.Request.QueryString["str"];
                    string strCurrent = context.Request.QueryString["page"];
                    string strcondition = string.Empty;
                    if (ShopNum1.Common.Common.ReqStr("hidtype") != "0")
                        strcondition = " and ImageCategoryID='" + ShopNum1.Common.Common.ReqStr("hidtype") + "' ";
                    if (strC.IndexOf("none") == -1)
                    {
                        strcondition += " and createuser='" + GetMemLoginId() + "'";
                        var shopNum1_Image_Action = new Shop_Image_Action();
                        string rp = GetJson(shopNum1_Image_Action.dt_Album_Page("14", strCurrent, strcondition, "1"));
                        int totalcount =
                            Convert.ToInt32(
                                shopNum1_Image_Action.dt_Album_Page("14", strCurrent, strcondition, "0").Rows[0][0]);
                        double pageC = Math.Ceiling(totalcount / Convert.ToDouble(14));
                        string page = "{ \"countinfo\":[ { \"countpage\":\"" + pageC + "\",\"allcount\":\"" + totalcount +
                                      "\",\"areacount\":\"0\"}]}|";
                        context.Response.Write(page + rp);
                    }
                }
                else if (strType == "4")
                {
                    var shop_ImageCategory_Action = new Shop_ImageCategory_Action();
                    context.Response.Write(GetJson(shop_ImageCategory_Action.Select_AllType(GetMemLoginId())));
                }
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }

        /// <summary>
        ///   文件上传方法
        /// </summary>
        public string fileSaveAs(HttpPostedFile _postedFile, string Speccheck)
        {
            try
            {
                string fileName = _postedFile.FileName;
                string _fileExt = _postedFile.FileName.Substring(fileName.LastIndexOf(".") + 1).Trim().ToLower();
                //验证合法的文件
                string[] strArray = { "jpg", "png", "jpge", "gif", "bmp", "jpeg" };
                if (!ShopNum1.Common.Common.CheckImgType(strArray, _fileExt))
                {
                    return "{msg: 0, imagepath: \"不允许上传" + _fileExt + "类型的文件！\"}";
                }
                if (_postedFile.ContentLength > 1024 * 1024)
                {
                    return "{msg: 0, imagepath: \"文件1M超过限制的大小啦！\"}";
                }
                if (fileName.IndexOf(' ') > -1)
                {
                    fileName = fileName.Substring(fileName.LastIndexOf(' ') + 1);
                }
                else if (fileName.IndexOf('/') > -1)
                {
                    fileName = fileName.Substring(fileName.LastIndexOf('/') + 1);
                }
                string strShopId = ShopNum1.Common.Common.GetNameById("ShopId", "shopnum1_shopinfo",
                                                      " and memloginid='" + GetMemLoginId() + "'");
                string strOpenTime = ShopNum1.Common.Common.GetNameById("OpenTime", "shopnum1_shopinfo",
                                                        " and memloginid='" + GetMemLoginId() + "'");
                string uploadDir = "/ImgUpload/shopImage/" + Convert.ToDateTime(strOpenTime).ToString("yyyy") + "/shop" +
                                   strShopId + "/";

                //检查是否有该路径没有就创建
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(uploadDir)))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(uploadDir));
                }
                string strFileExt = fileName.Substring(fileName.LastIndexOf("."));
                strFileExt = ".jpg";
                var r = new Random();
                string strNewFileName = DateTime.Now.ToString("yyyyMMddhhmmss") + r.Next(1, 9);
                string uploadPath = uploadDir + strNewFileName + strFileExt;
                _postedFile.SaveAs(HttpContext.Current.Server.MapPath(uploadPath));
                Image image = Image.FromStream(_postedFile.InputStream);
                float w = image.Width;
                float h = image.Height;
                string fileType = Path.GetExtension(fileName).ToLower();
                var shopNum1_Shop_Image = new ShopNum1_Shop_Image();
                var shop_Image_Action = (Shop_Image_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Image_Action();
                shopNum1_Shop_Image.Name = fileName.Replace(fileType, "");
                shopNum1_Shop_Image.ImageType = fileType;
                shopNum1_Shop_Image.ImagePath = uploadPath;
                shopNum1_Shop_Image.CreateUser = GetMemLoginId();
                shopNum1_Shop_Image.ImageCategoryID = 1;
                shopNum1_Shop_Image.ImageSize = _postedFile.ContentLength;
                shopNum1_Shop_Image.DisplaySize = w + "×" + h;
                shop_Image_Action.Insert(shopNum1_Shop_Image);

                string strImg25 = uploadPath + "_25x25.jpg";
                string strImg60 = uploadPath + "_60x60.jpg";
                string strImg100 = uploadPath + "_100x100.jpg";
                string strImg160 = uploadPath + "_160x160.jpg";
                string strImg300 = uploadPath + "_300x300.jpg";
                ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(uploadPath),
                                                  HttpContext.Current.Server.MapPath(strImg25), 25, 25);
                // 25x25(规格小图专用)  商品上传单独处理
                if (Speccheck == "")
                {
                    ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(uploadPath),
                                                      HttpContext.Current.Server.MapPath(strImg60), 60, 60);
                    //60x60    商品详细小图用
                    ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(uploadPath),
                                                      HttpContext.Current.Server.MapPath(strImg100), 100, 100);
                    //100x100(手机用)
                    ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(uploadPath),
                                                      HttpContext.Current.Server.MapPath(strImg160), 160, 160); //商品列表
                    ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(uploadPath),
                                                      HttpContext.Current.Server.MapPath(strImg300), 300, 300); //商品详细
                }
                return "{msg: 1, imagepath: \"" + uploadPath.Replace("~/", "/") + "\",smallimage:\"" + strImg60 +
                       "\",mediumimage:\"" + strImg100 + "\"}";
            }
            catch (Exception ex)
            {
                return "{msg: 0, imagepath: \"上传过程中发生意外错误！+" + ex.Message + "\"}";
            }
        }

        //获取登录用户方法
        private string GetMemLoginId()
        {
            string name = "jely";
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookieShopNum1MemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookieShopNum1MemberLogin);
                name = decodedCookieShopNum1MemberLogin.Values["MemLoginID"];
            }
            return name;
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
                        sbJson.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" +
                                      dt.Rows[i][j].ToString().Replace("~/", "/") + "\",");
                    }
                    sbJson.Remove(sbJson.Length - 1, 1);
                    sbJson.Append("},");
                }
                sbJson.Remove(sbJson.Length - 1, 1);
                sbJson.Append("]");
            }
            return sbJson.ToString();
        }
    }
}