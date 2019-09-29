using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;
using System.Web.UI;
using ShopNum1.DataAccess;

namespace ShopNum1.Deploy.Main.Admin
{


    public partial class ReChat : PageBase, IRequiresSessionState
    {
        protected Button CollapseBtn;
        protected Button ExpandBtn;
        protected Button FindBtn;
        
        protected int NodeCount;
        
        protected ScriptManager ScriptManager1;
      ShopNum1_OrderInfo_Action DB = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
       
        protected Button TopBtn;
        protected TreeView TreeView1;
        protected UpdatePanel UpdatePanel1;
        protected TextBox ValueBox;


        private void CreateSubTree(string strRecommendID, TreeNode tn)
        {

            string setsql = "select * from ShopNum1_Member where Superior = '" + strRecommendID + "' ";
            if (!base.checkadmin()) {
                setsql += " and MemLoginID not in(SELECT BLID from WHJ_BlackList) ";
            }
            DataSet set  = DatabaseExcetue.ReturnDataSet(setsql);
            if (set != null)
            {
                foreach (DataRow row in set.Tables[0].Rows)
                {
                    string str4 = row["Name"].ToString();
                    string membership_Level = row["PersonCate"].ToString();

                    string YesterdayAllBonus = row["YesterdayAllBonus"].ToString();
                    string MyAllBonus = row["MyAllBonus"].ToString();
                    decimal MYYeJi = Convert.ToDecimal(YesterdayAllBonus) - Convert.ToDecimal(MyAllBonus);
                    string membership_LevelName = "";
                    if (membership_Level == "0")
                    {
                        membership_LevelName = "普通会员";
                    }
                    if (membership_Level == "1")
                    {
                        membership_LevelName = "节点矿池";
                    }
                    if (membership_Level == "2")
                    {
                        membership_LevelName = "集群矿池";
                    }
                    if (membership_Level == "3")
                    {
                        membership_LevelName = "超级矿池";
                    }
                    if (membership_Level == "4")
                    {
                        membership_LevelName = "特级矿池";
                    }

                    string str7 = "会员编号：" + row["MemLoginID"].ToString() + "\n昵称：" + row["Name"].ToString() + "\nUSDT：" + row["AdvancePayment"].ToString() + "\nETH：" + row["Score_hv"].ToString() + "\nNEC：" + row["Score_dv"].ToString() + "\n电话：" + row["mobile"].ToString() + "\n会员等级：" + membership_LevelName + "\n我的业绩：" + MyAllBonus + "\n我的团队业绩：" + MYYeJi;
                    TreeNode child = new TreeNode
                    {
                        Value = row["MemLoginID"].ToString(),
                        Text = row["MemLoginID"].ToString() + "[" + str4 + "] [" + membership_LevelName + "]",
                        ToolTip = str7
                    };

                    child.Expanded = false;
                    child.PopulateOnDemand = true;
                    tn.ChildNodes.Add(child);
                }
            }
        }



        protected void FindBtn_Click(object sender, EventArgs e)
        {
            DataTable strIDTr = DB.Search_MJC_twoStr(this.ValueBox.Text,base.checkadmin());

            if (strIDTr != null && strIDTr.Rows.Count > 0)
            {
                string strID = strIDTr.Rows[0]["MemLoginID"].ToString();
                this.StartQuery(strID); 
            }
            else
            {
                Response.Write("<script>alert('没有数据存在或工号不存在');</script>");
            }

        }

        private bool IsLower(string strID)
        {
            string str = "c0000001";

            string recoCode = DB.GetRecoCode_MJCStr(strID,base.checkadmin()).Rows[0]["RecoCode"].ToString();
            if (((str.Length <= 0) || (recoCode.Length <= 0)) || (str.Length > recoCode.Length))
            {
                return false;
            }
            return (recoCode.Substring(0, str.Length) == str);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.NodeCount = 0;
                this.StartQuery("C0000001");
            }
        }

        private void StartQuery(string strRecommendID)
        {
            //DataSet set = DB.ExecuteSql4Ds("select * from ShopNum1_Member where ID = " + strRecommendID);

            string setsql = "select * from ShopNum1_Member where MemLoginID = '" + strRecommendID + "' ";
            if (!base.checkadmin())
            {
                setsql += " and MemLoginID not in(SELECT BLID from WHJ_BlackList) ";
            }



            DataSet set = DatabaseExcetue.ReturnDataSet(setsql);

            if (set != null)
            {
                foreach (DataRow row in set.Tables[0].Rows)
                {
                    string str4 = row["Name"].ToString();
                    string membership_Level = row["PersonCate"].ToString();

                    string YesterdayAllBonus = row["YesterdayAllBonus"].ToString();
                    string MyAllBonus = row["MyAllBonus"].ToString();
                    decimal MYYeJi = Convert.ToDecimal(YesterdayAllBonus) - Convert.ToDecimal(MyAllBonus);
                    string membership_LevelName = "";
                    if (membership_Level == "0")
                    {
                        membership_LevelName = "普通会员";
                    }
                    if (membership_Level == "1")
                    {
                        membership_LevelName = "节点矿池";
                    }
                    if (membership_Level == "2")
                    {
                        membership_LevelName = "集群矿池";
                    }
                    if (membership_Level == "3")
                    {
                        membership_LevelName = "超级矿池";
                    }
                    if (membership_Level == "4")
                    {
                        membership_LevelName = "特级矿池";
                    }

                    string str7 = "会员编号：" + row["MemLoginID"].ToString() + "\n昵称：" + row["Name"].ToString() + "\nUSDT：" + row["AdvancePayment"].ToString() + "\nETH：" + row["Score_hv"].ToString() + "\nNEC：" + row["Score_dv"].ToString() + "\n电话：" + row["mobile"].ToString() + "\n会员等级：" + membership_LevelName + "\n我的业绩：" + MyAllBonus + "\n我的团队业绩：" + MYYeJi;
                    this.TreeView1.Nodes.Clear();
                    TreeNode child = new TreeNode
                    {
                        Value = row["MemLoginID"].ToString(),
                        Text = row["MemLoginID"].ToString() + "[" + str4 + "] [" + membership_LevelName + "]",
                        ToolTip = str7
                    };
                   
                    this.TreeView1.Nodes.Add(child);
                    this.TreeView1.CollapseAll();
                    this.TreeView1.Nodes[0].Expand();
                }
            }
        }

       
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            DataTable strRecommendIDTr = DB.Search_MJCStr(this.TreeView1.SelectedNode.Value,base.checkadmin());
            if (strRecommendIDTr != null && strRecommendIDTr.Rows.Count > 0)
            {
                string strRecommendID = strRecommendIDTr.Rows[0]["MemLoginID"].ToString();
                if (strRecommendID != "")
                {
                    this.NodeCount = 0;
                    this.StartQuery(strRecommendID);
                }
            }
            else
            {
                Response.Write("<script>alert('没有数据存在');</script>");
            }
        }

        protected void tvChart_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            e.Node.ChildNodes.Clear();
            //DataTable Sercah = DB.Search_MJCStr(e.Node.Value);
            //string strRecommendID = Sercah.Rows[0]["ID"].ToString();
            //if (strRecommendID != "")
            //{
                this.NodeCount = 0;
                this.CreateSubTree(e.Node.Value, e.Node);
            //}
        }
    



       

    }
}