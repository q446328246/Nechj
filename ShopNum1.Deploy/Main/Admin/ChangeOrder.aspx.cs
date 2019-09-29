using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ChangeOrder : PageBase, IRequiresSessionState
    {
        protected string back { get; set; }

        protected string guid { get; set; }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            if (back == "prouduct")
            {
                base.Response.Redirect("Prouduct_List.aspx");
            }
            else if (back == "shop")
            {
                base.Response.Redirect("ShopInfoList_Manage.aspx");
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (back == "prouduct")
            {
                num =
                    ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action())
                        .UpdateProduct(guid, "OrderID", TextBoxOrderID.Text.Trim());
            }
            else if (back == ShopSettings.GetValue("PersonShopUrl"))
            {
                num = ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action()).Update(guid,
                                                                                                                TextBoxOrderID
                                                                                                                    .Text
                                                                                                                    .Trim
                                                                                                                    (),
                                                                                                                "OrderID");
            }
            if (num > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "ÐÞ¸ÄÅÅÐòºÅ³É¹¦",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ChangeOrder.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                if (back == "prouduct")
                {
                    base.Response.Redirect("Prouduct_List.aspx");
                }
                else if (back == "shop")
                {
                    base.Response.Redirect("ShopInfoList_Manage.aspx");
                }
            }
        }

        protected void BindData()
        {
            DataTable orderID =
                ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetOrderID(guid);
            if (orderID.Rows.Count > 0)
            {
                TextBoxOrderID.Text = orderID.Rows[0]["orderid"].ToString();
            }
            else
            {
                TextBoxOrderID.Text = "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            guid = (Page.Request.QueryString["guid"] == null)
                       ? Guid.NewGuid().ToString()
                       : Page.Request.QueryString["guid"];
            back = (Page.Request.QueryString["back"] == null) ? "-1" : Page.Request.QueryString["back"];
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
    }
}