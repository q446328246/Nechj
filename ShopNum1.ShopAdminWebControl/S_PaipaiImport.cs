using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_PaipaiImport : BaseShopWebControl, IPostBackEventHandler
    {
        private static MatchEvaluator matchEvaluator_0;

        private readonly Shop_Common_Action shop_Common_Action_0 =
            ((Shop_Common_Action) LogicFactory.CreateShop_Common_Action());

        private readonly Shop_ShopInfo_Action shop_ShopInfo_Action_0 =
            ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action());

        private DataTable dt = new DataTable();
        private HtmlInputHidden hidLoginId;
        private HtmlInputHidden hidatype;
        private HtmlInputHidden hidbtype;
        private HtmlInputHidden hidctype;
        private HtmlInputHidden hidpath;
        private HtmlInputHidden hidptype;
        private HtmlInputHidden hidsell;
        private HtmlInputHidden hidstype;
        private Label lblMsg;

        private string skinFilename = "S_PaipaiImport.ascx";
        private string string_1 = string.Empty;

        public S_PaipaiImport()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private string imgUploadPath { get; set; }

        private string ShopImgUpload { get; set; }

        private string ShopRank { get; set; }

        private string Temppath { get; set; }

        public void RaisePostBackEvent(string eventArgument)
        {
            string str = Page.Request.Form["__EVENTTARGET"];
            Func<string, bool> func = method_2;
            func(str);
        }

        public void AddImageSizeToXML(string filepath)
        {
            string str = filepath.Substring(filepath.LastIndexOf('/') + 1);
            string str2 = filepath.Substring(0, filepath.LastIndexOf('/') + 1);
            string str3 = "s_" + str;
            string path = str2 + str3;
            string str5 = Page.Server.MapPath(filepath);
            string str6 = Page.Server.MapPath(path);
            if (File.Exists(str5) && File.Exists(str6))
            {
                var info = new FileInfo(str5);
                var info2 = new FileInfo(str6);
                var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
                string str7 =
                    DateTime.Parse(action.GetMemLoginInfo(base.MemLoginID).Rows[0]["OpenTime"].ToString())
                        .ToString("yyyy-MM-dd");
                new XmlDataSource();
                string str8 = "~/Shop/Shop/" + str7.Replace("-", "/") + "/shop" + string_1 + "/Site_Settings.xml";
                var set = new DataSet();
                set.ReadXml(Page.Server.MapPath(str8));
                DataRow row = set.Tables["Setting"].Rows[0];
                row["UserImageSpace"] =
                    ((Convert.ToInt64(row["UserImageSpace"]) + info.Length) + info2.Length).ToString();
                set.AcceptChanges();
                set.WriteXml(Page.Server.MapPath(str8));
            }
        }

        public void AddImageToDataBase(string imagePath)
        {
            var image = new ShopNum1_Shop_Image();
            var action = (Shop_Image_Action) LogicFactory.CreateShop_Image_Action();
            image.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            image.CreateUser = "admin";
            image.ImageCategoryID = Convert.ToInt32(hidatype.Value.Split(new[] {'|'})[0]);
            image.ImagePath = imagePath;
            image.ImageType = ".jpg";
            image.Name = "tb_" + DateTime.Now.Month + DateTime.Now.Day +
                         DateTime.Now.Hour + DateTime.Now.Minute +
                         DateTime.Now.Millisecond;
            image.UseTimes = 0;
            action.Insert(image);
        }

        protected string GetShopName()
        {
            return shop_ShopInfo_Action_0.GetMemLoginInfo(base.MemLoginID).Rows[0]["ShopName"].ToString();
        }

        protected bool ImportCSV(string strPath)
        {
            bool flag;
            try
            {
                string str;
                ShopNum1UnZipClass.UnZip(strPath, strPath.Replace(".zip", "") + @"\", null);
                Thread.Sleep(20);
                File.Delete(strPath);
                string[] files = Directory.GetFiles(strPath.Replace(".zip", ""));
                string[] directories = Directory.GetDirectories(strPath.Replace(".zip", ""));
                if ((directories.Length == 1) && (files.Length == 0))
                {
                    string[] strArray3 = Directory.GetDirectories(directories[0]);
                    str = Directory.GetFiles(directories[0])[0];
                    imgUploadPath = strArray3[0];
                    dt = read_csv(str);
                    if ((dt != null) && (dt.Rows.Count > 0))
                    {
                        return true;
                    }
                    lblMsg.Text = "没有导入任何数据!";
                    return false;
                }
                if ((directories.Length == 1) && (files.Length == 1))
                {
                    str = files[0];
                    imgUploadPath = directories[0];
                    dt = read_csv(str);
                    if ((dt != null) && (dt.Rows.Count > 0))
                    {
                        return true;
                    }
                    lblMsg.Text = "没有导入任何数据!";
                    return false;
                }
                lblMsg.Text = "导入数据包格式不正确!";
                flag = false;
            }
            catch (Exception)
            {
                lblMsg.Text = "导入的文件的格式不对!请上传正确的ZIP压缩文件!";
                flag = false;
            }
            finally
            {
                try
                {
                    File.Delete(strPath);
                }
                catch
                {
                }
            }
            return flag;
        }

        protected override void InitializeSkin(Control skin)
        {
            hidctype = (HtmlInputHidden) skin.FindControl("hidctype");
            hidptype = (HtmlInputHidden) skin.FindControl("hidptype");
            hidstype = (HtmlInputHidden) skin.FindControl("hidstype");
            hidbtype = (HtmlInputHidden) skin.FindControl("hidbtype");
            hidatype = (HtmlInputHidden) skin.FindControl("hidatype");
            hidsell = (HtmlInputHidden) skin.FindControl("hidsell");
            hidpath = (HtmlInputHidden) skin.FindControl("hidpath");
            hidLoginId = (HtmlInputHidden) skin.FindControl("hidLoginId");
            lblMsg = (Label) skin.FindControl("lblMsg");
            hidLoginId.Value = base.MemLoginID;
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                ShopRank = cookie2.Values["ShopRank"];
            }
            Page.RegisterRequiresRaiseEvent(this);
        }

        protected void BindData()
        {
            Themes.DeleteFolder(Temppath);
        }

        private string method_1(string string_6, string string_7)
        {
            string[] strArray = string_6.Split(new[] {';'});
            string str = string_7;
            foreach (string str6 in strArray)
            {
                if (str6 != strArray[0])
                {
                    string[] strArray3 = str6.Split(new[] {':'});
                    if ((strArray3.Length != 4) && (strArray3.Length == 5))
                    {
                        try
                        {
                            var info = new FileInfo(imgUploadPath + @"\" + strArray3[0] + ".tbi");
                            string str3 = DateTime.Now.ToString("yyyyMMddHHmmss");
                            lock (str3)
                            {
                                Thread.Sleep(1);
                            }
                            string str5 = str3 + new Random().Next(0x3e8);
                            info.CopyTo(Page.Server.MapPath(ShopImgUpload + str5 + ".jpg"));
                            ImageOperator.CreateThumbnailAuto(Page.Server.MapPath(ShopImgUpload + str5 + ".jpg"),
                                Page.Server.MapPath(ShopImgUpload + "s_" + str5 + ".jpg"),
                                300, 300);
                            AddImageSizeToXML(ShopImgUpload + str5 + ".jpg");
                            AddImageToDataBase(ShopImgUpload + str5 + ".jpg");
                            if (str != string.Empty)
                            {
                                str = str + "," + ShopImgUpload + "s_" + str5 + ".jpg";
                            }
                            else
                            {
                                str = string_7 + "," + ShopImgUpload + "s_" + str5 + ".jpg";
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return str;
        }


        private bool method_2(string string_6)
        {
            string str = string_6;
            if ((str != null) && (str == "btnOk"))
            {
                OpImport();
            }
            return true;
        }

        protected bool OpImport()
        {
            int num = 0;
            string strPath = Page.Server.MapPath(hidpath.Value);
            if (ImportCSV(strPath))
            {
                DataTable memLoginInfo = shop_ShopInfo_Action_0.GetMemLoginInfo(base.MemLoginID);
                string_1 = memLoginInfo.Rows[0]["ShopID"].ToString();
                string str2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                ShopImgUpload = "/ImgUpload/shopImage/" + DateTime.Now.ToString("yyyy") + "/shop" + string_1 + "/" +
                                str2 + "/";
                var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
                var action2 = (Shop_Product_Action) LogicFactory.CreateShop_Product_Action();
                string str3 = action.IsAllowToAddProduct(base.MemLoginID, ShopRank, "1");
                int num2 = Convert.ToInt32(str3);
                if (str3 == "0")
                {
                    num2 = 0;
                    lblMsg.Text = "添加的商品已超过权限最大值!";
                    return false;
                }
                var product = new ShopNum1_Shop_Product
                {
                    Score = 0,
                    IsReal = 1,
                    IsSell = Convert.ToInt32(hidsell.Value),
                    UnitName = "",
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    IsNew = 0,
                    IsHot = 0,
                    IsPromotion = 0
                };
                if (ShopSettings.GetValue("AddProductIsAudit") == "0")
                {
                    product.IsAudit = 1;
                }
                else
                {
                    product.IsAudit = 0;
                }
                product.MemLoginID = base.MemLoginID;
                product.ShopName = GetShopName();
                product.ProductCategoryCode = hidptype.Value.Split(new[] {'|'})[0];
                product.ProductCategoryName = hidptype.Value.Split(new[] {'|'})[1];
                product.ProductSeriesCode = hidstype.Value.Split(new[] {'|'})[0];
                product.ProductSeriesName = hidstype.Value.Split(new[] {'|'})[1];
                product.BrandGuid = new Guid(hidbtype.Value.Split(new[] {'|'})[0]);
                product.BrandName = hidbtype.Value.Split(new[] {'|'})[1];
                int num3 = 0;
                while (true)
                {
                    if ((num3 >= dt.Rows.Count) || (num2 <= 0))
                    {
                        break;
                    }
                    try
                    {
                        product.Guid = Guid.NewGuid();
                        product.Name = dt.Rows[num3]["宝贝名称"].ToString();
                        product.ProductNum = dt.Rows[num3]["商家编码"].ToString();
                        product.OrderID = shop_Common_Action_0.ReturnMaxID("OrderID", "ShopNum1_Shop_Product") + 1;
                        product.ShopPrice = Convert.ToDecimal(dt.Rows[num3]["宝贝价格"].ToString().Trim());
                        product.MarketPrice = Convert.ToDecimal(dt.Rows[num3]["宝贝价格"].ToString().Trim());
                        product.RepertoryCount = Convert.ToInt32(dt.Rows[num3]["宝贝数量"].ToString());
                        if (dt.Rows[num3]["运费承担"].ToString() == "0")
                        {
                            product.FeeType = 0;
                            product.Post_fee = Convert.ToDecimal("0.00");
                            product.Express_fee = Convert.ToDecimal("0.00");
                            product.Ems_fee = Convert.ToDecimal("0.00");
                        }
                        else
                        {
                            product.FeeType = 1;
                            product.Post_fee = Convert.ToDecimal(dt.Rows[num3]["平邮"]);
                            product.Express_fee = Convert.ToDecimal(dt.Rows[num3]["快递"]);
                            product.Ems_fee = Convert.ToDecimal(dt.Rows[num3]["EMS"]);
                        }
                        if (matchEvaluator_0 == null)
                        {
                            matchEvaluator_0 = smethod_0;
                        }
                        product.Detail = Regex.Replace(
                            HttpUtility.HtmlDecode(dt.Rows[num3]["宝贝描述"].ToString()), "=\"\"[\\w](.*?)\"\"",
                            matchEvaluator_0);
                        product.Instruction = dt.Rows[num3]["宝贝名称"].ToString();
                        product.OriginalImage = "";
                        product.ThumbImage = "";
                        string str8 = "";
                        if (dt.Rows[num3]["新图片"].ToString() != string.Empty)
                        {
                            try
                            {
                                var strArray = new[] {":0:0:|;"};
                                string[] strArray2 = dt.Rows[num3]["新图片"].ToString().Split(new[] {':'});
                                var info = new FileInfo(imgUploadPath + @"\" + strArray2[0] + ".tbi");
                                string str5 = DateTime.Now.ToString("yyyyMMddHHmmss");
                                lock (str5)
                                {
                                    Thread.Sleep(1);
                                }
                                string str7 = str5 + new Random().Next(0x3e8);
                                info.CopyTo(Page.Server.MapPath(ShopImgUpload + str7 + ".jpg"));
                                product.OriginalImage = ShopImgUpload + str7 + ".jpg";
                                product.ThumbImage = ShopImgUpload + "s_" + str7 + ".jpg";
                                str8 = ShopImgUpload + "s_" + str7 + ".jpg";
                                ImageOperator.CreateThumbnailAuto(Page.Server.MapPath(ShopImgUpload + str7 + ".jpg"),
                                    Page.Server.MapPath(ShopImgUpload + "s_" + str7 +
                                                        ".jpg"), 300, 300);
                                string filepath = ShopImgUpload + str7 + ".jpg";
                                AddImageSizeToXML(filepath);
                                AddImageToDataBase(filepath);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        product.Ctype = Convert.ToInt32(hidctype.Value.Split(new[] {'|'})[0]);
                        product.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        product.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        product.StartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        product.OriginalImage = method_1(dt.Rows[num3]["新图片"].ToString(), str8);
                        product.ThumbImage = method_1(dt.Rows[num3]["新图片"].ToString(), str8);
                        product.SmallImage = method_1(dt.Rows[num3]["新图片"].ToString(), str8);
                        product.Description = dt.Rows[num3]["宝贝名称"].ToString();
                        product.Keywords = dt.Rows[num3]["宝贝名称"].ToString();
                        if (action2.AddShopProduct(product) > 0)
                        {
                            num++;
                            num2--;
                        }
                    }
                    catch (Exception)
                    {
                    }
                    num3++;
                }
                BindData();
                if (num > 0)
                {
                    lblMsg.Text = string.Format("您成功导入了{0}条商品数据!", num);
                    lblMsg.ForeColor = Color.Green;
                    return true;
                }
            }
            return false;
        }

        public static DataTable read_csv(string filepath)
        {
            int num2;
            string str = File.ReadAllText(filepath, Encoding.GetEncoding("gbk")).Replace("\t", ",");
            if (str == null)
            {
                return null;
            }
            var list2 = new List<string[]>();
            var list = new List<string>();
            var builder = new StringBuilder();
            bool flag3 = false;
            bool flag = true;
            for (num2 = 0; num2 < str.Length; num2++)
            {
                char ch = str[num2];
                if (flag3)
                {
                    if (ch == '"')
                    {
                        if ((num2 < (str.Length - 1)) && (str[num2 + 1] == '"'))
                        {
                            builder.Append('"');
                            num2++;
                        }
                        else
                        {
                            flag3 = false;
                        }
                    }
                    else
                    {
                        builder.Append(ch);
                    }
                    continue;
                }
                char ch2 = ch;
                if (ch2 <= '\r')
                {
                    if (ch2 != '\n')
                    {
                        if (ch2 != '\r')
                        {
                            goto lblMsg1A1;
                        }
                        if ((builder.Length > 0) || flag)
                        {
                            list.Add(builder.ToString());
                            builder.Remove(0, builder.Length);
                        }
                        list2.Add(list.ToArray());
                        list.Clear();
                        flag = true;
                        if ((num2 < (str.Length - 1)) && (str[num2 + 1] == '\n'))
                        {
                            num2++;
                        }
                    }
                    else
                    {
                        if ((builder.Length > 0) || flag)
                        {
                            list.Add(builder.ToString());
                            builder.Remove(0, builder.Length);
                        }
                        list2.Add(list.ToArray());
                        list.Clear();
                        flag = true;
                    }
                    continue;
                }
                switch (ch2)
                {
                    case '"':
                    {
                        if (flag)
                        {
                            flag3 = true;
                        }
                        else
                        {
                            builder.Append(ch);
                        }
                        continue;
                    }
                    case ',':
                    {
                        list.Add(builder.ToString());
                        builder.Remove(0, builder.Length);
                        flag = true;
                        continue;
                    }
                }
                lblMsg1A1:
                flag = false;
                builder.Append(ch);
            }
            if ((builder.Length > 10) || flag)
            {
                list.Add(builder.ToString());
            }
            if (list.Count > 0)
            {
                list2.Add(list.ToArray());
            }
            bool flag2 = false;
            var table2 = new DataTable();
            for (num2 = 0; num2 < list2.Count; num2++)
            {
                if (list2[0].Length < 20)
                {
                    list2.Remove(list2[0]);
                    list2.Remove(list2[0]);
                    break;
                }
            }
            for (num2 = 0; num2 < list2.Count; num2++)
            {
                int num;
                if (list2[num2].Length <= 10)
                {
                    continue;
                }
                if (num2 == 0)
                {
                    num = 0;
                    while (num < list2[0].Length)
                    {
                        if (!string.IsNullOrEmpty(list2[0][num]))
                        {
                            var column = new DataColumn
                            {
                                ColumnName = list2[0][num]
                            };
                            table2.Columns.Add(column);
                        }
                        num++;
                    }
                    continue;
                }
                DataRow row = table2.NewRow();
                for (num = 0; num < list2[num2].Length; num++)
                {
                    if ((list2[0][num] == null) || (list2[0][num] == string.Empty))
                    {
                        goto lblMsg371;
                    }
                    row[num] = list2[num2][num];
                }
                goto lblMsg374;
                lblMsg371:
                flag2 = true;
                lblMsg374:
                if (flag2)
                {
                    flag2 = false;
                    return table2;
                }
                table2.Rows.Add(row);
            }
            return table2;
        }


        private static string smethod_0(Match match_0)
        {
            return match_0.ToString().Replace("\"\"", "\"");
        }
    }
}