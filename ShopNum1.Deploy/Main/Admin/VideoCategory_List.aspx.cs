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
    public partial class VideoCategory_List : PageBase, IRequiresSessionState
    {
        public string strid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindProductCategory();
                if (ButtonNodeOperate.ToolTip == "NoExpand")
                {
                    TreeViewCategory.CollapseAll();
                }
            }
        }

        protected void AddSubProductCategory(TreeNode fatherNode, DataTable dataTable)
        {
            var action = (ShopNum1_VideoCategory_Action) LogicFactory.CreateShopNum1_VideoCategory_Action();
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
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                if (table.Rows.Count > 0)
                {
                    AddSubProductCategory(child, table);
                }
            }
        }

        protected void BindProductCategory()
        {
            TreeViewCategory.Nodes.Clear();
            var action = (ShopNum1_VideoCategory_Action) LogicFactory.CreateShopNum1_VideoCategory_Action();
            foreach (DataRow row in action.Search(0, 0).Rows)
            {
                var child = new TreeNode
                    {
                        Text = row["Name"].ToString(),
                        Value = row["ID"].ToString().Trim(),
                        SelectAction = TreeNodeSelectAction.Select
                    };
                child.Expand();
                TreeViewCategory.Nodes.Add(child);
                DataTable dataTable = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                if (dataTable.Rows.Count > 0)
                {
                    AddSubProductCategory(child, dataTable);
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("VideoCategory_Operate.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNodeCollection nodes = TreeViewCategory.Nodes;
                GetNodeDel(nodes);
                if (strid == "")
                {
                    MessageBox.Show("请选择要删除的记录!");
                }
                else
                {
                    strid = strid.Remove(strid.LastIndexOf(","), 1);
                    var action = new ShopNum1_VideoCategory_Action();
                    switch (action.Delete(strid))
                    {
                        case -1:
                            MessageShow.ShowMessage("此分类中含有相关文章,不能删除此分类!");
                            MessageShow.Visible = true;
                            break;

                        case -2:
                            MessageShow.ShowMessage("有子分类不能删除");
                            MessageShow.Visible = true;
                            break;

                        case 1:
                            {
                                var operateLog = new ShopNum1_OperateLog
                                    {
                                        Record = "删除成功",
                                        OperatorID = base.ShopNum1LoginID,
                                        IP = Globals.IPAddress,
                                        PageName = "VideoCategory_List.aspx",
                                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                    };
                                base.OperateLog(operateLog);
                                BindProductCategory();
                                MessageShow.ShowMessage("DelYes");
                                MessageShow.Visible = true;
                                TreeViewCategory.CollapseAll();
                                break;
                            }
                        case 0:
                            MessageShow.ShowMessage("DelNo");
                            MessageShow.Visible = true;
                            break;
                    }
                    TreeViewCategory.CollapseAll();
                    ButtonNodeOperate.Text = "全部展开";
                    ButtonNodeOperate.ToolTip = "NoExpand";
                }
            }
            catch
            {
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
                ButtonNodeOperate.Text = "全部折叠";
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
                    base.Response.Redirect("VideoCategory_Operate.aspx?id=" + node.Value);
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
                    strid = strid + node.Value + ",";
                }
                GetNodeDel(node.ChildNodes);
            }
        }
    }
}