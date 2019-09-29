using System;
using System.IO;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Xml;
using ShopNum1.Common;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ServiceSite_Settings : PageBase, IRequiresSessionState
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
                        case "PersonShopUrl":
                            this.txtShopUrl.Text = xmlNode2.InnerText;
                            break;
                        case "Name":
                            this.TextBoxName.Text = xmlNode2.InnerText;
                            break;
                        case "Title":
                            this.TextBoxTitle.Text = xmlNode2.InnerText;
                            break;
                        case "Description":
                            this.TextBoxDescription.Text = xmlNode2.InnerText;
                            break;
                        case "KeyWords":
                            this.TextBoxKeyWords.Text = xmlNode2.InnerText;
                            break;
                        case "Copyright":
                            this.TextBoxCopyright.Text = xmlNode2.InnerText;
                            break;
                        case "CopyrightLink":
                            this.TextBoxCopyrightLink.Text = xmlNode2.InnerText;
                            break;
                        case "Logo":
                            this.HiddenFieldOriginalImge.Value = xmlNode2.InnerText;
                            this.ImageOriginalImge.Src = this.Page.ResolveUrl(this.HiddenFieldOriginalImge.Value);
                            break;
                        case "Link":
                            this.TextBoxLink.Text = xmlNode2.InnerText;
                            break;
                        case "RegProtocol":
                            this.FCKeditorRegProtocol.Value=xmlNode2.InnerText;
                            this.TexteditorReg.Text = xmlNode2.InnerText;
                            break;
                        case "ShopRegProtocol":
                            this.FCKeditorShopRegProtocol.Value=xmlNode2.InnerText;
                            this.TexteditorShopReg.Text = xmlNode2.InnerText;
                            break;
                        case "ButtomInfo":
                            this.TextBoxButtomInfo.Text = xmlNode2.InnerText;
                            break;
                        case "ShopLogo":
                            this.TextBoxShopOriginalImge.Text = xmlNode2.InnerText;
                            this.ImageShopOriginalImge.Src = this.Page.ResolveUrl(this.TextBoxShopOriginalImge.Text);
                            break;
                        case "CopyrightShop":
                            this.TextBoxCopyrightShop.Text = xmlNode2.InnerText;
                            break;
                        case "MemberLogo":
                            this.HiddenFieldMemberOriginalImge.Value = xmlNode2.InnerText;
                            this.ImageMemberOriginalImge.Src = this.Page.ResolveUrl(this.HiddenFieldMemberOriginalImge.Value);
                            break;
                        case "CopyrightMember":
                            this.TextBoxCopyrightMember.Text = xmlNode2.InnerText;
                            break;
                        case "PhoneEWM":
                            this.hfPhoneEWM.Value = xmlNode2.InnerText;
                            this.imgPhoneEWM.Src = this.Page.ResolveUrl(this.hfPhoneEWM.Value).Replace("~/", "/");
                            break;
                        case "MicroEWM":
                            this.hfMicroEWM.Value = xmlNode2.InnerText;
                            this.ImgMicroEWM.Src = this.Page.ResolveUrl(this.hfMicroEWM.Value).Replace("~/", "/");
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
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/Name", this.TextBoxName.Text);
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/Title", this.TextBoxTitle.Text);
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/Description", this.TextBoxDescription.Text);
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/KeyWords", this.TextBoxKeyWords.Text);
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/Copyright", this.TextBoxCopyright.Text);
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/CopyrightLink", this.TextBoxCopyrightLink.Text);
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/Logo", this.HiddenFieldOriginalImge.Value);
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/Link", this.TextBoxLink.Text.Trim());
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RegProtocol", this.TexteditorReg.Text.Trim());
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopRegProtocol", this.TexteditorShopReg.Text.Trim());
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ButtomInfo", this.TextBoxButtomInfo.Text.Trim());
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MemberLogo", this.HiddenFieldMemberOriginalImge.Value);
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/CopyrightMember", this.TextBoxCopyrightMember.Text);
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShopLogo", this.TextBoxShopOriginalImge.Text.Trim());
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/PersonShopUrl", this.txtShopUrl.Text);
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/CopyrightShop", this.TextBoxCopyrightShop.Text);
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/PhoneEWM", this.hfPhoneEWM.Value);
                XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MicroEWM", this.hfMicroEWM.Value);
                ShopSettings.ResetShopSetting();
            }
            catch
            {
                this.MessageShow.ShowMessage("权限设置，请联系管理员");
                this.MessageShow.Visible = true;
                return;
            }
            if (num > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();
                
                shopNum1_OperateLog.Record="站点信息修改成功";
                shopNum1_OperateLog.OperatorID = cookie2.Values["LoginID"].ToString();
                shopNum1_OperateLog.IP=Globals.IPAddress;
                shopNum1_OperateLog.PageName="ServiceSite_Settings.aspx";
                shopNum1_OperateLog.Date=Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
              
                base.OperateLog(shopNum1_OperateLog);
               
                this.MessageShow.ShowMessage("EditYes");
                this.MessageShow.Visible = true;
                ShopSettings.ResetShopSetting();
                this.ImageMemberOriginalImge.Src = this.Page.ResolveUrl(this.HiddenFieldMemberOriginalImge.Value);
                this.ImageOriginalImge.Src = this.Page.ResolveUrl(this.HiddenFieldOriginalImge.Value);
                this.imgPhoneEWM.Src = this.Page.ResolveUrl(this.hfPhoneEWM.Value);
                this.ImgMicroEWM.Src = this.Page.ResolveUrl(this.hfMicroEWM.Value);
            }
            else
            {
                this.MessageShow.ShowMessage("EditNo");
                this.MessageShow.Visible = true;
            }
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