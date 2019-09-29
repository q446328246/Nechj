using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopNum1_ShopProductProp_List : PageBase, IRequiresSessionState
    {
        public enum ShowTypeImg : uint
        {
            const_0 = 1,
            const_1 = 2,
            const_2 = 3,
            const_3 = 4
        }

        protected void BindData()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "-1";
            base.Response.Redirect("ShopNum1_ShopProductProp_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = new ShopNum1_ShopProductProp_Action();
            if (action.Delete(CheckGuid.Value.Replace("'", "")) > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除属性",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "ShopNum1_ShopProductProp_List.aspx",
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
            string str = "'" + button.CommandArgument + "'";
            var action = new ShopNum1_ShopProductProp_Action();
            if (action.Delete(str) > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除属性",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "ShopNum1_ShopProductProp_List.aspx",
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

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Format("ShopNum1_ShopProductProp_Operate.aspx?guid={0}",
                                                 CheckGuid.Value.Replace("'", "").Trim()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        public string setProp(string strType)
        {
            string str = strType;
            switch (str)
            {
                case null:
                    break;

                case "0":
                    return "文字输入";

                case "1":
                    return "列表单选";

                default:
                    if (!(str == "2"))
                    {
                        if (str == "3")
                        {
                            return "多选";
                        }
                    }
                    else
                    {
                        return "下拉框单选";
                    }
                    break;
            }
            return "自定义属性";
        }
    }
}