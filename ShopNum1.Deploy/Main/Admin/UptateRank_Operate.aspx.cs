using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class UptateRank_Operate : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            HiddenFieldGuid.Value = (Page.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                GetShopRank();
                DateBind();
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            if (action.Update(HiddenFieldGuid.Value, CheckGuid.Value, "ShopRank") > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员修改店铺等级",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "UptateRank_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                string memberLoginID = Common.Common.GetNameById("MemLoginID", "ShopNum1_ShopInfo",
                                                                 "  AND Guid='" + HiddenFieldGuid.Value.Replace("'", "") +
                                                                 "'  ");
                DataTable table =
                    ((Shop_Rank_Action) ShopFactory.LogicFactory.CreateShop_Rank_Action()).Search(
                        "'" + CheckGuid.Value.Replace("'", "") + "'", 0);
                int num2 = 0;
                string str2 = string.Empty;
                if ((table != null) && (table.Rows.Count > 0))
                {
                    num2 = Convert.ToInt32(table.Rows[0]["IsDefault"].ToString());
                    str2 = table.Rows[0]["Name"].ToString();
                }
                if (num2 == 1)
                {
                    var action3 = (Shop_ShopApplyRank_Action) ShopFactory.LogicFactory.CreateShop_ShopApplyRank_Action();
                    try
                    {
                        action3.DeleteOutRankGuid(CheckGuid.Value.Replace("'", ""), memberLoginID);
                    }
                    catch (Exception)
                    {
                    }
                    var rank = new ShopNum1_Shop_ApplyShopRank
                        {
                            ApplyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            IsAudit = 1,
                            MemberLoginID = memberLoginID,
                            IsPayMent = 1,
                            PaymentName = "金币（BV）支付",
                            PaymentType = new Guid("385c9c54-2b58-4b65-8ea9-f01872126715"),
                            RankGuid = new Guid(CheckGuid.Value.Replace("'", "")),
                            VerifyTime = DateTime.Now.AddYears(1),
                            RankName = str2
                        };
                    try
                    {
                        action3.Add(rank);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("等级记录失败！");
                    }
                }
                base.Response.Redirect("ShopInfoList_Manage.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNO");
                MessageShow.Visible = true;
            }
        }

        protected void DateBind()
        {
            Num1GridViewShow.DataBind();
        }

        protected void GetShopRank()
        {
            DataTable allShopInfoByGuid =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action()).GetAllShopInfoByGuid(
                    HiddenFieldGuid.Value.Replace("'", ""));
            if ((allShopInfoByGuid != null) && (allShopInfoByGuid.Rows.Count > 0))
            {
                HiddenFieldShopRank.Value = allShopInfoByGuid.Rows[0]["ShopRank"].ToString();
            }
        }

        protected string IsDoMain(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "不可以";
            }
            if (object_0.ToString() == "1")
            {
                return "可以";
            }
            return "非法类型";
        }

        protected void Num1GridViewShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var box = (HtmlInputCheckBox) e.Row.Cells[0].FindControl("checkboxItem");
                if (box.Value == HiddenFieldShopRank.Value)
                {
                    box.Checked = true;
                }
            }
        }
    }
}