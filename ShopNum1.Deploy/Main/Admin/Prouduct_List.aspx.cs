using System;
using System.Collections.Generic;
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
    public partial class Prouduct_List : PageBase, IRequiresSessionState
    {

        public DataTable dt_ProductList = null;

        protected void BindGrid()
        {
            string str = ShopNum1.Common.Common.ReqStr("pagesize");
            if (str == "")
            {
                str = "10";
            }
            ShopNum1_ProuductChecked_Action action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
            string rawUrl = base.Request.RawUrl;
            if (rawUrl.IndexOf("?") != -1)
            {
                rawUrl = rawUrl.Split(new char[] { '?' })[0];
            }
            string currentpage = ShopNum1.Common.Common.ReqStr("PageID");
            if (currentpage == "")
            {
                currentpage = "1";
            }
            DataTable table = action.V8_2_SearchPerPageNew("3", str.ToString(), currentpage, this.TextBoxName.Text, this.HiddenFieldCode.Value, this.TextBoxPrice1.Text, this.TextBoxPrice2.Text, this.DropDownListIsSaled.SelectedValue, "1", this.TextBoxShopID.Text, this.TextBoxShopName.Text, this.DropDownListIsSell.SelectedValue, this.DropDownListIsShopNew.SelectedValue, this.DropDownListIsShopHot.SelectedValue, this.DropDownListIsShopGood.SelectedValue, this.DropDownListIsShopRecommend.SelectedValue);
            PageList1 list = new PageList1
            {
                PageSize = Convert.ToInt32(str),
                PageID = Convert.ToInt32(currentpage.ToString())
            };
            if ((table != null) && (table.Rows.Count > 0))
            {
                list.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                list.RecordCount = 0;
            }
            list.PageCount = list.RecordCount / list.PageSize;
            if (list.PageCount < (((double)list.RecordCount) / ((double)list.PageSize)))
            {
                list.PageCount++;
            }
            if (list.PageID > list.PageCount)
            {
                list.PageID = list.PageCount;
            }
            if ((list.PageSize > list.RecordCount) || (list.PageCount == 1))
            {
                this.showPage.Visible = false;
            }
            else
            {
                this.showPage.Visible = true;
            }
            this.pageDiv.InnerHtml = new PageListBll(rawUrl, true).GetPageListNewManage(list);
            this.dt_ProductList = action.V8_2_SearchPerPageNew("2", str.ToString(), list.PageID.ToString(), this.TextBoxName.Text, this.HiddenFieldCode.Value, this.TextBoxPrice1.Text, this.TextBoxPrice2.Text, this.DropDownListIsSaled.SelectedValue, "1", this.TextBoxShopID.Text, this.TextBoxShopName.Text, this.DropDownListIsSell.SelectedValue, this.DropDownListIsShopNew.SelectedValue, this.DropDownListIsShopHot.SelectedValue, this.DropDownListIsShopGood.SelectedValue, this.DropDownListIsShopRecommend.SelectedValue);
            if (this.dt_ProductList.Rows.Count == 0)
            {
                this.dt_ProductList = null;
            }
        }

        protected void ButtonChangeOrderID_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("ChangeOrder.aspx?guid=" + this.CheckGuid.Value + "&back=prouduct");
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
                    Record = "管理员删除商品",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "Prouduct_List.aspx",
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
                    ShopNum1_ProuductChecked_Action action2 = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
                    if (action2.UpdateProduct(this.CheckGuid.Value, strArray[0], strArray[1]) > 0)
                    {
                        if ((strArray[0] == "IsSaled") && (strArray[1] == "0"))
                        {
                            DataTable table = ShopNum1.Common.Common.GetTableById("Name,MemLoginId", "ShopNum1_Shop_Product", " And Guid=" + this.CheckGuid.Value);
                            if (table.Rows.Count > 0)
                            {
                                ShopNum1_MessageInfo messageInfo = new ShopNum1_MessageInfo
                                {
                                    Guid = Guid.NewGuid(),
                                    Title = "商品被管理员下架",
                                    Type = "1",
                                    Content = "您的商品被管理员下架,商品名称为[" + table.Rows[0]["Name"].ToString() + "]。",
                                    SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                    IsDeleted = 0,
                                    MemLoginID = "Admin"
                                };
                                List<string> usermessage = new List<string> {
                                table.Rows[0]["MemloginId"].ToString()
                            };
                                ((ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action()).Add(messageInfo, usermessage);
                                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                                {
                                    Record = "管理员下架商品",
                                    OperatorID = cookie2.Values["LoginID"].ToString(),
                                    IP = Globals.IPAddress,
                                    PageName = "Prouduct_List.aspx",
                                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                };
                                base.OperateLog(operateLog);
                            }
                        }
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
            base.Response.Redirect("ProductSearchDetal.aspx?guid=" + this.CheckGuid.Value + "&Type=Other&Back=1");
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

        public string ChangeIsSaled(string strIsSaled)
        {
            if ((strIsSaled != "0") && (strIsSaled == "1"))
            {
                return "images/shopNum1Admin-right.gif";
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
                return "images/shopNum1Admin-right.gif";
            }
            if (object_0.ToString() == "0")
            {
                return "images/shopNum1Admin-wrong.gif";
            }
            return "images/shopNum1Admin-wrong.gif";
        }

        public string IsSell(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "images/shopNum1Admin-wrong.gif";
            }
            if (object_0.ToString() == "1")
            {
                return "images/shopNum1Admin-right.gif";
            }
            return "非法状态";
        }

        private void method_5()
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

        protected void ObjectDataSourceDate_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.DropDownListProductGuidBind();
                this.method_6();
                this.method_5();
            }
            if (this.Page.Request.QueryString["hot"] != null)
            {
                this.DropDownListIsShopHot.SelectedValue = this.Page.Request.QueryString["hot"].ToString();
            }
            if (this.Page.Request.QueryString["new"] != null)
            {
                this.DropDownListIsShopNew.SelectedValue = this.Page.Request.QueryString["new"].ToString();
            }
            if (this.Page.Request.QueryString["recommend"] != null)
            {
                this.DropDownListIsShopRecommend.SelectedValue = this.Page.Request.QueryString["recommend"].ToString();
            }
            if (this.Page.Request.QueryString["good"] != null)
            {
                this.DropDownListIsShopGood.SelectedValue = this.Page.Request.QueryString["good"].ToString();
            }
            if ((ShopNum1.Common.Common.ReqStr("sign") == "del") && (ShopNum1.Common.Common.ReqStr("guid") != ""))
            {
                ShopNum1_ProuductChecked_Action action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
                string guids = "'" + ShopNum1.Common.Common.ReqStr("guid") + "'";
                if (action.Delete(guids) > 0)
                {
                      HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                    ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除商品",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "Prouduct_List.aspx",
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
            this.BindGrid();
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