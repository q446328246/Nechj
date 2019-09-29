using System;
using System.Data;
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
    public partial class User_List : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                method_6();
                method_7();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (CheckGuid.Value.Trim().Replace("'", "").ToUpper() == "8ea30851-571b-4ffa-8870-05a7e5134aa9".ToUpper())
            {
                MessageBox.Show("系统默认管理员不允许被删除!");
            }
            else
            {
                string str = CheckGuid.Value.Replace("'", "");
                var builder = new StringBuilder();
                var builder2 = new StringBuilder();
                if (str.IndexOf(",") != -1)
                {
                    string[] strArray = str.Split(new[] {','});
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        builder.Append("'" + strArray[i].Split(new[] {'|'})[0] + "',");
                        builder2.Append(strArray[i].Split(new[] {'|'})[1] + ",");
                    }
                    builder.Remove(builder.Length - 1, 1);
                    builder2.Remove(builder2.Length - 1, 1);
                }
                else
                {
                    builder.Append("'" + str.Split(new[] {'|'})[0] + "'");
                    builder2.Append(str.Split(new[] {'|'})[1] ?? "");
                }
                var action = (ShopNum1_User_Action) LogicFactory.CreateShopNum1_User_Action();
                if (action.Delete(builder.ToString()) > 0)
                {
                    var operateLog = new ShopNum1_OperateLog
                        {
                            Record = "删除后台管理员[" + builder2 + "]成功",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "User_List.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(operateLog);
                    MessageShow.ShowMessage("DelYes");
                    MessageShow.Visible = true;
                    method_5();
                }
                else
                {
                    MessageShow.ShowMessage("DelNo");
                    MessageShow.Visible = true;
                }
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            string str = "";
            if (base.Request.Cookies["AdminLoginCookie"] != null)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                str = HttpSecureCookie.Decode(cookie).Values["Guid"];
            }
            var button = (LinkButton) sender;
            string str3 = ("'" + button.CommandArgument + "'").Replace("'", "");
            var builder = new StringBuilder();
            var builder2 = new StringBuilder();
            builder.Append("'" + str3.Split(new[] {'|'})[0] + "'");
            builder2.Append(str3.Split(new[] {'|'})[1] ?? "");
            if (str3.ToUpper() == str.ToUpper())
            {
                MessageBox.Show("该用户正在使用中!");
            }
            else
            {
                var action = (ShopNum1_User_Action) LogicFactory.CreateShopNum1_User_Action();
                if (action.Delete(builder.ToString()) > 0)
                {
                    var operateLog = new ShopNum1_OperateLog
                        {
                            Record = "删除后台管理员" + builder2 + "成功",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "User_List.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(operateLog);
                    method_5();
                    MessageShow.ShowMessage("DelYes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("DelNo");
                    MessageShow.Visible = true;
                }
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            method_5();
        }

        public string ChangeAge(string strSex)
        {
            if (strSex == "0")
            {
                return "女";
            }
            if (strSex == "1")
            {
                return "男";
            }
            if (strSex == "2")
            {
                return "保密";
            }
            return "";
        }

        public string ChangeIsForbid(string strFobid)
        {
            if (strFobid == "0")
            {
                return "images/shopNum1Admin-right.gif";
            }
            if (strFobid == "1")
            {
                return "images/shopNum1Admin-wrong.gif";
            }
            return "";
        }

        public string FormatDate(string strDate)
        {
            if (strDate.Substring(0, 4) == "1900")
            {
                return "";
            }
            return strDate;
        }

        protected DataTable GetUser(string strGuid)
        {
            var action = (ShopNum1_User_Action) LogicFactory.CreateShopNum1_User_Action();
            return action.GetUserByGuid(strGuid, 0);
        }

        private void method_5()
        {
            Num1GridViewShow.DataBind();
        }

        private void method_6()
        {
            var action = (ShopNum1_Dept_Action) LogicFactory.CreateShopNum1_Dept_Action();
            foreach (DataRow row in action.Search(0).DefaultView.Table.Rows)
            {
                var item = new ListItem
                    {
                        Text = row["Name"].ToString().Trim(),
                        Value = row["GUID"].ToString().Trim()
                    };
                DropDownListSDept.Items.Add(item);
            }
        }

        private void method_7()
        {
            var action = (ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action();
            foreach (DataRow row in action.Search(0).DefaultView.Table.Rows)
            {
                var item = new ListItem
                    {
                        Text = row["Name"].ToString().Trim(),
                        Value = row["GUID"].ToString().Trim()
                    };
            }
        }
    }
}