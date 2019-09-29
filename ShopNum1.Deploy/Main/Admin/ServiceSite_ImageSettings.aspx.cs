using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Xml;
using ShopNum1.Common;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ServiceSite_ImageSettings : PageBase, IRequiresSessionState
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                this.HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
                this.BindSetting();
            }
        }
        protected void BindSetting()
        {
            XmlNodeList xmlNodeList = XmlOperator.ReadXmlReturnNodeList(this.HiddenFieldXmlPath.Value, "ShopSetting");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
                {
                    string name = xmlNode2.Name;
                    switch (name)
                    {
                        case "IfSetWaterMark":
                            if (xmlNode2.InnerText == "0")
                            {
                                this.RadioButtonListIfSetWaterMark.SelectedValue = "0";
                            }
                            if (xmlNode2.InnerText == "1")
                            {
                                this.RadioButtonListIfSetWaterMark.SelectedValue = "1";
                            }
                            if (xmlNode2.InnerText == "2")
                            {
                                this.RadioButtonListIfSetWaterMark.SelectedValue = "2";
                            }
                            break;
                        case "WaterMarkOriginalImge":
                            this.TextBoxWaterMarkOriginalImge.Text = xmlNode2.InnerText;
                            if (!string.IsNullOrEmpty(this.TextBoxWaterMarkOriginalImge.Text))
                            {
                                this.ImgWaterMarkOriginalImge.Src = this.TextBoxWaterMarkOriginalImge.Text;
                            }
                            else
                            {
                                this.ImgWaterMarkOriginalImge.Src = "/Images/noImage.gif";
                            }
                            break;
                        case "WaterMarkImagePosition":
                            this.RadioButtonListWaterMarkImagePosition.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ImageWaterMarkClarity":
                            this.TextBoxImageWaterMarkClarity.Text = xmlNode2.InnerText;
                            break;
                        case "WaterMarkWords":
                            this.TextBoxWaterMarkWords.Text = xmlNode2.InnerText;
                            break;
                        case "WaterMarkWordsFont":
                            {
                                ArrayList arrayList = WaterMarkFont.Font();
                                for (int i = 0; i < arrayList.Count; i++)
                                {
                                    this.DropDownListWaterMarkWordsFont.Items.Add(arrayList[i].ToString());
                                    if (xmlNode2.InnerText == arrayList[i].ToString())
                                    {
                                        this.DropDownListWaterMarkWordsFont.SelectedValue = arrayList[i].ToString();
                                    }
                                }
                                break;
                            }
                        case "WaterMarkWordsFontSize":
                            this.TextBoxWaterMarkWordsFontSize.Text = xmlNode2.InnerText;
                            break;
                        case "WaterMarkWordsColor":
                            this.TextBoxWaterMarkWordsColor.Text = xmlNode2.InnerText;
                            break;
                        case "WordsWaterMarkPosition":
                            this.RadioButtonListWordsWaterMarkPosition.SelectedValue = xmlNode2.InnerText;
                            break;
                    }
                }
            }
        }
        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            int num = 1;
            try
            {
                this.Updata();
            }
            catch (Exception)
            {
                num = 0;
            }
            if (num > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();
                
                shopNum1_OperateLog.Record="图片水印设置成功";
                shopNum1_OperateLog.OperatorID = cookie2.Values["LoginID"].ToString();
                shopNum1_OperateLog.IP=Globals.IPAddress;
                shopNum1_OperateLog.PageName="ServiceSite_ImageSettings.aspx";
                shopNum1_OperateLog.Date=Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
               
                base.OperateLog(shopNum1_OperateLog);
            
                this.MessageShow.ShowMessage("EditYes");
                this.MessageShow.Visible = true;
                ShopSettings.ResetShopSetting();
            }
            else
            {
                this.MessageShow.ShowMessage("EditNo");
                this.MessageShow.Visible = true;
            }
        }
        protected void Updata()
        {
            this.ImgWaterMarkOriginalImge.Src = this.TextBoxWaterMarkOriginalImge.Text;
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/IfSetWaterMark", this.RadioButtonListIfSetWaterMark.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WaterMarkOriginalImge", this.TextBoxWaterMarkOriginalImge.Text.Trim());
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WaterMarkImagePosition", this.RadioButtonListWaterMarkImagePosition.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ImageWaterMarkClarity", this.TextBoxImageWaterMarkClarity.Text.Trim());
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WaterMarkWords", this.TextBoxWaterMarkWords.Text.Trim());
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WaterMarkWordsFont", this.DropDownListWaterMarkWordsFont.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WaterMarkWordsFontSize", this.TextBoxWaterMarkWordsFontSize.Text.Trim());
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WaterMarkWordsColor", this.TextBoxWaterMarkWordsColor.Text.Trim());
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WordsWaterMarkPosition", this.RadioButtonListWordsWaterMarkPosition.SelectedValue);
            ShopSettings.ResetShopSetting();
        }
        protected bool FileUpload(FileUpload fileUpload, string filepath, out string strext)
        {
            new Random();
            string fileName = fileUpload.PostedFile.FileName;
            FileInfo fileInfo = new FileInfo(fileName);
            string text = "~/Upload/";
            fileName.Substring(fileName.LastIndexOf(".") + 1);
            string arg_3E_0 = fileUpload.PostedFile.ContentType;
            int contentLength = fileUpload.PostedFile.ContentLength;
            bool result;
            if (fileName != "")
            {
                if (contentLength < 1024000)
                {
                    if (!Directory.Exists(base.Server.MapPath(text)))
                    {
                        Directory.CreateDirectory(base.Server.MapPath(text));
                    }
                    fileUpload.PostedFile.SaveAs(base.Server.MapPath(text + fileInfo.Name));
                    strext = fileName;
                    result = true;
                }
                else
                {
                    strext = "文件不能大于1M！";
                    result = false;
                }
            }
            else
            {
                strext = "upload 为空！";
                result = false;
            }
            return result;
        }

    }
}