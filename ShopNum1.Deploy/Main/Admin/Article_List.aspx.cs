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
    public partial class Article_List : PageBase, IRequiresSessionState
    {
        protected string strSapce = "　　";

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            this.ButtonUp.Visible = false;
            this.ButtonDown.Visible = false;
            this.ButtonShow.Visible = false;
            this.ButtonHidden.Visible = false;
            this.ButtonBrowse.Visible = false;
            if (!this.Page.IsPostBack)
            {
                this.method_5();
                this.BindArticleCategory();
                this.BindGrid();
            }
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            this.CheckGuid.Value = "0";
            base.Response.Redirect("Article_Operate.aspx?guid=" + this.CheckGuid.Value);
        }
        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Article_Operate.aspx?guid=" + this.CheckGuid.Value);
        }
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
            int num = shopNum1_Article_Action.Delete(this.CheckGuid.Value.ToString());
            if (num > 0)
            {
                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();
                shopNum1_OperateLog.Record="删除成功";
                shopNum1_OperateLog.OperatorID=base.ShopNum1LoginID;
                shopNum1_OperateLog.IP=Globals.IPAddress;
                shopNum1_OperateLog.PageName="Article_List.aspx";
                shopNum1_OperateLog.Date=Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                base.OperateLog(shopNum1_OperateLog);
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
        protected void BindGrid()
        {
            try
            {
                this.Num1GridViewShow.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void method_5()
        {
            ListItem listItem = new ListItem();
            listItem.Text = "-全部-";
            listItem.Value = "-1";
            this.DropDownListIsShow.Items.Add(listItem);
            this.DropDownListIsAllowComment.Items.Add(listItem);
            this.DropDownListIsHead.Items.Add(listItem);
            this.DropDownListIsHot.Items.Add(listItem);
            this.DropDownListIsRecommend.Items.Add(listItem);
            ListItem listItem2 = new ListItem();
            listItem2.Text = "前台显示";
            listItem2.Value = "1";
            this.DropDownListIsShow.Items.Add(listItem2);
            ListItem listItem3 = new ListItem();
            listItem3.Text = "允许评论";
            listItem3.Value = "1";
            this.DropDownListIsAllowComment.Items.Add(listItem3);
            ListItem listItem4 = new ListItem();
            listItem4.Text = "头条";
            listItem4.Value = "1";
            this.DropDownListIsHead.Items.Add(listItem4);
            ListItem listItem5 = new ListItem();
            listItem5.Text = "热点";
            listItem5.Value = "1";
            this.DropDownListIsHot.Items.Add(listItem5);
            ListItem listItem6 = new ListItem();
            listItem6.Text = "推荐";
            listItem6.Value = "1";
            this.DropDownListIsRecommend.Items.Add(listItem6);
            ListItem listItem7 = new ListItem();
            listItem7.Text = "前台不显示";
            listItem7.Value = "0";
            this.DropDownListIsShow.Items.Add(listItem7);
            ListItem listItem8 = new ListItem();
            listItem8.Text = "不允许评论";
            listItem8.Value = "0";
            this.DropDownListIsAllowComment.Items.Add(listItem8);
            ListItem listItem9 = new ListItem();
            listItem9.Text = "非头条";
            listItem9.Value = "0";
            this.DropDownListIsHead.Items.Add(listItem9);
            ListItem listItem10 = new ListItem();
            listItem10.Text = "非热点";
            listItem10.Value = "0";
            this.DropDownListIsHot.Items.Add(listItem10);
            ListItem listItem11 = new ListItem();
            listItem11.Text = "非推荐";
            listItem11.Value = "0";
            this.DropDownListIsRecommend.Items.Add(listItem11);
        }
        protected void BindArticleCategory()
        {
            ListItem listItem = new ListItem();
            listItem.Text = "-全部-"; ;
            listItem.Value = "-1";
            this.DropDownListArticleCategoryID.Items.Add(listItem);
            ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
            DataView defaultView = shopNum1_ArticleCategory_Action.Search(0, 0).DefaultView;
            foreach (DataRow dataRow in defaultView.Table.Rows)
            {
                ListItem listItem2 = new ListItem();
                listItem2.Text = dataRow["Name"].ToString().Trim();
                listItem2.Value = dataRow["ID"].ToString().Trim();
                this.DropDownListArticleCategoryID.Items.Add(listItem2);
                DataTable dataTable = shopNum1_ArticleCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
                if (dataTable.Rows.Count > 0)
                {
                    this.AddSubArticleCategory(dataTable);
                }
            }
        }
        protected void AddSubArticleCategory(DataTable dataTable)
        {
            ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                ListItem listItem = new ListItem();
                string text = string.Empty;
                for (int i = 0; i < Convert.ToInt32(dataRow["CategoryLevel"].ToString()) - 1; i++)
                {
                    text += this.strSapce;
                }
                text += dataRow["Name"].ToString().Trim();
                listItem.Text = text;
                listItem.Value = dataRow["ID"].ToString().Trim();
                this.DropDownListArticleCategoryID.Items.Add(listItem);
                DataTable dataTable2 = shopNum1_ArticleCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
                if (dataTable2.Rows.Count > 0)
                {
                    this.AddSubArticleCategory(dataTable2);
                }
            }
        }
        public string ChangeIsShow(string strIsShow)
        {
            string result;
            if (strIsShow == "0")
            {
                result = "前台不显示";
            }
            else
            {
                if (strIsShow == "1")
                {
                    result = "前台显示";
                }
                else
                {
                    result = "";
                }
            }
            return result;
        }
        public string ChangeIsHot(string strIsHot)
        {
            string result;
            if (strIsHot == "0")
            {
                result = "非热点";
            }
            else
            {
                if (strIsHot == "1")
                {
                    result = "热点";
                }
                else
                {
                    result = "";
                }
            }
            return result;
        }
        public string ChangeIsHead(string strIsHead)
        {
            string result;
            if (strIsHead == "0")
            {
                result = "非头条";
            }
            else
            {
                if (strIsHead == "1")
                {
                    result = "头条";
                }
                else
                {
                    result = "";
                }
            }
            return result;
        }
        public string ChangeIsRecommend(string strIsRecommend)
        {
            string result;
            if (strIsRecommend == "0")
            {
                result = "非推荐";
            }
            else
            {
                if (strIsRecommend == "1")
                {
                    result = "推荐";
                }
                else
                {
                    result = "";
                }
            }
            return result;
        }
        protected void ButtonViewComment_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ArticleComment_List.aspx?ArticleGuid=" + this.CheckGuid.Value);
        }
        public string GetUrl(object strguid)
        {
            return GetPageName.RetUrl("ArticleDetail", strguid);
        }
        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            string commandArgument = linkButton.CommandArgument;
            ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
            int num = shopNum1_Article_Action.Delete("'" + commandArgument + "'");
            if (num > 0)
            {
                ShopNum1_OperateLog shopNum1_OperateLog = new ShopNum1_OperateLog();
                shopNum1_OperateLog.Record="删除成功";
                shopNum1_OperateLog.OperatorID=base.ShopNum1LoginID;
                shopNum1_OperateLog.IP=Globals.IPAddress;
                shopNum1_OperateLog.PageName="Article_List.aspx";
                shopNum1_OperateLog.Date=Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                base.OperateLog(shopNum1_OperateLog);
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
    }
}