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
    public partial class ArticleCategory_List : PageBase, IRequiresSessionState
    {
        public string strid = "-1";

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindArticleCategory();
            }
        }

        protected void AddSubArticleCategory(TreeNode fatherNode, DataTable dataTable)
        {
            var action1 = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
            foreach (DataRow row in dataTable.Rows)
            {
                var child = new TreeNode
                    {
                        Text = row["Name"].ToString(),
                        Value = row["ID"].ToString().Trim(),
                        SelectAction = TreeNodeSelectAction.Select
                    };
                child.Expand();
                fatherNode.ChildNodes.Add(child);
            }
        }

        protected void BindArticleCategory()
        {
            TreeViewCategory.Nodes.Clear();
            var action = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
            foreach (DataRow row in action.Search(0, 0).Rows)
            {
                var child = new TreeNode
                    {
                        Text = row["Name"].ToString(),
                        Value = row["ID"].ToString().Trim(),
                        SelectAction = TreeNodeSelectAction.Select,
                        Expanded = false
                    };
                TreeViewCategory.Nodes.Add(child);
                DataTable dataTable = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                if (dataTable.Rows.Count > 0)
                {
                    AddSubArticleCategory(child, dataTable);
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("ArticleCategory_Operate.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            TreeNodeCollection nodes = TreeViewCategory.Nodes;
            GetNodeDel(nodes);
            if (strid == "-1")
            {
                MessageBox.Show("请选择要删除的记录!");
            }
            else
            {
                var action = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
                switch (action.Delete(strid))
                {
                    case -1:
                        MessageShow.ShowMessage("AnnouncementCategory");
                        MessageShow.Visible = true;
                        break;

                    case 2:
                        MessageShow.ShowMessage("SupplyCategory");
                        MessageShow.Visible = true;
                        break;

                    case 1:
                        {
                            var operateLog = new ShopNum1_OperateLog
                                {
                                    Record = "资讯分类管理删除成功",
                                    OperatorID = base.ShopNum1LoginID,
                                    IP = Globals.IPAddress,
                                    PageName = "ArticleCategory_List.aspx",
                                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                };
                            base.OperateLog(operateLog);
                            BindArticleCategory();
                            MessageShow.ShowMessage("DelYes");
                            MessageShow.Visible = true;
                            break;
                        }
                    case 0:
                        MessageShow.ShowMessage("DelNo");
                        MessageShow.Visible = true;
                        break;
                }
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            TreeNodeCollection nodes = TreeViewCategory.Nodes;
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
                TreeViewCategory.ExpandAll();
                ButtonNodeOperate.Text = "全部收缩";
                ButtonNodeOperate.ToolTip = "Expand";
                ButtonNodeOperate.CssClass = "shuoso picbtn";
            }
            else
            {
                TreeViewCategory.CollapseAll();
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
                    base.Response.Redirect("ArticleCategory_Operate.aspx?id=" + node.Value);
                }
                GetNode(node.ChildNodes);
            }
        }

        public void GetNodeDel(TreeNodeCollection treeNodeCollection_0)
        {
            foreach (TreeNode node in treeNodeCollection_0)
            {
                if (node.Checked)
                {
                    strid = node.Value;
                }
                GetNodeDel(node.ChildNodes);
            }
        }

        protected void TreeViewCategory_SelectedNodeChanged(object sender, EventArgs e)
        {
        }
    }
}