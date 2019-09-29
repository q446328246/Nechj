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
    public partial class Video_List : PageBase, IRequiresSessionState
    {
        protected char charSapce = '　';

        protected string strSapce = "　　";

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindCategory();
            }
        }

        protected void AddSubCategory(DataTable dataTable)
        {
            var action = (ShopNum1_VideoCategory_Action) LogicFactory.CreateShopNum1_VideoCategory_Action();
            foreach (DataRow row in dataTable.Rows)
            {
                var item = new ListItem();
                string str = string.Empty;
                for (int i = 0; i < (Convert.ToInt32(row["CategoryLevel"].ToString()) - 1); i++)
                {
                    str = str + strSapce;
                }
                str = str + row["Name"].ToString().Trim();
                item.Text = str;
                item.Value = row["ID"].ToString().Trim();
                DropDownListCategoryID.Items.Add(item);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                if (table.Rows.Count > 0)
                {
                    AddSubCategory(table);
                }
            }
        }

        protected void BindCategory()
        {
            var item = new ListItem
                {
                    Text = " -全部-",//LocalizationUtil.GetCommonMessage("All"),
                    Value = "-1"
                };
            DropDownListCategoryID.Items.Add(item);
            var action = (ShopNum1_VideoCategory_Action) LogicFactory.CreateShopNum1_VideoCategory_Action();
            foreach (DataRow row in action.Search(0, 0).DefaultView.Table.Rows)
            {
                var item2 = new ListItem
                    {
                        Text = row["Name"].ToString().Trim(),
                        Value = row["ID"].ToString().Trim()
                    };
                DropDownListCategoryID.Items.Add(item2);
                DataTable dataTable = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                if (dataTable.Rows.Count > 0)
                {
                    AddSubCategory(dataTable);
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("Video_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Video_Action) LogicFactory.CreateShopNum1_Video_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Video_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                method_5();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            method_5();
        }

        protected void ButtonSearchComment_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(),"",
                                       "<script> window.open('" +
                                       GetPageName.RetUrl("VideoDetail", CheckGuid.Value.Replace("'", "")) +
                                       "')</script>");
        }

        public string GetUrl(object strguid)
        {
            return GetPageName.RetUrl("VideoDetail", strguid);
        }

        public string IsRecommend(string strIsRecommend)
        {
            if (strIsRecommend == "1")
            {
                return "推荐";
            }
            return "不推荐";
        }

        private void method_5()
        {
            Num1GridViewShow.DataBind();
        }
    }
}