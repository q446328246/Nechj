using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopNum1_ScoreProductCategory_List : PageBase, IRequiresSessionState
    {
        public string strid = "-1";

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            this.CheckGuid.Value = "0";
            base.Response.Redirect("ShopNum1_ScoreProductCategory_Operate.aspx?guid=" + this.CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            TreeNodeCollection nodes = this.TreeViewData.Nodes;
            this.method_7(nodes);
            if (this.strid == "-1")
            {
                MessageBox.Show("请选择要删除的记录!");
            }
            else
            {
                int num = ((ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action()).Delete(this.strid);
                if (num == 1)
                {
                    ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除红包商品类别",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopNum1_ScoreProductCategory_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                    base.OperateLog(operateLog);
                    this.MessageShow.ShowMessage("DelYes");
                    this.MessageShow.Visible = true;
                    this.TreeViewData.Nodes.Clear();
                    this.BindData();
                }
                else if (num == 2)
                {
                    this.MessageShow.ShowMessage("productCategory");
                    this.MessageShow.Visible = true;
                }
                else
                {
                    this.MessageShow.ShowMessage("DelNo");
                    this.MessageShow.Visible = true;
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
                this.ButtonNodeOperate.Text = "<span>全部折叠</span>";
                this.ButtonNodeOperate.ToolTip = "Expand";
            }
            else
            {
                this.TreeViewData.CollapseAll();
                this.ButtonNodeOperate.Text = "<span>全部展开</span>";
                this.ButtonNodeOperate.ToolTip = "NoExpand";
            }
        }

        public void GetNode(TreeNodeCollection treeNodeCollection_0)
        {
            foreach (TreeNode node in treeNodeCollection_0)
            {
                if (node.Checked)
                {
                    base.Response.Redirect("ShopNum1_ScoreProductCategory_Operate.aspx?guid=" + node.Value.ToString());
                }
                this.GetNode(node.ChildNodes);
            }
        }

        private void BindData()
        {
            DataTable table = ((ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action()).SearchtProductCategory(0, 0);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    TreeNode node = new TreeNode
                    {
                        Text = row["Name"].ToString(),
                        Value = row["ID"].ToString(),
                        Expanded = false
                    };
                    this.method_6(node, Convert.ToInt32(row["ID"].ToString()));
                    this.TreeViewData.Nodes.Add(node);
                }
            }
        }

        private void method_6(TreeNode treeNode_0, int int_0)
        {
            ShopNum1_ScoreProductCategory_Action action = (ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action();
            foreach (DataRow row in action.SearchtProductCategory(int_0, 0).Rows)
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

        private void method_7(TreeNodeCollection treeNodeCollection_0)
        {
            foreach (TreeNode node in treeNodeCollection_0)
            {
                if (node.Checked)
                {
                    this.strid = node.Value.ToString();
                }
                this.method_7(node.ChildNodes);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.BindData();
            }
        }

        protected void TreeViewData_SelectedNodeChanged(object sender, EventArgs e)
        {
        }

    }
}