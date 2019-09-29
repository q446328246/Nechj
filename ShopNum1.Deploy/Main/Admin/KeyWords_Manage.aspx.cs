using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class KeyWords_Manage : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            this.Num1GridViewShow.DataBind();
        }

        protected void BindStatus()
        {
            ListItem item = new ListItem
            {
                Text = "-ȫ��-",
                Value = "2"
            };
            this.DropDownListQIfShow.Items.Add(item);
            ListItem item2 = new ListItem
            {
                Text = "-��ѡ��-",
                Value = "-1"
            };
            ListItem item3 = new ListItem
            {
                Text = "��Ʒ",
                Value = "0"
            };
            ListItem item4 = new ListItem
            {
                Text = "��Ѷ",
                Value = "1"
            };
            ListItem item5 = new ListItem
            {
                Text = "��ʾ",
                Value = "1"
            };
            this.DropDownListQIfShow.Items.Add(item5);
            ListItem item6 = new ListItem
            {
                Text = "����ʾ",
                Value = "0"
            };
            this.DropDownListQIfShow.Items.Add(item6);
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            this.CheckGuid.Value = "0";
            base.Response.Redirect("KeyWords_Operate.aspx?guid=" + this.CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ShopNum1_KeyWords_Action action = (ShopNum1_KeyWords_Action)LogicFactory.CreateShopNum1_KeyWords_Action();
            if (action.Delete(this.CheckGuid.Value) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "ɾ���ɹ�",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "KeyWords_Manage.aspx",
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
            base.Response.Redirect("KeyWords_Operate.aspx?guid=" + this.CheckGuid.Value);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        public string ChangeIfShow(string strIfShow)
        {
            if (strIfShow == "0")
            {
                return "ǰ̨����ʾ";
            }
            if (strIfShow == "1")
            {
                return "ǰ̨��ʾ";
            }
            return "";
        }

        public string ChangeType(string strType)
        {
            if (strType == "1")
            {
                return "��Ʒ";
            }
            if (strType == "2")
            {
                return "����";
            }
            if (strType == "3")
            {
                return "��Ѷ";
            }
            if (strType == "4")
            {
                return "����";
            }
            if (strType == "5")
            {
                return "����";
            }
            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                this.BindStatus();
                this.BindGrid();
            }
        }

    }
}