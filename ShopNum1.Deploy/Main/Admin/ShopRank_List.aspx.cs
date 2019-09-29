using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopRank_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridviewShow.DataBind();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            int num = ((Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action()).Delete(CheckGuid.Value);
            if (num == -1)
            {
                MessageBox.Show("默认等级不能删除！");
            }
            else if (num == -2)
            {
                MessageBox.Show("该等级下含有店铺，不允许删除！");
            }
            else if (num > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺等级",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopRank_List.aspx",
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
            var action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
            var button = (LinkButton) sender;
            string commandArgument = button.CommandArgument;
            int num = 0;
            num = action.Delete("'" + commandArgument + "'");
            if (num == -1)
            {
                MessageBox.Show("默认等级不能删除！");
            }
            else if (num == -2)
            {
                MessageBox.Show("该等级下含有店铺，不允许删除！");
            }
            else if (num > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺等级",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopRank_List.aspx",
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
            base.Response.Redirect("ShopRank_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonEditBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string commandArgument = button.CommandArgument;
            MessageBox.Show(commandArgument);
            base.Response.Redirect("ShopRank_Operate.aspx?guid=" + commandArgument);
        }

        protected void DropDownListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        public string GetRight(string isshow, string strtype)
        {
            if (strtype == "0")
            {
                if (isshow == "0")
                {
                    return "images/shopNum1Admin-right.gif";
                }
                return "images/shopNum1Admin-wrong.gif";
            }
            if (isshow == "1")
            {
                return "images/shopNum1Admin-right.gif";
            }
            return "images/shopNum1Admin-wrong.gif";
        }

        protected string IsDoMain(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "不可以";
            }
            if (object_0.ToString() == "1")
            {
                return "可以";
            }
            return "非法类型";
        }

        protected string IsType(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "默认";
            }
            if (object_0.ToString() == "0")
            {
                return "非默认";
            }
            return "非法类型";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }
    }
}