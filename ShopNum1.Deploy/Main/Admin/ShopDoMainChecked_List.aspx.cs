using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopDoMainChecked_List : PageBase, IRequiresSessionState
    {
        protected const string ShopDoMain_List_Report = "~/Main/Admin/ShopDoMain_List_Report.aspx";

        protected void BindGrid()
        {
            num1GridViewShow.DataBind();
        }

        public void BindShopLoginID()
        {
            DataTable shopLoginID =
                ((ShopNum1_ShopURLManage_Action) LogicFactory.CreateShopNum1_ShopURLManage_Action()).GetShopLoginID(
                    hiddenFieldGuid.Value.Replace("'", ""));
            TextBoxMemLoginID.Text = shopLoginID.Rows[0]["MemLoginID"].ToString();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("ShopDoMain_Operate.aspx?guid=" + CheckGuid.Value + "&MemLoginID=" +
                                   hiddenFieldGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopURLManage_Action) LogicFactory.CreateShopNum1_ShopURLManage_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺域名审核数据",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopDoMainChecked_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
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
            string strID = "'" + button.CommandArgument + "'";
            var action = (ShopNum1_ShopURLManage_Action) LogicFactory.CreateShopNum1_ShopURLManage_Action();
            if (action.Delete(strID) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺域名审核数据",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopDoMainChecked_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
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
            base.Response.Redirect("ShopDoMain_Operate.aspx?guid=" + CheckGuid.Value + "&MemLoginID=" +
                                   hiddenFieldGuid.Value);
        }

        protected void ButtonIsAudit0_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopURLManage_Action) LogicFactory.CreateShopNum1_ShopURLManage_Action();
            if (action.UpdateIsAudit(CheckGuid.Value.Replace("'", ""), "2") > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "取消审核成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AgentDoMain_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonIsAudit1_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopURLManage_Action) LogicFactory.CreateShopNum1_ShopURLManage_Action();
            if (action.UpdateIsAudit(CheckGuid.Value.Replace("'", ""), "1") > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "审核成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "AgentDoMain_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
                MessageShow.ShowMessage("Audit1Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit1No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonReportExcel_Click(object sender, EventArgs e)
        {
            if (num1GridViewShow.Rows.Count < 1)
            {
                MessageBox.Show("当前无导出的记录！");
            }
            else
            {
                var cookie = new HttpCookie("ShopDoMainReportCookie");
                cookie.Values.Add("MemLoginID", TextBoxMemLoginID.Text.Trim());
                cookie.Values.Add("IsAudit", DropDownListIsAudit.SelectedValue);
                string str = string.Empty;
                if (RadioButtonListOutPage.SelectedValue == "0")
                {
                    cookie.Values.Add("PageCheck", "1");
                    for (int i = 0; i < num1GridViewShow.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            if (num1GridViewShow.Rows.Count != 1)
                            {
                                str = "'" + num1GridViewShow.Rows[i].Cells[1].Text + "',";
                            }
                            else
                            {
                                str = "'" + num1GridViewShow.Rows[i].Cells[1].Text + "'";
                            }
                        }
                        else if (i == (num1GridViewShow.Rows.Count - 1))
                        {
                            str = str + "'" + num1GridViewShow.Rows[i].Cells[1].Text + "'";
                        }
                        else
                        {
                            str = str + "'" + num1GridViewShow.Rows[i].Cells[1].Text + "',";
                        }
                    }
                    cookie.Values.Add("Guids", str);
                }
                else
                {
                    cookie.Values.Add("PageCheck", "0");
                    cookie.Values.Add("Guids", "0");
                }
                HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                base.Response.AppendCookie(cookie2);
                base.Response.Redirect("~/Main/Admin/ShopDoMain_List_Report.aspx?Type=xls");
            }
        }

        protected void ButtonReportHtml_Click(object sender, EventArgs e)
        {
            if (num1GridViewShow.Rows.Count < 1)
            {
                MessageBox.Show("当前无导出的记录！");
            }
            else
            {
                var cookie = new HttpCookie("ShopDoMainReportCookie");
                cookie.Values.Add("MemLoginID", TextBoxMemLoginID.Text.Trim());
                cookie.Values.Add("IsAudit", DropDownListIsAudit.SelectedValue);
                string str = string.Empty;
                if (RadioButtonListOutPage.SelectedValue == "0")
                {
                    cookie.Values.Add("PageCheck", "1");
                    for (int i = 0; i < num1GridViewShow.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            if (num1GridViewShow.Rows.Count != 1)
                            {
                                str = "'" + num1GridViewShow.Rows[i].Cells[1].Text + "',";
                            }
                            else
                            {
                                str = "'" + num1GridViewShow.Rows[i].Cells[1].Text + "'";
                            }
                        }
                        else if (i == (num1GridViewShow.Rows.Count - 1))
                        {
                            str = str + "'" + num1GridViewShow.Rows[i].Cells[1].Text + "'";
                        }
                        else
                        {
                            str = str + "'" + num1GridViewShow.Rows[i].Cells[1].Text + "',";
                        }
                    }
                    cookie.Values.Add("Guids", str);
                }
                else
                {
                    cookie.Values.Add("PageCheck", "0");
                    cookie.Values.Add("Guids", "0");
                }
                HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                base.Response.AppendCookie(cookie2);
                base.Response.Redirect("~/Main/Admin/ShopDoMain_List_Report.aspx?Type=html");
            }
        }

        public string ChangeIsAudit(string strIsAudit)
        {
            if (strIsAudit == "0")
            {
                return " 未审核";// LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsAudit", "0");
            }
            if (strIsAudit == "1")
            {
                return " 已审核";//LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsAudit", "1");
            }
            if (strIsAudit == "2")
            {
                return "审核未通过";
            }
            return "非法状态";
        }

        private void BindData()
        {
            DropDownListIsAudit.Items.Add(new ListItem("-全部-", "-2"));
            DropDownListIsAudit.Items.Add(new ListItem("审核未通过", "2"));
            DropDownListIsAudit.Items.Add(new ListItem("未审核", "0"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindData();
                BindGrid();
            }
        }
    }
}