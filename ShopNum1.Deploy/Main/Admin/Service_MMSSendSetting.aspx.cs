using System;
using System.Web.SessionState;
using System.Xml;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Service_MMSSendSetting : PageBase, IRequiresSessionState
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
                        case "PayIsMMS":
                            this.DropDownListPayIsMMS.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ShipmentIsMMS":
                            this.DropDownListShipmentIsMMS.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ShipmentOKIsMMS":
                            this.DropDownListShipmentOKIsMMS.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "CancelOrderIsMMS":
                            this.DropDownListCancelOrderIsMMS.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "OrderIsMMS":
                            this.DropDownListOrderIsMMS.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "RegistOrderIsMMS":
                            this.DropDownListRegistOrderIsMMS.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "ApplyOpenShopIsMMS":
                            this.DropDownListApplyOpenShopIsMMS.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "AuditOpenShopIsMMS":
                            this.DropDownListAuditOpenShopIsMMS.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "IsMobileCheckPay":
                            this.DropDownListMobileCheck.SelectedValue = xmlNode2.InnerText;
                            break;
                        case "OrderToShopIsMMS":
                            this.DropDownListOrderToShopIsMMS.SelectedValue = xmlNode2.InnerText;
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
                
                shopNum1_OperateLog.Record="∂Ã–≈∑¢ÀÕ…Ë÷√";
                shopNum1_OperateLog.OperatorID=base.ShopNum1LoginID;
                shopNum1_OperateLog.IP=Globals.IPAddress;
                shopNum1_OperateLog.PageName="Service_MMSSendSetting.aspx";
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
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/PayIsMMS", this.DropDownListPayIsMMS.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShipmentIsMMS", this.DropDownListShipmentIsMMS.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShipmentOKIsMMS", this.DropDownListShipmentOKIsMMS.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/CancelOrderIsMMS", this.DropDownListCancelOrderIsMMS.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/OrderIsMMS", this.DropDownListOrderIsMMS.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RegistOrderIsMMS", this.DropDownListRegistOrderIsMMS.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ApplyOpenShopIsMMS", this.DropDownListApplyOpenShopIsMMS.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AuditOpenShopIsMMS", this.DropDownListAuditOpenShopIsMMS.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/IsMobileCheckPay", this.DropDownListMobileCheck.SelectedValue);
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/OrderToShopIsMMS", this.DropDownListOrderToShopIsMMS.SelectedValue);
            ShopSettings.ResetShopSetting();
        }
    }
}