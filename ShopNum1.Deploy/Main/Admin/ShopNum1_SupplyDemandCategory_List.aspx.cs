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
    public partial class ShopNum1_SupplyDemandCategory_List : PageBase, IRequiresSessionState
    {
        public string strid = "-1";

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("ShopNum1_SupplyDemandCategory_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            TreeNodeCollection nodes = TreeViewData.Nodes;
            method_7(nodes);
            if (strid == "-1")
            {
                MessageBox.Show("请选择要删除的记录!");
            }
            else
            {
                int num =
                    ((ShopNum1_SupplyDemandCategory_Action) LogicFactory.CreateShopNum1_SupplyDemandCategory_Action())
                        .Delete(strid);
                if (num == 1)
                {
                    var operateLog = new ShopNum1_OperateLog
                        {
                            Record = "删除供求分类信息",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "ShopNum1_SupplyDemandCategory_List.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(operateLog);
                    ShopNum1_SupplyDemandCheck_Action.SupplyDemandCategoryTable = null;
                    MessageShow.ShowMessage("DelYes");
                    MessageShow.Visible = true;
                    TreeViewData.Nodes.Clear();
                    BindData();
                }
                else if (num == 2)
                {
                    MessageShow.ShowMessage("SupplyCategory");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("DelNo");
                    MessageShow.Visible = true;
                }
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            TreeNodeCollection nodes = TreeViewData.Nodes;
            GetNode(nodes);
        }

        protected void ButtonNodeOperate_Click(object sender, EventArgs e)
        {
            ExpendAll();
        }

        public void ExpendAll()
        {
            if (ButtonNodeOperate.ToolTip == "NoExpand")
            {
                TreeViewData.ExpandAll();
                ButtonNodeOperate.Text = "全部收缩";
                ButtonNodeOperate.ToolTip = "Expand";
                ButtonNodeOperate.CssClass = "shuoso picbtn";
            }
            else
            {
                TreeViewData.CollapseAll();
                ButtonNodeOperate.Text = "全部展开";
                ButtonNodeOperate.ToolTip = "NoExpand";
                ButtonNodeOperate.CssClass = "zhankai picbtn";
            }
        }

        public void GetNode(TreeNodeCollection treeNodeCollection_0)
        {
            foreach (TreeNode node in treeNodeCollection_0)
            {
                if (node.Checked)
                {
                    base.Response.Redirect("ShopNum1_SupplyDemandCategory_Operate.aspx?guid=" + node.Value);
                }
                GetNode(node.ChildNodes);
            }
        }

        private void BindData()
        {
            DataTable table =
                ((ShopNum1_SupplyDemandCategory_Action) LogicFactory.CreateShopNum1_SupplyDemandCategory_Action())
                    .SearchtSupplyDemandCategory(0, 0);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var node = new TreeNode
                        {
                            Text = row["Name"].ToString(),
                            Value = row["ID"].ToString(),
                            Expanded = false
                        };
                    method_6(node, Convert.ToInt32(row["ID"].ToString()));
                    TreeViewData.Nodes.Add(node);
                }
            }
        }

        private void method_6(TreeNode treeNode_0, int int_0)
        {
            var action =
                (ShopNum1_SupplyDemandCategory_Action) LogicFactory.CreateShopNum1_SupplyDemandCategory_Action();
            foreach (DataRow row in action.SearchtSupplyDemandCategory(int_0, 0).Rows)
            {
                var node = new TreeNode
                    {
                        Value = row["ID"].ToString(),
                        Text = row["Name"].ToString(),
                        Expanded = false
                    };
                method_6(node, Convert.ToInt32(row["ID"].ToString()));
                treeNode_0.ChildNodes.Add(node);
            }
        }

        private void method_7(TreeNodeCollection treeNodeCollection_0)
        {
            foreach (TreeNode node in treeNodeCollection_0)
            {
                if (node.Checked)
                {
                    strid = node.Value;
                }
                method_7(node.ChildNodes);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindData();
            }
        }

        protected void TreeViewData_SelectedNodeChanged(object sender, EventArgs e)
        {
            var view = sender as TreeView;
            TreeNode selectedNode = view.SelectedNode;
            CheckGuid.Value = selectedNode.Value;
            base.Response.Redirect("ShopNum1_SupplyDemandCategory_Operate.aspx?guid=" + CheckGuid.Value);
        }
    }
}