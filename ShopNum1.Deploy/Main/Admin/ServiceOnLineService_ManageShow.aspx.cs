using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;


namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ServiceOnLineService_ManageShow : PageBase, IRequiresSessionState
    {
        private ShopNum1_OnLineService_Action shopNum1_OnLineService_Action_0 = ((ShopNum1_OnLineService_Action)LogicFactory.CreateShopNum1_OnLineService_Action());

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
                this.BindData();
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            if (this.RadioButtonOpen.Checked)
            {
                str = "1";
            }
            else
            {
                str = "0";
            }
            try
            {
                this.method_6(str, "ShowCustomer");
                if (this.CheckBoxPhone.Checked)
                {
                    str2 = "1";
                }
                else
                {
                    str2 = "0";
                }
                this.method_6(str2, "IsOpenPhone");
                this.method_6(this.TextBoxServerPhone.Text, "ServerPhone");
            }
            catch (Exception)
            {
            }
            string[] strArray2 = new string[3];
            string[] isshow = new string[3];
            for (int i = 0; i < 2; i++)
            {
                strArray2[i] = (i + 1).ToString();
                isshow[i] = "0";
            }
            if (this.CheckBoxQQ.Checked)
            {
                isshow[0] = "1";
            }
            if (this.CheckBoxWW.Checked)
            {
                isshow[1] = "1";
            }
            if (this.shopNum1_OnLineService_Action_0.Update(strArray2, isshow) > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "客服管理信息编辑成功",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ServiceOnLineService_ManageShow.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.MessageShow.ShowMessage("在线客服栏目编辑成功");
                this.MessageShow.Visible = true;
                this.BindData();
            }
            else
            {
                this.MessageShow.ShowMessage("在线客服编辑失败");
                this.MessageShow.Visible = true;
            }
        }

        private void BindData()
        {
            ShopSettings settings = new ShopSettings();
            string str = settings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "ShowCustomer");
            string str2 = settings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "IsOpenPhone");
            string str3 = settings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "ServerPhone");
            if (str == "1")
            {
                this.RadioButtonOpen.Checked = true;
                this.RadioButtonClose.Checked = false;
            }
            else
            {
                this.RadioButtonOpen.Checked = false;
                this.RadioButtonClose.Checked = true;
            }
            this.TextBoxServerPhone.Text = str3;
            if (str2 == "1")
            {
                this.CheckBoxPhone.Checked = true;
            }
            else
            {
                this.CheckBoxPhone.Checked = false;
            }
            DataTable table = this.shopNum1_OnLineService_Action_0.Search("-1", "-1");
            if ((table != null) && (table.Rows.Count > 0))
            {
                foreach (DataRow row in table.Rows)
                {
                    string str4 = row["id"].ToString() + row["IsShow"].ToString();
                    if (str4 != null)
                    {
                        if (!(str4 == "11"))
                        {
                            if (str4 == "21")
                            {
                                this.CheckBoxWW.Checked = true;
                            }
                        }
                        else
                        {
                            this.CheckBoxQQ.Checked = true;
                        }
                    }
                }
            }
        }

        private void method_6(string string_4, string string_5)
        {
            XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/" + string_5, string_4);
            ShopSettings.ResetShopSetting();
        }

    }
}