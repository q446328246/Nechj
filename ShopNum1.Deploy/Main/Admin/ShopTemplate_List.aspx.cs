using System;
using System.Data;
using System.IO;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopTemplate_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            this.Num1GridviewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("ShopTemplate_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopTemplate_Action) LogicFactory.CreateShopNum1_ShopTemplate_Action();
            DataTable table = action.GetTemplatePathAndImg1(CheckGuid.Value);
            if (action.Delete1(CheckGuid.Value) > 0)
            {
                BindGrid();
                if (table.Rows.Count > 0)
                {
                    string str = table.Rows[0]["Path"].ToString();
                    string str2 = table.Rows[0]["TemplateImg"].ToString();
                    if (File.Exists(Page.Server.MapPath("~/Template/Shop/" + str)))
                    {
                        File.Delete(Page.Server.MapPath("~/Template/Shop/" + str));
                    }
                    if (File.Exists(Page.Server.MapPath("~/Template/Shop/" + str2)))
                    {
                        File.Delete(Page.Server.MapPath("~/Template/Shop/" + str2));
                    }
                }
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺模板",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopTemplate_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
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
            var action = (ShopNum1_ShopTemplate_Action) LogicFactory.CreateShopNum1_ShopTemplate_Action();
            var button = (LinkButton) sender;
            string str = "'" + button.CommandArgument + "'";
            DataTable table = action.GetTemplatePathAndImg1(str);
            if (action.Delete1(str) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺模板",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopTemplate_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
                if (table.Rows.Count > 0)
                {
                    string str2 = table.Rows[0]["Path"].ToString();
                    string str3 = table.Rows[0]["TemplateImg"].ToString();
                    if (File.Exists(Page.Server.MapPath("~/Template/Shop/" + str2)))
                    {
                        File.Delete(Page.Server.MapPath("~/Template/Shop/" + str2));
                    }
                    if (File.Exists(Page.Server.MapPath("~/Template/Shop/" + str3)))
                    {
                        File.Delete(Page.Server.MapPath("~/Template/Shop/" + str3));
                    }
                }
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopTemplate_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected string IsDefault(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "默认";
            }
            if (object_0.ToString() == "1")
            {
                return "非默认";
            }
            return "非法类型";
        }

        protected string IsForbid(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "未禁用";
            }
            if (object_0.ToString() == "1")
            {
                return "禁用";
            }
            return "非法类型";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }
    }
}