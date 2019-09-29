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
    public partial class City_List : PageBase, IRequiresSessionState
    {
        public string strid = "-1";

        protected void AddSubProductCategory(TreeNode fatherNode, DataTable dataTable)
        {
            ShopNum1_City_Action action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
            foreach (DataRow row in dataTable.Rows)
            {
                TreeNode child = new TreeNode
                {
                    Text = row["CityName"].ToString(),
                    Value = row["ID"].ToString().Trim(),
                    SelectAction = TreeNodeSelectAction.Select
                };
                child.Expand();
                fatherNode.ChildNodes.Add(child);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                if (table.Rows.Count > 0)
                {
                    this.AddSubProductCategory(child, table);
                }
            }
        }

        protected void BindProductCategory()
        {
            this.TreeViewCategory.Nodes.Clear();
            ShopNum1_City_Action action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
            foreach (DataRow row in action.Search(0, 0).Rows)
            {
                TreeNode child = new TreeNode
                {
                    Text = row["CityName"].ToString(),
                    Value = row["ID"].ToString().Trim(),
                    SelectAction = TreeNodeSelectAction.Select
                };
                child.Expand();
                this.TreeViewCategory.Nodes.Add(child);
                DataTable dataTable = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                if (dataTable.Rows.Count > 0)
                {
                    this.AddSubProductCategory(child, dataTable);
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("City_Operate.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            TreeNodeCollection nodes = this.TreeViewCategory.Nodes;
            this.GetNodeDel(nodes);
            if (this.strid == "-1")
            {
                MessageBox.Show("请选择要删除的记录!");
            }
            else
            {
                ShopNum1_City_Action action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
                if (action.Search2(Convert.ToInt32(this.strid), 0).Rows.Count > 0)
                {
                    MessageBox.Show("先删除子分类");
                }
                else
                {
                    switch (action.Delete(this.strid))
                    {
                        case -1:
                            this.MessageShow.ShowMessage("DelProductCategoryNo");
                            this.MessageShow.Visible = true;
                            break;

                        case -2:
                            this.MessageShow.ShowMessage("DelProductCategoryNo2");
                            this.MessageShow.Visible = true;
                            break;

                        case 1:
                            {
                                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                                {
                                    Record = "删除成功",
                                    OperatorID = base.ShopNum1LoginID,
                                    IP = Globals.IPAddress,
                                    PageName = "City_List.aspx",
                                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                };
                                base.OperateLog(operateLog);
                                this.BindProductCategory();
                                this.MessageShow.ShowMessage("DelYes");
                                this.MessageShow.Visible = true;
                                this.TreeViewCategory.CollapseAll();
                                break;
                            }
                        case 0:
                            this.MessageShow.ShowMessage("DelNo");
                            this.MessageShow.Visible = true;
                            break;
                    }
                }
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            TreeNodeCollection nodes = this.TreeViewCategory.Nodes;
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
                this.TreeViewCategory.ExpandAll();
                this.ButtonNodeOperate.Text = "全部折叠";
                this.ButtonNodeOperate.ToolTip = "Expand";
            }
            else
            {
                this.TreeViewCategory.CollapseAll();
                this.ButtonNodeOperate.Text = "全部展开";
                this.ButtonNodeOperate.ToolTip = "NoExpand";
            }
        }

        public void GetNode(TreeNodeCollection treeNodeCollection_0)
        {
            foreach (TreeNode node in treeNodeCollection_0)
            {
                if (node.Checked)
                {
                    base.Response.Redirect("City_Operate.aspx?id=" + node.Value.ToString());
                }
                this.GetNode(node.ChildNodes);
            }
        }

        public void GetNodeDel(TreeNodeCollection treeNodeCollection_0)
        {
            foreach (TreeNode node in treeNodeCollection_0)
            {
                if (node.Checked)
                {
                    this.strid = node.Value.ToString();
                }
                this.GetNodeDel(node.ChildNodes);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                this.BindProductCategory();
                if (this.ButtonNodeOperate.ToolTip == "NoExpand")
                {
                    this.TreeViewCategory.CollapseAll();
                }
            }
        }

    }
}