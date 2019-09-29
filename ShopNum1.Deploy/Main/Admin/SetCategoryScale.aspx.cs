using System;
using System.Data;
using System.Text;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SetCategoryScale : PageBase, IRequiresSessionState
    {
        private string method_5(DataTable dt)
        {
            var builder = new StringBuilder();
            builder.Append("[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    builder.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        builder.Append(
                            string.Concat(new[]
                                {
                                    "\"", dt.Columns[j].ColumnName.ToLower(), "\":\"", dt.Rows[i][j],
                                    "\","
                                }));
                    }
                    builder.Remove(builder.Length - 1, 1);
                    builder.Append("},");
                }
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append("]");
            return builder.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                ShopNum1_ProductCategory_Action action;
                if (Common.Common.ReqStr("category") != "")
                {
                    action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                    base.Response.Write(method_5(action.Select_ProductCategory()));
                }
                else if (Common.Common.ReqStr("getdata") != "")
                {
                    action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                    DataTable table = action.dt_GetScale(Common.Common.ReqStr("getdata"));
                    if (table.Rows.Count > 0)
                    {
                        base.Response.Write(table.Rows[0]["Scale"] + "|" + table.Rows[0]["IsOpen"]);
                    }
                }
                else if (((Common.Common.ReqStr("updateCode") != "") && (Common.Common.ReqStr("scale") != "")) &&
                         (Common.Common.ReqStr("isopen") != ""))
                {
                    ((ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action())
                        .Update_Scale(Common.Common.ReqStr("updateCode"), Common.Common.ReqStr("scale"),
                                      Common.Common.ReqStr("isopen"));
                      HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                   
                    var operateLog = new ShopNum1_OperateLog
                        {
                            Record = "设置分类提成信息成功",
                            OperatorID = cookie2.Values["LoginID"].ToString(),
                            IP = Globals.IPAddress,
                            PageName = "SetCategoryScale.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(operateLog);
                }
            }
        }
    }
}