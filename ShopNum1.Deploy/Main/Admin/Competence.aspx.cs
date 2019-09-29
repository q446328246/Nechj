using System;
using System.Collections.Generic;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Competence : PageBase, IRequiresSessionState
    {
        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = Page.Request.QueryString["id"];
            var strPagelList = new List<ShopNum1_GroupPage>();
            strPagelList.Clear();
            foreach (System.Web.UI.Control control in form1.Controls)
            {
                if (control.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
                {
                    var box = (CheckBox) control;
                    if (box.Checked && (box.ToolTip != ""))
                    {
                        var item = new ShopNum1_GroupPage
                            {
                                GroupGuid = new Guid(str.Replace("'", "")),
                                PageGuid = box.ToolTip,
                                CreateUser = base.ShopNum1LoginID,
                                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                ModifyUser = base.ShopNum1LoginID,
                                ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                IsDeleted = 0
                            };
                        strPagelList.Add(item);
                    }
                }
            }
            if (strPagelList.Count != 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "权限设置",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Competence.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                ((ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action()).Add(strPagelList);
                MessageBox.Show("修改成功！");
            }
            else
            {
                MessageBox.Show("请勾选一个菜单设置权限！");
            }
        }

        protected DataTable GetGroupByGuid(string GroupGuid)
        {
            GroupGuid = Page.Request.QueryString["id"];
            var action = (ShopNum1_Group_Action) LogicFactory.CreateShopNum1_Group_Action();
            return action.GetGroupByGuid(GroupGuid);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                string groupGuid = Page.Request.QueryString["id"];
                DataTable groupByGuid = GetGroupByGuid(groupGuid);
                for (int i = 0; i < groupByGuid.Rows.Count; i++)
                {
                    foreach (System.Web.UI.Control control in form1.Controls)
                    {
                        if (control.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
                        {
                            var box = (CheckBox) control;
                            if (groupByGuid.Rows[i]["PageGuid"].ToString().Equals(box.ToolTip))
                            {
                                box.Checked = true;
                            }
                        }
                    }
                }
            }
        }
    }
}