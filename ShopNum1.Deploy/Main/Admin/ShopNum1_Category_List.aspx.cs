using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopNum1_Category_List : PageBase, IRequiresSessionState
    {
        public string strid = "-1";

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("ShopNum1_Category_Operate.aspx?guid=" + CheckGuid.Value);
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
                var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                action.TableName = "ShopNum1_Category";
                switch (action.Delete(strid))
                {
                    case 2:
                        MessageShow.ShowMessage("Category");
                        MessageShow.Visible = true;
                        break;

                    case 1:
                        TreeViewData.Nodes.Clear();
                        BindData();
                        MessageShow.ShowMessage("DelYes");
                        MessageShow.Visible = true;
                        break;

                    case 0:
                        MessageShow.ShowMessage("DelNo");
                        MessageShow.Visible = true;
                        break;
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
                    base.Response.Redirect("ShopNum1_Category_Operate.aspx?guid=" + node.Value);
                }
                GetNode(node.ChildNodes);
            }
        }

        private void BindData()
        {
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_Category";
            DataTable table = action.SearchtProductCategory(0, 0);
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
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_Category";
            foreach (DataRow row in action.SearchtProductCategory(int_0, 0).Rows)
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
            BindData();
        }

        protected void TreeViewData_SelectedNodeChanged(object sender, EventArgs e)
        {
            var view = sender as TreeView;
            TreeNode selectedNode = view.SelectedNode;
            CheckGuid.Value = selectedNode.Value;
            base.Response.Redirect("ShopNum1_Category_Operate.aspx?guid=" + CheckGuid.Value);
        }
    }
}