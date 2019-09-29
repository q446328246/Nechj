using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MemberRank_BindCategories : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.Band();
                CheckGuid.Value = (Page.Request.QueryString["guid"] == "0")
                                      ? "0"
                                      : base.Request.QueryString["guid"];
                if (CheckGuid.Value != "0")
                {
                    IsReadOrBuy.Value = Page.Request.QueryString["right"];
                    DataTable data = LogicFactory.CreateMemberRank_LinkCategory_Action().GetRankLinkCategoryByID(CheckGuid.Value, IsReadOrBuy.Value);
                    IsCreateOrEdit.Value = "0";
                    if (data != null)
                    {
                        if (data.Rows.Count > 0)
                        {
                            IsCreateOrEdit.Value = data.Rows[0][0].ToString();
                            string checkedList = data.Rows[0][2].ToString();
                            List<string> list = checkedList.Split(',').ToList();
                            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                            {
                                foreach (var item in list)
                                {
                                    if (CheckBoxList1.Items[i].Value == item)
                                    {
                                        CheckBoxList1.Items[i].Selected = true;
                                    }
                                }
                            }
                        }
                    }

                    if (IsReadOrBuy.Value == "2")
                    {
                        LabelPageTitle.Text = "绑定可买专区";
                    }

                    if (IsReadOrBuy.Value == "1")
                    {
                        LabelPageTitle.Text = "绑定可缆专区";
                    }

                }

            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            string sq = getCheck(this.CheckBoxList1, ",");
            ShopNum1_MemberRank_LinkCategory rankLinkCategory = new ShopNum1_MemberRank_LinkCategory();
            rankLinkCategory.Categories = sq;

            DataTable data = new DataTable();

            if (IsCreateOrEdit.Value != "0")
            {
                LogicFactory.CreateMemberRank_LinkCategory_Action().Update(int.Parse(IsCreateOrEdit.Value), rankLinkCategory);
                if (IsReadOrBuy.Value == "2")
                {
                    data = LogicFactory.CreateMemberRank_LinkCategory_Action().GetRankLinkCategoryByID(CheckGuid.Value, "1");
                    rankLinkCategory.Categories = this.CombineBuytoRead(data.Rows[0][2].ToString(), sq);
                    LogicFactory.CreateMemberRank_LinkCategory_Action().Update(int.Parse(data.Rows[0][0].ToString()), rankLinkCategory);
                }
            }
            else
            {
                rankLinkCategory.IsReadOrBuy = int.Parse(IsReadOrBuy.Value);
                rankLinkCategory.RankID = new Guid(CheckGuid.Value);
                LogicFactory.CreateMemberRank_LinkCategory_Action().Add(rankLinkCategory);
                if (IsReadOrBuy.Value == "2")
                {
                    data = LogicFactory.CreateMemberRank_LinkCategory_Action().GetRankLinkCategoryByID(CheckGuid.Value, "1");
                    if (data != null)
                    {
                        rankLinkCategory.IsReadOrBuy = 1;
                        if (data.Rows.Count > 0)
                        {
                            rankLinkCategory.Categories = this.CombineBuytoRead(data.Rows[0][2].ToString(), sq);
                            LogicFactory.CreateMemberRank_LinkCategory_Action().Update(int.Parse(data.Rows[0][0].ToString()), rankLinkCategory);
                        }
                        else {
                            LogicFactory.CreateMemberRank_LinkCategory_Action().Add(rankLinkCategory);
                        }
                        
                    }
                }
            }
            base.Response.Redirect("MemberRank_LinkCategory.aspx");
        }

        public string getCheck(CheckBoxList checkList, string separator)
        {
            string selval = "";
            for (int i = 0; i < checkList.Items.Count; i++)
            {
                if (checkList.Items[i].Selected)
                {
                    selval += checkList.Items[i].Value + separator;
                }
            }
            if (selval.Length > 1)
            {
                selval = selval.Substring(0, selval.Length - 1);
            }
            return selval;
        }

        public string CombineBuytoRead(string read, string buy)
        {
            List<string> reads = read.Split(',').ToList();
            List<string> buys = buy.Split(',').ToList();
            reads.AddRange(buys);
            List<string> all = reads.Distinct().ToList();
            string result = "";
            foreach (var item in all)
            {
                result += item + ",";
            }
            if (result.Length > 1)
            {
                result = result.Substring(0, result.Length - 1);
            }
            return result;
        }
        private void Band()
        {
            this.CheckBoxList1.DataSourceID = "SqlDataSource1";
            this.CheckBoxList1.DataTextField = "category_name";
            this.CheckBoxList1.DataValueField = "id";
            this.CheckBoxList1.DataBind();
        }
    }
}