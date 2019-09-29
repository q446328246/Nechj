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
    public partial class ProductIntegralChecked_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonCancelAudit_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
            try
            {
                if (action.IsAudit(CheckGuid.Value, 2) > 0)
                {
                    var operateLog = new ShopNum1_OperateLog
                        {
                            Record = "�����Ʒ���δͨ��",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "ProductIntegralChecked_List.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(operateLog);
                    MessageBox.Show("�����ɹ���");
                    BindGrid();
                }
                else
                {
                    MessageBox.Show("���ʧ��!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("���ʧ�ܣ�ԭ��" + exception.Message);
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "ɾ�������Ʒ",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ProductIntegralChecked_List.aspx",
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
            var action = (ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
            try
            {
                if (action.IsAudit(CheckGuid.Value, 1) > 0)
                {
                    var operateLog = new ShopNum1_OperateLog
                        {
                            Record = "�����Ʒ���ͨ��",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "ProductIntegralChecked_List.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(operateLog);
                    MessageBox.Show("��˳ɹ�");
                    BindGrid();
                }
                else
                {
                    MessageBox.Show("���ʧ��!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("���ʧ�ܣ�ԭ��" + exception.Message);
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            returnProductCategory();
            BindGrid();
        }

        protected void ButtonSee_Click1(object sender, EventArgs e)
        {
            Page.Response.Redirect("ProductIntegralDetal.aspx?guid=" + CheckGuid.Value + "&type=0");
        }

        public string ChangeIsBest(string strIsBest)
        {
            if (strIsBest == "0")
            {
                return "\x00d7";
            }
            if (strIsBest == "1")
            {
                return "��";
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
                return "��";
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
                return "��";
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
                return "��";
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
            DropDownListProductGuid2.Items.Add(new ListItem("-��ѡ��-", "-1"));
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
            DropDownListProductGuid3.Items.Add(new ListItem("-��ѡ��-", "-1"));
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
            DropDownListProductGuid1.Items.Add(new ListItem("-��ѡ��-", "-1"));
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
                return "�����";
            }
            if (object_0.ToString() == "0")
            {
                return "δ���";
            }
            if (object_0.ToString() == "2")
            {
                return "���δͨ��";
            }
            return "";
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
            DropDownListIsAudit.Items.Add(new ListItem("�����", "1"));
        }

        private void method_6()
        {
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