using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;


namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Member_List : PageBase, IRequiresSessionState
    {

  



        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Member_Operate.aspx");
        }

        protected void ButtonAddMember_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("Member_Operate.aspx");
        }

        protected void ButtonAddShop_Click(object sender, EventArgs e)
        {
            DataTable memTypeByGuid = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMemTypeByGuid(this.CheckGuid.Value.ToString());
            if ((memTypeByGuid != null) && (memTypeByGuid.Rows.Count > 0))
            {
                if (memTypeByGuid.Rows[0]["MemberType"].ToString() == "2")
                {
                    MessageBox.Show("此会员已经有店铺");
                }
                else
                {
                    base.Response.Redirect("OpenShop.aspx?guid=" + this.CheckGuid.Value.ToString());
                }
            }
        }

        protected void ButtonAdvancePaymentFreezeLog_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("AdvancePaymentFreezeOperate.aspx?guid=" + this.CheckGuid.Value);
        }

        protected void ButtonAdvancePaymentModifyLog_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("AdvancePaymentAlterOperate.aspx?guid=" + this.CheckGuid.Value);
        }

        protected void ButtonCheck_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MemberInfo_Operate.aspx?guid=" + this.CheckGuid.Value.ToString());
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable memTypeByGuid = shopNum1_Member_Action.GetMemTypeByGuid(this.CheckGuid.Value.ToString());
            foreach (DataRow dataRow in memTypeByGuid.Rows)
            {
                if (dataRow["MemberType"].ToString() == "2")
                {
                    MessageBox.Show("无法删除,选择的会员是店铺会员!");
                    this.MessageShow.ShowMessage("DelNo");
                    this.MessageShow.Visible = true;
                    return;
                }
            }
            int num = shopNum1_Member_Action.Delete(this.CheckGuid.Value.ToString());
            if (num > 0)
            {
                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();
                shopNum1_OperateLog.Record = "管理员删除会员";
                shopNum1_OperateLog.OperatorID = base.ShopNum1LoginID;
                shopNum1_OperateLog.IP = Globals.IPAddress;
                shopNum1_OperateLog.PageName = "Member_List.aspx";
                shopNum1_OperateLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                base.OperateLog(shopNum1_OperateLog);
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
                this.method_6();
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            string text = "'" + linkButton.CommandArgument + "'";
            ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable memTypeByGuid = shopNum1_Member_Action.GetMemTypeByGuid(text);
            foreach (DataRow dataRow in memTypeByGuid.Rows)
            {
                if (dataRow["MemberType"].ToString() == "2")
                {
                    MessageBox.Show("无法删除,选择的会员是店铺会员!");
                    this.MessageShow.ShowMessage("DelNo");
                    this.MessageShow.Visible = true;
                    return;
                }
            }
            int num = shopNum1_Member_Action.Delete(text);
            if (num > 0)
            {
                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();
                shopNum1_OperateLog.Record = "管理员删除会员";
                shopNum1_OperateLog.OperatorID = base.ShopNum1LoginID;
                shopNum1_OperateLog.IP = Globals.IPAddress;
                shopNum1_OperateLog.PageName = "Member_List.aspx";
                shopNum1_OperateLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                base.OperateLog(shopNum1_OperateLog);
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
                this.method_6();
            }

        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Member_Operate.aspx?guid=" + this.CheckGuid.Value);
        }

        protected void ButtonIsForbid_Click(object sender, EventArgs e)
        {
            ShopNum1_Member_Action action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            if (action.UpdateemLoginTypeByMemLoginID(this.CheckGuid.Value.ToString(), 0) > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "会员状态启用成功",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "Member_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.MessageShow.ShowMessage("EditYes");
                this.MessageShow.Visible = true;
                this.method_6();
            }
        }

        protected void ButtonNoForbid_Click(object sender, EventArgs e)
        {
            ShopNum1_Member_Action action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            if (action.UpdateemLoginTypeByMemLoginID(this.CheckGuid.Value.ToString(), 1) > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "会员状态禁用成功",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "Member_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.MessageShow.ShowMessage("EditYes");
                this.MessageShow.Visible = true;
                this.method_6();
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.method_6();
        }

        public string ChangeIsForbid(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "已启用";
            }
            if (object_0.ToString() == "1")
            {
                return "已禁用";
            }
            return "非法状态";
        }

        public string ChangeLoginDate(object loginDate)
        {
            if (loginDate.ToString() == "1900-1-1 0:00:00")
            {
                return "";
            }
            return loginDate.ToString();
        }

        protected string ChangeSex(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "男";
            }
            if (object_0.ToString() == "1")
            {
                return "女";
            }
            return "保密";
        }

        protected string ChangeType(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "个人";
            }
            if (object_0.ToString() == "2")
            {
                return "店铺";
            }
            return "非法状态";
        }

        protected void DropDownListRegionCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DropDownListRegionCode2.Items.Clear();
            this.DropDownListRegionCode2.Items.Add(new ListItem("-市级-", "-1"));
            if (this.DropDownListRegionCode1.SelectedValue != "-1")
            {
                DataTable table = ((ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action()).SearchtRegionCategory(Convert.ToInt32(this.DropDownListRegionCode1.SelectedValue.Split(new char[] { '/' })[1].ToString()), 0);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    this.DropDownListRegionCode2.Items.Add(new ListItem(table.Rows[i]["Name"].ToString(), table.Rows[i]["Code"].ToString() + "/" + table.Rows[i]["ID"].ToString()));
                }
            }
            this.DropDownListRegionCode2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListRegionCode1Bind()
        {
            this.DropDownListRegionCode1.Items.Clear();
            this.DropDownListRegionCode1.Items.Add(new ListItem("-省级-", "-1"));
            DataTable table = ((ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action()).SearchtRegionCategory(0, 0);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                this.DropDownListRegionCode1.Items.Add(new ListItem(table.Rows[i]["Name"].ToString(), table.Rows[i]["Code"].ToString() + "/" + table.Rows[i]["ID"].ToString()));
            }
            this.DropDownListRegionCode1_SelectedIndexChanged(null, null);
        }

        protected void DropDownListRegionCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DropDownListRegionCode3.Items.Clear();
            this.DropDownListRegionCode3.Items.Add(new ListItem("-县级-", "-1"));
            if (this.DropDownListRegionCode2.SelectedValue != "-1")
            {
                DataTable table = ((ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action()).SearchtRegionCategory(Convert.ToInt32(this.DropDownListRegionCode2.SelectedValue.Split(new char[] { '/' })[1].ToString()), 0);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    this.DropDownListRegionCode3.Items.Add(new ListItem(table.Rows[i]["Name"].ToString(), table.Rows[i]["Code"].ToString() + "/" + table.Rows[i]["ID"].ToString()));
                }
            }
        }

        protected string GetAdress(object AddressValue, object Address)
        {
            try
            {
                string[] strArray2 = AddressValue.ToString().Split(new char[] { '|' })[0].ToString().Split(new char[] { ',' });
                string str2 = string.Empty;
                if (strArray2.Length == 3)
                {
                    str2 = strArray2[0] + strArray2[1] + strArray2[2];
                }
                else if (strArray2.Length == 2)
                {
                    str2 = strArray2[0] + strArray2[1];
                }
                else if (strArray2.Length == 1)
                {
                    str2 = strArray2[0];
                }
                else
                {
                    str2 = Address.ToString();
                }
                return (str2 + Address.ToString());
            }
            catch
            {
                return "";
            }
        }

        public string GetMemberRankPersonCate(string memLoginID)
        {
            DataTable table = ((ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action()).SearchMJC_PersonCate(memLoginID);
            if ((table != null) && (table.Rows.Count > 0))
            {
                if (table.Rows[0]["PersonCate"].ToString() == "0")
                {
                    return "普通";
                }
                else if (table.Rows[0]["PersonCate"].ToString() == "1")
                { return "节点"; }
                else if (table.Rows[0]["PersonCate"].ToString() == "2")
                { return "集群"; }
                else if (table.Rows[0]["PersonCate"].ToString() == "3")
                { return "超级"; }
                else if (table.Rows[0]["PersonCate"].ToString() == "4")
                { return "特级"; }

                else
                { return "普通"; }
            }
            return "";
        }
        public string GetMemberRank(string memLoginID)
        {
            DataTable table = ((ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action()).SearchMJC(memLoginID);
            if ((table != null) && (table.Rows.Count > 0))
            {
                if (table.Rows[0]["membership_Level"].ToString() == "0")
                {
                    return "体验会员";
                }
                else if (table.Rows[0]["membership_Level"].ToString() == "1")
                { return "一星会员"; }
                else if (table.Rows[0]["membership_Level"].ToString() == "2")
                { return "二星会员"; }
                else if (table.Rows[0]["membership_Level"].ToString() == "3")
                { return "三星会员"; }
                else if (table.Rows[0]["membership_Level"].ToString() == "4")
                { return "四星会员"; }
                else if (table.Rows[0]["membership_Level"].ToString() == "5")
                { return "五星会员"; }
                else
                { return "普通会员"; }
            }
            return "";
        }

        private void method_5()
        {
            this.DropDownListMemberRank.Items.Clear();
            this.DropDownListMemberRank.Items.Add(new ListItem("-全部-", "-1"));
            DataTable table = ((ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action()).Search("", 0);
            if ((table != null) && (table.Rows.Count > 0))
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    ListItem item = new ListItem
                    {
                        Text = table.Rows[i]["Name"].ToString(),
                        Value = table.Rows[i]["minScore"].ToString() + "/" + table.Rows[i]["maxScore"].ToString()
                    };
                    this.DropDownListMemberRank.Items.Add(item);
                }
            }
        }

        private void method_6()
        {
            this.SetShopRegionCode();
            this.Num1GridViewShow.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (base.checkadmin())
            {
                TextIsadmin.Value = "1";
            }
            if (!this.Page.IsPostBack)
            {
                this.DropDownListRegionCode1Bind();
                this.method_5();
                this.method_6();
            }
        }

        public void SetShopRegionCode()
        {
            if (this.DropDownListRegionCode3.SelectedValue != "-1")
            {
                this.HiddenFieldRegionCode.Value = this.DropDownListRegionCode3.SelectedValue.Split(new char[] { '/' })[0];
            }
            else if (this.DropDownListRegionCode2.SelectedValue != "-1")
            {
                this.HiddenFieldRegionCode.Value = this.DropDownListRegionCode2.SelectedValue.Split(new char[] { '/' })[0];
            }
            else if (this.DropDownListRegionCode1.SelectedValue != "-1")
            {
                this.HiddenFieldRegionCode.Value = this.DropDownListRegionCode1.SelectedValue.Split(new char[] { '/' })[0];
            }
            else
            {
                this.HiddenFieldRegionCode.Value = "0";
            }
        }
    }
}