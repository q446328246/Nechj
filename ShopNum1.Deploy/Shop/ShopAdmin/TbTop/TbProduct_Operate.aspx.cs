using System.Web.UI;

namespace ShopNum1.Deploy.Shop.ShopAdmin.TbTop
{
    public partial class TbProduct_Operate : Page
    {
        ////�����ո�
        //protected string strSapce = "����";
        ////һ���ո�
        //protected char charSapce = '��';

        //protected string strLine = " --- ";


        //DataTable dataMultiImage;
        //DataTable dataProductyAttributePrice;
        //ShopNum1_TbSysItemCat_Action shopNum1_FavourTicket_Action = (ShopNum1_TbSysItemCat_Action)LogicTbFactory.CreateShopNum1_TbSysItemCat_Action();

        //protected bool AtrributeValue0 = true;
        //protected bool AtrributeValue1 = false;
        //protected bool AtrributeValue2 = false;
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    this.CheckLogin();
        //    this.hiddenFieldGuid.Value = Request.QueryString["guid"] == null ? "0" : Request.QueryString["guid"];
        //    if (!CheckProductLine())
        //    {
        //        Label3.Visible = false;
        //        DropDownListProducLine.Visible = false;
        //    }
        //    if (this.HiddenFieldAtrributeValue0.Value == "true")
        //    {
        //        AtrributeValue0 = true;
        //    }
        //    else
        //    {
        //        AtrributeValue0 = false;
        //    }
        //    if (this.HiddenFieldAtrributeValue1.Value == "true")
        //    {
        //        AtrributeValue1 = true;
        //    }
        //    else
        //    {
        //        AtrributeValue1 = false;
        //    }
        //    if (this.HiddenFieldAtrributeValue2.Value == "true")
        //    {
        //        AtrributeValue2 = true;
        //    }
        //    else
        //    {
        //        AtrributeValue2 = false;
        //    }

        //    if (!Page.IsPostBack)
        //    {

        //        /// this.TreeViewTb.Scrollable = true;
        //        if (CheckUnionType() == "0")
        //        {
        //            PanelProductPushMoney.Visible = true;
        //        }

        //        CreateProductyAttributePriceTable();

        //        CreateMultiImageTable();

        //        //�󶨷���
        //        BindProductCategory();
        //        //����ƷƷ��
        //        BindBrand();


        //        //�󶨷���
        //        BindProductCategory();
        //        //����ƷƷ��
        //        BindBrand();
        //        //����Ʒ����
        //        DropDownListProductCategoryBind();


        //        //�󶨹�Ӧ��2
        //        BindDropDownListSupplierGuid();
        //        //�󶨼�����λ
        //        BindDropDownListUnitName();
        //        //��Ʒ����
        //        BindDropDownListProductTypeGuid();
        //        //����Ѷ����
        //        BindArticleCategory();
        //        //�󶨻�Ա�ȼ�
        //        this.Num1GridViewPrice.DataBind();

        //        this.Num1GridViewAgentPrice.DataBind();

        //        //�󶨲�Ʒ��
        //        BindProductLine();

        //        //ȡOrderID
        //        GetOrderID();
        //        //��Nu1GridViewPrice�浽ViewState��
        //        //ViewState["Num1GridViewPrice"] = Num1GridViewPrice;

        //        #region  ///�Ա�api����   ��ʼ��
        //        // DataTable dt = shopNum1_FavourTicket_Action.GetSysItemCatByParent(0);
        //        if (TopClient.IsAdminLogin && TopClient.isSessionTimeOut(this.Page, "admin"))
        //        {

        //            List<ShopNum1_TbSysItemCat> sysItems = XmlInsetObject("0");
        //            foreach (ShopNum1_TbSysItemCat sysItem in sysItems)
        //            {
        //                if (sysItem.is_parent == true)
        //                {
        //                    sysItem.name = sysItem.name + "           ->";
        //                }

        //            }
        //            lbox1.DataSource = sysItems;
        //            lbox1.DataTextField = "name";
        //            lbox1.DataValueField = "cid";
        //            lbox1.DataBind();
        //            //  lbox1.Items.Insert(0, new ListItem("��ѡ��", "0"));

        //            ProvinceBind();

        //            if (ddlProvince.SelectedValue != null)
        //            {
        //                CitysBind();
        //            }

        //            BindTbCat();
        //        }
        //        else
        //        {
        //            CheckBoxTb.Enabled = false;
        //            content10_0.Visible = false;

        //        }

        //        #endregion


        //        //�༭
        //        if (this.hiddenFieldGuid.Value != "0")
        //        {

        //            DropDownListProducLine.Enabled = false;

        //            //ȡ��Ʒ������Ϣ
        //            GetEditProductInfo();
        //            //ȡ��Ʒ������
        //            GetEditProductAccessory();
        //            //ȡ��Ʒ�����Ʒ
        //            GetEditRelatedProduct();
        //            //ȡ��Ʒ�����Ѷ
        //            GetEditProductArticle();
        //            //ȡ��Ʒ��ط���
        //            GetEditProdcutExtendType();
        //            //ȡ��Ա�ȼ��۸�
        //            GetProductMemberRankPrice();
        //            //ȡ�����̵ȼ��۸�
        //            GetAgentProductMemberRankPrice();
        //            //ȡ��Ʒ��ͼ
        //            GetProductImage();
        //            ////ȡ������Ʒ���Ե�ֵ
        //            // GetProductAttribute();
        //            //ȡ����Ʒ�۸����Ʒ���Ե�ֵ
        //            GetProductAttribute2();


        //            string tbstatus = GetItemStatus(hiddenFieldGuid.Value.Replace("'", "").Trim());
        //            if (tbstatus == "��ͬ��")
        //            {
        //                CheckBoxTbUpdate.Visible = true;
        //                CheckBoxTb.Visible = false;
        //                content10_0.Visible = false;
        //            }
        //            else
        //            {


        //                CheckBoxTbUpdate.Visible = false;
        //                CheckBoxTb.Visible = true;
        //            }


        //        }
        //        else
        //        {


        //        }


        //    }
        //}

        //#region ҳ���¼�

        ////ɾ��ѡ���ͼƬ
        //protected void ButtonDeleteImage_Click(object sender, EventArgs e)
        //{
        //    //����Ǳ༭������
        //    //if (this.hiddenFieldGuid.Value != "0")
        //    //{
        //    //    ViewState["dataMultiImage"] = (DataTable)this.DataListPorductImage.DataSource;
        //    //}
        //    //if (ViewState["dataMultiImage"] == null)
        //    //{
        //    //    ViewState["dataMultiImage"] = (DataTable)this.DataListPorductImage.DataSource;
        //    //}
        //    DataTable tempDataTalbe = (DataTable)ViewState["dataMultiImage"];
        //    for (int i = 0; i < this.DataListPorductImage.Items.Count; i++)
        //    {

        //        HtmlInputCheckBox d = this.DataListPorductImage.Items[i].FindControl("checkboxItem") as HtmlInputCheckBox;
        //        if (d.Checked)
        //        {
        //            DataRow[] foundRow;
        //            string strGuid = d.Value.ToString();
        //            foundRow = tempDataTalbe.Select("Guid ='" + strGuid + "'", "");
        //            foreach (DataRow row in foundRow)
        //            {
        //                tempDataTalbe.Rows.Remove(row);
        //            }
        //            ViewState["dataMultiImage"] = tempDataTalbe;
        //        }
        //    }
        //    DataView tempDataView = ((DataTable)ViewState["dataMultiImage"]).DefaultView;
        //    tempDataView.Sort = "CreateTime DESC";
        //    this.DataListPorductImage.DataSource = tempDataView;
        //    this.DataListPorductImage.DataBind();

        //}

        ////�����Ʒ��ͼ
        //protected void ButtonAddMultiImage_Click(object sender, EventArgs e)
        //{
        //    DataTable tempDataTalbe = (DataTable)ViewState["dataMultiImage"];
        //    DataRow dataRow = tempDataTalbe.NewRow();
        //    dataRow["Guid"] = Guid.NewGuid();
        //    //int textBoxMultiImageLength=this.TextBoxMultiImage;
        //    dataRow["OriginalImge"] = this.TextBoxMultiImage.Text;
        //    dataRow["CreateTime"] = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //    tempDataTalbe.Rows.Add(dataRow);
        //    DataView tempDataView = tempDataTalbe.DefaultView;
        //    tempDataView.Sort = "CreateTime DESC";
        //    this.DataListPorductImage.DataSource = tempDataTalbe.DefaultView;
        //    this.DataListPorductImage.DataBind();


        //    //foreach (ListItem tempItem in this.ListBoxPageRight.Items)
        //    //{
        //    //    DataRow dataRow = tablePage.NewRow();
        //    //    dataRow["Guid"] = tempItem.Value;
        //    //    dataRow["Name"] = tempItem.Text;
        //    //    tablePage.Rows.Add(dataRow);
        //    //}
        //    //this.DataListPageControl.DataSource = tablePage;
        //    //this.DataListPageControl.DataBind();


        //}

        ////ѡ����Ʒ����
        //protected void DropDownListProductTypeGuid_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    #region ������Լ۸�
        //    //���Num1GridViewProductyAttributePrice
        //    DataTable tempDataTable = (DataTable)ViewState["dataProductyAttributePrice"];
        //    tempDataTable.Rows.Clear();
        //    ViewState["dataProductyAttributePrice"] = tempDataTable;
        //    this.Num1GridViewProductyAttributePrice.DataSource = null;
        //    this.Num1GridViewProductyAttributePrice.DataBind();
        //    #endregion

        //    //this.Num1GridViewPrice = (Num1GridView)ViewState["Num1GridViewPrice"];
        //    BindDropDownListAttributeName();


        //    // ShopNum1_ProductAttribute_Action productAttributeAction = (ShopNum1_ProductAttribute_Action)LogicFactory.CreateShopNum1_ProductAttribute_Action();
        //    //DataTable dataTable = productAttributeAction.SearchByProductTypeIsMultiSelect12(this.DropDownListProductTypeGuid.SelectedValue);

        //    //for (int i = 0; i < dataTable.Rows.Count; i++)
        //    //{
        //    //    Table tempTable = new Table();
        //    //    tempTable.ID = "table" + tempTable.Rows.Count
        //    //    TableRow tableRow = new TableRow();
        //    //    TableCell tableCell = new TableCell();

        //    //    Label tempLable = new Label();
        //    //    tempLable.ID = "lable" + tempTable.Rows.Count;
        //    //    tempLable.Text = dataTable.Rows[i]["Name"].ToString();

        //    //    if(dataTable.Rows[i]["InputType"].ToString() == "0")
        //    //    {
        //    //       TextBox tempTextBox=new TextBox();
        //    //        tempTextBox.ID = "textBox" + tempTable.Rows.Count;              
        //    //    }else if(dataTable.Rows[i]["InputType"].ToString() == "1")
        //    //    {
        //    //          DropDownList tempDropDownList=new DropDownList(); 
        //    //         tempDropDownList.ID="dropDownList"+tempTable.Rows.Count; 
        //    //         for(int i=0;i<10;i++)
        //    //         {
        //    //             tempDropDownList.Items.Add(i.ToString();
        //    //         }
        //    //         tc2.Controls.Add(dpl);
        //    //    }
        //    //}

        //}


        ////����Ʒ�����б��еĿؼ�
        //protected void Num1GridViewProductyAttributeShow_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowIndex > -1)
        //    {
        //        //����"��ӣ�����"��ť
        //        //��Ϊ"Ψһ����"��ʱ��
        //        if (e.Row.Cells[4].Text == "0")
        //        {
        //            //((Button)e.Row.Cells[8].FindControl("ButtonAdd")).Visible = false;
        //            //((Button)e.Row.Cells[8].FindControl("ButtonRemove")).Visible = false;

        //            //����"���Լ۸���"
        //            //((TextBox)e.Row.Cells[7].FindControl("TextBoxPrice")).Visible = false;
        //        }

        //        if (e.Row.Cells[3].Text == "0")  //TextBox������,Ϊ�ֹ�����
        //        {
        //            TextBox textBox = new TextBox();
        //            textBox.ID = "textBox" + e.Row.RowIndex.ToString();
        //            textBox.Text = "";
        //            e.Row.Cells[2].Controls.Add(textBox);

        //        }
        //        else if (e.Row.Cells[3].Text == "1")  //DropDownList��ѡ��,Ϊѡ������
        //        {
        //            DropDownList dropDownList = new DropDownList();
        //            dropDownList.ID = "dropDownList" + e.Row.RowIndex.ToString();
        //            //�����ѡ��ֵ         
        //            if (e.Row.Cells[5].Text.Trim() != "&nbsp;")
        //            {
        //                //��AttrValue�����ֵ�á��س���
        //                string[] strAttrValue = e.Row.Cells[5].Text.Split('\n');
        //                if (strAttrValue.Length > 0)
        //                {
        //                    for (int i = 0; i < strAttrValue.Length; i++)
        //                    {
        //                        ListItem listItem = new ListItem();
        //                        listItem.Text = strAttrValue[i].ToString();
        //                        listItem.Value = strAttrValue[i].ToString();
        //                        dropDownList.Items.Add(listItem);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                ListItem listItem = new ListItem();
        //                listItem.Text = "";
        //                listItem.Value = "";
        //                dropDownList.Items.Add(listItem);
        //            }
        //            e.Row.Cells[2].Controls.Add(dropDownList);
        //        }
        //        else if (e.Row.Cells[3].Text == "2") //TextBox������ Ϊ�����ı�����
        //        {
        //            TextBox textBox = new TextBox();
        //            textBox.ID = "textBox" + e.Row.RowIndex.ToString();
        //            textBox.Text = "";
        //            textBox.TextMode = TextBoxMode.MultiLine;
        //            e.Row.Cells[2].Controls.Add(textBox);
        //        }
        //    }

        //}

        //#endregion

        //#region �Զ��巽��


        ////�õ���Ʒ����ID
        //public string returnProductCategoryID()
        //{
        //    string strProductCategoryID = string.Empty;
        //    if (DropDownListProductCategoryID3.SelectedValue != "-1")
        //    {
        //        strProductCategoryID = DropDownListProductCategoryID3.SelectedValue;
        //    }
        //    else
        //    {
        //        if (DropDownListProductCategoryID2.SelectedValue != "-1")
        //        {
        //            strProductCategoryID = DropDownListProductCategoryID2.SelectedValue;
        //        }
        //        else
        //        {
        //            if (DropDownListProductCategoryID1.SelectedValue != "-1")
        //            {
        //                strProductCategoryID = DropDownListProductCategoryID1.SelectedValue;
        //            }
        //            else
        //            {
        //                strProductCategoryID = "-1";
        //            }
        //        }
        //    }

        //    return strProductCategoryID;
        //}
        ////��ʼ�ּ�����Ʒ����
        //protected void DropDownListProductCategoryBind()
        //{
        //    DropDownListProductCategoryID1.Items.Clear();
        //    DropDownListProductCategoryID1.Items.Add(new ListItem("-��ѡ��-", "-1"));
        //    ShopNum1_ProductCategory_Action productCategoryAction = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
        //    DataTable dataTable = productCategoryAction.Search(0, 0);
        //    for (int i = 0; i < dataTable.Rows.Count; i++)
        //    {
        //        DropDownListProductCategoryID1.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["ID"].ToString()));
        //    }
        //    DropDownListProductCategoryID1_SelectedIndexChanged(null, null);
        //}

        ////һ������ı��¼�
        //protected void DropDownListProductCategoryID1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownListProductCategoryID2.Items.Clear();
        //    DropDownListProductCategoryID2.Items.Add(new ListItem("-��ѡ��-", "-1"));
        //    if (DropDownListProductCategoryID1.SelectedValue != "-1")
        //    {
        //        ShopNum1_ProductCategory_Action productCategoryAction = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
        //        DataTable dataTable = productCategoryAction.Search(Convert.ToInt32(DropDownListProductCategoryID1.SelectedValue), 0);

        //        for (int i = 0; i < dataTable.Rows.Count; i++)
        //        {
        //            DropDownListProductCategoryID2.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["ID"].ToString()));
        //        }
        //        //����ƷƷ��
        //        BindProductBranDrelation(DropDownListProductCategoryID1.SelectedValue);
        //    }
        //    DropDownListProductCategoryID2_SelectedIndexChanged(null, null);
        //}

        ////������Ʒ����iD����ƷƷ��
        //private void BindProductBranDrelation(string categroyid)
        //{
        //    this.DropDownListBrandGuid.Items.Clear();
        //    this.DropDownListBrandGuid.Items.Add(new ListItem("-��ѡ��-", "-1"));
        //    ShopNum1_Brand_Action brandAction = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
        //    DataTable dataTableBrand = brandAction.GetBrandByProductCategoryRelation(categroyid);

        //    if (dataTableBrand != null && dataTableBrand.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dataTableBrand.Rows)
        //        {
        //            ListItem listItem = new ListItem();
        //            listItem.Text = dr["Name"].ToString().Trim();
        //            listItem.Value = dr["Guid"].ToString().Trim();
        //            //�����ʱ��ġ���ƷƷ�ơ�DropDownListBrandGuid
        //            //����Ʒ�����ѯ��ġ���ƷƷ�ơ�DropDownListSProductAccessoryBrandGuid
        //            //�������Ʒ��ѯ��ġ���ƷƷ�ơ�DropDownListSRelatedProductBrandGuid
        //            this.DropDownListBrandGuid.Items.Add(listItem);
        //        }
        //    }
        //}

        ////������Ʒ����ı��¼�
        //protected void DropDownListProductCategoryID2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownListProductCategoryID3.Items.Clear();
        //    DropDownListProductCategoryID3.Items.Add(new ListItem("-��ѡ��-", "-1"));
        //    if (DropDownListProductCategoryID2.SelectedValue != "-1")
        //    {
        //        ShopNum1_ProductCategory_Action productCategoryAction = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
        //        DataTable dataTable = productCategoryAction.Search(Convert.ToInt32(DropDownListProductCategoryID2.SelectedValue), 0);
        //        for (int i = 0; i < dataTable.Rows.Count; i++)
        //        {
        //            DropDownListProductCategoryID3.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["ID"].ToString()));
        //        }
        //        //����ƷƷ��
        //        BindProductBranDrelation(DropDownListProductCategoryID2.SelectedValue);
        //    }
        //}

        ////������Ʒ����ı��¼�
        //protected void DropDownListProductCategoryID3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DropDownListProductCategoryID3.SelectedValue != "-1")
        //    {
        //        //����ƷƷ��
        //        BindProductBranDrelation(DropDownListProductCategoryID3.SelectedValue);
        //        //����Ʒ����
        //        BindProductProp();
        //    }
        //}


        ////ȡOrderID
        //protected void GetOrderID()
        //{
        //    ShopNum1_Common_Action shopNum1_Common_Action = (ShopNum1_Common_Action)LogicFactory.CreateShopNum1_Common_Action();
        //    string order_id = "OrderID", shopnum1_product = "ShopNum1_Product";
        //    this.TextBoxOrderID.Text = Convert.ToString(1 + shopNum1_Common_Action.ReturnMaxID(order_id, shopnum1_product));
        //}


        ///// ����Ʒ����
        ///// </summary>
        //protected void BindProductCategory()
        //{
        //    ListItem listItem1 = new ListItem();
        //    listItem1.Text = LocalizationUtil.GetCommonMessage("All");
        //    listItem1.Value = "-1";
        //    this.DropDownListSRelatedProductProductCategoryID.Items.Add(listItem1);
        //    this.DropDownListSProductAccessoryProductCategoryID.Items.Add(listItem1);


        //    ShopNum1_ProductCategory_Action productCategoryAction = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
        //    //ȡ��������
        //    DataView dataView = productCategoryAction.Search(0, 0).DefaultView;

        //    foreach (DataRow dr in dataView.Table.Rows)
        //    {
        //        ListItem listItem = new ListItem();
        //        DataTable dataTable;

        //        listItem.Text = dr["Name"].ToString().Trim();
        //        listItem.Value = dr["ID"].ToString().Trim();

        //        // �����ʱ��ġ���Ʒ���ࡱ DropDownListProductCategoryID
        //        //����Ʒ�����ѯ��ġ���Ʒ���ࡱ DropDownListSProductAccessoryProductCategoryID
        //        //�������Ʒ��ѯ��ġ���Ʒ���ࡱDropDownListSRelatedProductProductCategoryID
        //        //this.DropDownListProductCategoryID.Items.Add(listItem);
        //        this.DropDownListSProductAccessoryProductCategoryID.Items.Add(listItem);
        //        this.DropDownListSRelatedProductProductCategoryID.Items.Add(listItem);

        //        this.ListBoxLeftProductExtendCategory.Items.Add(listItem);

        //        //������ӷ���
        //        dataTable = productCategoryAction.Search(Convert.ToInt32(dr["ID"].ToString().Trim()), 0);
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            AddSubProductCategory(dataTable);
        //        }

        //    }
        //}
        ////����ӷ���
        //protected void AddSubProductCategory(DataTable dataTable)
        //{
        //    ShopNum1_ProductCategory_Action productCategoryAction = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
        //    foreach (DataRow dr in dataTable.Rows)
        //    {
        //        ListItem listItem = new ListItem();
        //        //listItem.Text = dr["Name"].ToString().Trim();
        //        string str = string.Empty;
        //        for (int i = 0; i < Convert.ToInt32(dr["CategoryLevel"].ToString()) - 1; i++)
        //        {
        //            //strSpace�������ո�
        //            str = str + strSapce;
        //        }
        //        str = str + dr["Name"].ToString().Trim();
        //        listItem.Text = str;
        //        listItem.Value = dr["ID"].ToString().Trim();

        //        // �����ʱ��ġ���Ʒ���ࡱ DropDownListProductCategoryID
        //        //����Ʒ�����ѯ��ġ���Ʒ���ࡱ DropDownListSProductAccessoryProductCategoryID
        //        //�������Ʒ��ѯ��ġ���Ʒ���ࡱDropDownListSRelatedProductProductCategoryID
        //        //this.DropDownListProductCategoryID.Items.Add(listItem);
        //        this.DropDownListSProductAccessoryProductCategoryID.Items.Add(listItem);
        //        this.DropDownListSRelatedProductProductCategoryID.Items.Add(listItem);

        //        this.ListBoxLeftProductExtendCategory.Items.Add(listItem);
        //        DataTable dataTable1 = productCategoryAction.Search(Convert.ToInt32(dr["ID"].ToString().Trim()), 0);
        //        if (dataTable1.Rows.Count > 0)
        //        {
        //            AddSubProductCategory(dataTable1);
        //        }
        //    }

        //}

        ////����ƷƷ��
        //protected void BindBrand()
        //{
        //    ListItem listItem1 = new ListItem();
        //    listItem1.Text = LocalizationUtil.GetCommonMessage("All");
        //    listItem1.Value = "-1";
        //    this.DropDownListSRelatedProductBrandGuid.Items.Add(listItem1);
        //    this.DropDownListSProductAccessoryBrandGuid.Items.Add(listItem1);

        //    ShopNum1_Brand_Action brandAction = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
        //    DataView dataView = brandAction.Search(0).DefaultView;
        //    foreach (DataRow dr in dataView.Table.Rows)
        //    {
        //        ListItem listItem = new ListItem();
        //        listItem.Text = dr["Name"].ToString().Trim();
        //        listItem.Value = dr["Guid"].ToString().Trim();
        //        //�����ʱ��ġ���ƷƷ�ơ�DropDownListBrandGuid
        //        //����Ʒ�����ѯ��ġ���ƷƷ�ơ�DropDownListSProductAccessoryBrandGuid
        //        //�������Ʒ��ѯ��ġ���ƷƷ�ơ�DropDownListSRelatedProductBrandGuid
        //        //this.DropDownListBrandGuid.Items.Add(listItem);
        //        this.DropDownListSProductAccessoryBrandGuid.Items.Add(listItem);
        //        this.DropDownListSRelatedProductBrandGuid.Items.Add(listItem);
        //    }
        //}


        ////�����ʱ��ġ�������λ��DropDownListUnitName
        //protected void BindDropDownListUnitName()
        //{
        //    ShopNum1_Unit_Action unitAction = (ShopNum1_Unit_Action)LogicFactory.CreateShopNum1_Unit_Action();
        //    DataView dataView = unitAction.Search().DefaultView;
        //    foreach (DataRow dr in dataView.Table.Rows)
        //    {
        //        ListItem listItem = new ListItem();

        //        //��������
        //        listItem.Text = dr["Name"].ToString().Trim();
        //        listItem.Value = dr["Name"].ToString().Trim();

        //        this.DropDownListUnitName.Items.Add(listItem);
        //    }
        //}

        ////�����ʱ��ġ���Ӧ�̡�DropDownListSupplierGuid
        //protected void BindDropDownListSupplierGuid()
        //{
        //    ShopNum1_Supplier_Action supplierAction = (ShopNum1_Supplier_Action)LogicFactory.CreateShopNum1_Supplier_Action();
        //    DataView dataView = supplierAction.Search(0).DefaultView;
        //    foreach (DataRow dr in dataView.Table.Rows)
        //    {
        //        ListItem listItem = new ListItem();

        //        listItem.Text = dr["Name"].ToString().Trim();
        //        listItem.Value = dr["Guid"].ToString().Trim();

        //        this.DropDownListSupplierGuid.Items.Add(listItem);
        //    }
        //}

        ////�����ʱ��ġ���Ʒ���͡�DropDownListProductTypeGuid
        //protected void BindDropDownListProductTypeGuid()
        //{
        //    ShopNum1_ProductType_Action productTypeAction = (ShopNum1_ProductType_Action)LogicFactory.CreateShopNum1_ProductType_Action();
        //    DataView dataView = productTypeAction.Search(0).DefaultView;
        //    foreach (DataRow dr in dataView.Table.Rows)
        //    {
        //        ListItem listItem = new ListItem();
        //        listItem.Text = dr["Name"].ToString().Trim();
        //        listItem.Value = dr["Guid"].ToString().Trim();

        //        this.DropDownListProductTypeGuid.Items.Add(listItem);
        //    }

        //}

        ////�����ʱ��ġ���Ѷ���ࡱ
        //protected void BindArticleCategory()
        //{
        //    ListItem listItem1 = new ListItem();
        //    listItem1.Text = LocalizationUtil.GetCommonMessage("All");
        //    listItem1.Value = "-1";
        //    this.DropDownListSArticleCategory.Items.Add(listItem1);

        //    ShopNum1_ArticleCategory_Action ariticleCategoryAction = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
        //    //ȡ��������
        //    DataView dataView = ariticleCategoryAction.Search(0, 0).DefaultView;

        //    foreach (DataRow dr in dataView.Table.Rows)
        //    {
        //        ListItem listItem = new ListItem();
        //        DataTable dataTable;

        //        listItem.Text = dr["Name"].ToString().Trim();
        //        listItem.Value = dr["ID"].ToString().Trim();

        //        //�������Ѷ��ġ���Ѷ���ࡱ DropDownListSArticleCategory
        //        this.DropDownListSArticleCategory.Items.Add(listItem);

        //        //������ӷ���
        //        dataTable = ariticleCategoryAction.Search(Convert.ToInt32(dr["ID"].ToString().Trim()), 0);
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            AddSubAriticleCategory(dataTable);
        //        }

        //    }
        //}
        ////�����Ѷ�ӷ���
        //protected void AddSubAriticleCategory(DataTable dataTable)
        //{
        //    ShopNum1_ArticleCategory_Action ariticleCategoryAction = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
        //    foreach (DataRow dr in dataTable.Rows)
        //    {
        //        ListItem listItem = new ListItem();
        //        //listItem.Text = dr["Name"].ToString().Trim();
        //        string str = string.Empty;
        //        for (int i = 0; i < Convert.ToInt32(dr["CategoryLevel"].ToString()) - 1; i++)
        //        {
        //            //strSpace�������ո�
        //            str = str + strSapce;
        //        }
        //        str = str + dr["Name"].ToString().Trim();
        //        listItem.Text = str;
        //        listItem.Value = dr["ID"].ToString().Trim();

        //        //�������Ѷ��ġ���Ѷ���ࡱ DropDownListSArticleCategory
        //        this.DropDownListSArticleCategory.Items.Add(listItem);


        //        DataTable dataTable1 = ariticleCategoryAction.Search(Convert.ToInt32(dr["ID"].ToString().Trim()), 0);
        //        if (dataTable1.Rows.Count > 0)
        //        {
        //            AddSubAriticleCategory(dataTable1);
        //        }
        //    }

        //}


        ////�󶨲�ѯʱ��ġ���Ʒ�����ListBoxLeftProductAccessory
        //protected void BindListBoxLeftProductAccessory()
        //{
        //    //������б�
        //    this.ListBoxLeftProductAccessory.Items.Clear();

        //    string productName = this.TextBoxSProductAccessoryName.Text.Trim();
        //    int productCategoryID = Convert.ToInt32(this.DropDownListSProductAccessoryProductCategoryID.SelectedValue);
        //    string brandGuid = this.DropDownListSProductAccessoryBrandGuid.SelectedValue;

        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    DataView dataView = productAction.Search(productName, productCategoryID, brandGuid).DefaultView;
        //    foreach (DataRow dr in dataView.Table.Rows)
        //    {
        //        ListItem listItem = new ListItem();
        //        listItem.Text = dr["Name"].ToString().Trim();
        //        listItem.Value = dr["Guid"].ToString().Trim();

        //        this.ListBoxLeftProductAccessory.Items.Add(listItem);
        //    }

        //}

        ////������Ʒ��ͼ�õ���DataTable
        //protected void CreateMultiImageTable()
        //{


        //    dataMultiImage = new DataTable();
        //    DataColumn column;
        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.Guid");
        //    column.ColumnName = "Guid";
        //    dataMultiImage.Columns.Add(column);

        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "OriginalImge";
        //    dataMultiImage.Columns.Add(column);

        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.DateTime");
        //    column.ColumnName = "CreateTime";
        //    dataMultiImage.Columns.Add(column);


        //    ViewState["dataMultiImage"] = dataMultiImage;

        //}

        //#endregion


        //protected void CreateProductyAttributePriceTable()
        //{

        //    dataProductyAttributePrice = new DataTable();
        //    DataColumn column;


        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.Guid");
        //    column.ColumnName = "Guid";
        //    dataProductyAttributePrice.Columns.Add(column);
        //    //��������
        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "Name";
        //    dataProductyAttributePrice.Columns.Add(column);

        //    //����ֵ
        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "AtrributeValue";
        //    dataProductyAttributePrice.Columns.Add(column);

        //    //���Լ۸�
        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.Decimal");
        //    column.ColumnName = "AttributePrice";
        //    dataProductyAttributePrice.Columns.Add(column);

        //    ViewState["dataProductyAttributePrice"] = dataProductyAttributePrice;
        //}

        ////�󶨲�Ʒ��
        //public void BindProductLine()
        //{
        //    //���ȫ��
        //    ListItem item = new ListItem();
        //    item.Text = LocalizationUtil.GetCommonMessage("Select");
        //    item.Value = "-1";
        //    this.DropDownListProducLine.Items.Add(item);

        //    ShopNum1_ProductLine_Action productLine_Action = (ShopNum1_ProductLine_Action)LogicFactory.CreateShopNum1_ProductLine_Action();
        //    DataView dataView = productLine_Action.GetProductLineName().DefaultView;
        //    foreach (DataRow dr in dataView.Table.Rows)
        //    {
        //        ListItem listItem = new ListItem();

        //        listItem.Text = dr["Name"].ToString().Trim();
        //        listItem.Value = dr["Guid"].ToString().Trim();

        //        this.DropDownListProducLine.Items.Add(listItem);
        //    }
        //}

        //protected void ButtonSearchProductAccessory_Click(object sender, EventArgs e)
        //{
        //    //����Ʒ����б�
        //    BindListBoxLeftProductAccessory();

        //}

        ////������б���Ʒ���ȫ����ӵ��ұ��б�
        //protected void ButtonAddAllProductAccessory_Click(object sender, EventArgs e)
        //{
        //    //foreach (ListItem listItem in this.ListBoxLeftProductAccessory.Items)
        //    //{
        //    //    if (CheckAddProductAccessory(listItem.Value))
        //    //    {
        //    //        this.ListBoxRightProductAccessory.Items.Add(listItem);
        //    //    }
        //    //}
        //}

        ////������б�ѡ�ֵ���Ʒ�����ӵ��ұ��б�
        //protected void ButtonAddProductAccessory_Click(object sender, EventArgs e)
        //{
        //    foreach (ListItem listItem in this.ListBoxLeftProductAccessory.Items)
        //    {
        //        if (listItem.Selected && CheckAddProductAccessory(listItem.Value))
        //        {
        //            ListItem itemTemp = new ListItem();
        //            itemTemp.Text = listItem.Text + strLine + this.TextBoxPriceProductAccessory.Text.Trim();
        //            itemTemp.Value = listItem.Value + ";" + this.TextBoxPriceProductAccessory.Text.Trim();
        //            this.ListBoxRightProductAccessory.Items.Add(itemTemp);
        //        }
        //    }
        //}
        ////���ұ��б�ѡ�ֵ���Ʒ������б����Ƴ�
        //protected void ButtonDeleteProductAccessory_Click(object sender, EventArgs e)
        //{
        //    int count = this.ListBoxRightProductAccessory.Items.Count;
        //    if (count != -1)
        //    {
        //        for (int i = this.ListBoxRightProductAccessory.Items.Count - 1; i >= 0; i--)
        //        {
        //            if (this.ListBoxRightProductAccessory.Items[i].Selected)
        //            {
        //                this.ListBoxRightProductAccessory.Items.Remove(ListBoxRightProductAccessory.Items[i]);
        //            }
        //        }
        //    }
        //}
        ////���ұ��б���Ʒ������б���ȫ���Ƴ�
        //protected void ButtonDeleteAllProductAccessory_Click(object sender, EventArgs e)
        //{
        //    int count = this.ListBoxRightProductAccessory.Items.Count;
        //    if (count != -1)
        //    {
        //        for (int i = this.ListBoxRightProductAccessory.Items.Count - 1; i >= 0; i--)
        //        {
        //            this.ListBoxRightProductAccessory.Items.Remove(ListBoxRightProductAccessory.Items[i]);
        //        }
        //    }
        //}
        ////����ұߵ��б����Ƿ�����˸����
        //private bool CheckAddProductAccessory(string guid)
        //{
        //    bool boolCheck = true;
        //    for (int i = 0; i < this.ListBoxRightProductAccessory.Items.Count; i++)
        //    {
        //        string[] strList = this.ListBoxRightProductAccessory.Items[i].Value.Trim().Split(';');
        //        //strList[0]Ϊguid
        //        if (strList[0] == guid.Trim())
        //        {
        //            boolCheck = false;
        //            break;
        //        }
        //    }
        //    return boolCheck;
        //}

        ////ѡ������Ʒ����󣬰Ѹ�����ļ۸���ʾ�ڼ۸��ı�����
        //protected void ListBoxLeftProductAccessory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    this.TextBoxPriceProductAccessory.Text = productAction.GetShopPriceByGuid(this.ListBoxLeftProductAccessory.SelectedValue);

        //    //TextBoxPriceProductAccessory
        //}

        //protected void ButtonSearchRelatedProduct_Click(object sender, EventArgs e)
        //{
        //    //�������Ʒ
        //    BindListBoxLeftRelatedProduct();
        //}

        ////�󶨲�ѯ��ġ������Ʒ���Ŀ�ѡ�б�ListBoxLeftRelatedProduct
        //protected void BindListBoxLeftRelatedProduct()
        //{
        //    //������б�
        //    this.ListBoxLeftRelatedProduct.Items.Clear();

        //    string productName = this.TextBoxSRelatedProductName.Text.Trim();
        //    int productCategoryID = Convert.ToInt32(this.DropDownListSRelatedProductProductCategoryID.SelectedValue);
        //    string brandGuid = this.DropDownListSRelatedProductBrandGuid.SelectedValue;

        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    DataView dataView = productAction.Search(productName, productCategoryID, brandGuid).DefaultView;
        //    foreach (DataRow dr in dataView.Table.Rows)
        //    {
        //        ListItem listItem = new ListItem();
        //        listItem.Text = dr["Name"].ToString().Trim();
        //        listItem.Value = dr["Guid"].ToString().Trim();

        //        this.ListBoxLeftRelatedProduct.Items.Add(listItem);
        //    }

        //}

        ////ȫ�����"�����Ʒ"
        //protected void ButtonAddAllRelatedProduct_Click(object sender, EventArgs e)
        //{
        //    foreach (ListItem listItem in this.ListBoxLeftRelatedProduct.Items)
        //    {
        //        if (CheckAddRelatedProduct(listItem.Value))
        //        {
        //            ListItem itemTemp = new ListItem();
        //            itemTemp.Text = listItem.Text + strLine + this.DropDownListRelatedProductIsBoth.SelectedItem.Text;
        //            itemTemp.Value = listItem.Value + ";" + this.DropDownListRelatedProductIsBoth.SelectedValue;

        //            this.ListBoxRightRelatedProduct.Items.Add(itemTemp);
        //        }
        //    }
        //}

        ////���ѡ��������Ʒ
        //protected void ButtonAddRelatedProduct_Click(object sender, EventArgs e)
        //{
        //    foreach (ListItem listItem in this.ListBoxLeftRelatedProduct.Items)
        //    {
        //        if (listItem.Selected && CheckAddRelatedProduct(listItem.Value))
        //        {
        //            ListItem itemTemp = new ListItem();
        //            itemTemp.Text = listItem.Text + strLine + this.DropDownListRelatedProductIsBoth.SelectedItem.Text;
        //            itemTemp.Value = listItem.Value + ";" + this.DropDownListRelatedProductIsBoth.SelectedValue;
        //            this.ListBoxRightRelatedProduct.Items.Add(itemTemp);
        //        }
        //    }
        //}

        ////����ұߵ��б����Ƿ�����������Ʒ
        //private bool CheckAddRelatedProduct(string guid)
        //{
        //    bool boolCheck = true;
        //    for (int i = 0; i < this.ListBoxRightRelatedProduct.Items.Count; i++)
        //    {
        //        string[] strList = this.ListBoxRightRelatedProduct.Items[i].Value.Trim().Split(';');
        //        //strList[0]Ϊguid
        //        if (strList[0] == guid.Trim())
        //        {
        //            boolCheck = false;
        //            break;
        //        }
        //    }
        //    return boolCheck;
        //}

        ////�Ƴ�ѡ��ġ������Ʒ��
        //protected void ButtonDeleteRelatedProduct_Click(object sender, EventArgs e)
        //{
        //    int count = this.ListBoxRightRelatedProduct.Items.Count;
        //    if (count != -1)
        //    {
        //        for (int i = this.ListBoxRightRelatedProduct.Items.Count - 1; i >= 0; i--)
        //        {
        //            if (this.ListBoxRightRelatedProduct.Items[i].Selected)
        //            {
        //                this.ListBoxRightRelatedProduct.Items.Remove(ListBoxRightRelatedProduct.Items[i]);
        //            }
        //        }
        //    }
        //}

        ////�Ƴ����еġ������Ʒ��
        //protected void ButtonDeleteAllRelatedProduct_Click(object sender, EventArgs e)
        //{
        //    int count = this.ListBoxRightRelatedProduct.Items.Count;
        //    if (count != -1)
        //    {
        //        for (int i = this.ListBoxRightRelatedProduct.Items.Count - 1; i >= 0; i--)
        //        {
        //            this.ListBoxRightRelatedProduct.Items.Remove(ListBoxRightRelatedProduct.Items[i]);
        //        }
        //    }
        //}

        //protected void ButtonSearchProductArticle_Click(object sender, EventArgs e)
        //{
        //    //�󶨲�ѯ����Ѷ
        //    BindListBoxLeftProductArticle();
        //}

        ////�󶨲�ѯ����Ѷ
        //protected void BindListBoxLeftProductArticle()
        //{
        //    //������б�
        //    this.ListBoxLeftProductArticle.Items.Clear();

        //    string title = this.TextBoxSProductArticleName.Text.Trim();
        //    int articleCagegoryID = Convert.ToInt32(this.DropDownListSArticleCategory.SelectedValue);

        //    ShopNum1_Article_Action articleAction = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
        //    DataView dataView = articleAction.Search(title, articleCagegoryID).DefaultView;
        //    foreach (DataRow dr in dataView.Table.Rows)
        //    {
        //        ListItem listItem = new ListItem();
        //        listItem.Text = dr["Title"].ToString().Trim();
        //        listItem.Value = dr["Guid"].ToString().Trim();

        //        this.ListBoxLeftProductArticle.Items.Add(listItem);
        //    }

        //}

        ////������е���Ѷ���ұ��б�
        //protected void ButtonAddAllProductArticle_Click(object sender, EventArgs e)
        //{
        //    foreach (ListItem listItem in this.ListBoxLeftProductArticle.Items)
        //    {
        //        if (CheckAddProductArticle(listItem.Value))
        //        {
        //            this.ListBoxRightProductArticle.Items.Add(listItem);
        //        }
        //    }
        //}
        ////���ѡ�ֵĵ��ұ��б�
        //protected void ButtonAddProductArticle_Click(object sender, EventArgs e)
        //{
        //    foreach (ListItem listItem in this.ListBoxLeftProductArticle.Items)
        //    {
        //        if (listItem.Selected && CheckAddProductArticle(listItem.Value))
        //        {
        //            this.ListBoxRightProductArticle.Items.Add(listItem);
        //        }
        //    }
        //}
        ////ɾ��ѡ����ұ��б��е���Ѷ
        //protected void ButtonDeleteProductArticle_Click(object sender, EventArgs e)
        //{
        //    int count = this.ListBoxRightProductArticle.Items.Count;
        //    if (count != -1)
        //    {
        //        for (int i = this.ListBoxRightProductArticle.Items.Count - 1; i >= 0; i--)
        //        {
        //            if (this.ListBoxRightProductArticle.Items[i].Selected)
        //            {
        //                this.ListBoxRightProductArticle.Items.Remove(ListBoxRightProductArticle.Items[i]);
        //            }
        //        }
        //    }
        //}
        ////ɾ�������ұ��б��е���Ѷ
        //protected void ButtonDeleteAllProductArticle_Click(object sender, EventArgs e)
        //{
        //    int count = this.ListBoxRightProductArticle.Items.Count;
        //    if (count != -1)
        //    {
        //        for (int i = this.ListBoxRightProductArticle.Items.Count - 1; i >= 0; i--)
        //        {
        //            this.ListBoxRightProductArticle.Items.Remove(ListBoxRightProductArticle.Items[i]);
        //        }
        //    }
        //}

        ////����ұߵ��б����Ƿ��������Ѷ
        //private bool CheckAddProductArticle(string guid)
        //{
        //    bool boolCheck = true;
        //    for (int i = 0; i < this.ListBoxRightProductArticle.Items.Count; i++)
        //    {
        //        if (this.ListBoxRightProductArticle.Items[i].Value.Trim() == guid.Trim())
        //        {
        //            boolCheck = false;
        //            break;
        //        }
        //    }
        //    return boolCheck;
        //}

        ////������б��е�������չ������ӵ��ұ��б�
        //protected void ButtonAddAllProductExtendCagegory_Click(object sender, EventArgs e)
        //{
        //    foreach (ListItem listItem in this.ListBoxLeftProductExtendCategory.Items)
        //    {
        //        if (CheckAddProductExtendCategory(listItem.Value))
        //        {
        //            this.ListBoxRightProductExtendCategory.Items.Add(listItem);
        //        }
        //    }
        //}
        ////������б���ѡ�ֵ���չ������ӵ��ұ��б�
        //protected void ButtonAddProductExtendCagegory_Click(object sender, EventArgs e)
        //{
        //    foreach (ListItem listItem in this.ListBoxLeftProductExtendCategory.Items)
        //    {
        //        if (listItem.Selected && CheckAddProductExtendCategory(listItem.Value))
        //        {
        //            this.ListBoxRightProductExtendCategory.Items.Add(listItem);
        //        }
        //    }
        //}
        ////���ұ��б���ѡ�ֵ���չ�����Ƴ�
        //protected void ButtonDeleteProductExtendCagegory_Click(object sender, EventArgs e)
        //{
        //    int count = this.ListBoxRightProductExtendCategory.Items.Count;
        //    if (count != -1)
        //    {
        //        for (int i = this.ListBoxRightProductExtendCategory.Items.Count - 1; i >= 0; i--)
        //        {
        //            if (this.ListBoxRightProductExtendCategory.Items[i].Selected)
        //            {
        //                this.ListBoxRightProductExtendCategory.Items.Remove(ListBoxRightProductExtendCategory.Items[i]);
        //            }
        //        }
        //    }
        //}
        ////�Ƴ������ұ��б��е���չ����
        //protected void ButtoDeleteAllProductExtendCagegory_Click(object sender, EventArgs e)
        //{
        //    int count = this.ListBoxRightProductExtendCategory.Items.Count;
        //    if (count != -1)
        //    {
        //        for (int i = this.ListBoxRightProductExtendCategory.Items.Count - 1; i >= 0; i--)
        //        {
        //            this.ListBoxRightProductExtendCategory.Items.Remove(ListBoxRightProductExtendCategory.Items[i]);
        //        }
        //    }
        //}

        ////����ұߵ��б����Ƿ�����˸���չ����
        //private bool CheckAddProductExtendCategory(string guid)
        //{
        //    bool boolCheck = true;
        //    for (int i = 0; i < this.ListBoxRightProductExtendCategory.Items.Count; i++)
        //    {
        //        if (this.ListBoxRightProductExtendCategory.Items[i].Value.Trim() == guid.Trim())
        //        {
        //            boolCheck = false;
        //            break;
        //        }
        //    }
        //    return boolCheck;
        //}

        //protected void Num1GridViewPrice_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowIndex > -1)
        //    {
        //        TextBox textBox = new TextBox();
        //        textBox.ID = "textBox" + e.Row.RowIndex.ToString();
        //        textBox.Text = "-1";
        //        e.Row.Cells[2].Controls.Add(textBox);
        //    }
        //}

        //protected void Num1GridViewAgentPrice_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowIndex > -1)
        //    {
        //        TextBox textBox = new TextBox();
        //        textBox.ID = "textBox" + e.Row.RowIndex.ToString();
        //        textBox.Text = "-1";
        //        e.Row.Cells[2].Controls.Add(textBox);
        //    }
        //}

        //protected void ButtonConfirm_Click(object sender, EventArgs e)
        //{
        //    if (hiddenFieldGuid.Value == "0")
        //    {
        //        #region �����Ʒ

        //        #region ��Ʒ��"ShopNum1_Product"
        //        ShopNum1_Product product = new ShopNum1_Product();
        //        product.Guid = Guid.NewGuid();
        //        product.Name = this.TextBoxName.Text;   //��Ʒ����
        //        product.OriginalImge = this.TextBoxOriginalImge.Text;  //�õĶ���ԭͼ
        //        product.ThumbImage = "";        //��ʱ���
        //        product.SmallImage = "";          //��ʱ���    
        //        product.RepertoryNumber = this.TextBoxRepertoryNumber.Text;  //�����(����)
        //        product.Weight = Convert.ToDecimal(this.TextBoxWeight.Text);    //��Ʒ����
        //        product.RepertoryCount = Convert.ToInt32(this.TextBoxRepertoryCount.Text);  //�����
        //        product.UnitName = this.TextBoxUnitName.Text;
        //        product.RepertoryAlertCount = Convert.ToInt32(this.TextBoxNameRepertoryAlertCount.Text); //��澯������
        //        product.PresentScore = Convert.ToInt32(this.TextBoxPresentScore.Text); //�������Ѻ��
        //        product.PresentRankScore = Convert.ToInt32(this.TextBoxPresentRankScore.Text); //���͵ȼ����
        //        product.SocreIntegral = Convert.ToInt32(this.TextBoxSocreIntegral.Text); //���������
        //        product.LimitBuyCount = Convert.ToInt32(this.TextBoxLimitBuyCount.Text); //ÿ�˴����ƹ�������
        //        product.CostPrice = Convert.ToDecimal(this.TextBoxCostPrice.Text); //�ɱ���
        //        product.MarketPrice = Convert.ToDecimal(this.TextBoxMarketPrice.Text); //�г���
        //        product.ShopPrice = Convert.ToDecimal(this.TextBoxShopPrice.Text); //�����ۼ�
        //        product.Brief = this.TextBoxBrief.Text; //��Ʒ�򵥽���
        //        product.Memo = this.TextBoxMemo.Text; //�̼ұ�ע
        //        product.Detail = this.Server.HtmlEncode(this.FCKeditorDetail.Value.Replace("'", ""));  //��Ʒ��ϸ
        //        product.ClickCount = 0;  //�������(�����)
        //        product.CollectCount = 0;  //���ղش���
        //        product.BuyCount = 0;   //���������
        //        product.CommentCount = 0;  //��Ʒ������
        //        product.ReferCount = 0;   //��Ʒ��Ѷ��
        //        product.IsSaled = Convert.ToInt32(this.DropDownListIsSaled.SelectedValue); //�Ƿ��ϼ�

        //        if (CheckUnionType() == "0")
        //        {
        //            product.PushMoney = decimal.Parse(TextBoxPushMoney.Text);
        //        }
        //        else
        //        {
        //            product.PushMoney = 0;
        //        }

        //        if (DropDownListProducLine.SelectedValue != "-1")
        //        {
        //            product.ProductLineGuid = DropDownListProducLine.SelectedValue;
        //        }

        //        //�Ƿ��Ǿ�Ʒ
        //        if (this.CheckBoxIsBest.Checked)
        //        {
        //            product.IsBest = 1;
        //        }
        //        else
        //        {
        //            product.IsBest = 0;
        //        }
        //        //�Ƿ�����Ʒ
        //        if (this.CheckBoxIsNew.Checked)
        //        {
        //            product.IsNew = 1;
        //        }
        //        else
        //        {
        //            product.IsNew = 0;
        //        }
        //        //�Ƿ�����
        //        if (this.CheckBoxIsHot.Checked)
        //        {
        //            product.IsHot = 1;
        //        }
        //        else
        //        {
        //            product.IsHot = 0;
        //        }
        //        //�Ƿ��Ƽ�
        //        if (this.CheckBoxIsRecommend.Checked)
        //        {
        //            product.IsRecommend = 1;
        //        }
        //        else
        //        {
        //            product.IsRecommend = 0;
        //        }
        //        product.IsReal = Convert.ToInt32(this.DropDownListIsReal.SelectedValue);  //�Ƿ���ʵ��
        //        product.IsOnlySaled = Convert.ToInt32(this.DropDownListIsOnlySaled.SelectedValue); //�Ƿ��ܵ�������(���۷�ʽ)
        //        product.Title = this.TextBoxTitle.Text;  //��ϸҳ����
        //        product.Description = this.TextBoxDescription.Text;  //��ϸҳ����
        //        product.Keywords = this.TextBoxKeywords.Text;  //��ϸҳ�����ؼ���
        //        product.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text);  //��Ʒ����
        //        if (this.DropDownListBrandGuid.SelectedValue != "-1")
        //        {
        //            product.BrandGuid = new Guid(this.DropDownListBrandGuid.SelectedValue); //��ƷƷ��
        //            product.BrandName = this.DropDownListBrandGuid.SelectedItem.Text; //Ʒ������
        //        }
        //        else
        //        {
        //            product.BrandGuid = Guid.Empty;
        //            product.BrandName = "";
        //        }

        //        //product.ProductCategoryID = Convert.ToInt32(this.DropDownListProductCategoryID.SelectedValue); //��Ʒ����
        //        product.ProductCategoryID = Convert.ToInt32(returnProductCategoryID()); //��Ʒ����
        //        product.ProductTypeGuid = new Guid(this.DropDownListProductTypeGuid.SelectedValue); //��Ʒ����
        //        product.CreateUser = "admin"; //�����
        //        product.CreateTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); //���ʱ��
        //        product.ModifyUser = "admin"; //����޸���
        //        product.ModifyTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); //����޸�ʱ��
        //        product.IsDeleted = 0; //�Ƿ�ɾ��

        //        product.SupplierGuid = new Guid(this.DropDownListSupplierGuid.SelectedValue); //��Ӧ��
        //        product.IsSupplierProduct = 1;
        //        product.SupplierLoginID = GetSupplierLoginID(this.DropDownListSupplierGuid.SelectedValue);

        //        #endregion

        //        #region  �����Ա�

        //        if (CheckBoxTb.Checked)
        //        {
        //            Dictionary<string, string> param = new Dictionary<string, string>();//���� APIӦ�ü��������

        //            //ϵͳҶ����Ŀcid
        //            if (ViewState["cid"] == null)
        //            {
        //                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "msg", "alert(\"��ûѡ�����\")", true);
        //                return;
        //            }

        //            //ϵͳҶ����Ŀcid
        //            string cid = string.Empty;
        //            cid = ViewState["cid"].ToString();

        //            ///�����Զ�����Ŀ����
        //            StringBuilder seller_cids = new StringBuilder();
        //            foreach (TreeNode td in TreeViewTb.CheckedNodes)
        //            {
        //                if (td.ChildNodes.Count != 0)
        //                {
        //                    foreach (TreeNode tdson in td.ChildNodes)
        //                    {
        //                        seller_cids.Append(tdson.Value + ",");
        //                    }
        //                }
        //                else
        //                {
        //                    seller_cids.Append(td.Value + ",");
        //                }
        //            }

        //            ///�¾ɳ̶�
        //            string stuff_status = string.Empty;
        //            if (radNew.Checked)
        //            {
        //                stuff_status = "new";
        //            }
        //            else if (radOld.Checked)
        //            {
        //                stuff_status = "unused";
        //            }
        //            else
        //            {
        //                stuff_status = "second";
        //            }

        //            ///��������
        //            string title = txtTitle.Text.Trim();

        //            //��������
        //            string num = txtCount.Text.Trim();

        //            ///ʡ��
        //            string province = ddlProvince.SelectedItem.Text.Trim();
        //            province = province.Replace("ʡ", "").TrimEnd().Replace("׳��������", "").TrimEnd().Replace("������", "").TrimEnd().Replace("����������", "").TrimEnd().Replace("ά���������", "").TrimEnd().Replace("�ر�������", "").TrimEnd();

        //            ///����
        //            string city = ddlCity.SelectedItem.Text.Trim();
        //            city = city.Replace("��", "").TrimEnd().Replace("����", "").TrimEnd().Replace("������", "").TrimEnd().Replace("����", "").TrimEnd().Replace("�ɹ���", "").TrimEnd().Replace("��", "").TrimEnd();

        //            ///�˷ѳе���
        //            string freight_payer = radSeller.Checked ? "seller" : "buyer";
        //            if (radFreight1.Checked && radBuyer.Checked)
        //            {
        //                freight_payer = "seller";
        //            }
        //            else if (radFreight2.Checked && radBuyer.Checked)
        //            {
        //                ///�Զ��������ʷ�
        //                param.Add("post_fee", txtSurfaceMail.Text.Trim());
        //                param.Add("express_fee", txtExpress.Text.Trim());
        //                param.Add("ems_fee", txtEms.Text.Trim());
        //            }

        //            ///��Чʱ��
        //            decimal valid_thru = radSeven.Checked == true ? 7 : 14;

        //            //�Ƿ��з�Ʊ
        //            string has_invoice = radInvoiceYes.Checked == true ? "true" : "false";

        //            ///�Ƿ��б�
        //            string has_warranty = radServiceNo.Checked == true ? "true" : "false";

        //            //�Ƿ����
        //            string has_discount = radDicCountYes.Checked == true ? "true" : "false";

        //            ///�̻�����
        //            string outer_id = txtNumCode.Text.Trim();

        //            ///һ�ڼ�
        //            string price = txtOnePrice.Text.Trim();

        //            //�������
        //            string auction_point = txtRate.Text.Trim();

        //            ///�ϼ�״̬
        //            string approve_status = radPut.Checked == true ? "onsale" : "instock";

        //            //�Ƿ�����Ƽ�
        //            string has_showcase = cboxYes.Checked == true ? "true" : "false";

        //            string strXml = string.Empty;

        //            param.Add("num", num);
        //            // param.Add("pic_path", ImageOriginalImge.Src);
        //            param.Add("price", price);
        //            param.Add("type", "fixed");
        //            param.Add("stuff_status", stuff_status);
        //            param.Add("props", GetAddProps());
        //            param.Add("title", title);
        //           // string desc = this.FCKeditorDetail.Value;  //��Ʒ��ϸ
        //           // desc = desc == "" ? "����ע" + title : desc;
        //            string desc = this.TextBoxDescription.Text;
        //            param.Add("desc", desc);
        //            param.Add("location.state", province);
        //            param.Add("location.city", city);
        //            param.Add("approve_status", approve_status);
        //            param.Add("cid", cid);
        //            param.Add("freight_payer", freight_payer);
        //            param.Add("valid_thru", valid_thru.ToString());
        //            param.Add("has_invoice", has_warranty);
        //            param.Add("has_discount", has_discount);
        //            //  �Ƿ���
        //            param.Add("has_warranty", has_warranty);

        //            //�Ƿ�����Ƽ�
        //            param.Add("has_showcase", has_showcase);

        //            //�̼��Զ������ 
        //            param.Add("seller_cids", seller_cids.ToString());

        //            // �̼ұ���
        //            param.Add("outer_id", outer_id);
        //            ///�̼�
        //            param.Add("auction_point", auction_point);

        //            //StringBuilder Sku_Properties = new StringBuilder(",");
        //            //StringBuilder Sku_Quantities = new StringBuilder(",");
        //            //StringBuilder Sku_Prices = new StringBuilder(",");
        //            //StringBuilder Sku_Outer_Ids = new StringBuilder(",");
        //            //if (dt != null)
        //            //{

        //            //    Sku_Properties.Append(dt.Rows[0]["properties"]);
        //            //    Sku_Quantities.Append(dt.Rows[0]["quantity"]);
        //            //    Sku_Prices.Append(dt.Rows[0]["price"]);
        //            //    Sku_Outer_Ids.Append(dt.Rows[0]["outer_id"]);

        //            //}
        //            strXml = TopAPI.Post("taobao.item.add", TopClient.AdminSession, param);

        //            ErrorRsp err = new ErrorRsp();
        //            ItemResponse itemRsp = new ItemResponse();
        //            new Parser().XmlToObject2(strXml, "item_add", "item", itemRsp, err);
        //            if (err.IsError)//�ж��Ƿ���¹����з�������
        //            {
        //                //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //                if (err.code == "530")
        //                {
        //                    ShopNum1.Common.MessageBox.Show("ͬ���Ա�����Ʒ������������!");
        //                    return;
        //                }
        //                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"�����Ʒʧ�ܣ�������룺{0}\\r����ԭ��{1}\\r����������{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
        //            }
        //            else
        //            {
        //                ///����ͼƬ�ϴ�
        //                if (TextBoxOriginalImge.Text.Trim() != "")
        //                {
        //                    param.Clear();
        //                    param.Add("num_iid", itemRsp.num_iid);
        //                    param.Add("position", "1");
        //                    param.Add("is_major", "true");
        //                    string picImgUrl = Server.MapPath(TextBoxOriginalImge.Text.Trim());
        //                    if (File.Exists(picImgUrl))
        //                    {
        //                        Dictionary<string, FileItem> fileParam = new Dictionary<string, FileItem>();
        //                        fileParam.Add("image", new FileItem(new System.IO.FileInfo(picImgUrl)));
        //                        strXml = TopAPI.Post("taobao.item.img.upload", TopClient.AdminSession, param, fileParam);
        //                        ItemImgResponse itemimg = new ItemImgResponse();
        //                        new Parser().XmlToObject2(strXml, "item_img_upload", itemimg, err);
        //                        if (err.IsError)
        //                        {
        //                            //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"�Ա��ϴ�ͼƬ��ʱ����ִ��󣡴�����룺{0}\\r����ԭ��{1}\\r����������{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
        //                        }
        //                    }

        //                }
        //                ShopNum1_ProductCategory_Action productCategoryAction = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
        //                string siteCid = product.Guid.ToString();
        //                string num_iid = itemRsp.num_iid;
        //                ShopNum1_TbItem_Action tbItemOperate = (ShopNum1_TbItem_Action)LogicTbFactory.CreateShopNum1_TbItem_Action();
        //                tbItemOperate.InsertItemSimplify(decimal.Parse(num_iid), siteCid, decimal.Parse(cid), false);
        //            }
        //        }

        //        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "err", "alert('��ӳɹ�')", true);
        //        //ClientScript.RegisterClientScriptBlock(typeof(Page), "err", "alert('��ӳɹ�')", true);
        //        #endregion

        //        #region ��Ʒ��Ա�ȼ��۸��"ShopNum1_ProductMemberRankPrice"
        //        List<ShopNum1_ProductMemberRankPrice> productMemberRankPrice = new List<ShopNum1_ProductMemberRankPrice>();

        //        if (this.Num1GridViewPrice.Rows.Count > 0)
        //        {
        //            for (int i = 0; i <= this.Num1GridViewPrice.Rows.Count - 1; i++)
        //            {
        //                if (((TextBox)this.Num1GridViewPrice.Rows[i].Cells[2].Controls[0]).Text != "-1" && !string.IsNullOrEmpty(((TextBox)this.Num1GridViewPrice.Rows[i].Cells[2].Controls[0]).Text))
        //                {
        //                    ShopNum1_ProductMemberRankPrice tempProductMemberRankPrice = new ShopNum1_ProductMemberRankPrice();
        //                    tempProductMemberRankPrice.Guid = Guid.NewGuid();
        //                    //tempProductMemberRankPrice.ProductGuid = product.Guid;   //��Ʒ��Guid
        //                    //�ȼ��۸�
        //                    tempProductMemberRankPrice.Price = Convert.ToDecimal(((TextBox)this.Num1GridViewPrice.Rows[i].Cells[2].Controls[0]).Text);
        //                    //��Ա�ȼ�Guid
        //                    tempProductMemberRankPrice.MemberRankGuid = new Guid(this.Num1GridViewPrice.Rows[i].Cells[0].Text);

        //                    //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //                    //tempProductMemberRankPrice.CreateUser = product.CreateUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //                    //tempProductMemberRankPrice.CreateTime = product.CreateTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                    //tempProductMemberRankPrice.ModifyUser = product.ModifyUser; //����޸���,��Ϊ����Ʒ��һ������������Ʒ��
        //                    //tempProductMemberRankPrice.ModifyTime = product.ModifyTime; //����޸�ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                    productMemberRankPrice.Add(tempProductMemberRankPrice);
        //                }
        //            }
        //        }
        //        #endregion

        //        #region ��Ʒ�������Ա�"ShopNum1_ProductAttributeValue"

        //        List<ShopNum1_ProductAttributeValue> productAttributeValue = new List<ShopNum1_ProductAttributeValue>();
        //        //// �޼۸������
        //        //if (this.Num1GridViewProductyAttributeShow.Rows.Count > 0)
        //        //{
        //        //    #region �޼۸������
        //        //    for (int i = 0; i <= this.Num1GridViewProductyAttributeShow.Rows.Count - 1; i++)
        //        //    {
        //        //        ShopNum1_ProductAttributeValue tempProductAttributeValue = new ShopNum1_ProductAttributeValue();
        //        //        tempProductAttributeValue.Guid = Guid.NewGuid();
        //        //        //��Ʒ����Guid
        //        //        tempProductAttributeValue.ProductTypeGuid = new Guid(this.DropDownListProductTypeGuid.SelectedValue);
        //        //        //��Ʒ����Guid
        //        //        tempProductAttributeValue.ProductAttributeGuid = new Guid(this.Num1GridViewProductyAttributeShow.Rows[i].Cells[0].Text);

        //        //        //this.Response.Write(tempProductAttributeValue.AtrributeValue);
        //        //        //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //        //        //tempProductAttributeValue.ProductGuid = product.Guid;
        //        //        //tempProductAttributeValue.CreateUser = product.CreateUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //        //        //tempProductAttributeValue.CreateTime = product.CreateTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //        //        //tempProductAttributeValue.ModifyUser = product.ModifyUser; //����޸���,��Ϊ����Ʒ��һ������������Ʒ��
        //        //        //tempProductAttributeValue.ModifyTime = product.ModifyTime; //����޸�ʱ��,��Ϊ����Ʒ��һ������������Ʒ��

        //        //        if (this.Num1GridViewProductyAttributeShow.Rows[i].Cells[3].Text == "0" || this.Num1GridViewProductyAttributeShow.Rows[i].Cells[3].Text == "2")
        //        //        {
        //        //            //�ֹ�����(����)���ֹ�����(����)
        //        //            //����ֵ
        //        //            tempProductAttributeValue.AtrributeValue = ((TextBox)this.Num1GridViewProductyAttributeShow.Rows[i].Cells[2].Controls[0]).Text;
        //        //        }
        //        //        else if (this.Num1GridViewProductyAttributeShow.Rows[i].Cells[3].Text == "1")
        //        //        {
        //        //            //ѡ������
        //        //            //����ֵ
        //        //            tempProductAttributeValue.AtrributeValue = ((DropDownList)this.Num1GridViewProductyAttributeShow.Rows[i].Cells[2].Controls[0]).SelectedItem.Text;
        //        //        }
        //        //        //���Լ۸�(�����Լ۸���Ϊ0����Ϊ�����Լ۸�)
        //        //        tempProductAttributeValue.AttributePrice = 0;

        //        //        productAttributeValue.Add(tempProductAttributeValue);
        //        //    }
        //        //    #endregion
        //        //}

        //        //�м۸������
        //        if (this.Num1GridViewProductyAttributePrice.Rows.Count > 0)
        //        {
        //            #region �м۸�����
        //            for (int i = 0; i <= this.Num1GridViewProductyAttributePrice.Rows.Count - 1; i++)
        //            {
        //                ShopNum1_ProductAttributeValue tempProductAttributeValue = new ShopNum1_ProductAttributeValue();
        //                tempProductAttributeValue.Guid = Guid.NewGuid();
        //                //��Ʒ����Guid
        //                tempProductAttributeValue.ProductTypeGuid = new Guid(this.DropDownListProductTypeGuid.SelectedValue);
        //                //��Ʒ����Guid

        //                tempProductAttributeValue.ProductAttributeGuid = new Guid(this.Num1GridViewProductyAttributePrice.Rows[i].Cells[0].Text);

        //                //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //                //tempProductAttributeValue.ProductGuid = product.Guid;
        //                //tempProductAttributeValue.CreateUser = product.CreateUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //                //tempProductAttributeValue.CreateTime = product.CreateTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                //tempProductAttributeValue.ModifyUser = product.ModifyUser; //����޸���,��Ϊ����Ʒ��һ������������Ʒ��
        //                //tempProductAttributeValue.ModifyTime = product.ModifyTime; //����޸�ʱ��,��Ϊ����Ʒ��һ������������Ʒ��

        //                //����ֵ
        //                tempProductAttributeValue.AtrributeValue = this.Num1GridViewProductyAttributePrice.Rows[i].Cells[2].Text;

        //                //���Լ۸�
        //                tempProductAttributeValue.AttributePrice = Convert.ToDecimal(this.Num1GridViewProductyAttributePrice.Rows[i].Cells[3].Text);

        //                productAttributeValue.Add(tempProductAttributeValue);
        //            }
        //            #endregion
        //        }
        //        #endregion

        //        #region ��Ʒ��ͼ"ShopNum1_ProductImage"
        //        List<ShopNum1_ProductImage> productImage = new List<ShopNum1_ProductImage>();

        //        //if (this.DataListPorductImage.Items.Count > 0)
        //        //{
        //        //    for (int i = 0; i < this.DataListPorductImage.Items.Count; i++)
        //        //    {
        //        //        ShopNum1_ProductImage tempProductImage = new ShopNum1_ProductImage();
        //        //        tempProductImage.Guid = Guid.NewGuid();
        //        //        //ͼƬ��ַ
        //        //        string strOriginallImage = ((Image)this.DataListPorductImage.Items[i].FindControl("loadImg")).ImageUrl;
        //        //        tempProductImage.OriginalImge = strOriginallImage.Substring(strOriginallImage.LastIndexOf("/") + 1);
        //        //        tempProductImage.ThumbImage = "";    //��ʱ���
        //        //        tempProductImage.SmallImage = "";      //��ʱ���
        //        //        tempProductImage.IsDeleted = 0;

        //        //        productImage.Add(tempProductImage);

        //        //    }
        //        //}


        //        if (this.DataListPorductImage.Items.Count > 0)
        //        {
        //            DataTable tempDataTalbe = (DataTable)ViewState["dataMultiImage"];
        //            for (int i = 0; i < tempDataTalbe.Rows.Count; i++)
        //            {
        //                ShopNum1_ProductImage tempProductImage = new ShopNum1_ProductImage();
        //                tempProductImage.Guid = Guid.NewGuid();
        //                //ͼƬ��ַ
        //                string strOriginallImage = tempDataTalbe.Rows[i]["OriginalImge"].ToString();
        //                tempProductImage.OriginalImge = strOriginallImage.Substring(strOriginallImage.LastIndexOf("/") + 1);
        //                tempProductImage.ThumbImage = "";    //��ʱ���
        //                tempProductImage.SmallImage = "";      //��ʱ���
        //                tempProductImage.IsDeleted = 0;
        //                tempProductImage.CreateTime = Convert.ToDateTime(tempDataTalbe.Rows[i]["CreateTime"].ToString());
        //                productImage.Add(tempProductImage);

        //            }
        //        }
        //        #endregion

        //        #region ��Ʒ���"ShopNum1_ProductAccessory"
        //        List<ShopNum1_ProductAccessory> productAccessory = new List<ShopNum1_ProductAccessory>();
        //        if (this.ListBoxRightProductAccessory.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightProductAccessory.Items.Count; i++)
        //            {
        //                ShopNum1_ProductAccessory tempProductAccessory = new ShopNum1_ProductAccessory();
        //                //��ΪListBoxRightProductAccessory��Valueֵ��"Guid"+";"+"�۸�"
        //                //���Բ�ֺ�ȡ�۸�
        //                string[] strTempArry = this.ListBoxRightProductAccessory.Items[i].Value.Split(';');
        //                tempProductAccessory.AccessoryProductGuid = new Guid(strTempArry[0]);
        //                tempProductAccessory.Price = Convert.ToDecimal(strTempArry[1]);

        //                //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //                //tempProductAccessory.ProductGuid = product.Guid;  //�õ�����Ʒ��Guid
        //                //tempProductAccessory.CreateUser = product.CreateUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //                //tempProductAccessory.CreateTime = product.CreateTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                productAccessory.Add(tempProductAccessory);
        //            }
        //        }
        //        #endregion

        //        #region �����Ʒ"ShopNum1_RelatedProduct"
        //        List<ShopNum1_RelatedProduct> relatedProduct = new List<ShopNum1_RelatedProduct>();

        //        if (this.ListBoxRightRelatedProduct.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightRelatedProduct.Items.Count; i++)
        //            {
        //                ShopNum1_RelatedProduct tempRelatedProduct = new ShopNum1_RelatedProduct();
        //                //��ΪListBoxRightProductAccessory��Valueֵ��"Guid"+";"+"IsBoth"
        //                //���Բ�ֺ�ȡ�۸�
        //                string[] strTempArry = this.ListBoxRightRelatedProduct.Items[i].Value.Split(';');
        //                tempRelatedProduct.SubProductGuid = new Guid(strTempArry[0]);
        //                tempRelatedProduct.IsBoth = Convert.ToInt32(strTempArry[1]);

        //                //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //                //tempRelatedProduct.ProductGuid = product.Guid;  //�õ�����Ʒ��Guid
        //                //tempRelatedProduct.CreateUser = product.CreateUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //                //tempRelatedProduct.CreateTime = product.CreateTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                relatedProduct.Add(tempRelatedProduct);
        //            }
        //        }
        //        #endregion

        //        #region �����Ѷ"ShopNum1_ProductArticle"
        //        List<ShopNum1_ProductArticle> productArticle = new List<ShopNum1_ProductArticle>();
        //        if (this.ListBoxRightProductArticle.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightProductArticle.Items.Count; i++)
        //            {
        //                ShopNum1_ProductArticle tempProductArticle = new ShopNum1_ProductArticle();
        //                tempProductArticle.ArticleGuid = new Guid(this.ListBoxRightProductArticle.Items[i].Value);
        //                //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //                //tempProductArticle.ProductGuid = product.Guid;  //�õ�����Ʒ��Guid
        //                //tempProductArticle.CreateUser = product.CreateUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //                //tempProductArticle.CreateTime = product.CreateTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                productArticle.Add(tempProductArticle);

        //            }
        //        }
        //        #endregion

        //        #region ��չ����"ShopNum1_ProdcutExtendType"
        //        List<ShopNum1_ProdcutExtendType> prodcutExtendType = new List<ShopNum1_ProdcutExtendType>();

        //        if (this.ListBoxRightProductExtendCategory.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightProductExtendCategory.Items.Count; i++)
        //            {
        //                ShopNum1_ProdcutExtendType tempProdcutExtendType = new ShopNum1_ProdcutExtendType();
        //                tempProdcutExtendType.ProductCategoryID = Convert.ToInt32(this.ListBoxRightProductExtendCategory.Items[i].Value);
        //                //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //                //prodcutExtendType.ProductGuid = product.Guid;  //�õ�����Ʒ��Guid
        //                //prodcutExtendType.CreateUser = product.CreateUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //                //prodcutExtendType.CreateTime = product.CreateTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                prodcutExtendType.Add(tempProdcutExtendType);

        //            }
        //        }
        //        #endregion

        //        ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //        int check = 0;
        //        check = productAction.Add(product,
        //                                                        productMemberRankPrice,
        //                                                        productAttributeValue,
        //                                                        productImage,
        //                                                        productAccessory,
        //                                                        relatedProduct,
        //                                                        productArticle,
        //                                                        prodcutExtendType);


        //        if (this.Num1GridViewAgentPrice.Rows.Count > 0)
        //        {
        //            for (int i = 0; i <= this.Num1GridViewAgentPrice.Rows.Count - 1; i++)
        //            {
        //                if (((TextBox)this.Num1GridViewAgentPrice.Rows[i].Cells[2].Controls[0]).Text != "-1" && !string.IsNullOrEmpty(((TextBox)this.Num1GridViewAgentPrice.Rows[i].Cells[2].Controls[0]).Text))
        //                {
        //                    ShopNum1_ProductMemberRankPrice tempProductMemberRankPrice = new ShopNum1_ProductMemberRankPrice();
        //                    tempProductMemberRankPrice.Guid = Guid.NewGuid();
        //                    tempProductMemberRankPrice.ProductGuid = product.Guid;   //��Ʒ��Guid
        //                    //�ȼ��۸�
        //                    tempProductMemberRankPrice.Price = Convert.ToDecimal(((TextBox)this.Num1GridViewAgentPrice.Rows[i].Cells[2].Controls[0]).Text);
        //                    //��Ա�ȼ�Guid
        //                    tempProductMemberRankPrice.MemberRankGuid = new Guid(this.Num1GridViewAgentPrice.Rows[i].Cells[0].Text);

        //                    //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //                    tempProductMemberRankPrice.CreateUser = product.CreateUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //                    tempProductMemberRankPrice.CreateTime = product.CreateTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                    tempProductMemberRankPrice.ModifyUser = product.ModifyUser; //����޸���,��Ϊ����Ʒ��һ������������Ʒ��
        //                    tempProductMemberRankPrice.ModifyTime = product.ModifyTime; //����޸�ʱ��,��Ϊ����Ʒ��һ������������Ʒ��

        //                    productAction.AddMemberRankPrice(tempProductMemberRankPrice);

        //                }
        //            }
        //        }

        //        if (check > 0)
        //        {
        //            #region  ������־����
        //            ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog();
        //            operateLog.Record = "����" + this.TextBoxName.Text.Trim() + "�ɹ�!";
        //            operateLog.OperatorID = this.ShopNum1LoginID;
        //            operateLog.IP = Globals.IPAddress;
        //            operateLog.PageName = "TbProduct_Operate.aspx";
        //            operateLog.Date = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //            int log = OperateLog(operateLog);
        //            #endregion

        //            if (DropDownListProducLine.SelectedValue != "-1")
        //            {
        //                ShopNum1_ProductLine_Action productLine_Action = (ShopNum1_ProductLine_Action)LogicFactory.CreateShopNum1_ProductLine_Action();
        //                DataTable dataTable = productLine_Action.GetEditInfo("'" + DropDownListProducLine.SelectedValue + "'");

        //                if (dataTable.Rows[0]["IsForcibly"].ToString() == "1")  //�ж��Ƿ���ǿ�ƴ����Ʒ��
        //                {
        //                    if (dataTable.Rows[0]["AgentID"].ToString() != "")  //�жϲ�Ʒ���Ƿ���Ȩ
        //                    {
        //                        string[] strAgentID = dataTable.Rows[0]["AgentID"].ToString().Split(',');

        //                        for (int i = 0; i < strAgentID.Length - 1; i++)
        //                        {
        //                            productLine_Action.AddAgentProductLineProduct(product.Guid.ToString(), product.ShopPrice.ToString(), strAgentID[i].ToString(), "1");
        //                        }
        //                    }
        //                }
        //            }

        //            //��ʾ������Ϣ
        //            this.MessageShowTb.ShowMessage("AddYes");
        //            this.MessageShowTb.Visible = true;


        //            //��ӳɹ�����տؼ�
        //            ClearControl();
        //        }
        //        else
        //        {
        //            //��ʾ������Ϣ
        //            this.MessageShowTb.ShowMessage("AddNo");
        //            this.MessageShowTb.Visible = true;
        //        }

        //        #endregion
        //    }
        //    else
        //    {
        //        #region �༭��Ʒ

        //        #region ��Ʒ��"ShopNum1_Product"
        //        ShopNum1_Product product = new ShopNum1_Product();
        //        product.Guid = new Guid(this.hiddenFieldGuid.Value.Replace("'", ""));
        //        product.Name = this.TextBoxName.Text;   //��Ʒ����
        //        product.OriginalImge = this.TextBoxOriginalImge.Text;  //�õĶ���ԭͼ
        //        product.ThumbImage = "";        //��ʱ���
        //        product.SmallImage = "";          //��ʱ���    
        //        product.RepertoryNumber = this.TextBoxRepertoryNumber.Text;  //�����(����)
        //        product.Weight = Convert.ToDecimal(this.TextBoxWeight.Text);    //��Ʒ����
        //        product.RepertoryCount = Convert.ToInt32(this.TextBoxRepertoryCount.Text);  //�����
        //        product.UnitName = this.TextBoxUnitName.Text;
        //        product.RepertoryAlertCount = Convert.ToInt32(this.TextBoxNameRepertoryAlertCount.Text); //��澯������
        //        product.PresentScore = Convert.ToInt32(this.TextBoxPresentScore.Text); //�������Ѻ��
        //        product.PresentRankScore = Convert.ToInt32(this.TextBoxPresentRankScore.Text); //���͵ȼ����
        //        product.SocreIntegral = Convert.ToInt32(this.TextBoxSocreIntegral.Text); //���������
        //        product.LimitBuyCount = Convert.ToInt32(this.TextBoxLimitBuyCount.Text); //ÿ�˴����ƹ�������
        //        product.CostPrice = Convert.ToDecimal(this.TextBoxCostPrice.Text); //�ɱ���
        //        product.MarketPrice = Convert.ToDecimal(this.TextBoxMarketPrice.Text); //�г���
        //        product.ShopPrice = Convert.ToDecimal(this.TextBoxShopPrice.Text); //�����ۼ�
        //        product.Brief = this.TextBoxBrief.Text; //��Ʒ�򵥽���
        //        product.Memo = this.TextBoxMemo.Text; //�̼ұ�ע
        //        product.Detail = this.Server.HtmlEncode(this.FCKeditorDetail.Value.Replace("'", ""));  //��Ʒ��ϸ
        //        //�༭��ʱ��������������ֶ�
        //        //product.ClickCount = 0;  //�������(�����)
        //        //product.CollectCount = 0;  //���ղش���
        //        //product.BuyCount = 0;   //���������
        //        //product.CommentCount = 0;  //��Ʒ������
        //        //product.ReferCount = 0;   //��Ʒ��Ѷ��
        //        product.IsSaled = Convert.ToInt32(this.DropDownListIsSaled.SelectedValue); //�Ƿ��ϼ�

        //        if (CheckUnionType() == "0")
        //        {
        //            product.PushMoney = decimal.Parse(TextBoxPushMoney.Text);
        //        }
        //        else
        //        {
        //            product.PushMoney = 0;
        //        }

        //        //�Ƿ��Ǿ�Ʒ
        //        if (this.CheckBoxIsBest.Checked)
        //        {
        //            product.IsBest = 1;
        //        }
        //        else
        //        {
        //            product.IsBest = 0;
        //        }
        //        //�Ƿ�����Ʒ
        //        if (this.CheckBoxIsNew.Checked)
        //        {
        //            product.IsNew = 1;
        //        }
        //        else
        //        {
        //            product.IsNew = 0;
        //        }
        //        //�Ƿ�����
        //        if (this.CheckBoxIsHot.Checked)
        //        {
        //            product.IsHot = 1;
        //        }
        //        else
        //        {
        //            product.IsHot = 0;
        //        }
        //        //�Ƿ��Ƽ�
        //        if (this.CheckBoxIsRecommend.Checked)
        //        {
        //            product.IsRecommend = 1;
        //        }
        //        else
        //        {
        //            product.IsRecommend = 0;
        //        }
        //        product.IsReal = Convert.ToInt32(this.DropDownListIsReal.SelectedValue);  //�Ƿ���ʵ��
        //        product.IsOnlySaled = Convert.ToInt32(this.DropDownListIsOnlySaled.SelectedValue); //�Ƿ��ܵ�������(���۷�ʽ)
        //        product.Title = this.TextBoxTitle.Text;  //��ϸҳ����
        //        product.Description = this.TextBoxDescription.Text;  //��ϸҳ����
        //        product.Keywords = this.TextBoxKeywords.Text;  //��ϸҳ�����ؼ���
        //        product.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text);  //��Ʒ����
        //        product.SupplierGuid = new Guid(this.DropDownListSupplierGuid.SelectedValue); //��Ӧ��
        //        if (this.DropDownListBrandGuid.SelectedValue != "-1")
        //        {
        //            product.BrandGuid = new Guid(this.DropDownListBrandGuid.SelectedValue); //��ƷƷ��
        //            product.BrandName = this.DropDownListBrandGuid.SelectedItem.Text; //Ʒ������
        //        }
        //        else
        //        {
        //            product.BrandGuid = Guid.Empty;
        //            product.BrandName = "";
        //        }
        //        product.BrandName = this.DropDownListBrandGuid.SelectedItem.Text; //Ʒ������
        //        //product.ProductCategoryID = Convert.ToInt32(this.DropDownListProductCategoryID.SelectedValue); //��Ʒ����
        //        product.ProductCategoryID = Convert.ToInt32(returnProductCategoryID()); //��Ʒ����

        //        product.ProductTypeGuid = new Guid(this.DropDownListProductTypeGuid.SelectedValue); //��Ʒ����
        //        //product.CreateUser = "admin"; //�����
        //        //product.CreateTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); //���ʱ��
        //        product.ModifyUser = "admin"; //����޸���
        //        product.ModifyTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); //����޸�ʱ��
        //        product.IsDeleted = 0; //�Ƿ�ɾ��

        //        if (DropDownListProducLine.SelectedValue != "-1")
        //        {
        //            product.ProductLineGuid = DropDownListProducLine.SelectedValue;
        //        }
        //        #endregion

        //        #region ��Ʒ��Ա�ȼ��۸��"ShopNum1_ProductMemberRankPrice"
        //        List<ShopNum1_ProductMemberRankPrice> productMemberRankPrice = new List<ShopNum1_ProductMemberRankPrice>();

        //        if (this.Num1GridViewPrice.Rows.Count > 0)
        //        {
        //            for (int i = 0; i <= this.Num1GridViewPrice.Rows.Count - 1; i++)
        //            {
        //                if (((TextBox)this.Num1GridViewPrice.Rows[i].Cells[2].Controls[0]).Text != "-1" && !string.IsNullOrEmpty(((TextBox)this.Num1GridViewPrice.Rows[i].Cells[2].Controls[0]).Text))
        //                {
        //                    ShopNum1_ProductMemberRankPrice tempProductMemberRankPrice = new ShopNum1_ProductMemberRankPrice();
        //                    tempProductMemberRankPrice.Guid = Guid.NewGuid();
        //                    //tempProductMemberRankPrice.ProductGuid = product.Guid;   //��Ʒ��Guid
        //                    //�ȼ��۸�
        //                    tempProductMemberRankPrice.Price = Convert.ToDecimal(((TextBox)this.Num1GridViewPrice.Rows[i].Cells[2].Controls[0]).Text);
        //                    //��Ա�ȼ�Guid
        //                    tempProductMemberRankPrice.MemberRankGuid = new Guid(this.Num1GridViewPrice.Rows[i].Cells[0].Text);

        //                    //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //                    //tempProductMemberRankPrice.CreateUser = product.CreateUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //                    //tempProductMemberRankPrice.CreateTime = product.CreateTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                    //tempProductMemberRankPrice.ModifyUser = product.ModifyUser; //����޸���,��Ϊ����Ʒ��һ������������Ʒ��
        //                    //tempProductMemberRankPrice.ModifyTime = product.ModifyTime; //����޸�ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                    productMemberRankPrice.Add(tempProductMemberRankPrice);
        //                }
        //            }
        //        }
        //        #endregion

        //        #region ��Ʒ�������Ա�"ShopNum1_ProductAttributeValue"

        //        List<ShopNum1_ProductAttributeValue> productAttributeValue = new List<ShopNum1_ProductAttributeValue>();
        //        //// �޼۸������
        //        //if (this.Num1GridViewProductyAttributeShow.Rows.Count > 0)
        //        //{
        //        //    #region �޼۸������
        //        //    for (int i = 0; i <= this.Num1GridViewProductyAttributeShow.Rows.Count - 1; i++)
        //        //    {
        //        //        ShopNum1_ProductAttributeValue tempProductAttributeValue = new ShopNum1_ProductAttributeValue();
        //        //        tempProductAttributeValue.Guid = Guid.NewGuid();
        //        //        //��Ʒ����Guid
        //        //        tempProductAttributeValue.ProductTypeGuid = new Guid(this.DropDownListProductTypeGuid.SelectedValue);
        //        //        //��Ʒ����Guid
        //        //        tempProductAttributeValue.ProductAttributeGuid = new Guid(this.Num1GridViewProductyAttributeShow.Rows[i].Cells[0].Text);

        //        //        //this.Response.Write(tempProductAttributeValue.AtrributeValue);
        //        //        //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //        //        //tempProductAttributeValue.ProductGuid = product.Guid;
        //        //        //tempProductAttributeValue.CreateUser = product.CreateUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //        //        //tempProductAttributeValue.CreateTime = product.CreateTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //        //        //tempProductAttributeValue.ModifyUser = product.ModifyUser; //����޸���,��Ϊ����Ʒ��һ������������Ʒ��
        //        //        //tempProductAttributeValue.ModifyTime = product.ModifyTime; //����޸�ʱ��,��Ϊ����Ʒ��һ������������Ʒ��

        //        //        if (this.Num1GridViewProductyAttributeShow.Rows[i].Cells[3].Text == "0" || this.Num1GridViewProductyAttributeShow.Rows[i].Cells[3].Text == "2")
        //        //        {
        //        //            //�ֹ�����(����)���ֹ�����(����)
        //        //            //����ֵ
        //        //            tempProductAttributeValue.AtrributeValue = ((TextBox)this.Num1GridViewProductyAttributeShow.Rows[i].Cells[2].Controls[0]).Text;
        //        //        }
        //        //        else if (this.Num1GridViewProductyAttributeShow.Rows[i].Cells[3].Text == "1")
        //        //        {
        //        //            //ѡ������
        //        //            //����ֵ
        //        //            tempProductAttributeValue.AtrributeValue = ((DropDownList)this.Num1GridViewProductyAttributeShow.Rows[i].Cells[2].Controls[0]).SelectedItem.Text;
        //        //        }
        //        //        //���Լ۸�(�����Լ۸���Ϊ0����Ϊ�����Լ۸�)
        //        //        tempProductAttributeValue.AttributePrice = 0;

        //        //        productAttributeValue.Add(tempProductAttributeValue);
        //        //    }
        //        //    #endregion
        //        //}

        //        //�м۸������
        //        if (this.Num1GridViewProductyAttributePrice.Rows.Count > 0)
        //        {
        //            #region �м۸�����
        //            for (int i = 0; i <= this.Num1GridViewProductyAttributePrice.Rows.Count - 1; i++)
        //            {
        //                ShopNum1_ProductAttributeValue tempProductAttributeValue = new ShopNum1_ProductAttributeValue();
        //                tempProductAttributeValue.Guid = Guid.NewGuid();
        //                //��Ʒ����Guid
        //                tempProductAttributeValue.ProductTypeGuid = new Guid(this.DropDownListProductTypeGuid.SelectedValue);
        //                //��Ʒ����Guid

        //                tempProductAttributeValue.ProductAttributeGuid = new Guid(this.Num1GridViewProductyAttributePrice.Rows[i].Cells[0].Text);

        //                //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //                //tempProductAttributeValue.ProductGuid = product.Guid;
        //                //tempProductAttributeValue.CreateUser = product.CreateUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //                //tempProductAttributeValue.CreateTime = product.CreateTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                //tempProductAttributeValue.ModifyUser = product.ModifyUser; //����޸���,��Ϊ����Ʒ��һ������������Ʒ��
        //                //tempProductAttributeValue.ModifyTime = product.ModifyTime; //����޸�ʱ��,��Ϊ����Ʒ��һ������������Ʒ��

        //                //����ֵ
        //                tempProductAttributeValue.AtrributeValue = this.Num1GridViewProductyAttributePrice.Rows[i].Cells[2].Text;

        //                //���Լ۸�
        //                tempProductAttributeValue.AttributePrice = Convert.ToDecimal(this.Num1GridViewProductyAttributePrice.Rows[i].Cells[3].Text);

        //                productAttributeValue.Add(tempProductAttributeValue);
        //            }
        //            #endregion
        //        }
        //        #endregion

        //        #region ��Ʒ��ͼ"ShopNum1_ProductImage"
        //        List<ShopNum1_ProductImage> productImage = new List<ShopNum1_ProductImage>();
        //        if (this.DataListPorductImage.Items.Count > 0)
        //        {
        //            DataTable tempDataTalbe = (DataTable)ViewState["dataMultiImage"];
        //            for (int i = 0; i < tempDataTalbe.Rows.Count; i++)
        //            {
        //                ShopNum1_ProductImage tempProductImage = new ShopNum1_ProductImage();
        //                tempProductImage.Guid = Guid.NewGuid();
        //                //ͼƬ��ַ
        //                string strOriginallImage = tempDataTalbe.Rows[i]["OriginalImge"].ToString();
        //                tempProductImage.OriginalImge = strOriginallImage.Substring(strOriginallImage.LastIndexOf("/") + 1);
        //                tempProductImage.ThumbImage = "";    //��ʱ���
        //                tempProductImage.SmallImage = "";      //��ʱ���
        //                tempProductImage.IsDeleted = 0;
        //                tempProductImage.CreateTime = Convert.ToDateTime(tempDataTalbe.Rows[i]["CreateTime"].ToString());
        //                productImage.Add(tempProductImage);

        //            }
        //        }
        //        //if (this.DataListPorductImage.Items.Count > 0)
        //        //{
        //        //    for (int i = 0; i < this.DataListPorductImage.Items.Count; i++)
        //        //    {
        //        //        ShopNum1_ProductImage tempProductImage = new ShopNum1_ProductImage();
        //        //        tempProductImage.Guid = Guid.NewGuid();
        //        //        //ͼƬ��ַ
        //        //        string strOriginallImage = ((Image)this.DataListPorductImage.Items[i].FindControl("loadImg")).ImageUrl;
        //        //        tempProductImage.OriginalImge = strOriginallImage.Substring(strOriginallImage.LastIndexOf("/") + 1);
        //        //        tempProductImage.ThumbImage = "";    //��ʱ���
        //        //        tempProductImage.SmallImage = "";      //��ʱ���
        //        //        tempProductImage.IsDeleted = 0;
        //        //        productImage.Add(tempProductImage);

        //        //    }
        //        //}
        //        #endregion

        //        #region ��Ʒ���"ShopNum1_ProductAccessory"
        //        List<ShopNum1_ProductAccessory> productAccessory = new List<ShopNum1_ProductAccessory>();
        //        if (this.ListBoxRightProductAccessory.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightProductAccessory.Items.Count; i++)
        //            {
        //                ShopNum1_ProductAccessory tempProductAccessory = new ShopNum1_ProductAccessory();
        //                //��ΪListBoxRightProductAccessory��Valueֵ��"Guid"+";"+"�۸�"
        //                //���Բ�ֺ�ȡ�۸�
        //                string[] strTempArry = this.ListBoxRightProductAccessory.Items[i].Value.Split(';');
        //                tempProductAccessory.AccessoryProductGuid = new Guid(strTempArry[0]);
        //                //MessageBox.Show(strTempArry.Length.ToString());

        //                tempProductAccessory.Price = Convert.ToDecimal(strTempArry[1]);

        //                //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //                //tempProductAccessory.ProductGuid = product.Guid;  //�õ�����Ʒ��Guid
        //                //tempProductAccessory.CreateUser = product.CreateUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //                //tempProductAccessory.CreateTime = product.CreateTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                productAccessory.Add(tempProductAccessory);
        //            }
        //        }
        //        #endregion

        //        #region �����Ʒ"ShopNum1_RelatedProduct"
        //        List<ShopNum1_RelatedProduct> relatedProduct = new List<ShopNum1_RelatedProduct>();

        //        if (this.ListBoxRightRelatedProduct.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightRelatedProduct.Items.Count; i++)
        //            {
        //                ShopNum1_RelatedProduct tempRelatedProduct = new ShopNum1_RelatedProduct();
        //                //��ΪListBoxRightProductAccessory��Valueֵ��"Guid"+";"+"IsBoth"
        //                //���Բ�ֺ�ȡ�۸�
        //                string[] strTempArry = this.ListBoxRightRelatedProduct.Items[i].Value.Split(';');
        //                tempRelatedProduct.SubProductGuid = new Guid(strTempArry[0]);
        //                tempRelatedProduct.IsBoth = Convert.ToInt32(strTempArry[1]);

        //                //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //                //tempRelatedProduct.ProductGuid = product.Guid;  //�õ�����Ʒ��Guid
        //                //tempRelatedProduct.CreateUser = product.CreateUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //                //tempRelatedProduct.CreateTime = product.CreateTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                relatedProduct.Add(tempRelatedProduct);
        //            }
        //        }
        //        #endregion

        //        #region �����Ѷ"ShopNum1_ProductArticle"
        //        List<ShopNum1_ProductArticle> productArticle = new List<ShopNum1_ProductArticle>();
        //        if (this.ListBoxRightProductArticle.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightProductArticle.Items.Count; i++)
        //            {
        //                ShopNum1_ProductArticle tempProductArticle = new ShopNum1_ProductArticle();
        //                tempProductArticle.ArticleGuid = new Guid(this.ListBoxRightProductArticle.Items[i].Value);
        //                //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //                //tempProductArticle.ProductGuid = product.Guid;  //�õ�����Ʒ��Guid
        //                //tempProductArticle.CreateUser = product.CreateUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //                //tempProductArticle.CreateTime = product.CreateTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                productArticle.Add(tempProductArticle);

        //            }
        //        }
        //        #endregion

        //        #region ��չ����"ShopNum1_ProdcutExtendType"
        //        List<ShopNum1_ProdcutExtendType> prodcutExtendType = new List<ShopNum1_ProdcutExtendType>();

        //        if (this.ListBoxRightProductExtendCategory.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightProductExtendCategory.Items.Count; i++)
        //            {
        //                ShopNum1_ProdcutExtendType tempProdcutExtendType = new ShopNum1_ProdcutExtendType();
        //                tempProdcutExtendType.ProductCategoryID = Convert.ToInt32(this.ListBoxRightProductExtendCategory.Items[i].Value);
        //                //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //                //prodcutExtendType.ProductGuid = product.Guid;  //�õ�����Ʒ��Guid
        //                //prodcutExtendType.CreateUser = product.CreateUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //                //prodcutExtendType.CreateTime = product.CreateTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                prodcutExtendType.Add(tempProdcutExtendType);

        //            }
        //        }
        //        #endregion

        //        ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //        int check = 0;
        //        check = productAction.Update(product,
        //                                                        productMemberRankPrice,
        //                                                        productAttributeValue,
        //                                                        productImage,
        //                                                        productAccessory,
        //                                                        relatedProduct,
        //                                                        productArticle,
        //                                                        prodcutExtendType);


        //        if (this.Num1GridViewAgentPrice.Rows.Count > 0)
        //        {
        //            for (int i = 0; i <= this.Num1GridViewAgentPrice.Rows.Count - 1; i++)
        //            {
        //                if (((TextBox)this.Num1GridViewAgentPrice.Rows[i].Cells[2].Controls[0]).Text != "-1" && !string.IsNullOrEmpty(((TextBox)this.Num1GridViewAgentPrice.Rows[i].Cells[2].Controls[0]).Text))
        //                {
        //                    ShopNum1_ProductMemberRankPrice tempProductMemberRankPrice = new ShopNum1_ProductMemberRankPrice();
        //                    tempProductMemberRankPrice.Guid = Guid.NewGuid();
        //                    tempProductMemberRankPrice.ProductGuid = product.Guid;   //��Ʒ��Guid
        //                    //�ȼ��۸�
        //                    tempProductMemberRankPrice.Price = Convert.ToDecimal(((TextBox)this.Num1GridViewAgentPrice.Rows[i].Cells[2].Controls[0]).Text);
        //                    //��Ա�ȼ�Guid
        //                    tempProductMemberRankPrice.MemberRankGuid = new Guid(this.Num1GridViewAgentPrice.Rows[i].Cells[0].Text);

        //                    //���µ���ShopNum1_Production_Action�ж��У����õ�����Ʒ����Ϣ
        //                    tempProductMemberRankPrice.CreateUser = product.ModifyUser;  //�����,��Ϊ����Ʒ��һ������������Ʒ��
        //                    tempProductMemberRankPrice.CreateTime = product.ModifyTime; //���ʱ��,��Ϊ����Ʒ��һ������������Ʒ��
        //                    tempProductMemberRankPrice.ModifyUser = product.ModifyUser; //����޸���,��Ϊ����Ʒ��һ������������Ʒ��
        //                    tempProductMemberRankPrice.ModifyTime = product.ModifyTime; //����޸�ʱ��,��Ϊ����Ʒ��һ������������Ʒ��

        //                    productAction.AddMemberRankPrice(tempProductMemberRankPrice);

        //                }
        //            }
        //        }

        //        if (check > 0)
        //        {
        //            #region  ������־����
        //            ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog();
        //            operateLog.Record = "�༭" + this.TextBoxName.Text.Trim() + "�ɹ�!";
        //            operateLog.OperatorID = this.ShopNum1LoginID;
        //            operateLog.IP = Globals.IPAddress;
        //            operateLog.PageName = "TbProduct_Operate.aspx";
        //            operateLog.Date = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //            int log = OperateLog(operateLog);
        //            #endregion

        //            if (DropDownListProducLine.Enabled)
        //            {
        //                if (DropDownListProducLine.SelectedValue != "-1")
        //                {
        //                    ShopNum1_ProductLine_Action productLine_Action = (ShopNum1_ProductLine_Action)LogicFactory.CreateShopNum1_ProductLine_Action();
        //                    DataTable dataTable = productLine_Action.GetEditInfo("'" + DropDownListProducLine.SelectedValue + "'");

        //                    if (dataTable.Rows[0]["IsForcibly"].ToString() == "1")  //�ж��Ƿ���ǿ�ƴ����Ʒ��
        //                    {
        //                        if (dataTable.Rows[0]["AgentID"].ToString() != "")  //�жϲ�Ʒ���Ƿ���Ȩ
        //                        {
        //                            string[] strAgentID = dataTable.Rows[0]["AgentID"].ToString().Split(',');

        //                            for (int i = 0; i < strAgentID.Length - 1; i++)
        //                            {
        //                                productLine_Action.AddAgentProductLineProduct(product.Guid.ToString(), product.ShopPrice.ToString(), strAgentID[i].ToString(), "1");
        //                            }
        //                        }
        //                    }
        //                }
        //            }


        //            //��ʾ������Ϣ
        //            this.MessageShowTb.ShowMessage("EditYes");
        //            this.MessageShowTb.Visible = true;

        //            //��ӳɹ�����տؼ�
        //            ClearControl();
        //            decimal numiid = GetNumiid(product.Guid.ToString());
        //            if (CheckBoxTb.Visible == false)
        //            {

        //                #region  �����Ա�
        //                ///�����Ա���Ʒ
        //                if (CheckBoxTbUpdate.Checked)
        //                {
        //                    if (numiid != 0)
        //                    {
        //                        updateTbItem(numiid.ToString());
        //                    }
        //                }
        //                //else if (CheckBoxTb.Checked)
        //                //{

        //                //}
        //                //else if (CheckBoxTbUpdate.Checked)
        //                //{
        //                ///�޸��Ա���Ʒ
        //                //  updateTbItem(numiid.ToString());
        //                // }
        //                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "err", "alert('��ӳɹ�')", true);
        //                //ClientScript.RegisterClientScriptBlock(typeof(Page), "err", "alert('��ӳɹ�')", true);
        //                #endregion
        //            }
        //            else
        //            {
        //                if (CheckBoxTb.Checked)
        //                {
        //                    #region
        //                    if (numiid == 0)
        //                    {
        //                        Dictionary<string, string> param = new Dictionary<string, string>();//���� APIӦ�ü��������

        //                        if (ViewState["cid"] == null)
        //                        {
        //                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "msg", "alert(\"��ûѡ�����\")", true);
        //                            return;
        //                        }

        //                        //ϵͳҶ����Ŀcid
        //                        string cid = string.Empty;
        //                        cid = ViewState["cid"].ToString();
        //                        ///�����Զ�����Ŀ����
        //                        StringBuilder seller_cids = new StringBuilder();
        //                        foreach (TreeNode td in TreeViewTb.CheckedNodes)
        //                        {
        //                            if (td.ChildNodes.Count != 0)
        //                            {
        //                                foreach (TreeNode tdson in td.ChildNodes)
        //                                {
        //                                    seller_cids.Append(tdson.Value + ",");
        //                                }
        //                            }
        //                            else
        //                            {
        //                                seller_cids.Append(td.Value + ",");
        //                            }
        //                        }

        //                        ///�¾ɳ̶�
        //                        string stuff_status = string.Empty;
        //                        if (radNew.Checked)
        //                        {
        //                            stuff_status = "new";
        //                        }
        //                        else if (radOld.Checked)
        //                        {
        //                            stuff_status = "unused";
        //                        }
        //                        else
        //                        {
        //                            stuff_status = "second";
        //                        }

        //                        ///��������
        //                        string title = txtTitle.Text.Trim();

        //                        //��������
        //                        string num = txtCount.Text.Trim();

        //                        ///ʡ��
        //                        string province = ddlProvince.SelectedItem.Text.Trim().Replace("ʡ", "").TrimEnd();

        //                        ///����
        //                        string city = ddlCity.SelectedItem.Text.Trim().Replace("��", "").TrimEnd();

        //                        ///�˷ѳе���
        //                        string freight_payer = radSeller.Checked ? "seller" : "buyer";
        //                        if (radFreight1.Checked && radBuyer.Checked)
        //                        {
        //                            freight_payer = "seller";
        //                        }
        //                        else if (radFreight2.Checked && radBuyer.Checked)
        //                        {
        //                            ///�Զ��������ʷ�
        //                            param.Add("post_fee", txtSurfaceMail.Text.Trim());
        //                            param.Add("express_fee", txtExpress.Text.Trim());
        //                            param.Add("ems_fee", txtEms.Text.Trim());
        //                        }


        //                        ///��Чʱ��
        //                        decimal valid_thru = radSeven.Checked == true ? 7 : 14;

        //                        //�Ƿ��з�Ʊ
        //                        string has_invoice = radInvoiceYes.Checked == true ? "true" : "false";

        //                        ///�Ƿ��б�
        //                        string has_warranty = radServiceNo.Checked == true ? "true" : "false";

        //                        //�Ƿ����
        //                        string has_discount = radDicCountYes.Checked == true ? "true" : "false";

        //                        ///�̻�����
        //                        string outer_id = txtNumCode.Text.Trim();

        //                        ///һ�ڼ�
        //                        string price = txtOnePrice.Text.Trim();

        //                        //�������
        //                        string auction_point = txtRate.Text.Trim();

        //                        ///�ϼ�״̬
        //                        string approve_status = radPut.Checked == true ? "onsale" : "instock";

        //                        //�Ƿ�����Ƽ�
        //                        string has_showcase = cboxYes.Checked == true ? "true" : "false";

        //                        string strXml = string.Empty;

        //                        param.Add("num", num);
        //                        //param.Add("pic_path", ImageOriginalImge.Src);
        //                        param.Add("price", price);
        //                        param.Add("type", "fixed");
        //                        param.Add("stuff_status", stuff_status);
        //                        //param.Add("input_str", "other;�ͺ�;other;");
        //                        //param.Add("input_pids", "2000");
        //                        param.Add("title", title);
        //                       // string desc = this.FCKeditorDetail.Value;  //��Ʒ��ϸ
        //                        //desc = desc == "" ? "�����ҵ���Ʒ!" + title : desc;
        //                        string desc = this.TextBoxDescription.Text;
        //                        param.Add("desc", desc);
        //                        param.Add("location.state", province);
        //                        param.Add("location.city", city);
        //                        param.Add("approve_status", approve_status);
        //                        param.Add("cid", cid);
        //                        param.Add("freight_payer", freight_payer);
        //                        param.Add("valid_thru", valid_thru.ToString());
        //                        param.Add("has_invoice", has_warranty);
        //                        param.Add("has_discount", has_discount);
        //                        //  �Ƿ���
        //                        param.Add("has_warranty", has_warranty);

        //                        //�Ƿ�����Ƽ�
        //                        param.Add("has_showcase", has_showcase);

        //                        //�̼��Զ������ 
        //                        param.Add("seller_cids", seller_cids.ToString());

        //                        // �̼ұ���
        //                        param.Add("outer_id", outer_id);
        //                        ///�̼�
        //                        param.Add("auction_point", auction_point);
        //                        param.Add("props", GetAddProps());

        //                        strXml = TopAPI.Post("taobao.item.add", TopClient.AdminSession, param);

        //                        ErrorRsp err = new ErrorRsp();
        //                        ItemResponse itemRsp = new ItemResponse();
        //                        new Parser().XmlToObject2(strXml, "item_add", "item", itemRsp, err);

        //                        //if (err.IsError)//�ж��Ƿ���¹����з�������
        //                        //{
        //                        //    //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //                        //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"�����Ʒʧ�ܣ�������룺{0}\\r����ԭ��{1}\\r����������{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
        //                        //    return;
        //                        //}
        //                        if (!err.IsError)
        //                        {
        //                            ///����ͼƬ�ϴ�
        //                            if (TextBoxOriginalImge.Text.Trim() != "")
        //                            {
        //                                try
        //                                {
        //                                    param.Clear();
        //                                    param.Add("num_iid", itemRsp.num_iid);
        //                                    param.Add("position", "1");
        //                                    param.Add("is_major", "true");

        //                                    string picImgUrl = Server.MapPath(TextBoxOriginalImge.Text.Trim());
        //                                    Dictionary<string, FileItem> fileParam = new Dictionary<string, FileItem>();

        //                                    fileParam.Add("image", new FileItem(new System.IO.FileInfo(picImgUrl)));

        //                                    strXml = TopAPI.Post("taobao.item.img.upload", TopClient.AdminSession, param, fileParam);


        //                                    ItemImgResponse itemimg = new ItemImgResponse();
        //                                    new Parser().XmlToObject2(strXml, "item_img_upload", itemimg, err);

        //                                    if (err.IsError)
        //                                    {
        //                                        // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"�Ա��ϴ�ͼƬ��ʱ����ִ��󣡴�����룺{0}\\r����ԭ��{1}\\r����������{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
        //                                    }
        //                                }
        //                                catch (Exception)
        //                                {

        //                                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"�Ա��ϴ�ͼƬʧ��\")"), true);

        //                                }

        //                            }
        //                            ShopNum1_ProductCategory_Action productCategoryAction = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
        //                            string siteCid = product.Guid.ToString();
        //                            string num_iid = itemRsp.num_iid;
        //                            ShopNum1_TbItem_Action tbItemOperate = (ShopNum1_TbItem_Action)LogicTbFactory.CreateShopNum1_TbItem_Action();
        //                            tbItemOperate.InsertItemSimplify(decimal.Parse(num_iid), siteCid, decimal.Parse(cid));
        //                        }
        //                        else
        //                        {
        //                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert(\"��Ʒ�༭�ɹ�,����ͬ���Ա���������!" + err.msg + "\")", true);
        //                        }

        //                    }
        //                    #endregion
        //                }

        //            }
        //        }
        //        else
        //        {
        //            //��ʾ������Ϣ
        //            this.MessageShowTb.ShowMessage("EditNo");
        //            this.MessageShowTb.Visible = true;
        //        }

        //        #endregion
        //    }
        //}

        ////����ѡ��Ӧ�̵��û�ID
        //public string GetSupplierLoginID(string strguid)
        //{
        //    ShopNum1_Supplier_Action supplier_Action = (ShopNum1_Supplier_Action)LogicFactory.CreateShopNum1_Supplier_Action();
        //    DataTable dataSupplierInfo = supplier_Action.GetEditInfo("'" + strguid + "'", -1);
        //    if (dataSupplierInfo != null && dataSupplierInfo.Rows.Count > 0)
        //    {
        //        return dataSupplierInfo.Rows[0]["SupplierLoginID"].ToString();
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}

        ////�������������(���ʱ����������)
        //protected void BindDropDownListAttributeName()
        //{
        //    this.DropDownListAttributeName.Items.Clear();

        //    ListItem listItem1 = new ListItem();
        //    //listItem1.Text = "-��ѡ��-";
        //    listItem1.Text = LocalizationUtil.GetCommonMessage("Select");
        //    listItem1.Value = "-1";
        //    this.DropDownListAttributeName.Items.Add(listItem1);

        //    ShopNum1_ProductAttribute_Action productAttributeAction = (ShopNum1_ProductAttribute_Action)LogicFactory.CreateShopNum1_ProductAttribute_Action();
        //    DataTable dataTableAttrbutePrice = productAttributeAction.SearchByProductTypeIsMultiSelect12(this.DropDownListProductTypeGuid.SelectedValue);
        //    foreach (DataRow dr in dataTableAttrbutePrice.Rows)
        //    {
        //        ListItem listItem = new ListItem();
        //        listItem.Text = dr["Name"].ToString().Trim();
        //        listItem.Value = dr["Guid"].ToString().Trim();
        //        this.DropDownListAttributeName.Items.Add(listItem);
        //    }
        //}
        //protected void DropDownListAttributeName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.DropDownListAttributeName.SelectedValue == "-1")
        //    {
        //        return;
        //    }
        //    ShopNum1_ProductAttribute_Action productAttributeAction = (ShopNum1_ProductAttribute_Action)LogicFactory.CreateShopNum1_ProductAttribute_Action();
        //    DataTable tempDataTable = productAttributeAction.SearchByGuid(this.DropDownListAttributeName.SelectedValue);
        //    if (tempDataTable.Rows[0]["InputType"].ToString() == "1")
        //    {
        //        this.HiddenFieldAtrributeValue1.Value = "true";
        //        AtrributeValue1 = true;
        //        this.HiddenFieldAtrributeValue0.Value = "false";
        //        AtrributeValue0 = false;
        //        this.HiddenFieldAtrributeValue2.Value = "false";
        //        AtrributeValue2 = false;

        //        string[] strAttributeGroup = tempDataTable.Rows[0]["AttrValue"].ToString().Split('\n');
        //        this.DropDownListAtrributeValue.Items.Clear();
        //        for (int i = 0; i < strAttributeGroup.Length; i++)
        //        {
        //            ListItem listItem = new ListItem();
        //            listItem.Text = strAttributeGroup[i].ToString();
        //            listItem.Value = strAttributeGroup[i].ToString();
        //            this.DropDownListAtrributeValue.Items.Add(listItem);
        //        }
        //    }
        //    else if (tempDataTable.Rows[0]["InputType"].ToString() == "0")
        //    {
        //        this.HiddenFieldAtrributeValue0.Value = "true";
        //        AtrributeValue0 = true;
        //        this.HiddenFieldAtrributeValue1.Value = "false";
        //        AtrributeValue1 = false;
        //        this.HiddenFieldAtrributeValue2.Value = "false";
        //        AtrributeValue2 = false;
        //        this.DropDownListAtrributeValue.Items.Clear();
        //    }
        //    else if (tempDataTable.Rows[0]["InputType"].ToString() == "2")
        //    {
        //        this.HiddenFieldAtrributeValue2.Value = "true";
        //        AtrributeValue2 = true;
        //        this.HiddenFieldAtrributeValue0.Value = "false";
        //        AtrributeValue0 = false;
        //        this.HiddenFieldAtrributeValue1.Value = "false";
        //        AtrributeValue1 = false;
        //        this.DropDownListAtrributeValue.Items.Clear();
        //    }
        //}

        //protected void ButtonAddAttributePrice_Click(object sender, EventArgs e)
        //{
        //    DataTable tempDataTalbe = (DataTable)ViewState["dataProductyAttributePrice"];
        //    DataRow dataRow = tempDataTalbe.NewRow();
        //    dataRow["Guid"] = new Guid(this.DropDownListAttributeName.SelectedValue);
        //    dataRow["Name"] = this.DropDownListAttributeName.SelectedItem.Text;
        //    if (this.HiddenFieldAtrributeValue0.Value == "true")
        //    {
        //        dataRow["AtrributeValue"] = this.TextBoxAtrributeValue0.Text;
        //    }
        //    else if (this.HiddenFieldAtrributeValue1.Value == "true")
        //    {
        //        dataRow["AtrributeValue"] = this.DropDownListAtrributeValue.SelectedValue;
        //        //dataRow["AtrributeValue"] = this.DropDownListAtrributeValue.SelectedItem.Text; 
        //    }
        //    else if (this.HiddenFieldAtrributeValue2.Value == "true")
        //    {
        //        dataRow["AtrributeValue"] = this.TextBoxAtrributeValue2.Text;

        //    }
        //    dataRow["AttributePrice"] = Convert.ToDecimal(this.TextBoxAttributePrice.Text);
        //    tempDataTalbe.Rows.Add(dataRow);
        //    //this.Response.Redirect("test.aspx?test=" + this.HiddenFieldAtrributeValue1.Value + "");
        //    this.Num1GridViewProductyAttributePrice.DataSource = tempDataTalbe.DefaultView;
        //    this.Num1GridViewProductyAttributePrice.DataBind();
        //}

        ////��տؼ�
        //protected void ClearControl()
        //{

        //}


        //#region �༭���ִ���

        ////ȡ�༭��Ʒ��Ϣ
        //protected void GetEditProductInfo()
        //{
        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    //ɾ����־��-1���������Ƿ�ɾ������
        //    DataTable dataTable = productAction.Search(this.hiddenFieldGuid.Value, -1);
        //    //��Ʒ����
        //    this.TextBoxName.Text = dataTable.Rows[0]["Name"].ToString();
        //    //�õĶ���ԭͼ
        //    this.TextBoxOriginalImge.Text = dataTable.Rows[0]["OriginalImge"].ToString();
        //    if (dataTable.Rows[0]["OriginalImge"].ToString() != string.Empty)
        //    {
        //        this.ImageOriginalImge.Src = dataTable.Rows[0]["OriginalImge"].ToString();
        //    }
        //    else
        //    {
        //        this.ImageOriginalImge.Src = "~/Images/noImage.gif";
        //    }
        //    //product.ThumbImage = "";   
        //    //product.SmallImage = "";    
        //    //�����(����)
        //    this.TextBoxRepertoryNumber.Text = dataTable.Rows[0]["RepertoryNumber"].ToString();
        //    //��Ʒ����
        //    this.TextBoxWeight.Text = dataTable.Rows[0]["Weight"].ToString();
        //    //�����
        //    this.TextBoxRepertoryCount.Text = dataTable.Rows[0]["RepertoryCount"].ToString();
        //    //��λ��
        //    this.TextBoxUnitName.Text = dataTable.Rows[0]["UnitName"].ToString();
        //    //��澯������
        //    this.TextBoxNameRepertoryAlertCount.Text = dataTable.Rows[0]["RepertoryAlertCount"].ToString();
        //    //�������Ѻ��
        //    this.TextBoxPresentRankScore.Text = dataTable.Rows[0]["PresentScore"].ToString();
        //    //���͵ȼ����
        //    this.TextBoxPresentScore.Text = dataTable.Rows[0]["PresentRankScore"].ToString();
        //    //���������
        //    this.TextBoxSocreIntegral.Text = dataTable.Rows[0]["SocreIntegral"].ToString();
        //    //ÿ�˴����ƹ�������
        //    this.TextBoxLimitBuyCount.Text = dataTable.Rows[0]["LimitBuyCount"].ToString();
        //    //�ɱ���
        //    this.TextBoxCostPrice.Text = dataTable.Rows[0]["CostPrice"].ToString();
        //    //�г��� 
        //    this.TextBoxMarketPrice.Text = dataTable.Rows[0]["MarketPrice"].ToString();
        //    //�����ۼ�
        //    this.TextBoxShopPrice.Text = dataTable.Rows[0]["ShopPrice"].ToString();
        //    //��Ʒ�򵥽���
        //    this.TextBoxBrief.Text = dataTable.Rows[0]["Brief"].ToString();
        //    //�̼ұ�ע
        //    this.TextBoxMemo.Text = dataTable.Rows[0]["Memo"].ToString();
        //    //��Ʒ��ϸ
        //    this.FCKeditorDetail.Value = this.Server.HtmlDecode(dataTable.Rows[0]["Detail"].ToString());
        //    //�Ƿ��ϼ�
        //    this.DropDownListIsSaled.SelectedValue = dataTable.Rows[0]["IsSaled"].ToString();
        //    //�Ƿ��Ǿ�Ʒ
        //    if (dataTable.Rows[0]["IsBest"].ToString() == "0")
        //    {
        //        this.CheckBoxIsBest.Checked = false;
        //    }
        //    else
        //    {
        //        this.CheckBoxIsBest.Checked = true;
        //    }
        //    //�Ƿ�����Ʒ
        //    if (dataTable.Rows[0]["IsNew"].ToString() == "0")
        //    {
        //        this.CheckBoxIsNew.Checked = false;
        //    }
        //    else
        //    {
        //        this.CheckBoxIsNew.Checked = true;
        //    }
        //    //�Ƿ�����
        //    if (dataTable.Rows[0]["IsHot"].ToString() == "0")
        //    {
        //        this.CheckBoxIsHot.Checked = false;
        //    }
        //    else
        //    {
        //        this.CheckBoxIsHot.Checked = true;
        //    }
        //    //�Ƿ��Ƽ�
        //    if (dataTable.Rows[0]["IsRecommend"].ToString() == "0")
        //    {
        //        this.CheckBoxIsRecommend.Checked = false;
        //    }
        //    else
        //    {
        //        this.CheckBoxIsRecommend.Checked = true;
        //    }

        //    //�Ƿ���ʵ��
        //    this.DropDownListIsReal.SelectedValue = dataTable.Rows[0]["IsReal"].ToString();
        //    //�Ƿ��ܵ�������(���۷�ʽ)
        //    this.DropDownListIsOnlySaled.SelectedValue = dataTable.Rows[0]["IsOnlySaled"].ToString();
        //    //��ϸҳ����
        //    this.TextBoxTitle.Text = dataTable.Rows[0]["Title"].ToString();
        //    //��ϸҳ����
        //    this.TextBoxDescription.Text = dataTable.Rows[0]["Description"].ToString();
        //    //��ϸҳ�����ؼ���
        //    this.TextBoxKeywords.Text = dataTable.Rows[0]["Keywords"].ToString();
        //    //��Ʒ����
        //    this.TextBoxOrderID.Text = dataTable.Rows[0]["OrderID"].ToString();
        //    //��Ӧ��
        //    this.DropDownListSupplierGuid.SelectedValue = dataTable.Rows[0]["SupplierGuid"].ToString();
        //    //��Ʒ����
        //    //this.DropDownListProductCategoryID.SelectedValue = dataTable.Rows[0]["ProductCategoryID"].ToString();

        //    #region  //ȷ�������Ʒѡ�����з���
        //    string ProductCode = dataTable.Rows[0]["ProductCategoryID"].ToString();
        //    //File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), ProductCode + "\r\n");
        //    if (!string.IsNullOrEmpty(ProductCode))
        //    {
        //        ShopNum1_ProductCategory_Action productCategoryAction = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
        //        DataTable dataTable3 = productCategoryAction.GetFatherIDProductCategory(ProductCode);

        //        string totalLevel = "0";
        //        string strCategoryID3 = string.Empty;
        //        if (dataTable3 != null && dataTable3.Rows.Count > 0)
        //        {
        //            totalLevel = dataTable3.Rows[0]["CategoryLevel"].ToString();
        //            strCategoryID3 = dataTable3.Rows[0]["FatherID"].ToString();
        //        }
        //        //File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), totalLevel + "asd" + strCategoryID3);

        //        switch (totalLevel.Trim().ToString())
        //        {
        //            case "3":
        //                //��������
        //                DataTable dataTable2 = null;
        //                DataTable dataTable1 = null;
        //                string strCategoryID2 = string.Empty;
        //                string strCategoryID1 = string.Empty;
        //                dataTable2 = productCategoryAction.GetFatherIDProductCategory(strCategoryID3);
        //                if (dataTable2 != null && dataTable2.Rows.Count > 0)
        //                {
        //                    strCategoryID2 = dataTable2.Rows[0]["FatherID"].ToString();
        //                    dataTable1 = productCategoryAction.GetFatherIDProductCategory(strCategoryID2);
        //                }
        //                if (dataTable1 != null && dataTable1.Rows.Count > 0)
        //                {
        //                    strCategoryID1 = dataTable1.Rows[0]["FatherID"].ToString();

        //                    #region �󶨷���
        //                    this.DropDownListProductCategoryID1.SelectedValue = strCategoryID2;
        //                    DropDownListProductCategoryID1_SelectedIndexChanged(null, null);

        //                    this.DropDownListProductCategoryID2.SelectedValue = strCategoryID3;
        //                    DropDownListProductCategoryID2_SelectedIndexChanged(null, null);

        //                    this.DropDownListProductCategoryID3.SelectedValue = ProductCode;
        //                    DropDownListProductCategoryID3_SelectedIndexChanged(null, null);
        //                    break;

        //                    #endregion
        //                }
        //                break;
        //            case "2":
        //                //��������
        //                DataTable dataTable21 = null;
        //                string strCategoryID21 = string.Empty;
        //                dataTable21 = productCategoryAction.GetFatherIDProductCategory(strCategoryID3);
        //                if (dataTable21 != null && dataTable21.Rows.Count > 0)
        //                {
        //                    strCategoryID21 = dataTable21.Rows[0]["FatherID"].ToString();
        //                    #region �󶨷���
        //                    this.DropDownListProductCategoryID1.SelectedValue = strCategoryID3;
        //                    DropDownListProductCategoryID1_SelectedIndexChanged(null, null);
        //                    this.DropDownListProductCategoryID2.SelectedValue = ProductCode;
        //                    DropDownListProductCategoryID2_SelectedIndexChanged(null, null);
        //                    break;
        //                    #endregion
        //                }
        //                break;
        //            case "1":
        //                //һ������
        //                #region �󶨷���
        //                this.DropDownListProductCategoryID1.SelectedValue = ProductCode;
        //                DropDownListProductCategoryID1_SelectedIndexChanged(null, null);
        //                #endregion

        //                break;
        //        }
        //    }
        //    #endregion

        //    //��ƷƷ��
        //    this.DropDownListBrandGuid.SelectedValue = dataTable.Rows[0]["BrandGuid"].ToString();

        //    //��Ʒ����
        //    this.DropDownListProductTypeGuid.SelectedValue = dataTable.Rows[0]["ProductTypeGuid"].ToString();

        //    this.DropDownListProducLine.SelectedValue = dataTable.Rows[0]["ProductLineGuid"].ToString();

        //    if (dataTable.Rows[0]["ProductLineGuid"].ToString() == "")
        //    {
        //        DropDownListProducLine.Enabled = true;
        //    }

        //    if (CheckUnionType() == "0")
        //    {
        //        TextBoxPushMoney.Text = dataTable.Rows[0]["PushMoney"].ToString();
        //    }
        //}

        ////ȡ�༭������
        //protected void GetEditProductAccessory()
        //{
        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    DataTable dataTable = productAction.SearchProductAccessory(this.hiddenFieldGuid.Value.Replace("'", ""));

        //    for (int i = 0; i < dataTable.Rows.Count; i++)
        //    {
        //        ListItem tempItem = new ListItem();
        //        tempItem.Text = dataTable.Rows[i]["Name"].ToString() + "--" + dataTable.Rows[i]["Price"].ToString();
        //        tempItem.Value = dataTable.Rows[i]["Guid"].ToString() + ";" + dataTable.Rows[i]["Price"].ToString();
        //        this.ListBoxRightProductAccessory.Items.Add(tempItem);
        //    }
        //}

        ////ȡ�༭�����Ʒ
        //protected void GetEditRelatedProduct()
        //{
        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    DataTable dataTable = productAction.SearchEditRelatedProduct(this.hiddenFieldGuid.Value.Replace("'", ""));
        //    for (int i = 0; i < dataTable.Rows.Count; i++)
        //    {
        //        ListItem tempItem = new ListItem();
        //        string str = string.Empty;
        //        if (dataTable.Rows[i]["IsBoth"].ToString() == "0")
        //        {
        //            str = "�������";
        //        }
        //        else
        //        {
        //            str = "˫�����";
        //        }
        //        tempItem.Text = dataTable.Rows[i]["Name"].ToString() + "--" + str;
        //        tempItem.Value = dataTable.Rows[i]["Guid"].ToString() + ";" + dataTable.Rows[i]["IsBoth"].ToString();
        //        this.ListBoxRightRelatedProduct.Items.Add(tempItem);
        //    }
        //}

        /////ȡ�༭�������Ѷ
        //protected void GetEditProductArticle()
        //{
        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    DataTable dataTable = productAction.GetEditRelatedArticle(this.hiddenFieldGuid.Value.Replace("'", ""));
        //    for (int i = 0; i < dataTable.Rows.Count; i++)
        //    {
        //        ListItem tempItem = new ListItem();

        //        tempItem.Text = dataTable.Rows[i]["Title"].ToString();
        //        tempItem.Value = dataTable.Rows[i]["Guid"].ToString();
        //        this.ListBoxRightProductArticle.Items.Add(tempItem);
        //    }
        //}

        ////ȡ��չ����
        //protected void GetEditProdcutExtendType()
        //{
        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    DataTable dataTable = productAction.GetEditProdcutExtendType(this.hiddenFieldGuid.Value.Replace("'", ""));
        //    for (int i = 0; i < dataTable.Rows.Count; i++)
        //    {
        //        ListItem tempItem = new ListItem();

        //        tempItem.Text = dataTable.Rows[i]["Name"].ToString();
        //        tempItem.Value = dataTable.Rows[i]["Id"].ToString();
        //        this.ListBoxRightProductExtendCategory.Items.Add(tempItem);
        //    }
        //}

        ////ȡ��Ա�ȼ��۸�
        //protected void GetProductMemberRankPrice()
        //{
        //    //this.Response.Write("fsdafdsafdsaf");
        //    //this.Response.End();
        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    DataTable dataTable = productAction.GetMemberProductMemberRankPrice(this.hiddenFieldGuid.Value.Replace("'", ""));
        //    for (int i = 0; i < this.Num1GridViewPrice.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < dataTable.Rows.Count; j++)
        //        {
        //            if (dataTable.Rows[j]["MemberRankGuid"].ToString() == this.Num1GridViewPrice.Rows[i].Cells[0].Text.ToString())
        //            {
        //                ((TextBox)this.Num1GridViewPrice.Rows[i].Cells[2].Controls[0]).Text = dataTable.Rows[j]["Price"].ToString();

        //            }
        //        }
        //    }

        //}

        ////ȡ�����̵ȼ��۸�
        //protected void GetAgentProductMemberRankPrice()
        //{
        //    //this.Response.Write("fsdafdsafdsaf");
        //    //this.Response.End();
        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    DataTable dataTable = productAction.GetMemberProductMemberRankPrice(this.hiddenFieldGuid.Value.Replace("'", ""));
        //    for (int i = 0; i < this.Num1GridViewAgentPrice.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < dataTable.Rows.Count; j++)
        //        {
        //            if (dataTable.Rows[j]["MemberRankGuid"].ToString() == this.Num1GridViewAgentPrice.Rows[i].Cells[0].Text.ToString())
        //            {
        //                ((TextBox)this.Num1GridViewAgentPrice.Rows[i].Cells[2].Controls[0]).Text = dataTable.Rows[j]["Price"].ToString();

        //            }
        //        }
        //    }

        //}

        ////ȡ��Ʒ��ͼ
        //protected void GetProductImage()
        //{
        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    DataTable dataTable = productAction.GetProductImage(this.hiddenFieldGuid.Value.Replace("'", ""));

        //    DataView tempDataView = dataTable.DefaultView;
        //    tempDataView.Sort = "CreateTime DESC";
        //    this.DataListPorductImage.DataSource = dataTable.DefaultView;
        //    this.DataListPorductImage.DataBind();

        //    //����Ǳ༭�Ļ��Ƚ�ͼƬViewState��
        //    ViewState["dataMultiImage"] = dataTable;

        //}

        ////ȡ������Ʒ�۸����Ʒ���Ե�ֵ
        ////protected void GetProductAttribute()
        ////{
        ////    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        ////    DataTable dataTable = productAction.SearchEditProductAttributeValue(this.hiddenFieldGuid.Value.Replace("'", ""));

        ////    for (int i = 0; i < Num1GridViewProductyAttributeShow.Rows.Count; i++)
        ////    {
        ////        for (int j = 0; j < dataTable.Rows.Count; j++)
        ////        {
        ////            if (Num1GridViewProductyAttributeShow.Rows[i].Cells[0].Text == dataTable.Rows[j]["ProductAttributeGuid"].ToString())
        ////            {
        ////                //0��Ϊ�ֹ����룻1��Ϊѡ�����룻2��Ϊ�����ı�����',
        ////                if (Num1GridViewProductyAttributeShow.Rows[i].Cells[3].Text.ToString() == "0")
        ////                {
        ////                    TextBox textBox = (TextBox)Num1GridViewProductyAttributeShow.Rows[i].Cells[2].Controls[0];
        ////                    textBox.Text = dataTable.Rows[j]["AtrributeValue"].ToString();
        ////                }
        ////                else if (Num1GridViewProductyAttributeShow.Rows[i].Cells[3].Text.ToString() == "1")
        ////                {
        ////                    DropDownList dropDownList = (DropDownList)Num1GridViewProductyAttributeShow.Rows[i].Cells[2].Controls[0];
        ////                    dropDownList.SelectedValue = dataTable.Rows[j]["AtrributeValue"].ToString();

        ////                }
        ////                else if (Num1GridViewProductyAttributeShow.Rows[i].Cells[3].Text.ToString() == "2")
        ////                {
        ////                    TextBox textBox = (TextBox)Num1GridViewProductyAttributeShow.Rows[i].Cells[2].Controls[0];
        ////                    textBox.Text = dataTable.Rows[j]["AtrributeValue"].ToString();
        ////                }
        ////            }
        ////        }
        ////    }

        ////}

        ////ȡ����Ʒ�۸����Ʒ���Ե�ֵ


        //protected void GetProductAttribute2()
        //{
        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    DataTable dataTable = productAction.SearchEditProductAttribueValue2(this.hiddenFieldGuid.Value.Replace("'", ""));
        //    Num1GridViewProductyAttributePrice.DataSource = dataTable.DefaultView;
        //    Num1GridViewProductyAttributePrice.DataBind();

        //    //���󶨹�����Ʒ�۸�浽ViewSate��
        //    ViewState["dataProductyAttributePrice"] = dataTable;
        //    //�������������(���ʱ����������)
        //    BindDropDownListAttributeName();
        //}
        //#endregion

        ///// <summary>
        ///// ����Ƿ�ʹ�ò�Ʒ��
        ///// </summary>
        ///// <returns></returns>
        //public bool CheckProductLine()
        //{
        //    ShopSettings shopSettings = new ShopSettings();
        //    string filePath = Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");

        //    bool agentProductLine = bool.Parse(shopSettings.GetValue(filePath, "AgentProductLine"));

        //    return agentProductLine;
        //}

        ////���������ɷ�ʽ
        //public string CheckUnionType()
        //{
        //    ShopSettings shopSettings = new ShopSettings();
        //    string filePath = Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");

        //    return shopSettings.GetValue(filePath, "UnionType");
        //}


        //#region ��Ʒ����
        ///// <summary>
        ///// ��ʾ��Ʒ����
        ///// </summary>
        //protected void BindProductProp()
        //{
        //    string strId = GetDropDownListProductCategoryID();
        //    ShopNum1_ProductProp_Action productProp_Action = new ShopNum1_ProductProp_Action();
        //    DataTable datatable = productProp_Action.GetShopProductPropByCategoryID(strId);

        //    if (datatable != null && datatable.Rows.Count > 0)
        //    {
        //        RepeaterPropData.DataSource = datatable;
        //        RepeaterPropData.DataBind();
        //    }
        //    else
        //    {
        //        RepeaterPropData.DataSource = null;
        //        RepeaterPropData.DataBind();
        //    }
        //}

        //protected void RepeaterPropData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        HiddenField HiddenFieldID = (HiddenField)e.Item.FindControl("HiddenFieldID");
        //        HiddenField HiddenFieldShowType = (HiddenField)e.Item.FindControl("HiddenFieldShowType");
        //        RadioButtonList RadioButtonListPropValue = (RadioButtonList)e.Item.FindControl("RadioButtonListPropValue");
        //        DropDownList DropDownListPropValue = (DropDownList)e.Item.FindControl("DropDownListPropValue");
        //        CheckBoxList CheckBoxListPropValue = (CheckBoxList)e.Item.FindControl("CheckBoxListPropValue");
        //        TextBox TextBoxPropValue = (TextBox)e.Item.FindControl("TextBoxPropValue");
        //        ShopNum1_ProductPropValue_Action shopNum1_ProductPropValue_Action = new ShopNum1_ProductPropValue_Action();
        //        DataTable datatable = shopNum1_ProductPropValue_Action.GetPropValuesByPropID(HiddenFieldID.Value);


        //        if (datatable == null || datatable.Rows.Count == 0)
        //        {
        //            if (RadioButtonListPropValue.Visible == true)
        //            {
        //                RadioButtonListPropValue.Items.Clear();
        //            }
        //            if (DropDownListPropValue.Visible == true)
        //            {
        //                DropDownListPropValue.Items.Clear();
        //            }

        //            if (CheckBoxListPropValue.Visible == true)
        //            {
        //                CheckBoxListPropValue.Items.Clear();
        //            }
        //            if (TextBoxPropValue.Visible == true)
        //            {
        //                TextBoxPropValue.Text = string.Empty;
        //            }

        //            return;
        //        }


        //        switch (int.Parse(HiddenFieldShowType.Value))
        //        {
        //            case 1:

        //                RadioButtonListPropValue.Visible = true;
        //                RadioButtonListPropValue.DataValueField = "ID";
        //                RadioButtonListPropValue.DataTextField = "Name";
        //                RadioButtonListPropValue.DataSource = datatable;
        //                RadioButtonListPropValue.DataBind();
        //                break;
        //            case 2:
        //                DropDownListPropValue.Visible = true;
        //                DataRow dr = datatable.NewRow();
        //                dr["ID"] = "-1";
        //                dr["Name"] = "-��ѡ��-";
        //                datatable.Rows.InsertAt(dr, 0);
        //                DropDownListPropValue.DataValueField = "ID";
        //                DropDownListPropValue.DataTextField = "Name";
        //                DropDownListPropValue.DataSource = datatable;
        //                DropDownListPropValue.DataBind();
        //                break;
        //            case 3:
        //                CheckBoxListPropValue.Visible = true;
        //                for (int i = 0; i < datatable.Rows.Count; i++)
        //                {
        //                    ListItem item = new ListItem();
        //                    item.Text = datatable.Rows[i]["Name"].ToString();
        //                    item.Value = datatable.Rows[i]["ID"].ToString();
        //                    CheckBoxListPropValue.Items.Add(item);
        //                }
        //                break;
        //            case 4:
        //                TextBoxPropValue.Visible = true;
        //                break;
        //        }
        //    }
        //}

        //protected void AddProductProp(Guid guid)
        //{
        //    List<ShopNum1_ProductRelationProp> listProps = new List<ShopNum1_ProductRelationProp>();
        //    foreach (RepeaterItem item in RepeaterPropData.Items)
        //    {
        //        HiddenField HiddenFieldID = (HiddenField)item.FindControl("HiddenFieldID");
        //        HiddenField HiddenFieldShowType = (HiddenField)item.FindControl("HiddenFieldShowType");
        //        RadioButtonList RadioButtonListPropValue = (RadioButtonList)item.FindControl("RadioButtonListPropValue");
        //        DropDownList DropDownListPropValue = (DropDownList)item.FindControl("DropDownListPropValue");
        //        CheckBoxList CheckBoxListPropValue = (CheckBoxList)item.FindControl("CheckBoxListPropValue");
        //        TextBox TextBoxPropValue = (TextBox)item.FindControl("TextBoxPropValue");
        //        ShopNum1_ProductRelationProp RelationProp = new ShopNum1_ProductRelationProp();
        //        RelationProp.ProdGuid = guid;
        //        // RelationProp.Memlogid = MemLoginID;
        //        RelationProp.PropID = int.Parse(HiddenFieldID.Value);
        //        switch (int.Parse(HiddenFieldShowType.Value))
        //        {
        //            case 1:
        //                if (RadioButtonListPropValue.SelectedIndex == -1)
        //                {
        //                    break;
        //                }
        //                RelationProp.PropValueName = RadioButtonListPropValue.SelectedItem.Text;
        //                RelationProp.PropValueID = int.Parse(RadioButtonListPropValue.SelectedValue);
        //                listProps.Add(RelationProp);
        //                break;
        //            case 2:
        //                if (DropDownListPropValue.SelectedValue == "-1")
        //                {
        //                    break;
        //                }
        //                RelationProp.PropValueName = DropDownListPropValue.SelectedItem.Text;
        //                RelationProp.PropValueID = int.Parse(DropDownListPropValue.SelectedValue);
        //                listProps.Add(RelationProp);
        //                break;
        //            case 3:
        //                for (int i = 0; i < CheckBoxListPropValue.Items.Count; i++)
        //                {
        //                    if (CheckBoxListPropValue.Items[i].Selected)
        //                    {
        //                        ShopNum1_ProductRelationProp RelationProp2 = new ShopNum1_ProductRelationProp();
        //                        RelationProp2.ProdGuid = guid;
        //                        //RelationProp2.Memlogid = MemLoginID;
        //                        RelationProp2.PropID = int.Parse(HiddenFieldID.Value);
        //                        RelationProp2.PropValueName = CheckBoxListPropValue.Items[i].Text;
        //                        RelationProp2.PropValueID = int.Parse(CheckBoxListPropValue.Items[i].Value);
        //                        listProps.Add(RelationProp2);
        //                    }
        //                }
        //                break;
        //            case 4:
        //                if (TextBoxPropValue.Text.Trim() == string.Empty)
        //                {
        //                    break;
        //                }
        //                RelationProp.PropValueName = TextBoxPropValue.Text.Trim();
        //                RelationProp.PropValueID = -1;
        //                listProps.Add(RelationProp);
        //                break;
        //        }
        //    }
        //    if (listProps.Count == 0)
        //    {
        //        return;
        //    }
        //    ShopNum1_ProductRelationProp_Action shopProductRelationProp_Action = (ShopNum1_ProductRelationProp_Action)LogicFactory.CreateShopNum1_ProductRelationProp_Action();
        //    shopProductRelationProp_Action.Add(listProps);
        //}

        ////������վѡ���ID
        //public string GetDropDownListProductCategoryID()
        //{
        //    if (DropDownListProductCategoryID3.Visible == true && DropDownListProductCategoryID3.SelectedValue != "-1")
        //    {
        //        return DropDownListProductCategoryID3.SelectedValue;
        //    }
        //    else
        //    {
        //        if (DropDownListProductCategoryID2.Visible == true && DropDownListProductCategoryID2.SelectedValue != "-1")
        //        {
        //            return DropDownListProductCategoryID2.SelectedValue;
        //        }
        //        else
        //        {
        //            if (DropDownListProductCategoryID1.Visible == true && DropDownListProductCategoryID1.SelectedValue != "-1")
        //            {
        //                return DropDownListProductCategoryID1.SelectedValue;
        //            }
        //            else
        //            {
        //                return "-1";
        //            }
        //        }
        //    }
        //}

        ////������վѡ���Name
        //public string GetDropDownListProductCategoryName()
        //{
        //    if (DropDownListProductCategoryID3.Visible == true && DropDownListProductCategoryID3.SelectedValue != "-1")
        //    {
        //        return DropDownListProductCategoryID1.SelectedItem.Text + "/" + DropDownListProductCategoryID2.SelectedItem.Text + "/" + DropDownListProductCategoryID3.SelectedItem.Text;
        //    }
        //    else
        //    {
        //        if (DropDownListProductCategoryID2.Visible == true && DropDownListProductCategoryID2.SelectedValue != "-1")
        //        {
        //            return DropDownListProductCategoryID1.SelectedItem.Text + "/" + DropDownListProductCategoryID2.SelectedItem.Text;
        //        }
        //        else
        //        {
        //            if (DropDownListProductCategoryID1.Visible == true && DropDownListProductCategoryID1.SelectedValue != "-1")
        //            {
        //                return DropDownListProductCategoryID1.SelectedItem.Text;
        //            }
        //            else
        //            {
        //                return "-1";
        //            }
        //        }
        //    }
        //}


        //#endregion


        //#region  �Ա�api ����

        ////��ȡ����xml���ݵ�������
        //private List<ShopNum1_TbSysItemCat> XmlInsetObject(string fatherCid)
        //{
        //    Dictionary<string, string> param = new Dictionary<string, string>();//���� APIӦ�ü��������
        //    //�践�ص��ֶ��б�
        //    param.Add("fields", "cid,parent_cid,name,is_parent,status,sort_order");
        //    param.Add("parent_cid", fatherCid);
        //    string strXml = TopAPI.Post("taobao.itemcats.get", TopClient.AdminSession, param);
        //    List<ShopNum1_TbSysItemCat> sysItems = new List<ShopNum1_TbSysItemCat>();//�����Ա���Ʒϵͳ����
        //    Parser parser = new Parser();//�������XML����
        //    ErrorRsp err = new ErrorRsp();
        //    //total = parser.XmlToTotalResults(strXml, "itemcats.get");
        //    parser.XmlToObject2<ShopNum1_TbSysItemCat>(strXml, "itemcats_get", "item_cats/item_cat", sysItems, err);

        //    if (err.IsError == true)
        //    {
        //        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"������룺{0}\\r����ԭ��{1}\\r����������{2}-{3}\");window.location.href=\"/index.aspx\";", err.code, err.msg, err.sub_code, err.sub_msg), true);
        //        return null;
        //    }

        //    return sysItems;
        //}

        ///// <summary>
        ///// �Ա���Ʒ����
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void updateTbItem(string numiid)
        //{

        //    Dictionary<string, string> param = new Dictionary<string, string>();
        //    string strXml = string.Empty;

        //    param.Add("fields", "num_iid,props,input_str,cid");
        //    param.Add("num_iid", numiid);
        //    param.Add("nick", TopClient.AdminUserNick);

        //    strXml = TopAPI.Post("taobao.item.get", TopClient.AdminSession, param);
        //    ErrorRsp err = new ErrorRsp();
        //    ShopNum1_TbItem tbitem = new ShopNum1_TbItem();
        //    new Parser().XmlToObject2(strXml, "item_get", "item", tbitem, err);
        //    if (err.IsError || tbitem == null)//�ж��Ƿ���¹����з�������
        //    {
        //        ////string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"�����Ʒʧ�ܣ�������룺{0}\\r����ԭ��{1}\\r����������{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
        //        return;
        //    }


        //    param.Clear();
        //    param.Add("num_iid", tbitem.num_iid.ToString());
        //    param.Add("cid", tbitem.cid.ToString());
        //    param.Add("title", this.TextBoxName.Text.Trim());
        //    param.Add("num", this.TextBoxRepertoryCount.Text.Trim());
        //    param.Add("price", this.TextBoxShopPrice.Text.Trim());

        //    //if (tbitem.props != null)
        //    //{
        //    //    param.Add("props", tbitem.props);
        //    //}
        //    //if (tbitem.input_str != null)
        //    //{
        //    //    param.Add("input_str", tbitem.input_str);

        //    //}

        //    strXml = TopAPI.Post("taobao.item.update", TopClient.AdminSession, param);
        //    ItemResponse itemRsp = new ItemResponse();
        //    new Parser().XmlToObject2(strXml, "item_update", "item", itemRsp, err);

        //    if (!err.IsError)
        //    {
        //        ClientScript.RegisterClientScriptBlock(typeof(Page), "err", "alert('�޸ĳɹ�')", true);
        //    }
        //    else 
        //    {
        //        ClientScript.RegisterClientScriptBlock(typeof(Page), "err", "alert('"+err.msg+"')", true);
        //    }
        //}

        ///// <summary>
        ///// ��Ʒͬ��״̬
        ///// </summary>
        ///// <param name="guid"></param>
        ///// <returns></returns>
        //protected string GetItemStatus(string guid)
        //{
        //    if (!TopClient.isAdminSessionTrue)
        //    {
        //        return "δ��Ȩ";
        //    }
        //    //ѡ�����Ա���Ʒ�Ƿ����

        //  //  CheckProductByNumiid(guid);

        //    ShopNum1_TbItem_Action tbItemOperate = (ShopNum1_TbItem_Action)LogicTbFactory.CreateShopNum1_TbItem_Action();

        //    DataSet ds = tbItemOperate.checkItemSiteExists(guid);
        //    if (ds == null || ds.Tables.Count == 0)
        //    {
        //        return "δͬ��";
        //    }
        //    else
        //    {
        //        int cout = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalCount"]);
        //        if (cout > 0)
        //            return "��ͬ��";
        //        else
        //            return "δͬ��";
        //    }

        //}

        ////private void CheckProductByNumiid(string numiid)
        ////{
        ////    Dictionary<string, string> param = new Dictionary<string, string>();
        ////    param.Add("fields", "num_iid");
        ////    param.Add("nick", TopClient.AdminUserNick);
        ////    param.Add("num_iid", numiid);

        ////    string strXml = TopAPI.Post("taobao.item.get", TopClient.AdminSession, param);
        ////    //ShopNum1_TbItem tbItem = new ShopNum1_TbItem();//������Ʒ
        ////    //ErrorRsp errItem = new ErrorRsp();//����������
        ////    //Parser parser = new Parser();
        ////    //parser.XmlToObject2(strXml, "item_get", "item", tbItem, errItem);

        ////    File.AppendAllText(HttpContext.Current.Server.MapPath("~/log/log.txt"), strXml + "\r\n" + numiid, Encoding.UTF8);
        ////    //if(strXml .Contains())
        ////    //{

        ////    //}


        ////}

        ///// <summary>
        ///// ��ȡ��Ʒ������numiid
        ///// </summary>
        ///// <param name="guid"></param>
        ///// <returns></returns>
        //private decimal GetNumiid(string guid)
        //{

        //    ShopNum1_TbItem_Action tbItemOperate = (ShopNum1_TbItem_Action)LogicTbFactory.CreateShopNum1_TbItem_Action();
        //    DataSet ds = tbItemOperate.checkItemSiteExists(guid);
        //    if (ds == null || ds.Tables.Count == 0)
        //    {
        //        return 0;
        //    }

        //    else
        //    {
        //        int cout = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalCount"]);
        //        if (cout > 0)
        //        {
        //            if (ds.Tables[1] == null)
        //                return 0;
        //            return Convert.ToDecimal(ds.Tables[1].Rows[0]["num_iid"]);
        //        }
        //        else
        //            return 0;
        //    }

        //}
        ///// <summary>
        ///// �����վ����Ʒ�Ա��Ƿ����
        ///// </summary>
        ///// <param name="sitecid"></param>
        ///// <returns></returns>
        //private bool CheckSite(string sitecid)
        //{
        //    ShopNum1_TbItem_Action itemOperate = (ShopNum1_TbItem_Action)LogicTbFactory.CreateShopNum1_TbItem_Action();
        //    DataSet ds = itemOperate.checkItemSiteExists(sitecid);
        //    if (ds == null || ds.Tables.Count == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        if (Convert.ToInt32(ds.Tables[0].Rows[0]["TotalCount"]) == 0)
        //            return false;
        //        else
        //            return true;
        //    }
        //}


        ///// ���Ա���Ʒ����
        ///// </summary>
        //protected void BindTbCat()
        //{


        //    this.TreeViewTb.Nodes.Clear();

        //    ShopNum1_TbSellCat_Action tbsellCatOperate = (ShopNum1_TbSellCat_Action)LogicTbFactory.CreateShopNum1_TbSellCat_Action();
        //    //ȡ��������
        //    DataTable dataTable = tbsellCatOperate.GetAllCidByShopName(TopClient.AdminUserNick);

        //    foreach (DataRow dr in dataTable.Rows)
        //    {

        //        TreeNode node = new TreeNode();
        //        if (Convert.ToDecimal(dr["parent_cid"]) == 0)
        //        {
        //            node.Text = dr["name"].ToString();
        //            node.Value = dr["cid"].ToString().Trim();
        //            node.SelectAction = TreeNodeSelectAction.Select;
        //            node.Expand();

        //            this.TreeViewTb.Nodes.Add(node);
        //            ///�������s����
        //            AddSubTbCat(node, dataTable, dr["cid"].ToString());
        //        }


        //    }
        //}
        ////����ӷ���
        //protected void AddSubTbCat(TreeNode fatherNode, DataTable dataTable, string cid)
        //{
        //    ShopNum1_TbSellCat_Action tbsellCatOperate = (ShopNum1_TbSellCat_Action)LogicTbFactory.CreateShopNum1_TbSellCat_Action();
        //    foreach (DataRow dr in dataTable.Rows)
        //    {
        //        TreeNode node = new TreeNode();
        //        if (dr["parent_cid"].ToString() == cid)
        //        {
        //            node.Text = dr["name"].ToString();
        //            node.Value = dr["cid"].ToString().Trim();
        //            node.SelectAction = TreeNodeSelectAction.Select;
        //            node.Expand();
        //            fatherNode.ChildNodes.Add(node);

        //        }
        //    }

        //}

        ///// <summary>
        /////��һ�б�
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void lbox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //System.Threading.Thread.Sleep(2000);
        //    ViewState["cid"] = lbox1.SelectedValue;
        //    PropRest();
        //    List<ShopNum1_TbSysItemCat> sysItems = XmlInsetObject(lbox1.SelectedValue);
        //    if (sysItems != null && sysItems.Count != 0)
        //    {


        //        foreach (ShopNum1_TbSysItemCat sysItem in sysItems)
        //        {
        //            if (sysItem.is_parent == true)
        //            {
        //                sysItem.name = sysItem.name + "           ->";
        //            }

        //        }

        //        lbox2.Visible = true;
        //        lbox3.Visible = false;
        //        lbox4.Visible = false;
        //        lbox5.Visible = false;


        //        lbox2.DataSource = sysItems;
        //        lbox2.DataTextField = "name";
        //        lbox2.DataValueField = "cid";
        //        lbox2.DataBind();
        //        // lbox2.Items.Insert(0, new ListItem("��ѡ��","0"));
        //        //lbox2.Style.Add(HtmlTextWriterStyle.Display,"block"


        //    }
        //    else
        //    {
        //        lbox2.Visible = false;
        //        lbox3.Visible = false;
        //        lbox4.Visible = false;
        //        lbox5.Visible = false;
        //        ViewState["cid"] = lbox1.SelectedValue;
        //        PropValuesBind(0, 0);
        //        GetCatProp(true);
        //        GetCatProp(false);

        //    }
        //}

        ///// <summary>
        ///// ���Գ�ʼ��
        ///// </summary>
        //private void PropRest()
        //{
        //    RepeaterProp.DataSource = null;
        //    RepeaterPropSale.DataSource = null;
        //    RepeaterProp.DataBind();
        //    RepeaterPropSale.DataBind();
        //    divPropValues.Visible = false;
        //    lblPropValue.Text = "";
        //    lblPropValue.Visible = false;
        //    lblPropValue3.Visible = false;
        //    ddlistPropValues1.DataSource = null;
        //    ddlistPropValues2.DataSource = null;
        //    ddlistPropValues3.DataSource = null;
        //    ddlistPropValues1.DataBind();
        //    ddlistPropValues2.DataBind();
        //    ddlistPropValues3.DataBind();
        //    ddlistPropValues1.Visible = false;
        //    ddlistPropValues2.Visible = false;
        //    ddlistPropValues3.Visible = false;
        //}
        ///// <summary>
        /////�ڶ��б�
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void lbox2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ViewState["cid"] = lbox2.SelectedValue;
        //    PropRest();
        //    List<ShopNum1_TbSysItemCat> sysItems = XmlInsetObject(lbox2.SelectedValue);
        //    if (sysItems != null && sysItems.Count != 0)
        //    {


        //        foreach (ShopNum1_TbSysItemCat sysItem in sysItems)
        //        {
        //            if (sysItem.is_parent == true)
        //            {
        //                sysItem.name = sysItem.name + "           ->";
        //            }

        //        }


        //        lbox3.Visible = true;
        //        lbox4.Visible = false;
        //        lbox5.Visible = false;


        //        lbox3.DataSource = sysItems;
        //        lbox3.DataTextField = "name";
        //        lbox3.DataValueField = "cid";
        //        lbox3.DataBind();
        //        // lbox3.Items.Insert(0, new ListItem("��ѡ��","0"));
        //        //lbox2.Style.Add(HtmlTextWriterStyle.Display,"block"


        //    }
        //    else
        //    {
        //        lbox3.Visible = false;
        //        lbox4.Visible = false;
        //        lbox5.Visible = false;
        //        ViewState["cid"] = lbox2.SelectedValue;
        //        PropValuesBind(0, 0);
        //        GetCatProp(true);
        //        GetCatProp(false);

        //    }
        //}
        ///// <summary>
        /////�����б�
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void lbox3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ViewState["cid"] = lbox3.SelectedValue;
        //    PropRest();
        //    List<ShopNum1_TbSysItemCat> sysItems = XmlInsetObject(lbox3.SelectedValue);
        //    if (sysItems != null && sysItems.Count != 0)
        //    {


        //        foreach (ShopNum1_TbSysItemCat sysItem in sysItems)
        //        {
        //            if (sysItem.is_parent == true)
        //            {
        //                sysItem.name = sysItem.name + "           ->";
        //            }

        //        }

        //        lbox4.Visible = true;
        //        lbox5.Visible = false;


        //        lbox4.DataSource = sysItems;
        //        lbox4.DataTextField = "name";
        //        lbox4.DataValueField = "cid";
        //        lbox4.DataBind();
        //        //  lbox4.Items.Insert(0, new ListItem("��ѡ��","0"));
        //        //lbox2.Style.Add(HtmlTextWriterStyle.Display,"block"


        //    }
        //    else
        //    {

        //        lbox4.Visible = false;
        //        lbox5.Visible = false;
        //        ViewState["cid"] = lbox3.SelectedValue;
        //        PropValuesBind(0, 0);
        //        GetCatProp(true);
        //        GetCatProp(false);

        //    }
        //}

        ///// <summary>
        ///// �����б�
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void lbox4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ViewState["cid"] = lbox4.SelectedValue;
        //    PropRest();
        //    List<ShopNum1_TbSysItemCat> sysItems = XmlInsetObject(lbox4.SelectedValue);
        //    if (sysItems != null && sysItems.Count != 0)
        //    {


        //        foreach (ShopNum1_TbSysItemCat sysItem in sysItems)
        //        {
        //            if (sysItem.is_parent == true)
        //            {
        //                sysItem.name = sysItem.name + "           ->";
        //            }

        //        }


        //        lbox5.Visible = true;


        //        lbox5.DataSource = sysItems;
        //        lbox5.DataTextField = "name";
        //        lbox5.DataValueField = "cid";
        //        lbox5.DataBind();
        //        //  lbox5.Items.Insert(0, new ListItem("��ѡ��","0"));
        //        //lbox2.Style.Add(HtmlTextWriterStyle.Display,"block"


        //    }
        //    else
        //    {


        //        lbox5.Visible = false;
        //        ViewState["cid"] = lbox4.SelectedValue;
        //        PropValuesBind(0, 0);
        //        GetCatProp(true);
        //        GetCatProp(false);

        //    }
        //}

        ///// <summary>
        ///// �����б�
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void lbox5_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    PropRest();
        //    ViewState["cid"] = lbox5.SelectedValue;
        //    PropValuesBind(0, 0);
        //    GetCatProp(true);
        //    GetCatProp(false);
        //}

        ///// <summary>
        ///// ��ȡ��Ʒ���
        ///// </summary>
        ///// <param name="cid"></param>
        //private void GetTbProduct(decimal cid)
        //{
        //    string strXml = string.Empty;
        //    Dictionary<string, string> param = new Dictionary<string, string>();
        //    param.Add("fields", "product_id,tsc,cat_name,name");
        //    param.Add("nick", TopClient.AdminUserNick);
        //    param.Add("cid", ViewState["cid"].ToString());
        //    strXml = TopAPI.Post("taobao.products.get", TopClient.AdminSession, param);
        //    ErrorRsp err = new ErrorRsp();
        //    List<ShopNum1_TbProduct> tbProducts = new List<ShopNum1_TbProduct>();
        //    new Parser().XmlToObject2<ShopNum1_TbProduct>(strXml, "products_get", "products/product", tbProducts, err);
        //    if (err.IsError == true)//�ж��Ƿ���¹����з�������
        //    {
        //        //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //        // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"�����Ʒʧ�ܣ�������룺{0}\\r����ԭ��{1}\\r����������{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
        //        return;
        //    }
        //}

        ///// <summary>
        ///// ʡ�ݰ�
        ///// </summary>
        //private void ProvinceBind()
        //{
        //    ShopNum1_TbAddress_Action tbAddress = (ShopNum1_TbAddress_Action)LogicTbFactory.CreateShopNum1_TbAddress_Action();
        //    ddlProvince.DataSource = tbAddress.GetCitysByParent(1);
        //    ddlProvince.DataTextField = "name";
        //    ddlProvince.DataValueField = "Id";
        //    ddlProvince.DataBind();
        //    ddlProvince.SelectedIndex = 0;
        //}


        ///// <summary>
        ///// ���а�
        ///// </summary>
        ///// <param name="Id"></param>
        //private void CitysBind()
        //{
        //    int Id = Convert.ToInt32(ddlProvince.SelectedValue);
        //    ShopNum1_TbAddress_Action tbAddress = (ShopNum1_TbAddress_Action)LogicTbFactory.CreateShopNum1_TbAddress_Action();
        //    ddlCity.DataSource = tbAddress.GetCitysByParent(Id);
        //    ddlCity.DataValueField = "Id";
        //    ddlCity.DataTextField = "name";
        //    ddlCity.DataBind();

        //}


        ///// <summary>
        ///// ʡ���¼�
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    CitysBind();
        //}


        //#region ��Ʒ����
        //#region  �ǹؼ�����

        ///// <summary>
        ///// ��ȡ��Ʒ����
        ///// </summary>
        ///// <param name="cid"></param>
        //private void GetCatProp(bool isSale)
        //{

        //    Dictionary<string, string> param = new Dictionary<string, string>();
        //    param.Add("fields", "multi,cid,pid,parent_pid,prop_name,sort_order,is_parent,vid,name,name_alias,status,parent_vid,must,is_enum_prop");
        //    param.Add("cid", ViewState["cid"].ToString());
        //    param.Add("parent_pid", "0");
        //    string is_sale_prop = isSale ? "true" : "false";
        //    param.Add("is_sale_prop", is_sale_prop);
        //    param.Add("is_key_prop", "false");
        //    // param.Add("is_input_prop", "false");
        //    // param.Add("pvs", "20000;");
        //    //param.Add("datetime", "2005-01-01");


        //    string strXml = string.Empty;
        //    strXml = TopAPI.Post("taobao.itemprops.get", TopClient.AdminSession, param); ;
        //    ErrorRsp err = new ErrorRsp();
        //    List<ShopNum1_TbPropValue> props = new List<ShopNum1_TbPropValue>();
        //    new Parser().XmlToObject2<ShopNum1_TbPropValue>(strXml, "itemprops_get", "item_props/item_prop", props, err);
        //    if (err.IsError)//�ж��Ƿ���¹����з�������
        //    {
        //        //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //        // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"��ӷǹؼ�����ʧ�ܣ�������룺{0}\\r����ԭ��{1}\\r����������{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
        //        return;
        //    }
        //    else
        //    {
        //        if (!isSale)
        //        {
        //            RepeaterProp.DataSource = props;
        //            RepeaterProp.DataBind();
        //        }
        //        else
        //        {
        //            RepeaterPropSale.DataSource = props;
        //            RepeaterPropSale.DataBind();
        //        }

        //    }
        //}


        ///// <summary>
        ///// ����ֵ�� 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void RepeaterProp_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        Literal literpid = (Literal)e.Item.FindControl("literpid");
        //        Literal litermust = (Literal)e.Item.FindControl("litermust");
        //        Label lblPropName = (Label)e.Item.FindControl("lblPropName");
        //        DropDownList ddlistValues = (DropDownList)e.Item.FindControl("ddlistValues");
        //        DropDownList ddlistValues2 = (DropDownList)e.Item.FindControl("ddlistValues2");
        //        CheckBoxList cblistValues = (CheckBoxList)e.Item.FindControl("cblistValues");
        //        if (ddlistValues.Visible)
        //        {

        //            ddlistValues.DataSource = GetPropValues(literpid.Text.Trim());
        //            ddlistValues.DataTextField = "name";
        //            ddlistValues.DataValueField = "pvs";
        //            ddlistValues.DataBind();
        //            ddlistValues.Items.Insert(0, new ListItem("��ѡ��", "0"));
        //            if (ddlistValues.SelectedValue != "0")
        //            {
        //                ShopNum1_TbPropValue propson = GetSonProp(ddlistValues.SelectedValue);
        //                if (propson != null && propson.name != null)
        //                {
        //                    ddlistValues2.Visible = true;
        //                    lblPropName.Visible = true;
        //                    lblPropName.Text = propson.name;
        //                    ddlistValues2.DataSource = GetPropValues(propson.pid.ToString());
        //                    ddlistValues2.DataTextField = "name";
        //                    ddlistValues2.DataValueField = "pvs";
        //                    ddlistValues2.DataBind();
        //                    ddlistValues2.Items.Insert(0, new ListItem("��ѡ��", "0"));
        //                }
        //            }


        //        }
        //        else
        //        {
        //            cblistValues.DataSource = GetPropValues(literpid.Text.Trim());
        //            cblistValues.DataTextField = "name";
        //            cblistValues.DataValueField = "vid";
        //            cblistValues.DataBind();

        //        }

        //    }
        //}


        ///// <summary>
        ///// ��ȡ����ֵ
        ///// </summary>
        ///// <param name="cid"></param>
        ///// <param name="pid"></param>
        ///// <returns></returns>
        //private List<ShopNum1_TbPropValue> GetPropValues(string pid)
        //{
        //    Dictionary<string, string> param = new Dictionary<string, string>();
        //    param.Add("fields", "cid,pid,parent_pid,prop_name,sort_order,is_parent,vid,name,name_alias,status,parent_vid");
        //    param.Add("cid", ViewState["cid"].ToString());
        //    param.Add("pvs", pid);
        //    string strXml = TopAPI.Post("taobao.itempropvalues.get", TopClient.AdminSession, param);
        //    List<ShopNum1_TbPropValue> propValues = new List<ShopNum1_TbPropValue>();
        //    ErrorRsp err = new ErrorRsp();
        //    new Parser().XmlToObject2<ShopNum1_TbPropValue>(strXml, "itempropvalues_get", "prop_values/prop_value", propValues, err);
        //    if (err.IsError == true)//�ж��Ƿ���¹����з�������
        //    {
        //        //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //        // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"{4}��ȡ����ֵ����������룺{0}\\r����ԭ��{1}\\r����������{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg,pid.ToString()), true);
        //        return null;
        //    }
        //    foreach (ShopNum1_TbPropValue propvalue in propValues)
        //    {
        //        propvalue.pvs = pid + ":" + propvalue.vid;
        //    }
        //    return propValues;

        //}

        ///// <summary>
        ///// �������԰�
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void RepeaterPropSale_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        Literal literpid = (Literal)e.Item.FindControl("literpid");
        //        Literal litermust = (Literal)e.Item.FindControl("litermust");

        //        DropDownList ddlistValues = (DropDownList)e.Item.FindControl("ddlistValues");
        //        CheckBoxList cblistValues = (CheckBoxList)e.Item.FindControl("cblistValues");
        //        if (ddlistValues.Visible)
        //        {
        //            ddlistValues.DataSource = GetPropValues(literpid.Text.Trim());
        //            ddlistValues.DataTextField = "name";
        //            ddlistValues.DataValueField = "pvs";

        //            ddlistValues.DataBind();
        //            ddlistValues.Items.Insert(0, new ListItem("��ѡ��", "0"));
        //        }
        //        else
        //        {
        //            cblistValues.DataSource = GetPropValues(literpid.Text.Trim());
        //            cblistValues.DataTextField = "name";
        //            cblistValues.DataValueField = "pvs";
        //            cblistValues.DataBind();


        //        }

        //    }
        //}

        //protected void ddlistValues_OnSelectedIndexChanged(object sender, EventArgs e)
        //{

        //    DropDownList ddlistValues = sender as DropDownList;
        //    Repeater rps = ddlistValues.Parent.Parent as Repeater;
        //    int n = ((RepeaterItem)ddlistValues.Parent).ItemIndex;
        //    Label lblPropName = (Label)(rps.Items[n].FindControl("lblPropName"));
        //    DropDownList ddlistValues2 = (DropDownList)(rps.Items[n].FindControl("ddlistValues2"));
        //    lblPropName.Visible = false;
        //    lblPropName.Text = "";
        //    ddlistValues2.Visible = false;
        //    ddlistValues2.DataSource = null;
        //    ddlistValues2.DataBind();

        //    if (ddlistValues.SelectedValue != "0")
        //    {
        //        ShopNum1_TbPropValue prop = GetSonProp(ddlistValues.SelectedValue);
        //        if (prop != null && prop.name != null)
        //        {
        //            lblPropName.Visible = true;
        //            lblPropName.Text = prop.name;
        //            ddlistValues2.Visible = true;
        //            ddlistValues2.DataSource = GetPropValues(prop.pid.ToString());
        //            ddlistValues2.DataTextField = "name";
        //            ddlistValues2.DataValueField = "pvs";
        //            ddlistValues2.DataBind();
        //            ddlistValues2.Items.Insert(0, new ListItem("��ѡ��", "0"));
        //        }
        //    }

        //}

        //protected void RepeaterPropSale_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{

        //}

        //protected void RepeaterProp_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{

        //}

        //#endregion

        //#region  �ؼ�����Ʒ�ƴ���
        ///// <summary>
        ///// Ʒ��
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void ddlistPropValues1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string props = ddlistPropValues1.SelectedValue;
        //    //decimal pid = decimal.Parse(props.Split(':')[0]);
        //    //decimal vid = decimal.Parse(props.Split(':')[1]);
        //    PropValues2Bind(props);


        //}

        //protected void ddlistPropValues2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string props = ddlistPropValues1.SelectedValue;
        //    props += ";" + ddlistPropValues2.SelectedValue;
        //    ddlistPropValues3.DataSource = null;
        //    ddlistPropValues3.DataBind();
        //    lblPropValue3.Visible = false;
        //    PropValues3Bind(props);
        //}

        ///// <summary>
        ///// Ʒ�ư�
        ///// </summary>
        ///// <param name="cid"></param>
        ///// <param name="parent_vid"></param>
        ///// <param name="parent_pid"></param>
        //private void PropValuesBind(decimal parent_vid, decimal parent_pid)
        //{

        //    Dictionary<string, string> param = new Dictionary<string, string>();
        //    param.Add("fields", "pid,name");
        //    param.Add("cid", ViewState["cid"].ToString());
        //    param.Add("parent_pid", parent_pid.ToString());
        //    param.Add("is_key_prop", "true");
        //    // param.Add("is_input_prop", "false");
        //    // param.Add("pvs", "20000;");
        //    //param.Add("datetime", "2005-01-01");


        //    string strXml = string.Empty;
        //    strXml = TopAPI.Post("taobao.itemprops.get", TopClient.AdminSession, param); ;
        //    ErrorRsp err = new ErrorRsp();
        //    ShopNum1_TbPropValue prop = new ShopNum1_TbPropValue();
        //    new Parser().XmlToObject2(strXml, "itemprops_get", "item_props/item_prop", prop, err);
        //    if (err.IsError)//�ж��Ƿ���¹����з�������
        //    {
        //        //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"��Ʒ������ʧ�ܣ�������룺{0}\\r����ԭ��{1}\\r����������{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
        //        return;
        //    }
        //    if (prop != null)
        //    {
        //        lblPropName.Text = prop.name;
        //        List<ShopNum1_TbPropValue> propvalues = GetPropValues(prop.pid.ToString());
        //        //DataTable dt = new DataTable();
        //        //dt.Columns.Add("name");
        //        //dt.Columns.Add("pvs");

        //        //foreach (ShopNum1_TbPropValue propvalue in propvalues)
        //        //{
        //        //    DataRow row = dt.NewRow();
        //        //    row["name"] = propvalue.name;
        //        //    row["pvs"] = propvalue.pvs;
        //        //    dt.Rows.Add(row);


        //        //}
        //        if (propvalues == null || propvalues.Count == 0)
        //        {
        //            PropRest();
        //            return;
        //        }
        //        divPropValues.Visible = true;
        //        ddlistPropValues1.Visible = true;
        //        ddlistPropValues1.DataSource = propvalues;
        //        ddlistPropValues1.DataTextField = "name";
        //        ddlistPropValues1.DataValueField = "pvs";
        //        ddlistPropValues1.DataBind();
        //        ddlistPropValues1.Items.Insert(0, new ListItem("��ѡ��", "0"));
        //    }
        //    else
        //    {
        //        PropRest();
        //    }

        //}

        ///// <summary>
        ///// ���صڶ�����
        ///// </summary>
        ///// <param name="props"></param>
        ///// <returns></returns>
        //private ShopNum1_TbPropValue GetSonProp(string props)
        //{
        //    Dictionary<string, string> param = new Dictionary<string, string>();
        //    param.Add("fields", "cid,pid,parent_pid,prop_name,sort_order,is_parent,vid,name,name_alias,status,parent_vid");
        //    param.Add("cid", ViewState["cid"].ToString());
        //    // param.Add("pvs", props);
        //    param.Add("child_path", props);
        //    string strXml = TopAPI.Post("taobao.itemprops.get", TopClient.AdminSession, param);
        //    ShopNum1_TbPropValue prop2 = new ShopNum1_TbPropValue();
        //    ErrorRsp err = new ErrorRsp();
        //    new Parser().XmlToObject2(strXml, "itemprops_get", "item_props/item_prop", prop2, err);
        //    if (err.IsError == true)//�ж��Ƿ���¹����з�������
        //    {
        //        //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //        return null;

        //    }
        //    else
        //    {
        //        return prop2;
        //    }
        //}

        ///// <summary>
        ///// Ʒ����չ����
        ///// </summary>
        ///// <param name="cid"></param>
        ///// <param name="parent_vid"></param>
        ///// <param name="parent_pid"></param>
        //private void PropValues2Bind(string props)
        //{

        //    Dictionary<string, string> param = new Dictionary<string, string>();
        //    param.Add("fields", "cid,pid,parent_pid,prop_name,sort_order,is_parent,vid,name,name_alias,status,parent_vid");
        //    param.Add("cid", ViewState["cid"].ToString());
        //    // param.Add("pvs", props);
        //    param.Add("child_path", props);
        //    string strXml = TopAPI.Post("taobao.itemprops.get", TopClient.AdminSession, param);
        //    ShopNum1_TbPropValue prop2 = new ShopNum1_TbPropValue();
        //    ErrorRsp err = new ErrorRsp();
        //    new Parser().XmlToObject2(strXml, "itemprops_get", "item_props/item_prop", prop2, err);
        //    if (err.IsError == true)//�ж��Ƿ���¹����з�������
        //    {
        //        //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"Ʒ����չ����ʧ�ܣ�������룺{0}\\r����ԭ��{1}\\r����������{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);

        //    }
        //    lblPropValue.Text = prop2.name;
        //    List<ShopNum1_TbPropValue> propvalues2 = new List<ShopNum1_TbPropValue>();
        //    propvalues2 = GetPropValues(prop2.pid.ToString());
        //    if (propvalues2 != null && propvalues2.Count != 0)
        //    {

        //        ddlistPropValues2.Visible = true;
        //        ddlistPropValues2.DataSource = propvalues2;
        //        ddlistPropValues2.DataTextField = "name";
        //        ddlistPropValues2.DataValueField = "pvs";
        //        ddlistPropValues2.DataBind();
        //        ddlistPropValues2.Items.Insert(0, new ListItem("��ѡ��", "0"));
        //    }
        //    else
        //    {
        //        ddlistPropValues2.Visible = false;
        //        lblPropValue.Text = "";
        //    }

        //}

        ///// <summary>
        ///// ��������ֵ��
        ///// </summary>
        ///// <param name="props"></param>
        //private void PropValues3Bind(string props)
        //{

        //    Dictionary<string, string> param = new Dictionary<string, string>();
        //    param.Add("fields", "name,pid");
        //    param.Add("cid", ViewState["cid"].ToString());
        //    // param.Add("pvs", props);
        //    param.Add("child_path", props);
        //    string strXml = TopAPI.Post("taobao.itemprops.get", TopClient.AdminSession, param);
        //    ShopNum1_TbPropValue prop2 = new ShopNum1_TbPropValue();
        //    ErrorRsp err = new ErrorRsp();
        //    new Parser().XmlToObject2(strXml, "itemprops_get", "item_props/item_prop", prop2, err);
        //    if (err.IsError == true)//�ж��Ƿ���¹����з�������
        //    {
        //        //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"�����Ʒ����ʧ�ܣ�������룺{0}\\r����ԭ��{1}\\r����������{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
        //        return;

        //    }
        //    if (prop2 == null || prop2.name == null || prop2.name == "")
        //    {
        //        lblPropValue3.Visible = false;
        //        ddlistPropValues3.Visible = false;
        //        ddlistPropValues3.DataSource = null;
        //        ddlistPropValues3.DataBind();

        //        return;
        //    }
        //    lblPropValue3.Visible = true;
        //    lblPropValue3.Text = prop2.name;
        //    List<ShopNum1_TbPropValue> propvalues2 = new List<ShopNum1_TbPropValue>();
        //    propvalues2 = GetPropValues(prop2.pid.ToString());
        //    if (propvalues2 != null && propvalues2.Count != 0)
        //    {

        //        ddlistPropValues3.Visible = true;
        //        ddlistPropValues3.DataSource = propvalues2;
        //        ddlistPropValues3.DataTextField = "name";
        //        ddlistPropValues3.DataValueField = "pvs";
        //        ddlistPropValues3.DataBind();
        //        ddlistPropValues3.Items.Insert(0, new ListItem("��ѡ��", "0"));
        //    }
        //    else
        //    {
        //        ddlistPropValues3.Visible = false;
        //        lblPropValue.Text = "";
        //    }

        //}


        //#endregion


        ///// <summary>
        ///// ��ȡ����props �ķ���
        ///// </summary>
        //protected string GetAddProps()
        //{

        //    StringBuilder props = new StringBuilder();
        //    //if (ddlistPropValues1.DataSource != null)
        //    //{

        //    ///�ؼ�����
        //    if (ddlistPropValues1.SelectedValue != "0" && ddlistPropValues1.SelectedValue != string.Empty)
        //    {
        //        props.Append(ddlistPropValues1.SelectedValue + ";");
        //    }
        //    //}
        //    //if (ddlistPropValues2.DataSource != null)
        //    //{

        //    if (ddlistPropValues2.SelectedValue != "0" && ddlistPropValues2.SelectedValue != string.Empty)
        //    {
        //        props.Append(ddlistPropValues2.SelectedValue + ";");
        //    }
        //    if (ddlistPropValues3.SelectedValue != "0" && ddlistPropValues3.SelectedValue != string.Empty)
        //    {
        //        props.Append(ddlistPropValues3.SelectedValue + ";");

        //    }
        //    ///��������
        //    for (int i = 0; i < RepeaterProp.Items.Count; i++)
        //    {
        //        Literal literpid = (Literal)RepeaterProp.Items[i].FindControl("literpid");
        //        DropDownList ddlistValues = (DropDownList)RepeaterProp.Items[i].FindControl("ddlistValues");
        //        DropDownList ddlistValues2 = (DropDownList)RepeaterProp.Items[i].FindControl("ddlistValues2");
        //        CheckBoxList cblistValues = (CheckBoxList)RepeaterProp.Items[i].FindControl("cblistValues");
        //        if (ddlistValues.Visible)
        //        {
        //            if (ddlistValues.SelectedValue != "0" && ddlistValues.SelectedValue != string.Empty)
        //            {
        //                //  props.Append(literpid.Text.Trim()+":"+ddlistValues.SelectedValue + ";");
        //                props.Append(ddlistValues.SelectedValue + ";");
        //                if (ddlistValues2.Visible)
        //                {
        //                    if (ddlistPropValues2.SelectedValue != "0" && ddlistPropValues2.SelectedValue != string.Empty)
        //                    {
        //                        // props.Append(literpid.Text.Trim()+":"+ddlistValues2.SelectedValue + ";");
        //                        props.Append(ddlistValues2.SelectedValue + ";");
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            foreach (ListItem item in cblistValues.Items)
        //            {
        //                if (item.Selected)
        //                {
        //                    //  props.Append(literpid.Text.Trim()+":"+item.Value + ";");
        //                    props.Append(item.Value + ";");
        //                }

        //            }
        //        }

        //    }

        //    ///�������Ա� 
        //    for (int i = 0; i < RepeaterPropSale.Items.Count; i++)
        //    {
        //        Literal literpid = (Literal)RepeaterPropSale.Items[i].FindControl("literpid");
        //        string pids = literpid.Text.Trim();
        //        DropDownList ddlistValues = (DropDownList)RepeaterPropSale.Items[i].FindControl("ddlistValues");
        //        CheckBoxList cblistValues = (CheckBoxList)RepeaterPropSale.Items[i].FindControl("cblistValues");
        //        if (ddlistValues.Visible)
        //        {
        //            if (ddlistValues.SelectedValue != "0" && ddlistValues.SelectedValue != string.Empty)
        //            {
        //                // props.Append(pids + ":" + ddlistValues.SelectedValue + ";");
        //                props.Append(ddlistValues.SelectedValue + ";");
        //            }
        //        }
        //        else
        //        {
        //            foreach (ListItem item in cblistValues.Items)
        //            {
        //                if (item.Selected && item.Value != string.Empty)
        //                {
        //                    // props.Append(pids + ":" + item.Value + ";");
        //                    props.Append(item.Value + ";");
        //                }

        //            }
        //        }

        //    }
        //    return props.ToString();
        //}

        //#endregion

        ///// <summary>
        ///// ��Ȩ���
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void CheckBoxTb_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (!TopClient.isAdminSessionTrue)
        //    {
        //        CheckBoxTb.Checked = false;
        //        this.ClientScript.RegisterClientScriptBlock(Page.GetType(), "msg", "<script type='text/javascript'>alert('���Ȼ�ȡ��Ȩ���ٽ���ͬ������')</script>");
        //        return;
        //    }
        //}

        ///// <summary>
        ///// ��Ȩ���
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void CheckBoxTbUpdate_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (!TopClient.isAdminSessionTrue)
        //    {
        //        CheckBoxTbUpdate.Checked = false;
        //        this.ClientScript.RegisterClientScriptBlock(Page.GetType(), "msg", "<script type='text/javascript'>alert('���Ȼ�ȡ��Ȩ���ٽ���ͬ������')</script>");
        //        return;
        //    }
        //}

        //#endregion
    }
}