/************************************************************
Design:By t(唐江国际)
WebSite:http://www.t.com
ShopNum1 WebSite:http://www.shopnum1.cn
Coder:WFK
Date:2008-12-21
************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.TbLinq;
using ShopNum1.TbTopCommon;
using ShopNum1MultiEntity;
using LogicFactory = ShopNum1.ShopFactory.LogicFactory;



namespace ShopNum1.Deploy.Shop.ShopAdmin.TbTop
{
    public partial class TbProductCategory_Operate : Page
    {
        //一个空格
        protected char charSapce = '　';
        protected string strSapce = "　　";

        /// <summary>
        ///     会员ID
        /// </summary>
        public string MemLoginID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            hiddenFieldGuid.Value = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"];
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                //退出
                GetUrl.RedirectTopLogin();
            }
            else
            {
                HttpCookie cookieShopMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
                string MemberType = decodedCookieShopMemberLogin.Values["MemberType"];
                if (MemberType != "2")
                {
                    //退出
                    GetUrl.RedirectTopLogin();
                    return;
                }
                //会员登录ID
                MemLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];

                BindCateGory();

                if (!TopClient.IsAgentLogin)
                {
                    CheckBoxTb.Enabled = false;
                }

                if (hiddenFieldGuid.Value != "0")
                {
                    if (!Page.IsPostBack)
                    {
                        LabelTitle.Text = "编辑商品分类";
                        GetEditInfo();
                        ///淘宝同步状态
                        if (CheckCatExists(Convert.ToInt32(hiddenFieldGuid.Value)))
                        {
                            //MessageBox.Show("sss");
                            spanTb.InnerText = "(已同步)";
                        }
                    }
                }
                else
                {
                    GetOrderID();
                }
            }
        }

        private void BindCateGory()
        {
            var listitems = new ListItem();
            listitems.Text = "顶级分类";
            listitems.Value = "0";
            DropDownListFatherCateGory.Items.Add(listitems);
            var shop_ProductCategory_Action =
                (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
            shop_ProductCategory_Action.TableName = "ShopNum1_shop_ProductCategory";
            DataTable dataTable = shop_ProductCategory_Action.GetShopProductCategoryCode("0", MemLoginID);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var items = new ListItem();
                items.Text = dataRow["Name"].ToString();
                items.Value = dataRow["ID"].ToString();
                DropDownListFatherCateGory.Items.Add(items);
            }
        }


        /// <summary>
        ///     检查分类下面是否有商品（有商品就返回false否则返回true）
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        private bool CheckItemSetItem(string cid)
        {
            //if (!TopClient.isAdminSessionTrue)
            //{
            //    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert(\"您还没有获取授权\")", true);
            //    return false;
            //}
            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
            param.Add("fields", "cid");
            param.Add("cid", cid);
            param.Add("nicks", TopClient.AdminUserNick);
            string strXml = TopAPI.Post("taobao.items.search", TopClient.AdminSession, param);
            var parser = new Parser();
            int i = parser.XmlToTotalResults(strXml, "item_search"); //如：解析XML的数量
            if (i == 0)
            {
                return true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert(\"上一级中有商品\")", true);
                return false;
            }
        }

        private void SearchCategory(string ID)
        {
            var shop_ProductCategory_Action =
                (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
            shop_ProductCategory_Action.TableName = "ShopNum1_shop_ProductCategory";
            DataTable datatable = shop_ProductCategory_Action.GetShopProductCategoryCode(ID, MemLoginID);
            foreach (DataRow dataRow in datatable.Rows)
            {
                string str = string.Empty;
                for (int i = 0; i < Convert.ToInt32(dataRow["CategoryLevel"].ToString()) - 1; i++)
                {
                    //strSpace是两个空格
                    str = str + strSapce;
                }
                //str = str + dataRow["Name"].ToString().Trim(); 
                var items = new ListItem();
                items.Text = str + dataRow["Name"];
                items.Value = dataRow["ID"].ToString();
                DropDownListFatherCateGory.Items.Add(items);
                SearchCategory(dataRow["ID"].ToString());
            }
        }


        protected void GetOrderID()
        {
            var shopcomm = (Shop_Common_Action) LogicFactory.CreateShop_Common_Action();
            //string order_id = "OrderID", shopnum1_productcategory = "ShopNum1_ProductCategory";
            //this.TextBoxOrderID.Text = Convert.ToString(1 + shopNum1_Common_Action.ReturnMaxID(order_id, shopnum1_productcategory));

            TextBoxOrderID.Text = Convert.ToString(shopcomm.ReturnMaxIDByMemLoginID(MemLoginID) + 1);
        }

        private void GetEditInfo()
        {
            var shop_ProductCategory_Action =
                (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
            shop_ProductCategory_Action.TableName = "ShopNum1_shop_ProductCategory";
            DataTable dataTable =
                shop_ProductCategory_Action.GetProductCategoryInfoByCode(hiddenFieldGuid.Value, MemLoginID);
            TextBoxName.Text = dataTable.Rows[0]["Name"].ToString();
            TextBoxKeywords.Text = dataTable.Rows[0]["Keywords"].ToString();
            TextBoxDescription.Text = dataTable.Rows[0]["Description"].ToString();
            TextBoxOrderID.Text = dataTable.Rows[0]["OrderID"].ToString();
            DropDownListFatherCateGory.Text = dataTable.Rows[0]["FatherID"].ToString();
            DropDownListFatherCateGory.Enabled = false;
            if (dataTable.Rows[0]["IsShow"].ToString() == "1")
            {
                CheckBoxIsShow.Checked = true;
            }
            else
            {
                CheckBoxIsShow.Checked = false;
            }
            // this.TextBoxProduceMemLoginID.Text = dataTble.Rows[0]["ProduceMemLoginID"].ToString();
            ButtonConfirm.Text = "更新";
            ButtonConfirm.ToolTip = "Update";
        }

        /// <summary>
        ///     检查分类是否存在
        /// </summary>
        /// <returns></returns>
        private bool CheckCatExists(int id)
        {
            var sellCatOperate =
                (ShopNum1_TbSellCat_Action) LogicTbFactory.CreateShopNum1_TbSellCat_Action();
            decimal tbcid = sellCatOperate.CheckSiteSellCat(id);
            if (tbcid > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (ButtonConfirm.ToolTip == "Submit")
            {
                #region 添加

                ///检查分类是否存在
                CheckSellCat();
                var ProductCategory_Action =
                    (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
                //ShopNum1_Shop_ProductCategory
                var productCategory = new ShopNum1_Shop_ProductCategory();
                productCategory.Name = TextBoxName.Text.Trim();
                productCategory.FatherID = Convert.ToInt32(DropDownListFatherCateGory.SelectedValue);
                productCategory.Keywords = TextBoxKeywords.Text.Trim();
                productCategory.Description = TextBoxDescription.Text.Trim();
                productCategory.OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim());
                if (CheckBoxIsShow.Checked)
                {
                    productCategory.IsShow = 1;
                }
                else
                {
                    productCategory.IsShow = 0;
                }
                productCategory.ID = ProductCategory_Action.GetMaxID(MemLoginID);
                //得到级别
                //先根据一个空格分字符串，如果有4个空格，就是3级，因为2个空格为1级
                if (DropDownListFatherCateGory.SelectedValue == "0")
                {
                    //如果为顶级分类
                    productCategory.CategoryLevel = 1;
                }
                else
                {
                    string[] strLevel = DropDownListFatherCateGory.SelectedItem.Text.Split(charSapce);
                    //  this.Response.Write(strLevel.Length.ToString());
                    if (strLevel.Length > 0)
                    {
                        productCategory.CategoryLevel = ((strLevel.Length + 1)/2) + 1;
                    }
                    else
                    {
                        productCategory.CategoryLevel = 2;
                    }
                    productCategory.CategoryLevel = 2;
                }
                productCategory.Family = string.Empty;
                productCategory.MemLoginID = MemLoginID;

                int check = 0;

                if (CheckBoxTb.Checked)
                {
                    ///和淘宝同步
                    InsertTb(productCategory.ID);
                }

                check = ProductCategory_Action.Add(productCategory);

                //更新
                if (check > 0)
                {
                    //#region  操作日志部分
                    //ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog();
                    //operateLog.Record = "新增" + this.TextBoxName.Text.Trim() + "成功";
                    //operateLog.OperatorID = this.MemLoginID;
                    //operateLog.IP = Globals.IPAddress;
                    //operateLog.PageName = "ProductCategory_Operate.aspx";
                    //operateLog.Date = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //int log = OperateLog(operateLog);
                    //#endregion
                    //显示操作信息

                    //this.MessageShowTb.ShowMessage("AddYes");
                    //this.MessageShowTb.Visible = true;
                    //绑定商品分类
                    BindProductCategory();
                    //清空控件
                    ClearControl();
                    GetOrderID();
                    MessageBox.Show("添加商品分类成功");
                    Response.Redirect("TbProductCategory_List.aspx");
                }
                else
                {
                    //显示操作信息
                    //this.MessageShowTb.ShowMessage("AddNo");
                    //this.MessageShowTb.Visible = true;
                }

                #endregion
            }
            else if (ButtonConfirm.ToolTip == "Update")
            {
                #region 编辑

                if (hiddenFieldGuid.Value == DropDownListFatherCateGory.SelectedValue)
                {
                    //this.MessageShowTb.ShowMessage("EditError");
                    //this.MessageShowTb.Visible = true;
                    return;
                }

                var productCategory = new ShopNum1_Shop_ProductCategory();
                productCategory.ID = Convert.ToInt32(hiddenFieldGuid.Value);
                productCategory.Name = TextBoxName.Text.Trim();
                productCategory.FatherID = Convert.ToInt32(DropDownListFatherCateGory.SelectedValue);
                productCategory.Keywords = TextBoxKeywords.Text.Trim();
                productCategory.Description = TextBoxDescription.Text.Trim();
                productCategory.OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim());
                if (CheckBoxIsShow.Checked)
                {
                    productCategory.IsShow = 1;
                }
                else
                {
                    productCategory.IsShow = 0;
                }

                //得到级别
                //先根据一个空格分字符串，如果有4个空格，就是3级，因为2个空格为1级
                if (DropDownListFatherCateGory.SelectedValue == "0")
                {
                    //如果为顶级分类
                    productCategory.CategoryLevel = 1;
                }
                else
                {
                    string[] strLevel = DropDownListFatherCateGory.SelectedItem.Text.Split(charSapce);
                    //  this.Response.Write(strLevel.Length.ToString());
                    if (strLevel.Length > 0)
                    {
                        productCategory.CategoryLevel = ((strLevel.Length + 1)/2) + 1;
                    }
                    else
                    {
                        productCategory.CategoryLevel = 2;
                    }
                }
                productCategory.Family = string.Empty;
                productCategory.MemLoginID = MemLoginID;

                if (CheckBoxTb.Checked)
                {
                    if (CheckCatExists(Convert.ToInt32(hiddenFieldGuid.Value)))
                    {
                        UpdateTb();
                    }
                    else
                    {
                        //以前不存在就插入
                        InsertTb(productCategory.ID);
                    }
                }

                int check = 0;
                var shop_ProductCategory_Action =
                    (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
                shop_ProductCategory_Action.TableName = "ShopNum1_Shop_ProductCategory";
                check = shop_ProductCategory_Action.Update(productCategory);

                //更新
                if (check > 0)
                {
                    //#region  操作日志部分
                    //ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog();
                    //operateLog.Record = "编辑" + this.TextBoxName.Text.Trim() + "成功";
                    //operateLog.OperatorID = this.MemLoginID;
                    //operateLog.IP = Globals.IPAddress;
                    //operateLog.PageName = "TbProductCategory_Operate.aspx";
                    //operateLog.Date = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //int log = OperateLog(operateLog);
                    //#endregion
                    Response.Redirect("TbProductCategory_List.aspx");
                }
                else
                {
                    ////显示操作信息
                    //this.MessageShowTb.ShowMessage("EditNo");
                    //this.MessageShowTb.Visible = true;
                }

                #endregion
            }
        }


        //#region  淘宝TOP 操作
        /// <summary>
        ///     向淘宝添加类目
        /// </summary>
        /// <returns></returns>
        private void InsertTb(int siteid)
        {
            if (CheckTbUse())
            {
                var param = new Dictionary<string, string>(); //定义 API应用级输入参数
                //需返回的字段列表。
                param.Add("name", TextBoxName.Text.Trim());
                int fatherId = Convert.ToInt32(DropDownListFatherCateGory.SelectedValue);
                string parent_cid = string.Empty;
                var sellCatOperate = (ShopNum1_TbSellCat_Action) LogicTbFactory.CreateShopNum1_TbSellCat_Action();
                parent_cid = fatherId == 0 ? "0" : sellCatOperate.CheckSiteSellCat(fatherId).ToString();

                param.Add("parent_cid", parent_cid);
                string sortOrder = TextBoxOrderID.Text.Trim();
                param.Add("sort_order", "0");
                string strXml = TopAPI.Post("taobao.sellercats.list.add", TopClient.AgentSession, param);
                var errItem = new ErrorRsp(); //定义错误对象
                var parser = new Parser();
                var sellcatResponse = new SellCatResponse();


                ////解析完整的SellCatResponse对象
                parser.XmlToObject2(strXml, "sellercats_list_add", "seller_cat", sellcatResponse, errItem);
                //如：解析XML对象到sellcatResponse
                ///////如果有错的就跳出
                if (!errItem.IsError)
                {
                    //decimal cid = decimal.Parse(sellcatResponse.Cid);
                    decimal d = 0;
                    if (decimal.TryParse(sellcatResponse.Cid, out d))
                    {
                        d = decimal.Parse(sellcatResponse.Cid);
                    }
                    InsertTbSellCat(d, decimal.Parse(parent_cid), siteid, fatherId);
                    return;
                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"同步淘宝错误：错误代码{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");window.location.href=\"/index.aspx\";", errItem.code, errItem.msg, errItem.sub_code, errItem.sub_msg), true);
                    ClientScript.RegisterClientScriptBlock(typeof (Page), "error",
                                                           "<script type='text/javascript'>alert('淘宝同步失败')</script>");
                    return;
                }
            }
        }

        /// <summary>
        ///     @
        ///     修改淘宝类目
        /// </summary>
        private void UpdateTb()
        {
            decimal tbcid = 0;
            if (CheckTbUse())
            {
                var param = new Dictionary<string, string>(); //定义 API应用级输入参数
                //需返回的字段列表。
                int ID = Convert.ToInt32(hiddenFieldGuid.Value);
                var sellCatOperate = (ShopNum1_TbSellCat_Action) LogicTbFactory.CreateShopNum1_TbSellCat_Action();

                tbcid = sellCatOperate.CheckSiteSellCat(ID);
                if (tbcid != 0)
                {
                    param.Add("cid", tbcid.ToString());
                    param.Add("name", TextBoxName.Text.Trim());
                    string sortOrder = TextBoxOrderID.Text.Trim();
                    param.Add("sort_order", "0");
                    string strXml = TopAPI.Post("taobao.sellercats.list.update", TopClient.AdminSession, param);
                    var errItem = new ErrorRsp(); //定义错误对象
                    var parser = new Parser();
                    var sellcatResponse = new SellCatResponse();
                    ////解析完整的SellCatResponse对象
                    parser.XmlToObject2(strXml, "sellercats_list_update", "seller_cat", sellcatResponse, errItem);
                    //如：解析XML对象到sellcatResponse
                    if (errItem.IsError)
                    {
                        ClientScript.RegisterClientScriptBlock(typeof (Page), "msg",
                                                               "<script type='text/javascript'>alert('淘宝同步暂时不能进行')</script>",
                                                               true);
                    }
                    else
                    {
                        UpdateTbSellCat(0, ID);
                    }
                    /////如果有错的就跳出
                    //if (errItem.IsError)
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");window.location.href=\"/index.aspx\";", errItem.code, errItem.msg, errItem.sub_code, errItem.sub_msg), true);
                    //    return 0;
                    //}
                }
            }
        }


        /// <summary>
        ///     操作中间表插入
        /// </summary>
        /// <returns></returns>
        private bool InsertTbSellCat(decimal cid, decimal fathercid, int siteCid, int sitefatherid)
        {
            var sellCat = new ShopNum1_TbSellCat();
            var tbSellCatOperate = (ShopNum1_TbSellCat_Action) LogicTbFactory.CreateShopNum1_TbSellCat_Action();
            //if (fatherId != 0)
            //{
            //    fatherId = ()tbSellCatOperate.CheckSiteSellCat(siteCid);
            //}
            sellCat.cid = cid;
            sellCat.name = TextBoxName.Text.Trim();
            sellCat.pic_url = "";
            sellCat.parent_cid = fathercid;
            sellCat.site_cid = siteCid;
            sellCat.site_parent_cid = sitefatherid;
            sellCat.sort_order = int.Parse(TextBoxOrderID.Text.Trim());
            sellCat.shopname = TopClient.AgentUserNick;
            sellCat.isTaobao = false;
            sellCat.MemloginId = MemLoginID;

            //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "d_"+cid.ToString()+"\r\n");
            //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "d_"+TextBoxName.Text.Trim() + "\r\n");
            //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "d_"+fathercid.ToString() + "\r\n");
            //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "d_" + siteCid.ToString() + "\r\n");
            //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "d_" + sitefatherid.ToString() + "\r\n");
            //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "d_" + TopClient.AgentUserNick + "\r\n");

            //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "B");
            if (tbSellCatOperate.InsertSellCat(sellCat))
            {
                //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "C");
                return true;
            }
            //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "D");
            return false;
        }

        /// <summary>
        ///     更新中间表
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="siteCid"></param>
        /// <returns></returns>
        private bool UpdateTbSellCat(decimal cid, int siteCid)
        {
            var sellCat = new ShopNum1_TbSellCat();
            var tbSellCatOperate = (ShopNum1_TbSellCat_Action) LogicTbFactory.CreateShopNum1_TbSellCat_Action();
            //if (fatherId != 0)
            //{
            //    fatherId = ()tbSellCatOperate.CheckSiteSellCat(siteCid);
            //}
            sellCat.cid = cid;
            sellCat.name = TextBoxName.Text.Trim();
            sellCat.pic_url = "";
            sellCat.site_cid = siteCid;
            sellCat.sort_order = int.Parse(TextBoxOrderID.Text.Trim());
            return tbSellCatOperate.UpdateSellCat(sellCat);
        }


        protected void CheckBoxTb_CheckedChanged(object sender, EventArgs e)
        {
            CheckSellCat();
        }

        /// <summary>
        ///     检查分类是否存在
        /// </summary>
        private void CheckSellCat()
        {
            DropDownListFatherCateGory.Enabled = true;
            if (ButtonConfirm.ToolTip == "Update")
            {
                if (CheckBoxTb.Checked)
                {
                    DropDownListFatherCateGory.Enabled = false;
                }
            }
            var sellCatOperate =
                (ShopNum1_TbSellCat_Action) LogicTbFactory.CreateShopNum1_TbSellCat_Action();
            int fatherId = Convert.ToInt32(DropDownListFatherCateGory.SelectedValue);
            decimal fatherCid = sellCatOperate.CheckSiteSellCat(fatherId);
            if (fatherId != 0)
            {
                if (fatherCid == 0 && CheckBoxTb.Checked)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof (Page), "msg", "alert('上级分类并没有和淘宝同步')", true);
                    CheckBoxTb.Checked = false;
                    DropDownListFatherCateGory.Enabled = true;
                    return;
                }
                if (!CheckItemSetItem(fatherCid.ToString()))
                {
                    CheckBoxTb.Checked = false;
                    DropDownListFatherCateGory.Enabled = true;
                    return;
                }
            }
        }


        /// <summary>
        ///     检查淘宝api是否可用
        /// </summary>
        private bool CheckTbUse()
        {
            //if (!TopClient.isAdminSessionTrue)
            //{
            //    return false;
            //}
            return true;
            // ShopNum1_TbSystem_Action tbSystemOperate = (ShopNum1_TbSystem_Action)LogicTbFactory.CreateShopNum1_TbSystem_Action();
            // DataTable dt = tbSystemOperate.GetTbSysem(TopClient.AdminUserNick);
            //if (dt == null && dt.Rows.Count == 0)
            //{

            //    Num1GridViewShow.Columns[15].Visible = false;
            //    return;
            //}
            //else
            //{
            //    if (Convert.ToBoolean(dt.Rows[0]["isOpen"]))
            //    {
            //        Num1GridViewShow.Columns[15].Visible = true;
            //        btnTbSite.Enabled = true;
            //    }
            //    else
            //    {
            //        Num1GridViewShow.Columns[15].Visible = false;

            //    }

            //}
        }


        /// 绑定商品分类
        /// </summary>
        private void BindProductCategory()
        {
            DropDownListFatherCateGory.Items.Clear();

            //添加顶级分类
            var item = new ListItem();
            item.Text = " 顶级分类";// LocalizationUtil.GetCommonMessage("OneCategory");
            item.Value = "0"; //顶级分类
            DropDownListFatherCateGory.Items.Add(item);

            var productCategoryAction =
                (ShopNum1_ProductCategory_Action) Factory.LogicFactory.CreateShopNum1_ProductCategory_Action();
            //取顶级分类
            DataView dataView = productCategoryAction.Search(0, 0).DefaultView;

            foreach (DataRow dr in dataView.Table.Rows)
            {
                var listItem = new ListItem();
                DataTable dataTable;
                ////如果是一级一分类
                //if (dr["FatherID"].ToString().Trim() == "0")
                //{       
                listItem.Text = dr["Name"].ToString().Trim();
                listItem.Value = dr["ID"].ToString().Trim();

                DropDownListFatherCateGory.Items.Add(listItem);
                //如果有子分类
                dataTable = productCategoryAction.Search(Convert.ToInt32(dr["ID"].ToString().Trim()), 0);
                if (dataTable.Rows.Count > 0)
                {
                    AddSubProductCategory(dataTable);
                }
                //}

                //else
                //{
                //    //子分类
                //    dataTable = productCategoryAction.Search(Convert.ToInt32(dr["ID"].ToString().Trim()), 0);
                //    if (dataTable.Rows.Count > 0)
                //    {
                //        AddSubProductCategory(dataTable);
                //    }
                //    else
                //    {
                //        listItem.Text = "├ " + dr["Name"].ToString().Trim();
                //        listItem.Value = dr["ID"].ToString().Trim();
                //        this.DropDownListFatherCateGory.Items.Add(listItem);
                //    }
                //}

                //this.DropDownListFatherCateGory.Items.Add(listItem);
            }
        }

        //添加子分类
        private void AddSubProductCategory(DataTable dataTable)
        {
            var productCategoryAction =
                (ShopNum1_ProductCategory_Action) Factory.LogicFactory.CreateShopNum1_ProductCategory_Action();
            foreach (DataRow dr in dataTable.Rows)
            {
                var listItem = new ListItem();
                //listItem.Text = dr["Name"].ToString().Trim();
                string str = string.Empty;
                for (int i = 0; i < Convert.ToInt32(dr["CategoryLevel"].ToString()) - 1; i++)
                {
                    //strSpace是两个空格
                    str = str + strSapce;
                }
                //for (int i = 0; i < 2; i++)
                //{
                //    str = str + strSapce;
                //}
                str = str + dr["Name"].ToString().Trim();
                listItem.Text = str;
                listItem.Value = dr["ID"].ToString().Trim();

                DropDownListFatherCateGory.Items.Add(listItem);
                DataTable dataTable1 = productCategoryAction.Search(Convert.ToInt32(dr["ID"].ToString().Trim()), 0);
                if (dataTable1.Rows.Count > 0)
                {
                    AddSubProductCategory(dataTable1);
                }
            }
        }


        //清空控件
        private void ClearControl()
        {
            TextBoxName.Text = string.Empty;
            //this.TextBoxOrderID.Text = string.Empty;
            DropDownListFatherCateGory.SelectedValue = "0";
            TextBoxKeywords.Text = string.Empty;
            TextBoxDescription.Text = string.Empty;
            CheckBoxIsShow.Checked = true;
        }
    }
}