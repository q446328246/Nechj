using System;
using System.Web.SessionState;
using System.Xml;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Service_EmailSendSetting : PageBase, IRequiresSessionState
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
                        case "PayIsEmail":
                            this.DropDownListPayIsEmail.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ShipmentIsEmail":
                            this.DropDownListShipmentIsEmail.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ShipmentOKIsEmail":
                            this.DropDownListShipmentOKIsEmail.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "CancelOrderIsEmail":
                            this.DropDownListCancelOrderIsEmail.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "OrderIsEmail":
                            this.DropDownListOrderIsEmail.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "OrderToShopIsEmail":
                            this.DropDownListOrderToShopIsEmail.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "RegIsEmail":
                            this.DropDownListMemberRegister.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "RegIsActivationEmail":
                            this.DropDownListRegIsActivationEmail.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ApplyOpenShopIsEmail":
                            this.DropDownListApplyOpenShopIsEmail.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "AuditOpenShopIsEmail":
                            this.DropDownListAuditOpenShopIsEmail.SelectedValue = xmlNode2.InnerText;
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
                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();
                shopNum1_OperateLog.Record="” º˛∑¢ÀÕ…Ë÷√";
                shopNum1_OperateLog.OperatorID=base.ShopNum1LoginID;
                shopNum1_OperateLog.IP=Globals.IPAddress;
                shopNum1_OperateLog.PageName="Service_EmailSendSetting.aspx";
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
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/PayIsEmail", this.DropDownListPayIsEmail.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShipmentIsEmail", this.DropDownListShipmentIsEmail.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShipmentOKIsEmail", this.DropDownListShipmentOKIsEmail.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/CancelOrderIsEmail", this.DropDownListCancelOrderIsEmail.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/OrderIsEmail", this.DropDownListOrderIsEmail.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RegIsEmail", this.DropDownListMemberRegister.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RegIsActivationEmail", this.DropDownListRegIsActivationEmail.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ApplyOpenShopIsEmail", this.DropDownListApplyOpenShopIsEmail.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/OrderToShopIsEmail", this.DropDownListOrderToShopIsEmail.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AuditOpenShopIsEmail", this.DropDownListAuditOpenShopIsEmail.SelectedValue);
            ShopSettings.ResetShopSetting();
        }
    }
}