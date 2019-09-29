using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ComplaintsManagement_List : PageBase, IRequiresSessionState
    {
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action =
                (ShopNum1_ComplaintsManagement_Action)LogicFactory.CreateShopNum1_ComplaintsManagement_Action();
            if (action.DeleteReport(CheckGuid.Value) > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除举报信息",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "ComplaintsManagement_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
                method_6();
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var action =
                (ShopNum1_ComplaintsManagement_Action)LogicFactory.CreateShopNum1_ComplaintsManagement_Action();
            var button = (LinkButton)sender;
            string commandArgument = button.CommandArgument;
            if (action.DeleteReport(commandArgument) > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除举报信息",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "ComplaintsManagement_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
                method_6();
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonReply_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_MemberReport_Action)LogicFactory.CreateShopNum1_MemberReport_Action();
            if (action.GetComplaintsManagement(CheckGuid.Value).Rows.Count > 0)
            {
                base.Response.Redirect("ComplaintsManagement_Operate.aspx?guid=" + CheckGuid.Value);
            }
            else
            {
                MessageBox.Show("举报的商品已被删除或不存在！");
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            method_6();
        }

        protected string IsProcess(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "未处理";
            }
            if (object_0.ToString() == "1")
            {
                return "处理中";
            }
            if (object_0.ToString() == "2")
            {
                return "已处理";
            }
            return "非法状态";
        }

        private void method_5()
        {
            DropDownListType.Items.Clear();
            DropDownListType.Items.Add(new ListItem("-全部-", "-1"));
            DropDownListType.Items.Add(new ListItem("炒作信用度", "炒作信用度"));
            DropDownListType.Items.Add(new ListItem("哄抬物价", "哄抬物价"));
            DropDownListType.Items.Add(new ListItem("图片发布侵权", "图片发布侵权"));
            DropDownListType.Items.Add(new ListItem("发布广告信息", "发布广告信息"));
            DropDownListType.Items.Add(new ListItem("支付方式不符合商品", "支付方式不符合商品"));
            DropDownListType.Items.Add(new ListItem("出售禁售货", "出售禁售货"));
            DropDownListType.Items.Add(new ListItem("放错类目属性", "放错类目属性"));
            DropDownListType.Items.Add(new ListItem("重复铺货", "重复铺货"));
            DropDownListType.Items.Add(new ListItem("滥用关键字", "滥用关键字"));
        }

        private void method_6()
        {
            Num1GridViewShow.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                method_5();
                method_6();
            }
        }
    }
}