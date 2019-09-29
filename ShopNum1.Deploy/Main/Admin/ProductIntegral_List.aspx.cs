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
    public partial class ProductIntegral_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除红包商品",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ProductIntegral_List.aspx",
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

        protected void ButtonOperate_Click(object sender, EventArgs e)
        {
            int num = 0;
            var action = (ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
            if ((DropDownListOperate.SelectedValue == "1") || (DropDownListOperate.SelectedValue == "4"))
            {
                if (DropDownListOperate.SelectedValue == "1")
                {
                    num = 1;
                }
                else
                {
                    num = 0;
                }
                if (action.Operate("IsSaled", num.ToString(), CheckGuid.Value) > 0)
                {
                    MessageBox.Show("操作成功！");
                    BindGrid();
                }
            }
            if ((DropDownListOperate.SelectedValue == "2") || (DropDownListOperate.SelectedValue == "5"))
            {
                if (DropDownListOperate.SelectedValue == "2")
                {
                    num = 1;
                }
                else
                {
                    num = 0;
                }
                if (action.Operate("IsNew", num.ToString(), CheckGuid.Value) > 0)
                {
                    MessageBox.Show("操作成功！");
                    BindGrid();
                }
            }
            if ((DropDownListOperate.SelectedValue == "3") || (DropDownListOperate.SelectedValue == "6"))
            {
                if (DropDownListOperate.SelectedValue == "3")
                {
                    num = 1;
                }
                else
                {
                    num = 0;
                }
                if (action.Operate("IsHot", num.ToString(), CheckGuid.Value) > 0)
                {
                    MessageBox.Show("操作成功！");
                    BindGrid();
                }
            }
            if ((DropDownListOperate.SelectedValue == "0") || (DropDownListOperate.SelectedValue == "-1"))
            {
                MessageBox.Show("选择操作错误");
            }
            else
            {
                BindGrid();
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            returnProductCategory();
            BindGrid();
        }

        protected void ButtonSee_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ProductSearchDetal.aspx?guid=" + CheckGuid.Value + "&Type=Panic&Back=3");
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
            DropDownListProductGuid2.Items.Clear();
            DropDownListProductGuid2.Items.Add(new ListItem("-请选择-", "-1"));
            if (DropDownListProductGuid1.SelectedValue != "-1")
            {
                DataTable category =
                    ((ShopNum1_ScoreProductCategory_Action) LogicFactory.CreateShopNum1_ScoreProductCategory_Action())
                        .GetCategory(DropDownListProductGuid1.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < category.Rows.Count; i++)
                {
                    DropDownListProductGuid2.Items.Add(new ListItem(category.Rows[i]["Name"].ToString(),
                                                                    category.Rows[i]["Code"] + "/" +
                                                                    category.Rows[i]["ID"]));
                }
            }
            DropDownListProductGuid2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListProductGuid2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListProductGuid3.Items.Clear();
            DropDownListProductGuid3.Items.Add(new ListItem("-请选择-", "-1"));
            if (DropDownListProductGuid2.SelectedValue != "-1")
            {
                DataTable category =
                    ((ShopNum1_ScoreProductCategory_Action) LogicFactory.CreateShopNum1_ScoreProductCategory_Action())
                        .GetCategory(DropDownListProductGuid2.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < category.Rows.Count; i++)
                {
                    DropDownListProductGuid3.Items.Add(new ListItem(category.Rows[i]["Name"].ToString(),
                                                                    category.Rows[i]["Code"] + "/" +
                                                                    category.Rows[i]["ID"]));
                }
            }
        }

        protected void DropDownListProductGuidBind()
        {
            DropDownListProductGuid1.Items.Clear();
            DropDownListProductGuid1.Items.Add(new ListItem("-请选择-", "-1"));
            DataTable category =
                ((ShopNum1_ScoreProductCategory_Action) LogicFactory.CreateShopNum1_ScoreProductCategory_Action())
                    .GetCategory("0");
            for (int i = 0; i < category.Rows.Count; i++)
            {
                DropDownListProductGuid1.Items.Add(new ListItem(category.Rows[i]["Name"].ToString(),
                                                                category.Rows[i]["Code"] + "/" + category.Rows[i]["ID"]));
            }
            DropDownListProductGuid1_SelectedIndexChanged(null, null);
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
            DropDownListIsAudit.Items.Add(new ListItem("已审核", "1"));
        }

        private void method_6()
        {
            var item = new ListItem
                {
                    Text = "-全部-",
                    Value = "-1"
                };
            DropDownListIsSaled.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = "否",
                    Value = "0"
                };
            DropDownListIsSaled.Items.Add(item2);
            var item3 = new ListItem
                {
                    Text = "是",
                    Value = "1"
                };
            DropDownListIsSaled.Items.Add(item3);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                DropDownListProductGuidBind();
                method_6();
                BindData();
                BindGrid();
            }
        }

        public void returnProductCategory()
        {
            if (DropDownListProductGuid3.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListProductGuid3.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListProductGuid2.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListProductGuid2.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListProductGuid1.SelectedValue != "-1")
            {
                HiddenFieldCode.Value = DropDownListProductGuid1.SelectedValue.Split(new[] {'/'})[0];
            }
            else
            {
                HiddenFieldCode.Value = "-1";
            }
        }
    }
}