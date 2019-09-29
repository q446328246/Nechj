using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopNum1Region_list : PageBase, IRequiresSessionState
    {
        public string strid = "-1";

        protected void btnCreateRegion_Click(object sender, EventArgs e)
        {
            int num;
            string strSql = "select name,code from shopnum1_region where categorylevel=1";
            DataTable table = DatabaseExcetue.ReturnDataTable(strSql);
            StringBuilder builder = new StringBuilder();
            builder.Append("//jely " + DateTime.Now.ToLocalTime() + " 新增区域 json \r\n");
            builder.Append("var Json_vj={\"province\":[");
            for (num = 0; num < table.Rows.Count; num++)
            {
                builder.Append(string.Concat(new object[] { "{\"name\":\"", table.Rows[num]["name"], "\", \"code\":\"", table.Rows[num]["code"], "\"}," }));
            }
            builder.Remove(builder.Length - 1, 1);
            string str3 = "select name,code from shopnum1_region where categorylevel=2";
            DataTable table3 = DatabaseExcetue.ReturnDataTable(str3);
            builder.Append("],\"city\":[");
            for (num = 0; num < table3.Rows.Count; num++)
            {
                builder.Append(string.Concat(new object[] { "{\"name\":\"", table3.Rows[num]["name"], "\", \"code\":\"", table3.Rows[num]["code"], "\"}," }));
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append("],\"district\":[");
            string str2 = "select name,code from shopnum1_region where categorylevel=3";
            DataTable table2 = DatabaseExcetue.ReturnDataTable(str2);
            for (num = 0; num < table2.Rows.Count; num++)
            {
                builder.Append(string.Concat(new object[] { "{\"name\":\"", table2.Rows[num]["name"], "\", \"code\":\"", table2.Rows[num]["code"], "\"}," }));
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append("]}");
            FileStream stream = new FileStream(base.Server.MapPath("/Main/js/areas.js"), FileMode.Create);
            StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
            writer.Write(builder.ToString());
            writer.Dispose();
            writer.Close();
            MessageBox.Show("恭喜您生成成功！");
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            this.CheckGuid.Value = "0";
            base.Response.Redirect("ShopNum1Region_Operate.aspx?guid=" + this.CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            TreeNodeCollection nodes = this.TreeViewData.Nodes;
            this.method_8(nodes);
            if (this.strid == "-1")
            {
                MessageBox.Show("请选择要删除的记录!");
            }
            else
            {
                ShopNum1_DispatchRegion_Action action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
                action.TableName="ShopNum1_Region";
                switch (action.Delete(this.strid))
                {
                    case 2:
                        this.MessageShow.ShowMessage("Region");
                        this.MessageShow.Visible = true;
                        break;

                    case 1:
                        {
                              HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                            ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                            {
                                Record = "删除地区信息成功",
                                OperatorID = cookie2.Values["LoginID"].ToString(),
                                IP = Globals.IPAddress,
                                PageName = "ShopNum1Region_list.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                            base.OperateLog(operateLog);
                            this.TreeViewData.Nodes.Clear();
                            this.BindData();
                            this.MessageShow.ShowMessage("DelYes");
                            this.MessageShow.Visible = true;
                            break;
                        }
                    case 0:
                        this.MessageShow.ShowMessage("DelNo");
                        this.MessageShow.Visible = true;
                        break;
                }
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            TreeNodeCollection nodes = this.TreeViewData.Nodes;
            this.GetNode(nodes);
        }

        protected void ButtonNodeOperate_Click(object sender, EventArgs e)
        {
            this.ExpendAll();
        }

        public void ExpendAll()
        {
            if (this.ButtonNodeOperate.ToolTip == "NoExpand")
            {
                this.TreeViewData.ExpandAll();
                this.ButtonNodeOperate.Text = "全部收缩";
                this.ButtonNodeOperate.ToolTip = "Expand";
                this.ButtonNodeOperate.CssClass = "shuoso picbtn";
            }
            else
            {
                this.TreeViewData.CollapseAll();
                this.ButtonNodeOperate.Text = "全部展开";
                this.ButtonNodeOperate.ToolTip = "NoExpand";
                this.ButtonNodeOperate.CssClass = "zhankai picbtn";
            }
        }

        public void GetNode(TreeNodeCollection treeNodeCollection_0)
        {
            foreach (TreeNode node in treeNodeCollection_0)
            {
                if (node.Checked)
                {
                    base.Response.Redirect("ShopNum1Region_Operate.aspx?guid=" + node.Value.ToString());
                }
                this.GetNode(node.ChildNodes);
            }
        }

        private void BindData()
        {
            ShopNum1_DispatchRegion_Action action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
            action.TableName="ShopNum1_Region";
            DataTable table = action.SearchtDispatchRegion(0, 0);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    TreeNode child = new TreeNode
                    {
                        Text = row["Name"].ToString(),
                        Value = row["ID"].ToString(),
                        Expanded = false
                    };
                    if (this.method_9(Convert.ToInt32(child.Value)))
                    {
                        child.PopulateOnDemand = true;
                    }
                    else
                    {
                        child.PopulateOnDemand = false;
                    }
                    this.TreeViewData.Nodes.Add(child);
                }
            }
        }

        private void method_6(TreeNode treeNode_0, int int_0)
        {
            ShopNum1_DispatchRegion_Action action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
            action.TableName="ShopNum1_Region";
            foreach (DataRow row in action.SearchtDispatchRegion(int_0, 0).Rows)
            {
                TreeNode node = new TreeNode
                {
                    Value = row["ID"].ToString(),
                    Text = row["Name"].ToString(),
                    Expanded = false
                };
                this.method_6(node, Convert.ToInt32(row["ID"].ToString()));
                treeNode_0.ChildNodes.Add(node);
            }
        }

        private void method_7()
        {
            base.RegisterStartupScriptNew("PAGE", "window.location.href=window.location.href;");
        }

        private void method_8(TreeNodeCollection treeNodeCollection_0)
        {
            foreach (TreeNode node in treeNodeCollection_0)
            {
                if (node.Checked)
                {
                    this.strid = node.Value.ToString();
                }
                this.method_8(node.ChildNodes);
            }
        }

        private bool method_9(int int_0)
        {
            ShopNum1_DispatchRegion_Action action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
            action.TableName="ShopNum1_Region";
            if (action.GetDispatchCount(int_0, 0) == 0)
            {
                return false;
            }
            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.BindData();
                this.TreeViewData.Attributes.Add("onclick", "getcheck(event)");
            }
        }

        protected void TreeViewData_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeView view = sender as TreeView;
            TreeNode selectedNode = view.SelectedNode;
            this.CheckGuid.Value = selectedNode.Value.ToString();
            base.Response.Redirect("ShopNum1Region_Operate.aspx?guid=" + this.CheckGuid.Value);
        }

        protected void TreeViewData_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            ShopNum1_DispatchRegion_Action action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
            action.TableName="ShopNum1_Region";
            int num = Convert.ToInt32(e.Node.Value);
            foreach (DataRow row in action.SearchtDispatchRegion(num, 0).Rows)
            {
                TreeNode child = new TreeNode
                {
                    Value = row["ID"].ToString(),
                    Text = row["Name"].ToString(),
                    Expanded = false,
                    NavigateUrl = "javascript:void(0);"
                };
                if (this.method_9(Convert.ToInt32(row["ID"])))
                {
                    child.PopulateOnDemand = true;
                }
                else
                {
                    child.PopulateOnDemand = false;
                }
                child.Collapse();
                e.Node.ChildNodes.Add(child);
            }
        }

    }
}