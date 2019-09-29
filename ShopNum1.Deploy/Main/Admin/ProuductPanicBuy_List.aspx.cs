using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ProuductPanicBuy_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.DropDownListProductGuidBind();
                this.method_6();
                this.BindData();
                this.BindGrid();
            }
        }

        protected void BindGrid()
        {
            this.Num1GridViewShow.DataBind();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ShopNum1_ProuductChecked_Action action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
            if (action.Delete(this.CheckGuid.Value.ToString()) > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员删除抢购商品",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ProuductPanicBuy_List.aspx",
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

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            ShopNum1_ProuductChecked_Action action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
            LinkButton button = (LinkButton)sender;
            string guids = "'" + button.CommandArgument + "'";
            if (action.Delete(guids) > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                   
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员删除抢购商品",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ProuductPanicBuy_List.aspx",
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

        protected void ButtonOperate_Click(object sender, EventArgs e)
        {
            if ((this.DropDownListOperate.SelectedValue == "-1") || (this.DropDownListOperate.SelectedValue == "-2"))
            {
                MessageBox.Show("请选择需要的操作！");
            }
            else
            {
                string[] strArray = this.DropDownListOperate.SelectedValue.ToString().Split(new char[] { ',' });
                if (strArray.Length >= 2)
                {
                    ShopNum1_ProuductChecked_Action action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
                    if (action.UpdateProduct(this.CheckGuid.Value, strArray[0], strArray[1]) > 0)
                    {
                        this.BindGrid();
                        this.MessageShow.ShowMessage("OperateYes");
                        this.MessageShow.Visible = true;
                    }
                    else
                    {
                        this.MessageShow.ShowMessage("OperateNo");
                        this.MessageShow.Visible = true;
                    }
                    this.BindGrid();
                }
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.returnProductCategory();
            this.BindGrid();
        }

        protected void ButtonSee_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ProductSearchDetal.aspx?guid=" + this.CheckGuid.Value + "&Type=Panic&Back=3");
        }

        public string ChangeIsBest(string strIsBest)
        {
            if (strIsBest == "0")
            {
                return "\x00d7";
            }
            if (strIsBest == "1")
            {
                return "√";
            }
            return "";
        }

        public string ChangeIsHot(string strIsHot)
        {
            if (strIsHot == "0")
            {
                return "\x00d7";
            }
            if (strIsHot == "1")
            {
                return "√";
            }
            return "";
        }

        public string ChangeIsNew(string strIsNew)
        {
            if (strIsNew == "0")
            {
                return "\x00d7";
            }
            if (strIsNew == "1")
            {
                return "√";
            }
            return "";
        }

        public string ChangeIsPromotion(string strIsRecommend)
        {
            if (strIsRecommend == "0")
            {
                return "\x00d7";
            }
            if (strIsRecommend == "1")
            {
                return "√";
            }
            return "";
        }

        public string ChangeIsSaledImg(string strIsSaled)
        {
            if (strIsSaled != "0")
            {
                if (strIsSaled == "1")
                {
                    return "images/shopNum1Admin-right.gif";
                }
                if (strIsSaled == "2")
                {
                    return "images/shopNum1Admin-wrong.gif";
                }
            }
            return "images/shopNum1Admin-wrong.gif";
        }

        protected void DropDownListProductGuid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DropDownListProductGuid2.Items.Clear();
            this.DropDownListProductGuid2.Items.Add(new ListItem("-请选择-", "-1"));
            if (this.DropDownListProductGuid1.SelectedValue != "-1")
            {
                DataTable list = ((ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetList(this.DropDownListProductGuid1.SelectedValue.Split(new char[] { '/' })[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    this.DropDownListProductGuid2.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
                }
            }
            this.DropDownListProductGuid2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListProductGuid2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DropDownListProductGuid3.Items.Clear();
            this.DropDownListProductGuid3.Items.Add(new ListItem("-请选择-", "-1"));
            if (this.DropDownListProductGuid2.SelectedValue != "-1")
            {
                DataTable list = ((ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetList(this.DropDownListProductGuid2.SelectedValue.Split(new char[] { '/' })[1]);
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    this.DropDownListProductGuid3.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
                }
            }
        }

        protected void DropDownListProductGuidBind()
        {
            this.DropDownListProductGuid1.Items.Clear();
            this.DropDownListProductGuid1.Items.Add(new ListItem("-请选择-", "-1"));
            DataTable list = ((ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action()).GetList("0");
            for (int i = 0; i < list.Rows.Count; i++)
            {
                this.DropDownListProductGuid1.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
            }
            this.DropDownListProductGuid1_SelectedIndexChanged(null, null);
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "已审核";
            }
            if (object_0.ToString() == "0")
            {
                return "未审核";
            }
            return "审核未通过";
        }

        public string IsSell(object object_0)
        {
            if ((object_0.ToString() != "0") && (object_0.ToString() == "1"))
            {
                return "images/shopNum1Admin-right.gif";
            }
            return "images/shopNum1Admin-wrong.gif";
        }

        private void BindData()
        {
            this.DropDownListIsAudit.Items.Add(new ListItem("已审核", "1"));
        }

        private void method_6()
        {
            ListItem item = new ListItem
            {
                Text = "-全部-",
                Value = "-1"
            };
            this.DropDownListIsSaled.Items.Add(item);
            ListItem item2 = new ListItem
            {
                Text = "否",
                Value = "0"
            };
            this.DropDownListIsSaled.Items.Add(item2);
            ListItem item3 = new ListItem
            {
                Text = "是",
                Value = "1"
            };
            this.DropDownListIsSaled.Items.Add(item3);
        }



        public void returnProductCategory()
        {
            if (this.DropDownListProductGuid3.SelectedValue != "-1")
            {
                this.HiddenFieldCode.Value = this.DropDownListProductGuid3.SelectedValue.Split(new char[] { '/' })[0];
            }
            else if (this.DropDownListProductGuid2.SelectedValue != "-1")
            {
                this.HiddenFieldCode.Value = this.DropDownListProductGuid2.SelectedValue.Split(new char[] { '/' })[0];
            }
            else if (this.DropDownListProductGuid1.SelectedValue != "-1")
            {
                this.HiddenFieldCode.Value = this.DropDownListProductGuid1.SelectedValue.Split(new char[] { '/' })[0];
            }
            else
            {
                this.HiddenFieldCode.Value = "-1";
            }
        }
    }
}