using System;
using System.Web.SessionState;
using System.Xml;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Limit_Setting : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
                BindData();
            }
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = true;
            try
            {
                XmlOperator.XmlNodeReplace(HiddenFieldXmlPath.Value, "ShopSetting/Limit_Money", txtMoney.Value);
                XmlOperator.XmlNodeReplace(HiddenFieldXmlPath.Value, "ShopSetting/Limit_ActivityCount",
                                           txtMonthActivity.Value);
                XmlOperator.XmlNodeReplace(HiddenFieldXmlPath.Value, "ShopSetting/Limit_GoodsCount", txtGoodsCount.Value);
                ShopSettings.ResetShopSetting();
                lblMsg.Text = "²Ù×÷³É¹¦£¡";
            }
            catch (Exception exception)
            {
                lblMsg.Text = exception.Message;
            }
        }

        private void BindData()
        {
            foreach (XmlNode node2 in XmlOperator.ReadXmlReturnNodeList(HiddenFieldXmlPath.Value, "ShopSetting"))
            {
                foreach (XmlNode node in node2.ChildNodes)
                {
                    string name = node.Name;
                    if (name != null)
                    {
                        if (name != "Limit_Money")
                        {
                            if (!(name == "Limit_ActivityCount"))
                            {
                                if (name == "Limit_GoodsCount")
                                {
                                    txtGoodsCount.Value = node.InnerText;
                                }
                            }
                            else
                            {
                                txtMonthActivity.Value = node.InnerText;
                            }
                        }
                        else
                        {
                            txtMoney.Value = node.InnerText;
                        }
                    }
                }
            }
        }


    }
}