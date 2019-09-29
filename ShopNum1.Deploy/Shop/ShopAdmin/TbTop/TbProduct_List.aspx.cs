/************************************************************
Design:By t(�ƽ�����)
WebSite:http://www.t.com
ShopNum1 WebSite:http://www.shopnum1.cn
Coder:WFK
Date:2009-1-8
************************************************************/

using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.Deploy.Shop.ShopAdmin.TbTop
{
    public partial class TbProduct_List : Page
    {
        ////�����ո�
        //protected string strSapce = "����";
        ////һ���ո�
        //protected char charSapce = '��';

        //protected const string VirtualCard_List = "VirtualCard_List.aspx";
        //protected const string BasePriceAuction_Operate = "BasePriceAuction_Operate.aspx";
        //protected const string LongPriceAuction_Operate = "LongPriceAuction_Operate.aspx";
        //protected const string Organiz_Operate = "Organiz_Operate.aspx";
        //protected const string Wholesale_Operate = "Wholesale_Operate.aspx";


        public string MemLoginID { get; set; }

        public int PageCount { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //��֤��Ա���ĵ�cookies
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                //�˳�
                GetUrl.RedirectTopLogin();
            }
            else
            {
                HttpCookie cookieMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieMemberLogin = HttpSecureCookie.Decode(cookieMemberLogin);
                string MemberType = decodedCookieMemberLogin.Values["MemberType"];
                if (MemberType != "2")
                {
                    //�˳�

                    GetUrl.RedirectTopLogin();
                    return;
                }
                //��Ա��¼ID
            }

            if (!Page.IsPostBack)
            {
                //BindData();
            }
        }

        protected void ButtonSearchDetail_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("Product_SearchDetail.aspx?guid=" + CheckGuid.Value.Replace("'", ""));
        }

        //�¼�
        protected void ButtonDownSaled_Click(object sender, EventArgs e)
        {
            var shop_Product_Action = (Shop_Product_Action) LogicFactory.CreateShop_Product_Action();
            if (shop_Product_Action.UpdateProductSaled(CheckGuid.Value, "2") > 0)
            {
                MessageBox.Show("�޸ĳɹ���");
                BindData();
            }
        }

        //�ϼ�
        protected void ButtonUpSaled_Click(object sender, EventArgs e)
        {
            var shop_Product_Action = (Shop_Product_Action) LogicFactory.CreateShop_Product_Action();
            if (shop_Product_Action.UpdateProductSaled(CheckGuid.Value, "1") > 0)
            {
                MessageBox.Show("�޸ĳɹ���");
                BindData();
            }
        }

        //ɾ��
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var shop_Product_Action = (Shop_Product_Action) LogicFactory.CreateShop_Product_Action();
            if (shop_Product_Action.DeleteShopProduct(CheckGuid.Value, MemLoginID) > 0)
            {
                MessageBox.Show("ɾ���ɹ���");
                BindData();
            }
        }

        //�༭
        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("TbProduct_Operate.aspx.aspx?guid=" + CheckGuid.Value.Replace("'", ""));
        }

        //���
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("TbProduct_Operate.aspx.aspx?IsNew=1");
        }

        //��ѯ
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        //������
        private void BindData()
        {
            string name = TextBoxName.Text == "" ? "-1" : TextBoxName.Text;
            string productNum = TextBoxProductNum.Text == "" ? "-1" : TextBoxProductNum.Text;
            string isSaled = DropDownListIsSaled.SelectedValue;
            string beginPrice = TextBoxBeginPrice.Text == "" ? "-1" : TextBoxBeginPrice.Text;
            string endPrice = TextBoxEndPrice.Text == "" ? "-1" : TextBoxEndPrice.Text;
            string productSeriesCode = GetDropDownListProductSeriesCode();
            //string productCategoryCode = "-1";
            var product_Action = (Shop_Product_Action) LogicFactory.CreateShop_Product_Action();
            DataTable dataTable = product_Action.GetShopProduct(name, productNum, isSaled, beginPrice, endPrice,
                                                                DropDownListType.SelectedValue, productSeriesCode, "-1",
                                                                MemLoginID, "-1");

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                #region ��ҳ����

                var pds = new PagedDataSource();
                pds.DataSource = dataTable.DefaultView;
                pds.AllowPaging = true;
                //��ҳ�������ж���ÿҳ��ʾ������
                pds.PageSize = PageCount; //ÿҳ������
                int currentpage = -1;
                //  ��URL�����л�ȡpageҳ�����
                if (Page.Request.QueryString.Get("page") != null)
                {
                    currentpage = Convert.ToInt32(Page.Request.QueryString.Get("page"));
                }
                else
                {
                    currentpage = 1;
                }
                //���õ�ǰҪ��ʾ������ҳ
                pds.CurrentPageIndex = currentpage - 1;
                var nwc = new Num1WebControlCommon();
                LabelPageMessage.Text = nwc.GetPageMessage(pds.DataSourceCount, pds.PageCount, pds.PageSize, currentpage);
                string strotherParam = "&&MemLoginID=" + MemLoginID;
                lnkTo.Text = nwc.AppendPage(Page, pds.PageCount, currentpage, strotherParam);
                lnkPrev.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" +
                                      Convert.ToInt32(currentpage - 1) +
                                      "&&MemLoginID=" + MemLoginID;
                lnkFirst.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=1" + "&&MemLoginID=" + MemLoginID;
                lnkNext.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" +
                                      Convert.ToInt32(currentpage + 1) +
                                      "&&MemLoginID=" + MemLoginID;
                lnkLast.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" + pds.PageCount + "&&MemLoginID=" +
                                      MemLoginID;

                if (currentpage <= 1 && pds.PageCount <= 1)
                {
                    lnkFirst.NavigateUrl = "";
                    lnkPrev.NavigateUrl = "";
                    lnkNext.NavigateUrl = "";
                    lnkLast.NavigateUrl = "";
                }
                if (currentpage <= 1 && pds.PageCount > 1)
                {
                    lnkFirst.NavigateUrl = "";
                    lnkPrev.NavigateUrl = "";
                }
                if (currentpage >= pds.PageCount)
                {
                    lnkNext.NavigateUrl = "";
                    lnkLast.NavigateUrl = "";
                }

                #endregion

                RepeaterShow.DataSource = pds;
                RepeaterShow.DataBind();
            }
        }

        public static string ChangIsSaled(string strIsSaled)
        {
            if (strIsSaled == "1")
            {
                return "���ϼ�";
            }
            else if (strIsSaled == "0")
            {
                return "δ�ϼ�";
            }
            else if (strIsSaled == "2")
            {
                return "�¼�";
            }
            else
            {
                return "�Ƿ�״̬";
            }
        }

        public static string ChangIsNew(string strIsNew)
        {
            if (strIsNew == "1")
            {
                return "��";
            }
            else
            {
                return "��";
            }
        }

        public static string ChangIsAudit(string IsAudit)
        {
            if (IsAudit == "1")
            {
                return "�����";
            }
            else if (IsAudit == "0")
            {
                return "δ���";
            }
            else
            {
                return "�Ƿ�״̬";
            }
        }

        #region ������Ʒ����

        protected void DropDownListProductSeriesCode1Bind()
        {
            DropDownListProductSeriesCode1.Items.Clear();
            DropDownListProductSeriesCode1.Items.Add(new ListItem("-��ѡ��-", "-1"));
            BindShopCategoryCode("0", DropDownListProductSeriesCode1);
            DropDownListProductSeriesCode1_SelectedIndexChanged(null, null);
        }

        protected void DropDownListProductSeriesCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListProductSeriesCode2.Items.Clear();
            DropDownListProductSeriesCode2.Items.Add(new ListItem("-��ѡ��-", "-1"));
            if (DropDownListProductSeriesCode1.SelectedValue != "-1")
            {
                BindShopCategoryCode(DropDownListProductSeriesCode1.SelectedValue.Split('/')[1],
                                     DropDownListProductSeriesCode2);
            }
            DropDownListProductSeriesCode2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListProductSeriesCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListProductSeriesCode3.Items.Clear();
            DropDownListProductSeriesCode3.Items.Add(new ListItem("-��ѡ��-", "-1"));
            if (DropDownListProductSeriesCode2.SelectedValue != "-1")
            {
                BindShopCategoryCode(DropDownListProductSeriesCode2.SelectedValue.Split('/')[1],
                                     DropDownListProductSeriesCode3);
            }
        }

        /// <summary>
        ///     ���¼�����
        /// </summary>
        /// <param name="fatherID"></param>
        /// <param name="DropDownListCategoryCode"></param>
        private void BindShopCategoryCode(string fatherID, DropDownList DropDownListCategoryCode)
        {
            var productCategory_Action = (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
            productCategory_Action.TableName = "ShopNum1_Shop_ProductCategory";
            DataTable dataTable = productCategory_Action.GetShopProductCategoryCode(fatherID, MemLoginID);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DropDownListCategoryCode.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(),
                                                                dataTable.Rows[i]["Code"] + "/" +
                                                                dataTable.Rows[i]["ID"]));
            }
        }


        //����ѡ���code
        public string GetDropDownListProductSeriesCode()
        {
            if (DropDownListProductSeriesCode3.SelectedValue != "-1")
            {
                return DropDownListProductSeriesCode3.SelectedValue.Split('/')[0];
            }
            else
            {
                if (DropDownListProductSeriesCode2.SelectedValue != "-1")
                {
                    return DropDownListProductSeriesCode2.SelectedValue.Split('/')[0];
                }
                else
                {
                    if (DropDownListProductSeriesCode1.SelectedValue != "-1")
                    {
                        return DropDownListProductSeriesCode1.SelectedValue.Split('/')[0];
                    }
                    else
                    {
                        return "-1";
                    }
                }
            }
        }

        #endregion
    }
}