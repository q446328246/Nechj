using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class CouponList : PageBase, IRequiresSessionState
    {
        protected void BindDropDownListType()
        {
            DropDownListType.Items.Clear();
            DropDownListType.Items.Add(new ListItem("-全部-", "-1"));
            DataTable table = ((Shop_CouponType_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_CouponType_Action()).search(-1, 1);
            if ((table != null) && (table.Rows.Count > 0))
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    var item = new ListItem
                        {
                            Text = table.Rows[i]["Name"].ToString(),
                            Value = table.Rows[i]["ID"].ToString()
                        };
                    DropDownListType.Items.Add(item);
                }
            }
        }

        protected void BindProductIsAudit()
        {
            DropDownListIsAudit.Items.Clear();
            DropDownListIsAudit.Items.Add(new ListItem("-已审核-", "1"));
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (Shop_Coupon_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Coupon_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺优惠劵",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "CouponList.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindData();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string iD = "'" + button.CommandArgument + "'";
            var action = (Shop_Coupon_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Coupon_Action();
            if (action.Delete(iD) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺优惠劵",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "CouponList.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindData();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonOperate_Click(object sender, EventArgs e)
        {
            var action = (Shop_Coupon_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Coupon_Action();
            if (action.UpdateAudit("IsAudit", "1", CheckGuid.Value) > 0)
            {
                BindData();
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonOperate1_Click(object sender, EventArgs e)
        {
            var action = (Shop_Coupon_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Coupon_Action();
            if (action.UpdateAudit("IsAudit", "2", CheckGuid.Value) > 0)
            {
                BindData();
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ButtonSearchBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string str = "'" + button.CommandArgument + "'";
            base.Response.Redirect("CouponList_Search.aspx?guid=" + str + "&Type=List");
        }

        protected void ButtonSearchShop_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CouponList_Search.aspx?guid=" + CheckGuid.Value + "&Type=List");
        }

        protected void DropDownListRegionCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListRegionCode2.Items.Clear();
            DropDownListRegionCode2.Items.Add(new ListItem("-市级-", "-1"));
            if (DropDownListRegionCode1.SelectedValue != "-1")
            {
                DataTable table =
                    ((ShopNum1_Region_Action) LogicFactory.CreateShopNum1_Region_Action()).SearchtRegionCategory(
                        Convert.ToInt32(DropDownListRegionCode1.SelectedValue.Split(new[] {'/'})[1]), 0);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DropDownListRegionCode2.Items.Add(new ListItem(table.Rows[i]["Name"].ToString(),
                                                                   table.Rows[i]["Code"] + "/" + table.Rows[i]["ID"]));
                }
            }
            DropDownListRegionCode2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListRegionCode1Bind()
        {
            DropDownListRegionCode1.Items.Clear();
            DropDownListRegionCode1.Items.Add(new ListItem("-省级-", "-1"));
            DataTable table =
                ((ShopNum1_Region_Action) LogicFactory.CreateShopNum1_Region_Action()).SearchtRegionCategory(0, 0);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownListRegionCode1.Items.Add(new ListItem(table.Rows[i]["Name"].ToString(),
                                                               table.Rows[i]["Code"] + "/" + table.Rows[i]["ID"]));
            }
            DropDownListRegionCode1_SelectedIndexChanged(null, null);
        }

        protected void DropDownListRegionCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListRegionCode3.Items.Clear();
            DropDownListRegionCode3.Items.Add(new ListItem("-县级-", "-1"));
            if (DropDownListRegionCode2.SelectedValue != "-1")
            {
                DataTable table =
                    ((ShopNum1_Region_Action) LogicFactory.CreateShopNum1_Region_Action()).SearchtRegionCategory(
                        Convert.ToInt32(DropDownListRegionCode2.SelectedValue.Split(new[] {'/'})[1]), 0);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DropDownListRegionCode3.Items.Add(new ListItem(table.Rows[i]["Name"].ToString(),
                                                                   table.Rows[i]["Code"] + "/" + table.Rows[i]["ID"]));
                }
            }
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "未审核";
            }
            if (object_0.ToString() == "1")
            {
                return "已通过";
            }
            if (object_0.ToString() == "2")
            {
                return "审核未通过";
            }
            return "非法状态";
        }

        private void BindData()
        {
            try
            {
                SetShopRegionCode();
                Num1GridViewShow.DataBind();
            }
            catch (Exception)
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindProductIsAudit();
                DropDownListRegionCode1Bind();
                BindDropDownListType();
                BindData();
            }
        }

        public void SetShopRegionCode()
        {
            if (DropDownListRegionCode3.SelectedValue != "-1")
            {
                HiddenFieldRegionCode.Value = DropDownListRegionCode3.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListRegionCode2.SelectedValue != "-1")
            {
                HiddenFieldRegionCode.Value = DropDownListRegionCode2.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListRegionCode1.SelectedValue != "-1")
            {
                HiddenFieldRegionCode.Value = DropDownListRegionCode1.SelectedValue.Split(new[] {'/'})[0];
            }
            else
            {
                HiddenFieldRegionCode.Value = "-1";
            }
        }
    }
}