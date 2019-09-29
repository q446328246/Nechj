using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_AdvertisementOperate : BaseShopWebControl
    {
        private Button btn_Back;
        private Button btn_Save;
        private HtmlInputHidden hid_AdType;
        private HtmlInputHidden hid_PathType;
        private HtmlImage imgShow;
        private HtmlInputFile input_fileUpPath;
        private string skinFilename = "S_AdvertisementOperate.ascx";
        private string string_1;
        private HtmlInputText txt_AdHeight;
        private HtmlInputText txt_AdLink;
        private HtmlInputText txt_AdType;
        private HtmlInputText txt_Adwidth;
        private HtmlInputText txt_Content;
        private HtmlInputText txt_Explain;
        private HtmlInputText txt_Path;
        private HtmlInputText txt_divID;
        private HtmlInputText txt_fieName;
        private HtmlInputText txt_pageName;

        public S_AdvertisementOperate()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Guid { get; set; }

        public string OpenTime { get; set; }

        public string SetPath { get; set; }

        public string ShopID { get; set; }

        public void AddImageSizeToXML(string filepath)
        {
            string path = filepath;
            if (File.Exists(path))
            {
                var info = new FileInfo(path);
                var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
                string str2 =
                    DateTime.Parse(action.GetMemLoginInfo(base.MemLoginID).Rows[0]["OpenTime"].ToString())
                        .ToString("yyyy-MM-dd");
                new XmlDataSource();
                string str3 = "~/Shop/Shop/" + str2.Replace("-", "/") + "/shop" + ShopID + "/Site_Settings.xml";
                var set = new DataSet();
                set.ReadXml(Page.Server.MapPath(str3));
                DataRow row = set.Tables["Setting"].Rows[0];
                row["UserImageSpace"] = (Convert.ToInt64(row["UserImageSpace"]) + info.Length).ToString();
                set.AcceptChanges();
                set.WriteXml(Page.Server.MapPath(str3));
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Edit();
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_AdvertisementList.aspx");
        }

        public void Edit()
        {
            var advertisement = new Advertisement
            {
                Guid = Guid,
                Explain = txt_Explain.Value,
                PageName = txt_pageName.Value,
                FileName = txt_fieName.Value,
                DivID = txt_divID.Value,
                Type = hid_AdType.Value,
                Href = txt_AdLink.Value,
                Content = txt_Content.Value,
                Width = txt_Adwidth.Value,
                Height = txt_AdHeight.Value
            };
            string retstr = "";
            long num = Convert.ToInt64(input_fileUpPath.PostedFile.ContentLength);
            var action = (ShopNum1_ShopInfoList_Action) Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
            long num2 = (Convert.ToInt64(action.Search(base.MemLoginID).Rows[0]["BmaxFileCount"].ToString())*0x400L)*
                        0x400L;
            if ((loadImageSzie() + num) > num2)
            {
                Page.Response.Write(
                    string.Format("<script>alert(\"{0}\");window.location.href=window.location.href;</script>",
                        "空间已满，无法继续上传数据了"));
            }
            else
            {
                if (FileUpload(input_fileUpPath, "/ImgUpload/" + OpenTime.Replace("-", "/") + "/shop" + ShopID + "/",
                    out retstr))
                {
                    advertisement.Content = "Themes/Skin_Default/Images/" + string_1;
                }
                else
                {
                    advertisement.Content = "";
                }
                var action2 = (Shop_Advertisement_Action) LogicFactory.CreateShop_Advertisement_Action();
                action2.StrPath = SetPath;
                if (action2.Update(advertisement) > 0)
                {
                    MessageBox.Show("编辑成功！");
                    Page.Response.Redirect("S_AdvertisementList.aspx");
                }
                else
                {
                    MessageBox.Show("编辑失败");
                }
            }
        }

        protected bool FileUpload(HtmlInputFile fileUpload, string filepath, out string retstr)
        {
            if ((Convert.ToInt64(fileUpload.PostedFile.ContentLength) > 0L) ||
                !string.IsNullOrEmpty(txt_Content.Value.Trim()))
            {
                var random = new Random();
                string fileName = fileUpload.PostedFile.FileName;
                string path = "~/Shop/Shop/" + OpenTime.Replace("-", "/") + "/shop" + ShopID +
                              "/Themes/Skin_Default/Images/";
                string str3 = fileName.Substring(fileName.LastIndexOf(".") + 1);
                string contentType = fileUpload.PostedFile.ContentType;
                int contentLength = fileUpload.PostedFile.ContentLength;
                string str4 = DateTime.Now.ToString("yyyyMMddHHmmss");
                string_1 = str4 + random.Next(100, 0x3e7) + "." + str3;
                if (contentLength < 0xfa000)
                {
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
                    }
                    fileUpload.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(path) + string_1);
                    if (Convert.ToInt64(fileUpload.PostedFile.ContentLength) > 0L)
                    {
                        retstr = HttpContext.Current.Server.MapPath(path) + string_1;
                    }
                    else
                    {
                        retstr = txt_Content.Value.Trim();
                        if (!File.Exists(Page.Server.MapPath(retstr)))
                        {
                            retstr = "文件路径不存在！";
                            return false;
                        }
                    }
                    AddImageSizeToXML(retstr);
                    return true;
                }
                retstr = "文件不能大于1M！";
                return false;
            }
            retstr = "请选择文件！";
            return false;
        }

        public void GetEditInfo()
        {
            var action = (Shop_Advertisement_Action) LogicFactory.CreateShop_Advertisement_Action();
            action.StrPath = SetPath;
            DataRow row = action.SelectByID(Guid).Rows[0];
            txt_pageName.Value = row["pagename"].ToString();
            txt_fieName.Value = row["filename"].ToString();
            txt_divID.Value = row["divid"].ToString();
            txt_Explain.Value = row["explain"].ToString();
            hid_AdType.Value = row["type"].ToString();
            txt_AdLink.Value = row["href"].ToString();
            imgShow.Src = "/Shop/Shop/" + OpenTime.Replace("-", "/") + "/shop" + ShopID + "/" + row["content"];
            if (hid_AdType.Value == "0")
            {
                txt_Content.Value = "/Shop/Shop/" + OpenTime.Replace("-", "/") + "/shop" + ShopID + "/" +
                                    row["content"];
            }
            else
            {
                txt_Content.Value = "/Shop/Shop/" + OpenTime.Replace("-", "/") + "/shop" + ShopID + "/" +
                                    row["content"];
                txt_AdHeight.Value = row["height"].ToString();
                txt_Adwidth.Value = row["width"].ToString();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            txt_pageName = (HtmlInputText) skin.FindControl("txt_pageName");
            txt_fieName = (HtmlInputText) skin.FindControl("txt_fieName");
            txt_divID = (HtmlInputText) skin.FindControl("txt_divID");
            txt_Explain = (HtmlInputText) skin.FindControl("txt_Explain");
            txt_AdType = (HtmlInputText) skin.FindControl("txt_AdType");
            txt_AdLink = (HtmlInputText) skin.FindControl("txt_AdLink");
            txt_Content = (HtmlInputText) skin.FindControl("txt_Content");
            txt_Path = (HtmlInputText) skin.FindControl("txt_Path");
            input_fileUpPath = (HtmlInputFile) skin.FindControl("input_fileUpPath");
            txt_AdHeight = (HtmlInputText) skin.FindControl("txt_AdHeight");
            txt_Adwidth = (HtmlInputText) skin.FindControl("txt_Adwidth");
            hid_AdType = (HtmlInputHidden) skin.FindControl("hid_AdType");
            hid_PathType = (HtmlInputHidden) skin.FindControl("hid_PathType");
            btn_Save = (Button) skin.FindControl("btn_Save");
            btn_Save.Click += btn_Save_Click;
            btn_Back = (Button) skin.FindControl("btn_Back");
            btn_Back.Click += btn_Back_Click;
            imgShow = (HtmlImage) skin.FindControl("imgShow");
            DataTable memLoginInfo =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetMemLoginInfo(base.MemLoginID);
            ShopID = memLoginInfo.Rows[0]["ShopID"].ToString();
            OpenTime = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            SetPath = "~/Shop/Shop/" + OpenTime.Replace("-", "/") + "/shop" + ShopID +
                      "/Themes/Skin_Default/Advertisement.xml";
            Guid = (Common.Common.ReqStr("guid") == "") ? "0" : Common.Common.ReqStr("Guid");
            if (Guid != "0")
            {
                GetEditInfo();
            }
        }

        public long loadImageSzie()
        {
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            string str =
                DateTime.Parse(action.GetMemLoginInfo(base.MemLoginID).Rows[0]["OpenTime"].ToString())
                    .ToString("yyyy-MM-dd");
            new XmlDataSource();
            string path = "~/Shop/Shop/" + str.Replace("-", "/") + "/shop" + ShopID + "/Site_Settings.xml";
            var set = new DataSet();
            set.ReadXml(Page.Server.MapPath(path));
            DataRow row = set.Tables["Setting"].Rows[0];
            return Convert.ToInt64(row["UserImageSpace"]);
        }
    }
}