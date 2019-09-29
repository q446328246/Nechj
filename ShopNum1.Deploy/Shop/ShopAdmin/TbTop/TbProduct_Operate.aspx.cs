using System.Web.UI;

namespace ShopNum1.Deploy.Shop.ShopAdmin.TbTop
{
    public partial class TbProduct_Operate : Page
    {
        ////两个空格
        //protected string strSapce = "　　";
        ////一个空格
        //protected char charSapce = '　';

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

        //        //绑定分类
        //        BindProductCategory();
        //        //绑定商品品牌
        //        BindBrand();


        //        //绑定分类
        //        BindProductCategory();
        //        //绑定商品品牌
        //        BindBrand();
        //        //绑定商品分类
        //        DropDownListProductCategoryBind();


        //        //绑定供应商2
        //        BindDropDownListSupplierGuid();
        //        //绑定计量单位
        //        BindDropDownListUnitName();
        //        //商品类型
        //        BindDropDownListProductTypeGuid();
        //        //绑定资讯分类
        //        BindArticleCategory();
        //        //绑定会员等级
        //        this.Num1GridViewPrice.DataBind();

        //        this.Num1GridViewAgentPrice.DataBind();

        //        //绑定产品线
        //        BindProductLine();

        //        //取OrderID
        //        GetOrderID();
        //        //将Nu1GridViewPrice存到ViewState中
        //        //ViewState["Num1GridViewPrice"] = Num1GridViewPrice;

        //        #region  ///淘宝api操作   初始化
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
        //            //  lbox1.Items.Insert(0, new ListItem("请选择", "0"));

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


        //        //编辑
        //        if (this.hiddenFieldGuid.Value != "0")
        //        {

        //            DropDownListProducLine.Enabled = false;

        //            //取商品基本信息
        //            GetEditProductInfo();
        //            //取商品相关配件
        //            GetEditProductAccessory();
        //            //取商品相关商品
        //            GetEditRelatedProduct();
        //            //取商品相关资讯
        //            GetEditProductArticle();
        //            //取商品相关分类
        //            GetEditProdcutExtendType();
        //            //取会员等级价格
        //            GetProductMemberRankPrice();
        //            //取分销商等级价格
        //            GetAgentProductMemberRankPrice();
        //            //取商品多图
        //            GetProductImage();
        //            ////取不带商品属性的值
        //            // GetProductAttribute();
        //            //取带商品价格的商品属性的值
        //            GetProductAttribute2();


        //            string tbstatus = GetItemStatus(hiddenFieldGuid.Value.Replace("'", "").Trim());
        //            if (tbstatus == "已同步")
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

        //#region 页面事件

        ////删除选择的图片
        //protected void ButtonDeleteImage_Click(object sender, EventArgs e)
        //{
        //    //如果是编辑进来的
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

        ////添加商品多图
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

        ////选择商品类型
        //protected void DropDownListProductTypeGuid_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    #region 清空属性价格
        //    //清空Num1GridViewProductyAttributePrice
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


        ////加商品属性列表中的控件
        //protected void Num1GridViewProductyAttributeShow_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowIndex > -1)
        //    {
        //        //隐藏"添加，隐藏"按钮
        //        //当为"唯一属性"的时候
        //        if (e.Row.Cells[4].Text == "0")
        //        {
        //            //((Button)e.Row.Cells[8].FindControl("ButtonAdd")).Visible = false;
        //            //((Button)e.Row.Cells[8].FindControl("ButtonRemove")).Visible = false;

        //            //隐藏"属性价格列"
        //            //((TextBox)e.Row.Cells[7].FindControl("TextBoxPrice")).Visible = false;
        //        }

        //        if (e.Row.Cells[3].Text == "0")  //TextBox，单行,为手工输入
        //        {
        //            TextBox textBox = new TextBox();
        //            textBox.ID = "textBox" + e.Row.RowIndex.ToString();
        //            textBox.Text = "";
        //            e.Row.Cells[2].Controls.Add(textBox);

        //        }
        //        else if (e.Row.Cells[3].Text == "1")  //DropDownList，选择,为选择输入
        //        {
        //            DropDownList dropDownList = new DropDownList();
        //            dropDownList.ID = "dropDownList" + e.Row.RowIndex.ToString();
        //            //如果有选择值         
        //            if (e.Row.Cells[5].Text.Trim() != "&nbsp;")
        //            {
        //                //将AttrValue里面的值用“回车”
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
        //        else if (e.Row.Cells[3].Text == "2") //TextBox，多行 为多行文本输入
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

        //#region 自定义方法


        ////得到商品分类ID
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
        ////开始分级绑定商品分类
        //protected void DropDownListProductCategoryBind()
        //{
        //    DropDownListProductCategoryID1.Items.Clear();
        //    DropDownListProductCategoryID1.Items.Add(new ListItem("-请选择-", "-1"));
        //    ShopNum1_ProductCategory_Action productCategoryAction = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
        //    DataTable dataTable = productCategoryAction.Search(0, 0);
        //    for (int i = 0; i < dataTable.Rows.Count; i++)
        //    {
        //        DropDownListProductCategoryID1.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["ID"].ToString()));
        //    }
        //    DropDownListProductCategoryID1_SelectedIndexChanged(null, null);
        //}

        ////一级分类改变事件
        //protected void DropDownListProductCategoryID1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownListProductCategoryID2.Items.Clear();
        //    DropDownListProductCategoryID2.Items.Add(new ListItem("-请选择-", "-1"));
        //    if (DropDownListProductCategoryID1.SelectedValue != "-1")
        //    {
        //        ShopNum1_ProductCategory_Action productCategoryAction = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
        //        DataTable dataTable = productCategoryAction.Search(Convert.ToInt32(DropDownListProductCategoryID1.SelectedValue), 0);

        //        for (int i = 0; i < dataTable.Rows.Count; i++)
        //        {
        //            DropDownListProductCategoryID2.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["ID"].ToString()));
        //        }
        //        //绑定商品品牌
        //        BindProductBranDrelation(DropDownListProductCategoryID1.SelectedValue);
        //    }
        //    DropDownListProductCategoryID2_SelectedIndexChanged(null, null);
        //}

        ////根据商品分类iD绑定商品品牌
        //private void BindProductBranDrelation(string categroyid)
        //{
        //    this.DropDownListBrandGuid.Items.Clear();
        //    this.DropDownListBrandGuid.Items.Add(new ListItem("-请选择-", "-1"));
        //    ShopNum1_Brand_Action brandAction = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
        //    DataTable dataTableBrand = brandAction.GetBrandByProductCategoryRelation(categroyid);

        //    if (dataTableBrand != null && dataTableBrand.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dataTableBrand.Rows)
        //        {
        //            ListItem listItem = new ListItem();
        //            listItem.Text = dr["Name"].ToString().Trim();
        //            listItem.Value = dr["Guid"].ToString().Trim();
        //            //绑定添加时候的“商品品牌”DropDownListBrandGuid
        //            //绑定商品配件查询里的“商品品牌”DropDownListSProductAccessoryBrandGuid
        //            //绑定相关商品查询里的“商品品牌”DropDownListSRelatedProductBrandGuid
        //            this.DropDownListBrandGuid.Items.Add(listItem);
        //        }
        //    }
        //}

        ////二级商品分类改变事件
        //protected void DropDownListProductCategoryID2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownListProductCategoryID3.Items.Clear();
        //    DropDownListProductCategoryID3.Items.Add(new ListItem("-请选择-", "-1"));
        //    if (DropDownListProductCategoryID2.SelectedValue != "-1")
        //    {
        //        ShopNum1_ProductCategory_Action productCategoryAction = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
        //        DataTable dataTable = productCategoryAction.Search(Convert.ToInt32(DropDownListProductCategoryID2.SelectedValue), 0);
        //        for (int i = 0; i < dataTable.Rows.Count; i++)
        //        {
        //            DropDownListProductCategoryID3.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["ID"].ToString()));
        //        }
        //        //绑定商品品牌
        //        BindProductBranDrelation(DropDownListProductCategoryID2.SelectedValue);
        //    }
        //}

        ////三级商品分类改变事件
        //protected void DropDownListProductCategoryID3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DropDownListProductCategoryID3.SelectedValue != "-1")
        //    {
        //        //绑定商品品牌
        //        BindProductBranDrelation(DropDownListProductCategoryID3.SelectedValue);
        //        //绑定商品属性
        //        BindProductProp();
        //    }
        //}


        ////取OrderID
        //protected void GetOrderID()
        //{
        //    ShopNum1_Common_Action shopNum1_Common_Action = (ShopNum1_Common_Action)LogicFactory.CreateShopNum1_Common_Action();
        //    string order_id = "OrderID", shopnum1_product = "ShopNum1_Product";
        //    this.TextBoxOrderID.Text = Convert.ToString(1 + shopNum1_Common_Action.ReturnMaxID(order_id, shopnum1_product));
        //}


        ///// 绑定商品分类
        ///// </summary>
        //protected void BindProductCategory()
        //{
        //    ListItem listItem1 = new ListItem();
        //    listItem1.Text = LocalizationUtil.GetCommonMessage("All");
        //    listItem1.Value = "-1";
        //    this.DropDownListSRelatedProductProductCategoryID.Items.Add(listItem1);
        //    this.DropDownListSProductAccessoryProductCategoryID.Items.Add(listItem1);


        //    ShopNum1_ProductCategory_Action productCategoryAction = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
        //    //取顶级分类
        //    DataView dataView = productCategoryAction.Search(0, 0).DefaultView;

        //    foreach (DataRow dr in dataView.Table.Rows)
        //    {
        //        ListItem listItem = new ListItem();
        //        DataTable dataTable;

        //        listItem.Text = dr["Name"].ToString().Trim();
        //        listItem.Value = dr["ID"].ToString().Trim();

        //        // 绑定添加时候的“商品分类” DropDownListProductCategoryID
        //        //绑定商品配件查询里的“商品分类” DropDownListSProductAccessoryProductCategoryID
        //        //绑定相关商品查询里的“商品分类”DropDownListSRelatedProductProductCategoryID
        //        //this.DropDownListProductCategoryID.Items.Add(listItem);
        //        this.DropDownListSProductAccessoryProductCategoryID.Items.Add(listItem);
        //        this.DropDownListSRelatedProductProductCategoryID.Items.Add(listItem);

        //        this.ListBoxLeftProductExtendCategory.Items.Add(listItem);

        //        //如果有子分类
        //        dataTable = productCategoryAction.Search(Convert.ToInt32(dr["ID"].ToString().Trim()), 0);
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            AddSubProductCategory(dataTable);
        //        }

        //    }
        //}
        ////添加子分类
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
        //            //strSpace是两个空格
        //            str = str + strSapce;
        //        }
        //        str = str + dr["Name"].ToString().Trim();
        //        listItem.Text = str;
        //        listItem.Value = dr["ID"].ToString().Trim();

        //        // 绑定添加时候的“商品分类” DropDownListProductCategoryID
        //        //绑定商品配件查询里的“商品分类” DropDownListSProductAccessoryProductCategoryID
        //        //绑定相关商品查询里的“商品分类”DropDownListSRelatedProductProductCategoryID
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

        ////绑定商品品牌
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
        //        //绑定添加时候的“商品品牌”DropDownListBrandGuid
        //        //绑定商品配件查询里的“商品品牌”DropDownListSProductAccessoryBrandGuid
        //        //绑定相关商品查询里的“商品品牌”DropDownListSRelatedProductBrandGuid
        //        //this.DropDownListBrandGuid.Items.Add(listItem);
        //        this.DropDownListSProductAccessoryBrandGuid.Items.Add(listItem);
        //        this.DropDownListSRelatedProductBrandGuid.Items.Add(listItem);
        //    }
        //}


        ////绑定添加时候的“计量单位”DropDownListUnitName
        //protected void BindDropDownListUnitName()
        //{
        //    ShopNum1_Unit_Action unitAction = (ShopNum1_Unit_Action)LogicFactory.CreateShopNum1_Unit_Action();
        //    DataView dataView = unitAction.Search().DefaultView;
        //    foreach (DataRow dr in dataView.Table.Rows)
        //    {
        //        ListItem listItem = new ListItem();

        //        //都绑定名称
        //        listItem.Text = dr["Name"].ToString().Trim();
        //        listItem.Value = dr["Name"].ToString().Trim();

        //        this.DropDownListUnitName.Items.Add(listItem);
        //    }
        //}

        ////绑定添加时候的“供应商”DropDownListSupplierGuid
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

        ////绑定添加时候的“商品类型”DropDownListProductTypeGuid
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

        ////绑定添加时候的“资讯分类”
        //protected void BindArticleCategory()
        //{
        //    ListItem listItem1 = new ListItem();
        //    listItem1.Text = LocalizationUtil.GetCommonMessage("All");
        //    listItem1.Value = "-1";
        //    this.DropDownListSArticleCategory.Items.Add(listItem1);

        //    ShopNum1_ArticleCategory_Action ariticleCategoryAction = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
        //    //取顶级分类
        //    DataView dataView = ariticleCategoryAction.Search(0, 0).DefaultView;

        //    foreach (DataRow dr in dataView.Table.Rows)
        //    {
        //        ListItem listItem = new ListItem();
        //        DataTable dataTable;

        //        listItem.Text = dr["Name"].ToString().Trim();
        //        listItem.Value = dr["ID"].ToString().Trim();

        //        //绑定相关资讯里的“资讯分类” DropDownListSArticleCategory
        //        this.DropDownListSArticleCategory.Items.Add(listItem);

        //        //如果有子分类
        //        dataTable = ariticleCategoryAction.Search(Convert.ToInt32(dr["ID"].ToString().Trim()), 0);
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            AddSubAriticleCategory(dataTable);
        //        }

        //    }
        //}
        ////添加资讯子分类
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
        //            //strSpace是两个空格
        //            str = str + strSapce;
        //        }
        //        str = str + dr["Name"].ToString().Trim();
        //        listItem.Text = str;
        //        listItem.Value = dr["ID"].ToString().Trim();

        //        //绑定相关资讯里的“资讯分类” DropDownListSArticleCategory
        //        this.DropDownListSArticleCategory.Items.Add(listItem);


        //        DataTable dataTable1 = ariticleCategoryAction.Search(Convert.ToInt32(dr["ID"].ToString().Trim()), 0);
        //        if (dataTable1.Rows.Count > 0)
        //        {
        //            AddSubAriticleCategory(dataTable1);
        //        }
        //    }

        //}


        ////绑定查询时候的“商品配件”ListBoxLeftProductAccessory
        //protected void BindListBoxLeftProductAccessory()
        //{
        //    //先清空列表
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

        ////创建商品多图用到的DataTable
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
        //    //属性名称
        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "Name";
        //    dataProductyAttributePrice.Columns.Add(column);

        //    //属性值
        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.String");
        //    column.ColumnName = "AtrributeValue";
        //    dataProductyAttributePrice.Columns.Add(column);

        //    //属性价格
        //    column = new DataColumn();
        //    column.DataType = System.Type.GetType("System.Decimal");
        //    column.ColumnName = "AttributePrice";
        //    dataProductyAttributePrice.Columns.Add(column);

        //    ViewState["dataProductyAttributePrice"] = dataProductyAttributePrice;
        //}

        ////绑定产品线
        //public void BindProductLine()
        //{
        //    //添加全部
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
        //    //绑定商品配件列表
        //    BindListBoxLeftProductAccessory();

        //}

        ////将左边列表商品配件全部添加到右边列表
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

        ////将左边列表被选种的商品配件添加到右边列表
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
        ////将右边列表被选种的商品配件从列表中移除
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
        ////将右边列表商品配件从列表中全部移除
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
        ////检查右边的列表中是否添加了该配件
        //private bool CheckAddProductAccessory(string guid)
        //{
        //    bool boolCheck = true;
        //    for (int i = 0; i < this.ListBoxRightProductAccessory.Items.Count; i++)
        //    {
        //        string[] strList = this.ListBoxRightProductAccessory.Items[i].Value.Trim().Split(';');
        //        //strList[0]为guid
        //        if (strList[0] == guid.Trim())
        //        {
        //            boolCheck = false;
        //            break;
        //        }
        //    }
        //    return boolCheck;
        //}

        ////选择了商品配件后，把该配件的价格显示在价格文本框中
        //protected void ListBoxLeftProductAccessory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    this.TextBoxPriceProductAccessory.Text = productAction.GetShopPriceByGuid(this.ListBoxLeftProductAccessory.SelectedValue);

        //    //TextBoxPriceProductAccessory
        //}

        //protected void ButtonSearchRelatedProduct_Click(object sender, EventArgs e)
        //{
        //    //绑定相关商品
        //    BindListBoxLeftRelatedProduct();
        //}

        ////绑定查询后的“相关商品”的可选列表ListBoxLeftRelatedProduct
        //protected void BindListBoxLeftRelatedProduct()
        //{
        //    //先清空列表
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

        ////全部添加"相关商品"
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

        ////添加选择的相关商品
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

        ////检查右边的列表中是否添加了相关商品
        //private bool CheckAddRelatedProduct(string guid)
        //{
        //    bool boolCheck = true;
        //    for (int i = 0; i < this.ListBoxRightRelatedProduct.Items.Count; i++)
        //    {
        //        string[] strList = this.ListBoxRightRelatedProduct.Items[i].Value.Trim().Split(';');
        //        //strList[0]为guid
        //        if (strList[0] == guid.Trim())
        //        {
        //            boolCheck = false;
        //            break;
        //        }
        //    }
        //    return boolCheck;
        //}

        ////移除选择的“相关商品”
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

        ////移除所有的“相关商品”
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
        //    //绑定查询的资讯
        //    BindListBoxLeftProductArticle();
        //}

        ////绑定查询的资讯
        //protected void BindListBoxLeftProductArticle()
        //{
        //    //先清空列表
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

        ////添加所有的资讯到右边列表
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
        ////添加选种的到右边列表
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
        ////删除选择的右边列表中的资讯
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
        ////删除所有右边列表中的资讯
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

        ////检查右边的列表中是否添加了资讯
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

        ////将左边列表中的所有扩展分类添加到右边列表
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
        ////将左边列表中选种的扩展分类添加到右边列表
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
        ////将右边列表中选种的扩展分类移除
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
        ////移除所有右边列表中的扩展分类
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

        ////检查右边的列表中是否添加了该扩展分类
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
        //        #region 添加商品

        //        #region 商品表"ShopNum1_Product"
        //        ShopNum1_Product product = new ShopNum1_Product();
        //        product.Guid = Guid.NewGuid();
        //        product.Name = this.TextBoxName.Text;   //商品名称
        //        product.OriginalImge = this.TextBoxOriginalImge.Text;  //用的都是原图
        //        product.ThumbImage = "";        //暂时存空
        //        product.SmallImage = "";          //暂时存空    
        //        product.RepertoryNumber = this.TextBoxRepertoryNumber.Text;  //库存编号(货号)
        //        product.Weight = Convert.ToDecimal(this.TextBoxWeight.Text);    //商品重量
        //        product.RepertoryCount = Convert.ToInt32(this.TextBoxRepertoryCount.Text);  //库存量
        //        product.UnitName = this.TextBoxUnitName.Text;
        //        product.RepertoryAlertCount = Convert.ToInt32(this.TextBoxNameRepertoryAlertCount.Text); //库存警告数量
        //        product.PresentScore = Convert.ToInt32(this.TextBoxPresentScore.Text); //赠送消费红包
        //        product.PresentRankScore = Convert.ToInt32(this.TextBoxPresentRankScore.Text); //赠送等级红包
        //        product.SocreIntegral = Convert.ToInt32(this.TextBoxSocreIntegral.Text); //红包购买额度
        //        product.LimitBuyCount = Convert.ToInt32(this.TextBoxLimitBuyCount.Text); //每人次限制购买数量
        //        product.CostPrice = Convert.ToDecimal(this.TextBoxCostPrice.Text); //成本价
        //        product.MarketPrice = Convert.ToDecimal(this.TextBoxMarketPrice.Text); //市场价
        //        product.ShopPrice = Convert.ToDecimal(this.TextBoxShopPrice.Text); //本店售价
        //        product.Brief = this.TextBoxBrief.Text; //商品简单介绍
        //        product.Memo = this.TextBoxMemo.Text; //商家备注
        //        product.Detail = this.Server.HtmlEncode(this.FCKeditorDetail.Value.Replace("'", ""));  //商品详细
        //        product.ClickCount = 0;  //被点击数(浏览量)
        //        product.CollectCount = 0;  //被收藏次数
        //        product.BuyCount = 0;   //被购买次数
        //        product.CommentCount = 0;  //商品评论量
        //        product.ReferCount = 0;   //商品资讯量
        //        product.IsSaled = Convert.ToInt32(this.DropDownListIsSaled.SelectedValue); //是否上架

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

        //        //是否是精品
        //        if (this.CheckBoxIsBest.Checked)
        //        {
        //            product.IsBest = 1;
        //        }
        //        else
        //        {
        //            product.IsBest = 0;
        //        }
        //        //是否是新品
        //        if (this.CheckBoxIsNew.Checked)
        //        {
        //            product.IsNew = 1;
        //        }
        //        else
        //        {
        //            product.IsNew = 0;
        //        }
        //        //是否热销
        //        if (this.CheckBoxIsHot.Checked)
        //        {
        //            product.IsHot = 1;
        //        }
        //        else
        //        {
        //            product.IsHot = 0;
        //        }
        //        //是否推荐
        //        if (this.CheckBoxIsRecommend.Checked)
        //        {
        //            product.IsRecommend = 1;
        //        }
        //        else
        //        {
        //            product.IsRecommend = 0;
        //        }
        //        product.IsReal = Convert.ToInt32(this.DropDownListIsReal.SelectedValue);  //是否是实物
        //        product.IsOnlySaled = Convert.ToInt32(this.DropDownListIsOnlySaled.SelectedValue); //是否能单独销售(销售方式)
        //        product.Title = this.TextBoxTitle.Text;  //详细页标题
        //        product.Description = this.TextBoxDescription.Text;  //详细页描述
        //        product.Keywords = this.TextBoxKeywords.Text;  //详细页搜索关键字
        //        product.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text);  //商品排序
        //        if (this.DropDownListBrandGuid.SelectedValue != "-1")
        //        {
        //            product.BrandGuid = new Guid(this.DropDownListBrandGuid.SelectedValue); //商品品牌
        //            product.BrandName = this.DropDownListBrandGuid.SelectedItem.Text; //品牌名称
        //        }
        //        else
        //        {
        //            product.BrandGuid = Guid.Empty;
        //            product.BrandName = "";
        //        }

        //        //product.ProductCategoryID = Convert.ToInt32(this.DropDownListProductCategoryID.SelectedValue); //商品分类
        //        product.ProductCategoryID = Convert.ToInt32(returnProductCategoryID()); //商品分类
        //        product.ProductTypeGuid = new Guid(this.DropDownListProductTypeGuid.SelectedValue); //商品类型
        //        product.CreateUser = "admin"; //添加人
        //        product.CreateTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); //添加时间
        //        product.ModifyUser = "admin"; //最后修改人
        //        product.ModifyTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); //最后修改时间
        //        product.IsDeleted = 0; //是否删除

        //        product.SupplierGuid = new Guid(this.DropDownListSupplierGuid.SelectedValue); //供应商
        //        product.IsSupplierProduct = 1;
        //        product.SupplierLoginID = GetSupplierLoginID(this.DropDownListSupplierGuid.SelectedValue);

        //        #endregion

        //        #region  操作淘宝

        //        if (CheckBoxTb.Checked)
        //        {
        //            Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数

        //            //系统叶子类目cid
        //            if (ViewState["cid"] == null)
        //            {
        //                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "msg", "alert(\"还没选择分类\")", true);
        //                return;
        //            }

        //            //系统叶子类目cid
        //            string cid = string.Empty;
        //            cid = ViewState["cid"].ToString();

        //            ///店铺自定义类目分类
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

        //            ///新旧程度
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

        //            ///宝贝标题
        //            string title = txtTitle.Text.Trim();

        //            //宝贝数量
        //            string num = txtCount.Text.Trim();

        //            ///省份
        //            string province = ddlProvince.SelectedItem.Text.Trim();
        //            province = province.Replace("省", "").TrimEnd().Replace("壮族自治区", "").TrimEnd().Replace("自治区", "").TrimEnd().Replace("回族自治区", "").TrimEnd().Replace("维吾尔自治区", "").TrimEnd().Replace("特别行政区", "").TrimEnd();

        //            ///城市
        //            string city = ddlCity.SelectedItem.Text.Trim();
        //            city = city.Replace("市", "").TrimEnd().Replace("地区", "").TrimEnd().Replace("自治州", "").TrimEnd().Replace("藏族", "").TrimEnd().Replace("蒙古族", "").TrimEnd().Replace("岛", "").TrimEnd();

        //            ///运费承担方
        //            string freight_payer = radSeller.Checked ? "seller" : "buyer";
        //            if (radFreight1.Checked && radBuyer.Checked)
        //            {
        //                freight_payer = "seller";
        //            }
        //            else if (radFreight2.Checked && radBuyer.Checked)
        //            {
        //                ///自定义设置邮费
        //                param.Add("post_fee", txtSurfaceMail.Text.Trim());
        //                param.Add("express_fee", txtExpress.Text.Trim());
        //                param.Add("ems_fee", txtEms.Text.Trim());
        //            }

        //            ///有效时间
        //            decimal valid_thru = radSeven.Checked == true ? 7 : 14;

        //            //是否有发票
        //            string has_invoice = radInvoiceYes.Checked == true ? "true" : "false";

        //            ///是否有保
        //            string has_warranty = radServiceNo.Checked == true ? "true" : "false";

        //            //是否打折
        //            string has_discount = radDicCountYes.Checked == true ? "true" : "false";

        //            ///商户编码
        //            string outer_id = txtNumCode.Text.Trim();

        //            ///一口价
        //            string price = txtOnePrice.Text.Trim();

        //            //返点比例
        //            string auction_point = txtRate.Text.Trim();

        //            ///上架状态
        //            string approve_status = radPut.Checked == true ? "onsale" : "instock";

        //            //是否橱窗推荐
        //            string has_showcase = cboxYes.Checked == true ? "true" : "false";

        //            string strXml = string.Empty;

        //            param.Add("num", num);
        //            // param.Add("pic_path", ImageOriginalImge.Src);
        //            param.Add("price", price);
        //            param.Add("type", "fixed");
        //            param.Add("stuff_status", stuff_status);
        //            param.Add("props", GetAddProps());
        //            param.Add("title", title);
        //           // string desc = this.FCKeditorDetail.Value;  //商品详细
        //           // desc = desc == "" ? "请多关注" + title : desc;
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
        //            //  是否保修
        //            param.Add("has_warranty", has_warranty);

        //            //是否橱窗推荐
        //            param.Add("has_showcase", has_showcase);

        //            //商家自定义分类 
        //            param.Add("seller_cids", seller_cids.ToString());

        //            // 商家编码
        //            param.Add("outer_id", outer_id);
        //            ///商家
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
        //            if (err.IsError)//判断是否更新过程中发生错误
        //            {
        //                //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //                if (err.code == "530")
        //                {
        //                    ShopNum1.Common.MessageBox.Show("同步淘宝的商品分类有误，请检查!");
        //                    return;
        //                }
        //                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"添加商品失败！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
        //            }
        //            else
        //            {
        //                ///处理图片上传
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
        //                            //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"淘宝上传图片的时候出现错误！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
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

        //        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "err", "alert('添加成功')", true);
        //        //ClientScript.RegisterClientScriptBlock(typeof(Page), "err", "alert('添加成功')", true);
        //        #endregion

        //        #region 商品会员等级价格表"ShopNum1_ProductMemberRankPrice"
        //        List<ShopNum1_ProductMemberRankPrice> productMemberRankPrice = new List<ShopNum1_ProductMemberRankPrice>();

        //        if (this.Num1GridViewPrice.Rows.Count > 0)
        //        {
        //            for (int i = 0; i <= this.Num1GridViewPrice.Rows.Count - 1; i++)
        //            {
        //                if (((TextBox)this.Num1GridViewPrice.Rows[i].Cells[2].Controls[0]).Text != "-1" && !string.IsNullOrEmpty(((TextBox)this.Num1GridViewPrice.Rows[i].Cells[2].Controls[0]).Text))
        //                {
        //                    ShopNum1_ProductMemberRankPrice tempProductMemberRankPrice = new ShopNum1_ProductMemberRankPrice();
        //                    tempProductMemberRankPrice.Guid = Guid.NewGuid();
        //                    //tempProductMemberRankPrice.ProductGuid = product.Guid;   //商品的Guid
        //                    //等级价格
        //                    tempProductMemberRankPrice.Price = Convert.ToDecimal(((TextBox)this.Num1GridViewPrice.Rows[i].Cells[2].Controls[0]).Text);
        //                    //会员等级Guid
        //                    tempProductMemberRankPrice.MemberRankGuid = new Guid(this.Num1GridViewPrice.Rows[i].Cells[0].Text);

        //                    //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //                    //tempProductMemberRankPrice.CreateUser = product.CreateUser;  //添加人,因为和商品的一样，所有用商品的
        //                    //tempProductMemberRankPrice.CreateTime = product.CreateTime; //添加时间,因为和商品的一样，所有用商品的
        //                    //tempProductMemberRankPrice.ModifyUser = product.ModifyUser; //最后修改人,因为和商品的一样，所有用商品的
        //                    //tempProductMemberRankPrice.ModifyTime = product.ModifyTime; //最后修改时间,因为和商品的一样，所有用商品的
        //                    productMemberRankPrice.Add(tempProductMemberRankPrice);
        //                }
        //            }
        //        }
        //        #endregion

        //        #region 商品具体属性表"ShopNum1_ProductAttributeValue"

        //        List<ShopNum1_ProductAttributeValue> productAttributeValue = new List<ShopNum1_ProductAttributeValue>();
        //        //// 无价格的属性
        //        //if (this.Num1GridViewProductyAttributeShow.Rows.Count > 0)
        //        //{
        //        //    #region 无价格的属性
        //        //    for (int i = 0; i <= this.Num1GridViewProductyAttributeShow.Rows.Count - 1; i++)
        //        //    {
        //        //        ShopNum1_ProductAttributeValue tempProductAttributeValue = new ShopNum1_ProductAttributeValue();
        //        //        tempProductAttributeValue.Guid = Guid.NewGuid();
        //        //        //商品类型Guid
        //        //        tempProductAttributeValue.ProductTypeGuid = new Guid(this.DropDownListProductTypeGuid.SelectedValue);
        //        //        //商品属性Guid
        //        //        tempProductAttributeValue.ProductAttributeGuid = new Guid(this.Num1GridViewProductyAttributeShow.Rows[i].Cells[0].Text);

        //        //        //this.Response.Write(tempProductAttributeValue.AtrributeValue);
        //        //        //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //        //        //tempProductAttributeValue.ProductGuid = product.Guid;
        //        //        //tempProductAttributeValue.CreateUser = product.CreateUser;  //添加人,因为和商品的一样，所有用商品的
        //        //        //tempProductAttributeValue.CreateTime = product.CreateTime; //添加时间,因为和商品的一样，所有用商品的
        //        //        //tempProductAttributeValue.ModifyUser = product.ModifyUser; //最后修改人,因为和商品的一样，所有用商品的
        //        //        //tempProductAttributeValue.ModifyTime = product.ModifyTime; //最后修改时间,因为和商品的一样，所有用商品的

        //        //        if (this.Num1GridViewProductyAttributeShow.Rows[i].Cells[3].Text == "0" || this.Num1GridViewProductyAttributeShow.Rows[i].Cells[3].Text == "2")
        //        //        {
        //        //            //手工输入(单行)或手工输入(多行)
        //        //            //属性值
        //        //            tempProductAttributeValue.AtrributeValue = ((TextBox)this.Num1GridViewProductyAttributeShow.Rows[i].Cells[2].Controls[0]).Text;
        //        //        }
        //        //        else if (this.Num1GridViewProductyAttributeShow.Rows[i].Cells[3].Text == "1")
        //        //        {
        //        //            //选择输入
        //        //            //属性值
        //        //            tempProductAttributeValue.AtrributeValue = ((DropDownList)this.Num1GridViewProductyAttributeShow.Rows[i].Cells[2].Controls[0]).SelectedItem.Text;
        //        //        }
        //        //        //属性价格(将属性价格设为0，因为无属性价格)
        //        //        tempProductAttributeValue.AttributePrice = 0;

        //        //        productAttributeValue.Add(tempProductAttributeValue);
        //        //    }
        //        //    #endregion
        //        //}

        //        //有价格的属性
        //        if (this.Num1GridViewProductyAttributePrice.Rows.Count > 0)
        //        {
        //            #region 有价格属性
        //            for (int i = 0; i <= this.Num1GridViewProductyAttributePrice.Rows.Count - 1; i++)
        //            {
        //                ShopNum1_ProductAttributeValue tempProductAttributeValue = new ShopNum1_ProductAttributeValue();
        //                tempProductAttributeValue.Guid = Guid.NewGuid();
        //                //商品类型Guid
        //                tempProductAttributeValue.ProductTypeGuid = new Guid(this.DropDownListProductTypeGuid.SelectedValue);
        //                //商品属性Guid

        //                tempProductAttributeValue.ProductAttributeGuid = new Guid(this.Num1GridViewProductyAttributePrice.Rows[i].Cells[0].Text);

        //                //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //                //tempProductAttributeValue.ProductGuid = product.Guid;
        //                //tempProductAttributeValue.CreateUser = product.CreateUser;  //添加人,因为和商品的一样，所有用商品的
        //                //tempProductAttributeValue.CreateTime = product.CreateTime; //添加时间,因为和商品的一样，所有用商品的
        //                //tempProductAttributeValue.ModifyUser = product.ModifyUser; //最后修改人,因为和商品的一样，所有用商品的
        //                //tempProductAttributeValue.ModifyTime = product.ModifyTime; //最后修改时间,因为和商品的一样，所有用商品的

        //                //属性值
        //                tempProductAttributeValue.AtrributeValue = this.Num1GridViewProductyAttributePrice.Rows[i].Cells[2].Text;

        //                //属性价格
        //                tempProductAttributeValue.AttributePrice = Convert.ToDecimal(this.Num1GridViewProductyAttributePrice.Rows[i].Cells[3].Text);

        //                productAttributeValue.Add(tempProductAttributeValue);
        //            }
        //            #endregion
        //        }
        //        #endregion

        //        #region 商品多图"ShopNum1_ProductImage"
        //        List<ShopNum1_ProductImage> productImage = new List<ShopNum1_ProductImage>();

        //        //if (this.DataListPorductImage.Items.Count > 0)
        //        //{
        //        //    for (int i = 0; i < this.DataListPorductImage.Items.Count; i++)
        //        //    {
        //        //        ShopNum1_ProductImage tempProductImage = new ShopNum1_ProductImage();
        //        //        tempProductImage.Guid = Guid.NewGuid();
        //        //        //图片地址
        //        //        string strOriginallImage = ((Image)this.DataListPorductImage.Items[i].FindControl("loadImg")).ImageUrl;
        //        //        tempProductImage.OriginalImge = strOriginallImage.Substring(strOriginallImage.LastIndexOf("/") + 1);
        //        //        tempProductImage.ThumbImage = "";    //暂时存空
        //        //        tempProductImage.SmallImage = "";      //暂时存空
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
        //                //图片地址
        //                string strOriginallImage = tempDataTalbe.Rows[i]["OriginalImge"].ToString();
        //                tempProductImage.OriginalImge = strOriginallImage.Substring(strOriginallImage.LastIndexOf("/") + 1);
        //                tempProductImage.ThumbImage = "";    //暂时存空
        //                tempProductImage.SmallImage = "";      //暂时存空
        //                tempProductImage.IsDeleted = 0;
        //                tempProductImage.CreateTime = Convert.ToDateTime(tempDataTalbe.Rows[i]["CreateTime"].ToString());
        //                productImage.Add(tempProductImage);

        //            }
        //        }
        //        #endregion

        //        #region 商品配件"ShopNum1_ProductAccessory"
        //        List<ShopNum1_ProductAccessory> productAccessory = new List<ShopNum1_ProductAccessory>();
        //        if (this.ListBoxRightProductAccessory.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightProductAccessory.Items.Count; i++)
        //            {
        //                ShopNum1_ProductAccessory tempProductAccessory = new ShopNum1_ProductAccessory();
        //                //因为ListBoxRightProductAccessory的Value值是"Guid"+";"+"价格"
        //                //所以拆分后取价格
        //                string[] strTempArry = this.ListBoxRightProductAccessory.Items[i].Value.Split(';');
        //                tempProductAccessory.AccessoryProductGuid = new Guid(strTempArry[0]);
        //                tempProductAccessory.Price = Convert.ToDecimal(strTempArry[1]);

        //                //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //                //tempProductAccessory.ProductGuid = product.Guid;  //用的是商品的Guid
        //                //tempProductAccessory.CreateUser = product.CreateUser;  //添加人,因为和商品的一样，所有用商品的
        //                //tempProductAccessory.CreateTime = product.CreateTime; //添加时间,因为和商品的一样，所有用商品的
        //                productAccessory.Add(tempProductAccessory);
        //            }
        //        }
        //        #endregion

        //        #region 相关商品"ShopNum1_RelatedProduct"
        //        List<ShopNum1_RelatedProduct> relatedProduct = new List<ShopNum1_RelatedProduct>();

        //        if (this.ListBoxRightRelatedProduct.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightRelatedProduct.Items.Count; i++)
        //            {
        //                ShopNum1_RelatedProduct tempRelatedProduct = new ShopNum1_RelatedProduct();
        //                //因为ListBoxRightProductAccessory的Value值是"Guid"+";"+"IsBoth"
        //                //所以拆分后取价格
        //                string[] strTempArry = this.ListBoxRightRelatedProduct.Items[i].Value.Split(';');
        //                tempRelatedProduct.SubProductGuid = new Guid(strTempArry[0]);
        //                tempRelatedProduct.IsBoth = Convert.ToInt32(strTempArry[1]);

        //                //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //                //tempRelatedProduct.ProductGuid = product.Guid;  //用的是商品的Guid
        //                //tempRelatedProduct.CreateUser = product.CreateUser;  //添加人,因为和商品的一样，所有用商品的
        //                //tempRelatedProduct.CreateTime = product.CreateTime; //添加时间,因为和商品的一样，所有用商品的
        //                relatedProduct.Add(tempRelatedProduct);
        //            }
        //        }
        //        #endregion

        //        #region 相关资讯"ShopNum1_ProductArticle"
        //        List<ShopNum1_ProductArticle> productArticle = new List<ShopNum1_ProductArticle>();
        //        if (this.ListBoxRightProductArticle.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightProductArticle.Items.Count; i++)
        //            {
        //                ShopNum1_ProductArticle tempProductArticle = new ShopNum1_ProductArticle();
        //                tempProductArticle.ArticleGuid = new Guid(this.ListBoxRightProductArticle.Items[i].Value);
        //                //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //                //tempProductArticle.ProductGuid = product.Guid;  //用的是商品的Guid
        //                //tempProductArticle.CreateUser = product.CreateUser;  //添加人,因为和商品的一样，所有用商品的
        //                //tempProductArticle.CreateTime = product.CreateTime; //添加时间,因为和商品的一样，所有用商品的
        //                productArticle.Add(tempProductArticle);

        //            }
        //        }
        //        #endregion

        //        #region 扩展分类"ShopNum1_ProdcutExtendType"
        //        List<ShopNum1_ProdcutExtendType> prodcutExtendType = new List<ShopNum1_ProdcutExtendType>();

        //        if (this.ListBoxRightProductExtendCategory.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightProductExtendCategory.Items.Count; i++)
        //            {
        //                ShopNum1_ProdcutExtendType tempProdcutExtendType = new ShopNum1_ProdcutExtendType();
        //                tempProdcutExtendType.ProductCategoryID = Convert.ToInt32(this.ListBoxRightProductExtendCategory.Items[i].Value);
        //                //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //                //prodcutExtendType.ProductGuid = product.Guid;  //用的是商品的Guid
        //                //prodcutExtendType.CreateUser = product.CreateUser;  //添加人,因为和商品的一样，所有用商品的
        //                //prodcutExtendType.CreateTime = product.CreateTime; //添加时间,因为和商品的一样，所有用商品的
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
        //                    tempProductMemberRankPrice.ProductGuid = product.Guid;   //商品的Guid
        //                    //等级价格
        //                    tempProductMemberRankPrice.Price = Convert.ToDecimal(((TextBox)this.Num1GridViewAgentPrice.Rows[i].Cells[2].Controls[0]).Text);
        //                    //会员等级Guid
        //                    tempProductMemberRankPrice.MemberRankGuid = new Guid(this.Num1GridViewAgentPrice.Rows[i].Cells[0].Text);

        //                    //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //                    tempProductMemberRankPrice.CreateUser = product.CreateUser;  //添加人,因为和商品的一样，所有用商品的
        //                    tempProductMemberRankPrice.CreateTime = product.CreateTime; //添加时间,因为和商品的一样，所有用商品的
        //                    tempProductMemberRankPrice.ModifyUser = product.ModifyUser; //最后修改人,因为和商品的一样，所有用商品的
        //                    tempProductMemberRankPrice.ModifyTime = product.ModifyTime; //最后修改时间,因为和商品的一样，所有用商品的

        //                    productAction.AddMemberRankPrice(tempProductMemberRankPrice);

        //                }
        //            }
        //        }

        //        if (check > 0)
        //        {
        //            #region  操作日志部分
        //            ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog();
        //            operateLog.Record = "新增" + this.TextBoxName.Text.Trim() + "成功!";
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

        //                if (dataTable.Rows[0]["IsForcibly"].ToString() == "1")  //判断是否是强制代理产品线
        //                {
        //                    if (dataTable.Rows[0]["AgentID"].ToString() != "")  //判断产品线是否授权
        //                    {
        //                        string[] strAgentID = dataTable.Rows[0]["AgentID"].ToString().Split(',');

        //                        for (int i = 0; i < strAgentID.Length - 1; i++)
        //                        {
        //                            productLine_Action.AddAgentProductLineProduct(product.Guid.ToString(), product.ShopPrice.ToString(), strAgentID[i].ToString(), "1");
        //                        }
        //                    }
        //                }
        //            }

        //            //显示操作信息
        //            this.MessageShowTb.ShowMessage("AddYes");
        //            this.MessageShowTb.Visible = true;


        //            //添加成功后清空控件
        //            ClearControl();
        //        }
        //        else
        //        {
        //            //显示操作信息
        //            this.MessageShowTb.ShowMessage("AddNo");
        //            this.MessageShowTb.Visible = true;
        //        }

        //        #endregion
        //    }
        //    else
        //    {
        //        #region 编辑商品

        //        #region 商品表"ShopNum1_Product"
        //        ShopNum1_Product product = new ShopNum1_Product();
        //        product.Guid = new Guid(this.hiddenFieldGuid.Value.Replace("'", ""));
        //        product.Name = this.TextBoxName.Text;   //商品名称
        //        product.OriginalImge = this.TextBoxOriginalImge.Text;  //用的都是原图
        //        product.ThumbImage = "";        //暂时存空
        //        product.SmallImage = "";          //暂时存空    
        //        product.RepertoryNumber = this.TextBoxRepertoryNumber.Text;  //库存编号(货号)
        //        product.Weight = Convert.ToDecimal(this.TextBoxWeight.Text);    //商品重量
        //        product.RepertoryCount = Convert.ToInt32(this.TextBoxRepertoryCount.Text);  //库存量
        //        product.UnitName = this.TextBoxUnitName.Text;
        //        product.RepertoryAlertCount = Convert.ToInt32(this.TextBoxNameRepertoryAlertCount.Text); //库存警告数量
        //        product.PresentScore = Convert.ToInt32(this.TextBoxPresentScore.Text); //赠送消费红包
        //        product.PresentRankScore = Convert.ToInt32(this.TextBoxPresentRankScore.Text); //赠送等级红包
        //        product.SocreIntegral = Convert.ToInt32(this.TextBoxSocreIntegral.Text); //红包购买额度
        //        product.LimitBuyCount = Convert.ToInt32(this.TextBoxLimitBuyCount.Text); //每人次限制购买数量
        //        product.CostPrice = Convert.ToDecimal(this.TextBoxCostPrice.Text); //成本价
        //        product.MarketPrice = Convert.ToDecimal(this.TextBoxMarketPrice.Text); //市场价
        //        product.ShopPrice = Convert.ToDecimal(this.TextBoxShopPrice.Text); //本店售价
        //        product.Brief = this.TextBoxBrief.Text; //商品简单介绍
        //        product.Memo = this.TextBoxMemo.Text; //商家备注
        //        product.Detail = this.Server.HtmlEncode(this.FCKeditorDetail.Value.Replace("'", ""));  //商品详细
        //        //编辑的时候无需更新以下字段
        //        //product.ClickCount = 0;  //被点击数(浏览量)
        //        //product.CollectCount = 0;  //被收藏次数
        //        //product.BuyCount = 0;   //被购买次数
        //        //product.CommentCount = 0;  //商品评论量
        //        //product.ReferCount = 0;   //商品资讯量
        //        product.IsSaled = Convert.ToInt32(this.DropDownListIsSaled.SelectedValue); //是否上架

        //        if (CheckUnionType() == "0")
        //        {
        //            product.PushMoney = decimal.Parse(TextBoxPushMoney.Text);
        //        }
        //        else
        //        {
        //            product.PushMoney = 0;
        //        }

        //        //是否是精品
        //        if (this.CheckBoxIsBest.Checked)
        //        {
        //            product.IsBest = 1;
        //        }
        //        else
        //        {
        //            product.IsBest = 0;
        //        }
        //        //是否是新品
        //        if (this.CheckBoxIsNew.Checked)
        //        {
        //            product.IsNew = 1;
        //        }
        //        else
        //        {
        //            product.IsNew = 0;
        //        }
        //        //是否热销
        //        if (this.CheckBoxIsHot.Checked)
        //        {
        //            product.IsHot = 1;
        //        }
        //        else
        //        {
        //            product.IsHot = 0;
        //        }
        //        //是否推荐
        //        if (this.CheckBoxIsRecommend.Checked)
        //        {
        //            product.IsRecommend = 1;
        //        }
        //        else
        //        {
        //            product.IsRecommend = 0;
        //        }
        //        product.IsReal = Convert.ToInt32(this.DropDownListIsReal.SelectedValue);  //是否是实物
        //        product.IsOnlySaled = Convert.ToInt32(this.DropDownListIsOnlySaled.SelectedValue); //是否能单独销售(销售方式)
        //        product.Title = this.TextBoxTitle.Text;  //详细页标题
        //        product.Description = this.TextBoxDescription.Text;  //详细页描述
        //        product.Keywords = this.TextBoxKeywords.Text;  //详细页搜索关键字
        //        product.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text);  //商品排序
        //        product.SupplierGuid = new Guid(this.DropDownListSupplierGuid.SelectedValue); //供应商
        //        if (this.DropDownListBrandGuid.SelectedValue != "-1")
        //        {
        //            product.BrandGuid = new Guid(this.DropDownListBrandGuid.SelectedValue); //商品品牌
        //            product.BrandName = this.DropDownListBrandGuid.SelectedItem.Text; //品牌名称
        //        }
        //        else
        //        {
        //            product.BrandGuid = Guid.Empty;
        //            product.BrandName = "";
        //        }
        //        product.BrandName = this.DropDownListBrandGuid.SelectedItem.Text; //品牌名称
        //        //product.ProductCategoryID = Convert.ToInt32(this.DropDownListProductCategoryID.SelectedValue); //商品分类
        //        product.ProductCategoryID = Convert.ToInt32(returnProductCategoryID()); //商品分类

        //        product.ProductTypeGuid = new Guid(this.DropDownListProductTypeGuid.SelectedValue); //商品类型
        //        //product.CreateUser = "admin"; //添加人
        //        //product.CreateTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); //添加时间
        //        product.ModifyUser = "admin"; //最后修改人
        //        product.ModifyTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); //最后修改时间
        //        product.IsDeleted = 0; //是否删除

        //        if (DropDownListProducLine.SelectedValue != "-1")
        //        {
        //            product.ProductLineGuid = DropDownListProducLine.SelectedValue;
        //        }
        //        #endregion

        //        #region 商品会员等级价格表"ShopNum1_ProductMemberRankPrice"
        //        List<ShopNum1_ProductMemberRankPrice> productMemberRankPrice = new List<ShopNum1_ProductMemberRankPrice>();

        //        if (this.Num1GridViewPrice.Rows.Count > 0)
        //        {
        //            for (int i = 0; i <= this.Num1GridViewPrice.Rows.Count - 1; i++)
        //            {
        //                if (((TextBox)this.Num1GridViewPrice.Rows[i].Cells[2].Controls[0]).Text != "-1" && !string.IsNullOrEmpty(((TextBox)this.Num1GridViewPrice.Rows[i].Cells[2].Controls[0]).Text))
        //                {
        //                    ShopNum1_ProductMemberRankPrice tempProductMemberRankPrice = new ShopNum1_ProductMemberRankPrice();
        //                    tempProductMemberRankPrice.Guid = Guid.NewGuid();
        //                    //tempProductMemberRankPrice.ProductGuid = product.Guid;   //商品的Guid
        //                    //等级价格
        //                    tempProductMemberRankPrice.Price = Convert.ToDecimal(((TextBox)this.Num1GridViewPrice.Rows[i].Cells[2].Controls[0]).Text);
        //                    //会员等级Guid
        //                    tempProductMemberRankPrice.MemberRankGuid = new Guid(this.Num1GridViewPrice.Rows[i].Cells[0].Text);

        //                    //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //                    //tempProductMemberRankPrice.CreateUser = product.CreateUser;  //添加人,因为和商品的一样，所有用商品的
        //                    //tempProductMemberRankPrice.CreateTime = product.CreateTime; //添加时间,因为和商品的一样，所有用商品的
        //                    //tempProductMemberRankPrice.ModifyUser = product.ModifyUser; //最后修改人,因为和商品的一样，所有用商品的
        //                    //tempProductMemberRankPrice.ModifyTime = product.ModifyTime; //最后修改时间,因为和商品的一样，所有用商品的
        //                    productMemberRankPrice.Add(tempProductMemberRankPrice);
        //                }
        //            }
        //        }
        //        #endregion

        //        #region 商品具体属性表"ShopNum1_ProductAttributeValue"

        //        List<ShopNum1_ProductAttributeValue> productAttributeValue = new List<ShopNum1_ProductAttributeValue>();
        //        //// 无价格的属性
        //        //if (this.Num1GridViewProductyAttributeShow.Rows.Count > 0)
        //        //{
        //        //    #region 无价格的属性
        //        //    for (int i = 0; i <= this.Num1GridViewProductyAttributeShow.Rows.Count - 1; i++)
        //        //    {
        //        //        ShopNum1_ProductAttributeValue tempProductAttributeValue = new ShopNum1_ProductAttributeValue();
        //        //        tempProductAttributeValue.Guid = Guid.NewGuid();
        //        //        //商品类型Guid
        //        //        tempProductAttributeValue.ProductTypeGuid = new Guid(this.DropDownListProductTypeGuid.SelectedValue);
        //        //        //商品属性Guid
        //        //        tempProductAttributeValue.ProductAttributeGuid = new Guid(this.Num1GridViewProductyAttributeShow.Rows[i].Cells[0].Text);

        //        //        //this.Response.Write(tempProductAttributeValue.AtrributeValue);
        //        //        //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //        //        //tempProductAttributeValue.ProductGuid = product.Guid;
        //        //        //tempProductAttributeValue.CreateUser = product.CreateUser;  //添加人,因为和商品的一样，所有用商品的
        //        //        //tempProductAttributeValue.CreateTime = product.CreateTime; //添加时间,因为和商品的一样，所有用商品的
        //        //        //tempProductAttributeValue.ModifyUser = product.ModifyUser; //最后修改人,因为和商品的一样，所有用商品的
        //        //        //tempProductAttributeValue.ModifyTime = product.ModifyTime; //最后修改时间,因为和商品的一样，所有用商品的

        //        //        if (this.Num1GridViewProductyAttributeShow.Rows[i].Cells[3].Text == "0" || this.Num1GridViewProductyAttributeShow.Rows[i].Cells[3].Text == "2")
        //        //        {
        //        //            //手工输入(单行)或手工输入(多行)
        //        //            //属性值
        //        //            tempProductAttributeValue.AtrributeValue = ((TextBox)this.Num1GridViewProductyAttributeShow.Rows[i].Cells[2].Controls[0]).Text;
        //        //        }
        //        //        else if (this.Num1GridViewProductyAttributeShow.Rows[i].Cells[3].Text == "1")
        //        //        {
        //        //            //选择输入
        //        //            //属性值
        //        //            tempProductAttributeValue.AtrributeValue = ((DropDownList)this.Num1GridViewProductyAttributeShow.Rows[i].Cells[2].Controls[0]).SelectedItem.Text;
        //        //        }
        //        //        //属性价格(将属性价格设为0，因为无属性价格)
        //        //        tempProductAttributeValue.AttributePrice = 0;

        //        //        productAttributeValue.Add(tempProductAttributeValue);
        //        //    }
        //        //    #endregion
        //        //}

        //        //有价格的属性
        //        if (this.Num1GridViewProductyAttributePrice.Rows.Count > 0)
        //        {
        //            #region 有价格属性
        //            for (int i = 0; i <= this.Num1GridViewProductyAttributePrice.Rows.Count - 1; i++)
        //            {
        //                ShopNum1_ProductAttributeValue tempProductAttributeValue = new ShopNum1_ProductAttributeValue();
        //                tempProductAttributeValue.Guid = Guid.NewGuid();
        //                //商品类型Guid
        //                tempProductAttributeValue.ProductTypeGuid = new Guid(this.DropDownListProductTypeGuid.SelectedValue);
        //                //商品属性Guid

        //                tempProductAttributeValue.ProductAttributeGuid = new Guid(this.Num1GridViewProductyAttributePrice.Rows[i].Cells[0].Text);

        //                //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //                //tempProductAttributeValue.ProductGuid = product.Guid;
        //                //tempProductAttributeValue.CreateUser = product.CreateUser;  //添加人,因为和商品的一样，所有用商品的
        //                //tempProductAttributeValue.CreateTime = product.CreateTime; //添加时间,因为和商品的一样，所有用商品的
        //                //tempProductAttributeValue.ModifyUser = product.ModifyUser; //最后修改人,因为和商品的一样，所有用商品的
        //                //tempProductAttributeValue.ModifyTime = product.ModifyTime; //最后修改时间,因为和商品的一样，所有用商品的

        //                //属性值
        //                tempProductAttributeValue.AtrributeValue = this.Num1GridViewProductyAttributePrice.Rows[i].Cells[2].Text;

        //                //属性价格
        //                tempProductAttributeValue.AttributePrice = Convert.ToDecimal(this.Num1GridViewProductyAttributePrice.Rows[i].Cells[3].Text);

        //                productAttributeValue.Add(tempProductAttributeValue);
        //            }
        //            #endregion
        //        }
        //        #endregion

        //        #region 商品多图"ShopNum1_ProductImage"
        //        List<ShopNum1_ProductImage> productImage = new List<ShopNum1_ProductImage>();
        //        if (this.DataListPorductImage.Items.Count > 0)
        //        {
        //            DataTable tempDataTalbe = (DataTable)ViewState["dataMultiImage"];
        //            for (int i = 0; i < tempDataTalbe.Rows.Count; i++)
        //            {
        //                ShopNum1_ProductImage tempProductImage = new ShopNum1_ProductImage();
        //                tempProductImage.Guid = Guid.NewGuid();
        //                //图片地址
        //                string strOriginallImage = tempDataTalbe.Rows[i]["OriginalImge"].ToString();
        //                tempProductImage.OriginalImge = strOriginallImage.Substring(strOriginallImage.LastIndexOf("/") + 1);
        //                tempProductImage.ThumbImage = "";    //暂时存空
        //                tempProductImage.SmallImage = "";      //暂时存空
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
        //        //        //图片地址
        //        //        string strOriginallImage = ((Image)this.DataListPorductImage.Items[i].FindControl("loadImg")).ImageUrl;
        //        //        tempProductImage.OriginalImge = strOriginallImage.Substring(strOriginallImage.LastIndexOf("/") + 1);
        //        //        tempProductImage.ThumbImage = "";    //暂时存空
        //        //        tempProductImage.SmallImage = "";      //暂时存空
        //        //        tempProductImage.IsDeleted = 0;
        //        //        productImage.Add(tempProductImage);

        //        //    }
        //        //}
        //        #endregion

        //        #region 商品配件"ShopNum1_ProductAccessory"
        //        List<ShopNum1_ProductAccessory> productAccessory = new List<ShopNum1_ProductAccessory>();
        //        if (this.ListBoxRightProductAccessory.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightProductAccessory.Items.Count; i++)
        //            {
        //                ShopNum1_ProductAccessory tempProductAccessory = new ShopNum1_ProductAccessory();
        //                //因为ListBoxRightProductAccessory的Value值是"Guid"+";"+"价格"
        //                //所以拆分后取价格
        //                string[] strTempArry = this.ListBoxRightProductAccessory.Items[i].Value.Split(';');
        //                tempProductAccessory.AccessoryProductGuid = new Guid(strTempArry[0]);
        //                //MessageBox.Show(strTempArry.Length.ToString());

        //                tempProductAccessory.Price = Convert.ToDecimal(strTempArry[1]);

        //                //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //                //tempProductAccessory.ProductGuid = product.Guid;  //用的是商品的Guid
        //                //tempProductAccessory.CreateUser = product.CreateUser;  //添加人,因为和商品的一样，所有用商品的
        //                //tempProductAccessory.CreateTime = product.CreateTime; //添加时间,因为和商品的一样，所有用商品的
        //                productAccessory.Add(tempProductAccessory);
        //            }
        //        }
        //        #endregion

        //        #region 相关商品"ShopNum1_RelatedProduct"
        //        List<ShopNum1_RelatedProduct> relatedProduct = new List<ShopNum1_RelatedProduct>();

        //        if (this.ListBoxRightRelatedProduct.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightRelatedProduct.Items.Count; i++)
        //            {
        //                ShopNum1_RelatedProduct tempRelatedProduct = new ShopNum1_RelatedProduct();
        //                //因为ListBoxRightProductAccessory的Value值是"Guid"+";"+"IsBoth"
        //                //所以拆分后取价格
        //                string[] strTempArry = this.ListBoxRightRelatedProduct.Items[i].Value.Split(';');
        //                tempRelatedProduct.SubProductGuid = new Guid(strTempArry[0]);
        //                tempRelatedProduct.IsBoth = Convert.ToInt32(strTempArry[1]);

        //                //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //                //tempRelatedProduct.ProductGuid = product.Guid;  //用的是商品的Guid
        //                //tempRelatedProduct.CreateUser = product.CreateUser;  //添加人,因为和商品的一样，所有用商品的
        //                //tempRelatedProduct.CreateTime = product.CreateTime; //添加时间,因为和商品的一样，所有用商品的
        //                relatedProduct.Add(tempRelatedProduct);
        //            }
        //        }
        //        #endregion

        //        #region 相关资讯"ShopNum1_ProductArticle"
        //        List<ShopNum1_ProductArticle> productArticle = new List<ShopNum1_ProductArticle>();
        //        if (this.ListBoxRightProductArticle.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightProductArticle.Items.Count; i++)
        //            {
        //                ShopNum1_ProductArticle tempProductArticle = new ShopNum1_ProductArticle();
        //                tempProductArticle.ArticleGuid = new Guid(this.ListBoxRightProductArticle.Items[i].Value);
        //                //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //                //tempProductArticle.ProductGuid = product.Guid;  //用的是商品的Guid
        //                //tempProductArticle.CreateUser = product.CreateUser;  //添加人,因为和商品的一样，所有用商品的
        //                //tempProductArticle.CreateTime = product.CreateTime; //添加时间,因为和商品的一样，所有用商品的
        //                productArticle.Add(tempProductArticle);

        //            }
        //        }
        //        #endregion

        //        #region 扩展分类"ShopNum1_ProdcutExtendType"
        //        List<ShopNum1_ProdcutExtendType> prodcutExtendType = new List<ShopNum1_ProdcutExtendType>();

        //        if (this.ListBoxRightProductExtendCategory.Items.Count > 0)
        //        {
        //            for (int i = 0; i < this.ListBoxRightProductExtendCategory.Items.Count; i++)
        //            {
        //                ShopNum1_ProdcutExtendType tempProdcutExtendType = new ShopNum1_ProdcutExtendType();
        //                tempProdcutExtendType.ProductCategoryID = Convert.ToInt32(this.ListBoxRightProductExtendCategory.Items[i].Value);
        //                //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //                //prodcutExtendType.ProductGuid = product.Guid;  //用的是商品的Guid
        //                //prodcutExtendType.CreateUser = product.CreateUser;  //添加人,因为和商品的一样，所有用商品的
        //                //prodcutExtendType.CreateTime = product.CreateTime; //添加时间,因为和商品的一样，所有用商品的
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
        //                    tempProductMemberRankPrice.ProductGuid = product.Guid;   //商品的Guid
        //                    //等级价格
        //                    tempProductMemberRankPrice.Price = Convert.ToDecimal(((TextBox)this.Num1GridViewAgentPrice.Rows[i].Cells[2].Controls[0]).Text);
        //                    //会员等级Guid
        //                    tempProductMemberRankPrice.MemberRankGuid = new Guid(this.Num1GridViewAgentPrice.Rows[i].Cells[0].Text);

        //                    //以下的在ShopNum1_Production_Action中都有，都用的是商品的信息
        //                    tempProductMemberRankPrice.CreateUser = product.ModifyUser;  //添加人,因为和商品的一样，所有用商品的
        //                    tempProductMemberRankPrice.CreateTime = product.ModifyTime; //添加时间,因为和商品的一样，所有用商品的
        //                    tempProductMemberRankPrice.ModifyUser = product.ModifyUser; //最后修改人,因为和商品的一样，所有用商品的
        //                    tempProductMemberRankPrice.ModifyTime = product.ModifyTime; //最后修改时间,因为和商品的一样，所有用商品的

        //                    productAction.AddMemberRankPrice(tempProductMemberRankPrice);

        //                }
        //            }
        //        }

        //        if (check > 0)
        //        {
        //            #region  操作日志部分
        //            ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog();
        //            operateLog.Record = "编辑" + this.TextBoxName.Text.Trim() + "成功!";
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

        //                    if (dataTable.Rows[0]["IsForcibly"].ToString() == "1")  //判断是否是强制代理产品线
        //                    {
        //                        if (dataTable.Rows[0]["AgentID"].ToString() != "")  //判断产品线是否授权
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


        //            //显示操作信息
        //            this.MessageShowTb.ShowMessage("EditYes");
        //            this.MessageShowTb.Visible = true;

        //            //添加成功后清空控件
        //            ClearControl();
        //            decimal numiid = GetNumiid(product.Guid.ToString());
        //            if (CheckBoxTb.Visible == false)
        //            {

        //                #region  操作淘宝
        //                ///更新淘宝商品
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
        //                ///修改淘宝商品
        //                //  updateTbItem(numiid.ToString());
        //                // }
        //                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "err", "alert('添加成功')", true);
        //                //ClientScript.RegisterClientScriptBlock(typeof(Page), "err", "alert('添加成功')", true);
        //                #endregion
        //            }
        //            else
        //            {
        //                if (CheckBoxTb.Checked)
        //                {
        //                    #region
        //                    if (numiid == 0)
        //                    {
        //                        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数

        //                        if (ViewState["cid"] == null)
        //                        {
        //                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "msg", "alert(\"还没选择分类\")", true);
        //                            return;
        //                        }

        //                        //系统叶子类目cid
        //                        string cid = string.Empty;
        //                        cid = ViewState["cid"].ToString();
        //                        ///店铺自定义类目分类
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

        //                        ///新旧程度
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

        //                        ///宝贝标题
        //                        string title = txtTitle.Text.Trim();

        //                        //宝贝数量
        //                        string num = txtCount.Text.Trim();

        //                        ///省份
        //                        string province = ddlProvince.SelectedItem.Text.Trim().Replace("省", "").TrimEnd();

        //                        ///城市
        //                        string city = ddlCity.SelectedItem.Text.Trim().Replace("市", "").TrimEnd();

        //                        ///运费承担方
        //                        string freight_payer = radSeller.Checked ? "seller" : "buyer";
        //                        if (radFreight1.Checked && radBuyer.Checked)
        //                        {
        //                            freight_payer = "seller";
        //                        }
        //                        else if (radFreight2.Checked && radBuyer.Checked)
        //                        {
        //                            ///自定义设置邮费
        //                            param.Add("post_fee", txtSurfaceMail.Text.Trim());
        //                            param.Add("express_fee", txtExpress.Text.Trim());
        //                            param.Add("ems_fee", txtEms.Text.Trim());
        //                        }


        //                        ///有效时间
        //                        decimal valid_thru = radSeven.Checked == true ? 7 : 14;

        //                        //是否有发票
        //                        string has_invoice = radInvoiceYes.Checked == true ? "true" : "false";

        //                        ///是否有保
        //                        string has_warranty = radServiceNo.Checked == true ? "true" : "false";

        //                        //是否打折
        //                        string has_discount = radDicCountYes.Checked == true ? "true" : "false";

        //                        ///商户编码
        //                        string outer_id = txtNumCode.Text.Trim();

        //                        ///一口价
        //                        string price = txtOnePrice.Text.Trim();

        //                        //返点比例
        //                        string auction_point = txtRate.Text.Trim();

        //                        ///上架状态
        //                        string approve_status = radPut.Checked == true ? "onsale" : "instock";

        //                        //是否橱窗推荐
        //                        string has_showcase = cboxYes.Checked == true ? "true" : "false";

        //                        string strXml = string.Empty;

        //                        param.Add("num", num);
        //                        //param.Add("pic_path", ImageOriginalImge.Src);
        //                        param.Add("price", price);
        //                        param.Add("type", "fixed");
        //                        param.Add("stuff_status", stuff_status);
        //                        //param.Add("input_str", "other;型号;other;");
        //                        //param.Add("input_pids", "2000");
        //                        param.Add("title", title);
        //                       // string desc = this.FCKeditorDetail.Value;  //商品详细
        //                        //desc = desc == "" ? "请光顾我的商品!" + title : desc;
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
        //                        //  是否保修
        //                        param.Add("has_warranty", has_warranty);

        //                        //是否橱窗推荐
        //                        param.Add("has_showcase", has_showcase);

        //                        //商家自定义分类 
        //                        param.Add("seller_cids", seller_cids.ToString());

        //                        // 商家编码
        //                        param.Add("outer_id", outer_id);
        //                        ///商家
        //                        param.Add("auction_point", auction_point);
        //                        param.Add("props", GetAddProps());

        //                        strXml = TopAPI.Post("taobao.item.add", TopClient.AdminSession, param);

        //                        ErrorRsp err = new ErrorRsp();
        //                        ItemResponse itemRsp = new ItemResponse();
        //                        new Parser().XmlToObject2(strXml, "item_add", "item", itemRsp, err);

        //                        //if (err.IsError)//判断是否更新过程中发生错误
        //                        //{
        //                        //    //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //                        //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"添加商品失败！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
        //                        //    return;
        //                        //}
        //                        if (!err.IsError)
        //                        {
        //                            ///处理图片上传
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
        //                                        // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"淘宝上传图片的时候出现错误！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
        //                                    }
        //                                }
        //                                catch (Exception)
        //                                {

        //                                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"淘宝上传图片失败\")"), true);

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
        //                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert(\"商品编辑成功,但是同步淘宝出现问题!" + err.msg + "\")", true);
        //                        }

        //                    }
        //                    #endregion
        //                }

        //            }
        //        }
        //        else
        //        {
        //            //显示操作信息
        //            this.MessageShowTb.ShowMessage("EditNo");
        //            this.MessageShowTb.Visible = true;
        //        }

        //        #endregion
        //    }
        //}

        ////用于选择供应商的用户ID
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

        ////绑定添加属性名称(添加时的属性名称)
        //protected void BindDropDownListAttributeName()
        //{
        //    this.DropDownListAttributeName.Items.Clear();

        //    ListItem listItem1 = new ListItem();
        //    //listItem1.Text = "-请选择-";
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

        ////清空控件
        //protected void ClearControl()
        //{

        //}


        //#region 编辑部分代码

        ////取编辑商品信息
        //protected void GetEditProductInfo()
        //{
        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    //删除标志传-1，不限制是否删除过的
        //    DataTable dataTable = productAction.Search(this.hiddenFieldGuid.Value, -1);
        //    //商品名称
        //    this.TextBoxName.Text = dataTable.Rows[0]["Name"].ToString();
        //    //用的都是原图
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
        //    //库存编号(货号)
        //    this.TextBoxRepertoryNumber.Text = dataTable.Rows[0]["RepertoryNumber"].ToString();
        //    //商品重量
        //    this.TextBoxWeight.Text = dataTable.Rows[0]["Weight"].ToString();
        //    //库存量
        //    this.TextBoxRepertoryCount.Text = dataTable.Rows[0]["RepertoryCount"].ToString();
        //    //单位名
        //    this.TextBoxUnitName.Text = dataTable.Rows[0]["UnitName"].ToString();
        //    //库存警告数量
        //    this.TextBoxNameRepertoryAlertCount.Text = dataTable.Rows[0]["RepertoryAlertCount"].ToString();
        //    //赠送消费红包
        //    this.TextBoxPresentRankScore.Text = dataTable.Rows[0]["PresentScore"].ToString();
        //    //赠送等级红包
        //    this.TextBoxPresentScore.Text = dataTable.Rows[0]["PresentRankScore"].ToString();
        //    //红包购买额度
        //    this.TextBoxSocreIntegral.Text = dataTable.Rows[0]["SocreIntegral"].ToString();
        //    //每人次限制购买数量
        //    this.TextBoxLimitBuyCount.Text = dataTable.Rows[0]["LimitBuyCount"].ToString();
        //    //成本价
        //    this.TextBoxCostPrice.Text = dataTable.Rows[0]["CostPrice"].ToString();
        //    //市场价 
        //    this.TextBoxMarketPrice.Text = dataTable.Rows[0]["MarketPrice"].ToString();
        //    //本店售价
        //    this.TextBoxShopPrice.Text = dataTable.Rows[0]["ShopPrice"].ToString();
        //    //商品简单介绍
        //    this.TextBoxBrief.Text = dataTable.Rows[0]["Brief"].ToString();
        //    //商家备注
        //    this.TextBoxMemo.Text = dataTable.Rows[0]["Memo"].ToString();
        //    //商品详细
        //    this.FCKeditorDetail.Value = this.Server.HtmlDecode(dataTable.Rows[0]["Detail"].ToString());
        //    //是否上架
        //    this.DropDownListIsSaled.SelectedValue = dataTable.Rows[0]["IsSaled"].ToString();
        //    //是否是精品
        //    if (dataTable.Rows[0]["IsBest"].ToString() == "0")
        //    {
        //        this.CheckBoxIsBest.Checked = false;
        //    }
        //    else
        //    {
        //        this.CheckBoxIsBest.Checked = true;
        //    }
        //    //是否是新品
        //    if (dataTable.Rows[0]["IsNew"].ToString() == "0")
        //    {
        //        this.CheckBoxIsNew.Checked = false;
        //    }
        //    else
        //    {
        //        this.CheckBoxIsNew.Checked = true;
        //    }
        //    //是否热销
        //    if (dataTable.Rows[0]["IsHot"].ToString() == "0")
        //    {
        //        this.CheckBoxIsHot.Checked = false;
        //    }
        //    else
        //    {
        //        this.CheckBoxIsHot.Checked = true;
        //    }
        //    //是否推荐
        //    if (dataTable.Rows[0]["IsRecommend"].ToString() == "0")
        //    {
        //        this.CheckBoxIsRecommend.Checked = false;
        //    }
        //    else
        //    {
        //        this.CheckBoxIsRecommend.Checked = true;
        //    }

        //    //是否是实物
        //    this.DropDownListIsReal.SelectedValue = dataTable.Rows[0]["IsReal"].ToString();
        //    //是否能单独销售(销售方式)
        //    this.DropDownListIsOnlySaled.SelectedValue = dataTable.Rows[0]["IsOnlySaled"].ToString();
        //    //详细页标题
        //    this.TextBoxTitle.Text = dataTable.Rows[0]["Title"].ToString();
        //    //详细页描述
        //    this.TextBoxDescription.Text = dataTable.Rows[0]["Description"].ToString();
        //    //详细页搜索关键字
        //    this.TextBoxKeywords.Text = dataTable.Rows[0]["Keywords"].ToString();
        //    //商品排序
        //    this.TextBoxOrderID.Text = dataTable.Rows[0]["OrderID"].ToString();
        //    //供应商
        //    this.DropDownListSupplierGuid.SelectedValue = dataTable.Rows[0]["SupplierGuid"].ToString();
        //    //商品分类
        //    //this.DropDownListProductCategoryID.SelectedValue = dataTable.Rows[0]["ProductCategoryID"].ToString();

        //    #region  //确定添加商品选择是有分类
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
        //                //三级分类
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

        //                    #region 绑定分类
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
        //                //二级分类
        //                DataTable dataTable21 = null;
        //                string strCategoryID21 = string.Empty;
        //                dataTable21 = productCategoryAction.GetFatherIDProductCategory(strCategoryID3);
        //                if (dataTable21 != null && dataTable21.Rows.Count > 0)
        //                {
        //                    strCategoryID21 = dataTable21.Rows[0]["FatherID"].ToString();
        //                    #region 绑定分类
        //                    this.DropDownListProductCategoryID1.SelectedValue = strCategoryID3;
        //                    DropDownListProductCategoryID1_SelectedIndexChanged(null, null);
        //                    this.DropDownListProductCategoryID2.SelectedValue = ProductCode;
        //                    DropDownListProductCategoryID2_SelectedIndexChanged(null, null);
        //                    break;
        //                    #endregion
        //                }
        //                break;
        //            case "1":
        //                //一级分类
        //                #region 绑定分类
        //                this.DropDownListProductCategoryID1.SelectedValue = ProductCode;
        //                DropDownListProductCategoryID1_SelectedIndexChanged(null, null);
        //                #endregion

        //                break;
        //        }
        //    }
        //    #endregion

        //    //商品品牌
        //    this.DropDownListBrandGuid.SelectedValue = dataTable.Rows[0]["BrandGuid"].ToString();

        //    //商品类型
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

        ////取编辑相关配件
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

        ////取编辑相关商品
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
        //            str = "单向关联";
        //        }
        //        else
        //        {
        //            str = "双向关联";
        //        }
        //        tempItem.Text = dataTable.Rows[i]["Name"].ToString() + "--" + str;
        //        tempItem.Value = dataTable.Rows[i]["Guid"].ToString() + ";" + dataTable.Rows[i]["IsBoth"].ToString();
        //        this.ListBoxRightRelatedProduct.Items.Add(tempItem);
        //    }
        //}

        /////取编辑的相关资讯
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

        ////取扩展分类
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

        ////取会员等级价格
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

        ////取分销商等级价格
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

        ////取商品多图
        //protected void GetProductImage()
        //{
        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    DataTable dataTable = productAction.GetProductImage(this.hiddenFieldGuid.Value.Replace("'", ""));

        //    DataView tempDataView = dataTable.DefaultView;
        //    tempDataView.Sort = "CreateTime DESC";
        //    this.DataListPorductImage.DataSource = dataTable.DefaultView;
        //    this.DataListPorductImage.DataBind();

        //    //如果是编辑的话先将图片ViewState中
        //    ViewState["dataMultiImage"] = dataTable;

        //}

        ////取不带商品价格的商品属性的值
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
        ////                //0，为手工输入；1，为选择输入；2，为多行文本输入',
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

        ////取带商品价格的商品属性的值


        //protected void GetProductAttribute2()
        //{
        //    ShopNum1_Product_Action productAction = (ShopNum1_Product_Action)LogicFactory.CreateShopNum1_Product_Action();
        //    DataTable dataTable = productAction.SearchEditProductAttribueValue2(this.hiddenFieldGuid.Value.Replace("'", ""));
        //    Num1GridViewProductyAttributePrice.DataSource = dataTable.DefaultView;
        //    Num1GridViewProductyAttributePrice.DataBind();

        //    //将绑定过的商品价格存到ViewSate中
        //    ViewState["dataProductyAttributePrice"] = dataTable;
        //    //绑定添加属性名称(添加时的属性名称)
        //    BindDropDownListAttributeName();
        //}
        //#endregion

        ///// <summary>
        ///// 检测是否使用产品线
        ///// </summary>
        ///// <returns></returns>
        //public bool CheckProductLine()
        //{
        //    ShopSettings shopSettings = new ShopSettings();
        //    string filePath = Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");

        //    bool agentProductLine = bool.Parse(shopSettings.GetValue(filePath, "AgentProductLine"));

        //    return agentProductLine;
        //}

        ////检测联盟提成方式
        //public string CheckUnionType()
        //{
        //    ShopSettings shopSettings = new ShopSettings();
        //    string filePath = Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");

        //    return shopSettings.GetValue(filePath, "UnionType");
        //}


        //#region 商品属性
        ///// <summary>
        ///// 显示商品属性
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
        //                dr["Name"] = "-请选择-";
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

        ////返回主站选择的ID
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

        ////返回主站选择的Name
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


        //#region  淘宝api 操作

        ////读取子类xml数据到对象中
        //private List<ShopNum1_TbSysItemCat> XmlInsetObject(string fatherCid)
        //{
        //    Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        //    //需返回的字段列表。
        //    param.Add("fields", "cid,parent_cid,name,is_parent,status,sort_order");
        //    param.Add("parent_cid", fatherCid);
        //    string strXml = TopAPI.Post("taobao.itemcats.get", TopClient.AdminSession, param);
        //    List<ShopNum1_TbSysItemCat> sysItems = new List<ShopNum1_TbSysItemCat>();//定义淘宝商品系统分类
        //    Parser parser = new Parser();//定义解析XML对象
        //    ErrorRsp err = new ErrorRsp();
        //    //total = parser.XmlToTotalResults(strXml, "itemcats.get");
        //    parser.XmlToObject2<ShopNum1_TbSysItemCat>(strXml, "itemcats_get", "item_cats/item_cat", sysItems, err);

        //    if (err.IsError == true)
        //    {
        //        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");window.location.href=\"/index.aspx\";", err.code, err.msg, err.sub_code, err.sub_msg), true);
        //        return null;
        //    }

        //    return sysItems;
        //}

        ///// <summary>
        ///// 淘宝商品更新
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
        //    if (err.IsError || tbitem == null)//判断是否更新过程中发生错误
        //    {
        //        ////string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"添加商品失败！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
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
        //        ClientScript.RegisterClientScriptBlock(typeof(Page), "err", "alert('修改成功')", true);
        //    }
        //    else 
        //    {
        //        ClientScript.RegisterClientScriptBlock(typeof(Page), "err", "alert('"+err.msg+"')", true);
        //    }
        //}

        ///// <summary>
        ///// 商品同步状态
        ///// </summary>
        ///// <param name="guid"></param>
        ///// <returns></returns>
        //protected string GetItemStatus(string guid)
        //{
        //    if (!TopClient.isAdminSessionTrue)
        //    {
        //        return "未授权";
        //    }
        //    //选查找淘宝商品是否存在

        //  //  CheckProductByNumiid(guid);

        //    ShopNum1_TbItem_Action tbItemOperate = (ShopNum1_TbItem_Action)LogicTbFactory.CreateShopNum1_TbItem_Action();

        //    DataSet ds = tbItemOperate.checkItemSiteExists(guid);
        //    if (ds == null || ds.Tables.Count == 0)
        //    {
        //        return "未同步";
        //    }
        //    else
        //    {
        //        int cout = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalCount"]);
        //        if (cout > 0)
        //            return "已同步";
        //        else
        //            return "未同步";
        //    }

        //}

        ////private void CheckProductByNumiid(string numiid)
        ////{
        ////    Dictionary<string, string> param = new Dictionary<string, string>();
        ////    param.Add("fields", "num_iid");
        ////    param.Add("nick", TopClient.AdminUserNick);
        ////    param.Add("num_iid", numiid);

        ////    string strXml = TopAPI.Post("taobao.item.get", TopClient.AdminSession, param);
        ////    //ShopNum1_TbItem tbItem = new ShopNum1_TbItem();//定义商品
        ////    //ErrorRsp errItem = new ErrorRsp();//定义错误对象
        ////    //Parser parser = new Parser();
        ////    //parser.XmlToObject2(strXml, "item_get", "item", tbItem, errItem);

        ////    File.AppendAllText(HttpContext.Current.Server.MapPath("~/log/log.txt"), strXml + "\r\n" + numiid, Encoding.UTF8);
        ////    //if(strXml .Contains())
        ////    //{

        ////    //}


        ////}

        ///// <summary>
        ///// 获取商品的数字numiid
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
        ///// 检查网站的商品淘宝是否存在
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


        ///// 绑定淘宝商品分类
        ///// </summary>
        //protected void BindTbCat()
        //{


        //    this.TreeViewTb.Nodes.Clear();

        //    ShopNum1_TbSellCat_Action tbsellCatOperate = (ShopNum1_TbSellCat_Action)LogicTbFactory.CreateShopNum1_TbSellCat_Action();
        //    //取顶级分类
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
        //            ///如果有子s分类
        //            AddSubTbCat(node, dataTable, dr["cid"].ToString());
        //        }


        //    }
        //}
        ////添加子分类
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
        /////第一列表
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
        //        // lbox2.Items.Insert(0, new ListItem("请选择","0"));
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
        ///// 属性初始化
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
        /////第二列表
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
        //        // lbox3.Items.Insert(0, new ListItem("请选择","0"));
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
        /////第三列表
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
        //        //  lbox4.Items.Insert(0, new ListItem("请选择","0"));
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
        ///// 第四列表
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
        //        //  lbox5.Items.Insert(0, new ListItem("请选择","0"));
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
        ///// 第五列表
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
        ///// 获取产品类表
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
        //    if (err.IsError == true)//判断是否更新过程中发生错误
        //    {
        //        //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //        // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"添加商品失败！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
        //        return;
        //    }
        //}

        ///// <summary>
        ///// 省份绑定
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
        ///// 城市绑定
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
        ///// 省份事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    CitysBind();
        //}


        //#region 商品属性
        //#region  非关键属性

        ///// <summary>
        ///// 获取产品属性
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
        //    if (err.IsError)//判断是否更新过程中发生错误
        //    {
        //        //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //        // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"添加非关键属性失败！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
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
        ///// 属性值绑定 
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
        //            ddlistValues.Items.Insert(0, new ListItem("请选择", "0"));
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
        //                    ddlistValues2.Items.Insert(0, new ListItem("请选择", "0"));
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
        ///// 获取属性值
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
        //    if (err.IsError == true)//判断是否更新过程中发生错误
        //    {
        //        //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //        // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"{4}获取属性值出错！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg,pid.ToString()), true);
        //        return null;
        //    }
        //    foreach (ShopNum1_TbPropValue propvalue in propValues)
        //    {
        //        propvalue.pvs = pid + ":" + propvalue.vid;
        //    }
        //    return propValues;

        //}

        ///// <summary>
        ///// 销售属性绑定
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
        //            ddlistValues.Items.Insert(0, new ListItem("请选择", "0"));
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
        //            ddlistValues2.Items.Insert(0, new ListItem("请选择", "0"));
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

        //#region  关键属性品牌处理
        ///// <summary>
        ///// 品牌
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
        ///// 品牌绑定
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
        //    if (err.IsError)//判断是否更新过程中发生错误
        //    {
        //        //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"绑定品牌属性失败！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
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
        //        ddlistPropValues1.Items.Insert(0, new ListItem("请选择", "0"));
        //    }
        //    else
        //    {
        //        PropRest();
        //    }

        //}

        ///// <summary>
        ///// 返回第二属性
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
        //    if (err.IsError == true)//判断是否更新过程中发生错误
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
        ///// 品牌扩展属性
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
        //    if (err.IsError == true)//判断是否更新过程中发生错误
        //    {
        //        //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"品牌扩展属性失败！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);

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
        //        ddlistPropValues2.Items.Insert(0, new ListItem("请选择", "0"));
        //    }
        //    else
        //    {
        //        ddlistPropValues2.Visible = false;
        //        lblPropValue.Text = "";
        //    }

        //}

        ///// <summary>
        ///// 第三属性值绑定
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
        //    if (err.IsError == true)//判断是否更新过程中发生错误
        //    {
        //        //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
        //        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"添加商品属性失败！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
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
        //        ddlistPropValues3.Items.Insert(0, new ListItem("请选择", "0"));
        //    }
        //    else
        //    {
        //        ddlistPropValues3.Visible = false;
        //        lblPropValue.Text = "";
        //    }

        //}


        //#endregion


        ///// <summary>
        ///// 获取属性props 的方法
        ///// </summary>
        //protected string GetAddProps()
        //{

        //    StringBuilder props = new StringBuilder();
        //    //if (ddlistPropValues1.DataSource != null)
        //    //{

        //    ///关键属性
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
        //    ///其它属性
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

        //    ///销售属性表 
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
        ///// 授权情况
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void CheckBoxTb_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (!TopClient.isAdminSessionTrue)
        //    {
        //        CheckBoxTb.Checked = false;
        //        this.ClientScript.RegisterClientScriptBlock(Page.GetType(), "msg", "<script type='text/javascript'>alert('请先获取授权，再进行同步操作')</script>");
        //        return;
        //    }
        //}

        ///// <summary>
        ///// 授权情况
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void CheckBoxTbUpdate_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (!TopClient.isAdminSessionTrue)
        //    {
        //        CheckBoxTbUpdate.Checked = false;
        //        this.ClientScript.RegisterClientScriptBlock(Page.GetType(), "msg", "<script type='text/javascript'>alert('请先获取授权，再进行同步操作')</script>");
        //        return;
        //    }
        //}

        //#endregion
    }
}