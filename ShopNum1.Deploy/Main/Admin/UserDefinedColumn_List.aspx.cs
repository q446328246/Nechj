using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class UserDefinedColumn_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                this.BindGrid();
            }
        }

        protected void BindGrid()
        {
            this.Num1GridViewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            this.CheckGuid.Value = "0";
            base.Response.Redirect("UserDefinedColumn_Operate.aspx?guid=" + this.CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ShopNum1_UserDefinedColumn_Action action = (ShopNum1_UserDefinedColumn_Action)LogicFactory.CreateShopNum1_UserDefinedColumn_Action();
            if (action.Delete(this.CheckGuid.Value.ToString()) > 0)
            {
                this.BindGrid();
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "删除栏目信息",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "UserDefinedColumn_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string guid = "'" + button.CommandArgument + "'";
            ShopNum1_UserDefinedColumn_Action action = (ShopNum1_UserDefinedColumn_Action)LogicFactory.CreateShopNum1_UserDefinedColumn_Action();
            if (action.Delete(guid) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "删除栏目信息",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "UserDefinedColumn_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.BindGrid();
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("UserDefinedColumn_Operate.aspx?guid=" + this.CheckGuid.Value);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        public string ChangeIfOpen(string strIfOpen)
        {
            if (strIfOpen == "0")
            {
                return "本窗口打开";
            }
            if (strIfOpen == "1")
            {
                return "新窗口打开";
            }
            return "";
        }

        public string ChangeIfShow(string strIfShow)
        {
            if (strIfShow == "0")
            {
                return "不显示";
            }
            if (strIfShow == "1")
            {
                return "显示";
            }
            return "";
        }

        public string ChangeIsMember(string isMember)
        {
            if (isMember == "0")
            {
                return "不显示";
            }
            if (isMember == "1")
            {
                return "显示";
            }
            return "";
        }

        public string ChangeIsShop(string isShop)
        {
            if (isShop == "0")
            {
                return "不显示";
            }
            if (isShop == "1")
            {
                return "显示";
            }
            return "";
        }



        public string ShowLocation(string string_4)
        {
            if (string_4.ToString() == "0")
            {
                return "中部导航";
            }
            if (string_4.ToString() == "1")
            {
                return "底部导航";
            }
            return "右上角导航";
        }
    }
}