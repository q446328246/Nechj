using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class websites_Operate : PageBase, IRequiresSessionState
    {
        private readonly ShopNum1_DispatchRegion_Action shopNum1_DispatchRegion_Action_0 =
            (ShopNum1_DispatchRegion_Action) LogicFactory.CreateShopNum1_DispatchRegion_Action();


        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["ID"] == null)
                                        ? "0"
                                        : base.Request.QueryString["ID"].Replace("'", "");
            shopNum1_DispatchRegion_Action_0.TableName = "ShopNum1_DispatchRegion";
            if (!base.IsPostBack)
            {
                DropDownListRegionCode1Bind();
                if (hiddenFieldGuid.Value != "0")
                {
                    LabelTitle.Text = "编辑站点";
                    GetEditInfo();
                }
            }
        }

        protected void Add()
        {
            var website = new ShopNum1_WebSite
                {
                    addressName = GetDropDownListDispatchRegionName(),
                    addressCode = GetDropDownListRegionCode(),
                    domain = TextBoxDomain.Text.Trim().ToLower(),
                    isAvailable = RadioButtonListOpen.SelectedValue == "1"
                };
            IShopNum1_WebSite_Action action = LogicFactory.CreateShopNum1_WebSite_Action();
            if (action.CheckAddressName(website.addressName))
            {
                MessageBox.Show("选择的地区已经添加过站点了!");
            }
            else if (action.Insert(website))
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "添加站点成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "websites_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindData();
                MessageShow.ShowMessage("AddYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (hiddenFieldGuid.Value != "0")
            {
                Edit();
            }
            else
            {
                Add();
            }
        }

        protected void DropDownLis1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListRegionCode1.SelectedValue != "-1")
            {
                DataTable dispatchRegionName =
                    shopNum1_DispatchRegion_Action_0.GetDispatchRegionName(
                        DropDownListRegionCode1.SelectedValue.Split(new[] {'/'})[1]);
                if ((dispatchRegionName != null) && (dispatchRegionName.Rows.Count != 0))
                {
                    DropDownListRegionCode2.Visible = true;
                    DropDownListRegionCode2.Items.Clear();
                    DropDownListRegionCode2.Items.Add(new ListItem("-请选择-", "-1"));
                    method_6(DropDownListRegionCode1.SelectedValue.Split(new[] {'/'})[1], DropDownListRegionCode2);
                    DropDownList2_SelectedIndexChanged(null, null);
                }
            }
            else
            {
                DropDownListRegionCode2.Visible = false;
                DropDownListRegionCode2.Items.Clear();
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListRegionCode2.SelectedValue != "-1")
            {
                DataTable dispatchRegionName =
                    shopNum1_DispatchRegion_Action_0.GetDispatchRegionName(
                        DropDownListRegionCode2.SelectedValue.Split(new[] {'/'})[1]);
                if ((dispatchRegionName != null) && (dispatchRegionName.Rows.Count != 0))
                {
                    DropDownListRegionCode3.Visible = true;
                    DropDownListRegionCode3.Items.Clear();
                    DropDownListRegionCode3.Items.Add(new ListItem("-请选择-", "-1"));
                    method_6(DropDownListRegionCode2.SelectedValue.Split(new[] {'/'})[1], DropDownListRegionCode3);
                }
            }
            else
            {
                DropDownListRegionCode3.Visible = false;
                DropDownListRegionCode3.Items.Clear();
            }
        }

        protected void DropDownListRegionCode1Bind()
        {
            DropDownListRegionCode1.Items.Clear();
            DropDownListRegionCode1.Items.Add(new ListItem("-省级-", "-1"));
            DataTable dispatchRegionName = shopNum1_DispatchRegion_Action_0.GetDispatchRegionName("0");
            for (int i = 0; i < dispatchRegionName.Rows.Count; i++)
            {
                DropDownListRegionCode1.Items.Add(new ListItem(dispatchRegionName.Rows[i]["Name"].ToString(),
                                                               dispatchRegionName.Rows[i]["Code"] + "/" +
                                                               dispatchRegionName.Rows[i]["ID"]));
            }
        }

        protected void Edit()
        {
            var website = new ShopNum1_WebSite
                {
                    ID = int.Parse(hiddenFieldGuid.Value.Replace("'", "")),
                    addressName = GetDropDownListDispatchRegionName(),
                    addressCode = GetDropDownListRegionCode(),
                    domain = TextBoxDomain.Text.Trim().ToLower(),
                    isAvailable = RadioButtonListOpen.SelectedValue == "1"
                };
            IShopNum1_WebSite_Action action = LogicFactory.CreateShopNum1_WebSite_Action();
            if ((ViewState["addressName"].ToString() != website.addressName) && action.CheckAddressName(TextBoxDomain.Text.Trim()))
            {
                MessageBox.Show("选择的地区已经添加过站点了!");
            }
            else if (action.Update(website))
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "编辑站点成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "websites_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("EditYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        public string GetDropDownListDispatchRegionName()
        {
            if ((DropDownListRegionCode3.SelectedValue != "") && (DropDownListRegionCode3.SelectedValue != "-1"))
            {
                return (DropDownListRegionCode1.SelectedItem.Text + DropDownListRegionCode2.SelectedItem.Text +
                        DropDownListRegionCode3.SelectedItem.Text);
            }
            if ((DropDownListRegionCode2.SelectedValue != "") && (DropDownListRegionCode2.SelectedValue != "-1"))
            {
                return (DropDownListRegionCode1.SelectedItem.Text + DropDownListRegionCode2.SelectedItem.Text);
            }
            if ((DropDownListRegionCode1.SelectedValue != "") && (DropDownListRegionCode1.SelectedValue != "-1"))
            {
                return DropDownListRegionCode1.SelectedItem.Text;
            }
            return "-1";
        }

        public string GetDropDownListRegionCode()
        {
            if ((DropDownListRegionCode3.SelectedValue != "") && (DropDownListRegionCode3.SelectedValue != "-1"))
            {
                return DropDownListRegionCode3.SelectedValue.Split(new[] {'/'})[0];
            }
            if ((DropDownListRegionCode2.SelectedValue != "") && (DropDownListRegionCode2.SelectedValue != "-1"))
            {
                return DropDownListRegionCode2.SelectedValue.Split(new[] {'/'})[0];
            }
            if ((DropDownListRegionCode1.SelectedValue != "") && (DropDownListRegionCode1.SelectedValue != "-1"))
            {
                return DropDownListRegionCode1.SelectedValue.Split(new[] {'/'})[0];
            }
            return "-1";
        }

        protected void GetEditInfo()
        {
            IShopNum1_WebSite_Action action = LogicFactory.CreateShopNum1_WebSite_Action();
            IShopNum1_Address_Action action2 = LogicFactory.CreateShopNum1_Address_Action();
            DataTable siteByID = action.GetSiteByID(hiddenFieldGuid.Value);
            if ((siteByID != null) && (siteByID.Rows.Count > 0))
            {
                TextBoxDomain.Text = siteByID.Rows[0]["domain"].ToString();
                RadioButtonListOpen.SelectedValue = Convert.ToBoolean(siteByID.Rows[0]["isAvailable"]) ? "1" : "0";
                ViewState["addressName"] = siteByID.Rows[0]["addressName"].ToString();
                string code = siteByID.Rows[0]["addressCode"].ToString();
                if (code.Length >= 3)
                {
                    DataTable regionCode = action2.GetRegionCode(code.Substring(0, 3));
                    if ((regionCode != null) && (regionCode.Rows.Count > 0))
                    {
                        DropDownListRegionCode1.SelectedValue = regionCode.Rows[0]["Code"] + "/" +
                                                                regionCode.Rows[0]["ID"];
                        DropDownLis1_SelectedIndexChanged(null, null);
                    }
                }
                if (code.Length >= 6)
                {
                    DataTable table3 = action2.GetRegionCode(code.Substring(0, 6));
                    if ((table3 != null) && (table3.Rows.Count > 0))
                    {
                        DropDownListRegionCode2.Visible = true;
                        DropDownListRegionCode2.SelectedValue = table3.Rows[0]["Code"] + "/" + table3.Rows[0]["ID"];
                        DropDownList2_SelectedIndexChanged(null, null);
                    }
                }
                if (code.Length == 9)
                {
                    DataTable table2 = action2.GetRegionCode(code);
                    if ((table2 != null) && (table2.Rows.Count > 0))
                    {
                        DropDownListRegionCode3.Visible = true;
                        DropDownListRegionCode3.SelectedValue = table2.Rows[0]["Code"] + "/" + table2.Rows[0]["ID"];
                    }
                }
            }
        }

        private void BindData()
        {
            TextBoxDomain.Text = string.Empty;
        }

        private void method_6(string string_4, DropDownList dropDownList_0)
        {
            DataTable dispatchRegionName = shopNum1_DispatchRegion_Action_0.GetDispatchRegionName(string_4);
            for (int i = 0; i < dispatchRegionName.Rows.Count; i++)
            {
                if (!(string_4 == "0") || !(dispatchRegionName.Rows[i]["Name"].ToString().Trim() == "所有地区"))
                {
                    dropDownList_0.Items.Add(new ListItem(dispatchRegionName.Rows[i]["Name"].ToString(),
                                                          dispatchRegionName.Rows[i]["Code"] + "/" +
                                                          dispatchRegionName.Rows[i]["ID"]));
                }
            }
        }
    }
}