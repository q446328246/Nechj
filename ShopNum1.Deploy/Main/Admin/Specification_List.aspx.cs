using System;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Specification_List : PageBase, IRequiresSessionState
    {
        public enum ShowTypeImg : uint
        {
            const_0 = 0,
            const_1 = 1
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Specification_Operate.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var builder = new StringBuilder();
            builder.Append(CheckGuid.Value + ",");
            if (builder.ToString() != "")
            {
                var action = (ShopNum1_Spec_Action) LogicFactory.CreateShopNum1_Spec_Action();
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除规格",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "Specification_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                if (action.Delete(builder.ToString().Substring(0, builder.ToString().Length - 1)) > 0)
                {
                    MessageBox.Show("删除成功");
                    Num1GridViewShow.DataBind();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var builder = new StringBuilder();
            var button = (LinkButton) sender;
            builder.Append(("'" + button.CommandArgument + "'") + ",");
            if (builder.ToString() != "")
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                  
                var action = (ShopNum1_Spec_Action) LogicFactory.CreateShopNum1_Spec_Action();
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除规格",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "Specification_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                if (action.Delete(builder.ToString().Substring(0, builder.ToString().Length - 1)) > 0)
                {
                    MessageBox.Show("删除成功");
                    Num1GridViewShow.DataBind();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Format("Specification_Edit.aspx?id={0}",
                                                 CheckGuid.Value.Replace("'", "").Trim()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            HttpContext.Current.Session["order"] = null;
        }
    }
}