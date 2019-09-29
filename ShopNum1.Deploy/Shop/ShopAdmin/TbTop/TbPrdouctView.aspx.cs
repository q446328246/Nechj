using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.TbBusinessEntity;
using ShopNum1.TbLinq;
using ShopNum1.TbTopCommon;
using ShopNum1MultiEntity;
using LogicFactory = ShopNum1.ShopFactory.LogicFactory;
using PageListBll = ShopNum1.TbTopCommon.PageListBll;

namespace ShopNum1.Deploy.Shop.ShopAdmin.TbTop
{
    public partial class TbPrdouctView : PageBase
    {
        //�����ո�
        //һ���ո�
        private string ProductCategoryName; //ϵͳ��Ʒ��������
        private string ShopName; //��������
        private string brandName; //��������
        private string brandguid; //Ʒ�Ʊ�ʾguid
        protected char charSapce = '��';
        private string prodcategorycode; //ϵͳ��Ʒ����
        private string shopimgpath;
        private string shopproductcategorycode; //������Ʒ����

        private string shopproductcategoryname; //������Ʒ��������

        protected string strLine = " --- ";
        protected string strSapce = "����";

        /// <summary>
        ///     ��Ա��
        /// </summary>
        private string MemLoginID { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            DropDownListOne.SelectedIndexChanged += DropDownListOne_SelectedIndexChanged;
            DropDownListOne.AutoPostBack = true;


            ///��վ��Ʒ���� �¼�
            DropDownListProductCategoryCode1.SelectedIndexChanged +=
                DropDownListProductCategoryCode1_SelectedIndexChanged;
            DropDownListProductCategoryCode2.SelectedIndexChanged +=
                DropDownListProductCategoryCode2_SelectedIndexChanged;
            DropDownListProductCategoryCode3.SelectedIndexChanged +=
                DropDownListProductCategoryCode3_SelectedIndexChanged;

            //������Ʒ���� �¼�
            DropDownListProductSeriesCode1.SelectedIndexChanged +=
                DropDownListProductSeriesCode1_SelectedIndexChanged;
            DropDownListProductSeriesCode2.SelectedIndexChanged +=
                DropDownListProductSeriesCode2_SelectedIndexChanged;
        }

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
                MemLoginID = decodedCookieMemberLogin.Values["MemLoginID"];
            }

            bool isExisit = CheckMemberID(MemLoginID);
            if (!isExisit)
            {
                Response.Redirect("TbAuthorization.aspx");
            }

            if (!TopClient.IsAgentLogin)
            {
                Response.Redirect("TbAuthorization.aspx");
            }
            if (!TopClient.isSessionTimeOut(Page, "agent"))
            {
                Response.Redirect("TbAuthorization.aspx");
            }


            SaveShopCategory();

            if (!IsPostBack)
            {
                ///
                BindTbFirstCategroysCat();

                BindProductList("0");
                ///�󶨵���div
                DropDownListProductSeriesCode1Bind(); //�󶨵�����Ʒ����
                DropDownListProductCategoryCode1Bind(); //����ƽ̨��Ʒ����
                BindImageCategory(); //�󶨵���ͼƬ����
                //BindImageCategory();
            }
            else
            {
                if (Page.Request.Form["pageid"] != null && Page.Request.Form["pageid"] != "0")
                {
                    ///ҳ��
                    string pageid = Page.Request.Form["pageid"];
                    BindProductList(pageid);
                    ViewState["pageid"] = Page.Request.Form["pageid"];
                }
            }
        }


        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
        }

        private bool CheckMemberID(string MemLoginID)
        {
            try
            {
                ShopName =
                    HttpUtility.UrlDecode(
                        HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["visitor_nick"]);
            }
            catch
            {
                ShopName = "";
            }

            var tbSystem = (ShopNum1_TbSystem_Action) LogicTbFactory.CreateShopNum1_TbSystem_Action();
            if (tbSystem.GetTbSysem(MemLoginID, ShopName) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string GetShopName(string MemLoginID)
        {
            string shopname = string.Empty;
            var ShopInfo_Action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();

            DataTable da = ShopInfo_Action.GetShopInfo(MemLoginID);
            if (da.Rows.Count > 0 && da != null)
            {
                shopname = da.Rows[0]["ShopName"].ToString();
            }
            else
            {
                shopname = "";
            }
            return shopname;
        }

        #region   �Զ��巽��

        /// <summary>
        ///     �����Ʒ
        /// </summary>
        /// <param name="isSaled">�Ƿ��ϼ�</param>
        /// <param name="isNew">�Ƿ�����</param>
        /// <param name="isHot">�Ƿ����</param>
        /// <param name="isPromotion">�Ƿ�����</param>
        /// <param name="isPanicBuy">�Ƿ�ƴ��</param>
        /// <param name="isSpellBuy">�Ƿ�����</param>
        public void AddProduct(ShopNum1_TbItem_Action tbItemOperate, TbItem tbItem, ShopNum1_TbSystem tbsystem)
        {
            var shop_Product = new ShopNum1_Shop_Product();
            shop_Product.Guid = Guid.NewGuid();
            shop_Product.Name = tbItem.title;
            shop_Product.ProductNum = tbItem.outer_id;
            shop_Product.OrderID = ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_Shop_Product") + 1;
            shop_Product.ShopPrice = decimal.Parse(tbItem.price);
            shop_Product.MarketPrice = decimal.Parse(tbItem.price);
            shop_Product.IsReal = 1;

            shop_Product.IsSell = RadioButtonIsSaleTrue.Checked ? 1 : 0; //��������
            try
            {
                shop_Product.RepertoryCount = int.Parse(tbItem.num);
            }
            catch
            {
                shop_Product.RepertoryCount = 22;
            }
            shop_Product.IsSaled = 1;
            shop_Product.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shop_Product.UnitName = "";
            shop_Product.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shop_Product.Detail = tbItem.desc;
            shop_Product.Instruction = tbItem.title;

            #region ��Ʒ�����Ʒ�����ȣ�������

            int isNew, isHot, isPromotion, IsShopRecommend;
            isNew = isHot = isPromotion = IsShopRecommend = 0;
            if (CheckBoxIsNew.Checked)
            {
                isNew = 1;
            }
            if (CheckBoxIsHot.Checked)
            {
                isHot = 1;
            }
            if (CheckBoxIsPromotion.Checked)
            {
                isPromotion = 1;
            }
            if (CheckBoxIsShopRecommend.Checked)
            {
                IsShopRecommend = 1;
            }
            shop_Product.IsShopNew = isNew;
            shop_Product.IsShopHot = isHot;
            shop_Product.IsShopPromotion = isPromotion;
            shop_Product.IsShopRecommend = IsShopRecommend;

            #endregion

            shop_Product.OriginalImage = tbItem.pic_url; //��Ʒ��ԭͼ
            shop_Product.ThumbImage = tbItem.pic_url; // WaterMark();
            shop_Product.SmallImage = tbItem.pic_url;
            string mulitimgs = SaveTaobaoImgs(tbItem.num_iid, tbsystem);
            shop_Product.MultiImages = mulitimgs;
            //��������ͼ����
            SimpleImg(mulitimgs);
            shop_Product.Description = tbItem.title;
            shop_Product.Keywords = tbItem.title;
            string IsAudit = ShopSettings.GetValue("AddProductIsAudit"); //�Ƿ���Ҫ���
            if (IsAudit == "0")
            {
                shop_Product.IsAudit = 1;
            }
            else
            {
                shop_Product.IsAudit = 0;
            }
            shop_Product.MemLoginID = MemLoginID;
            shop_Product.ShopName = GetShopName(MemLoginID);
            shop_Product.FeeType = 1;
            shop_Product.Post_fee = 0;
            shop_Product.Express_fee = 0;
            shop_Product.Ems_fee = 0;
            if (tbItem.freight_payer == "buyer")
            {
                shop_Product.FeeType = 0;
                shop_Product.Post_fee = decimal.Parse(tbItem.post_fee);
                shop_Product.Express_fee = decimal.Parse(tbItem.express_fee);
                shop_Product.Ems_fee = decimal.Parse(tbItem.ems_fee);
            }

            shop_Product.MinusFee = 0;

            shop_Product.FeeTemplateID = 0;
            shop_Product.FeeTemplateName = "";

            shop_Product.MinusFee = 0;
            //��վ����
            shop_Product.ProductCategoryCode = prodcategorycode;
            shop_Product.ProductCategoryName = ProductCategoryName;
            //���̷���
            shop_Product.ProductSeriesCode = shopproductcategorycode;
            shop_Product.ProductSeriesName = shopproductcategoryname;

            shop_Product.BrandGuid = new Guid(brandguid);
            shop_Product.BrandName = brandName;
            shop_Product.Wap_desc = "";
            shop_Product.PulishType = 1;
            var product_Action = (Shop_Product_Action) LogicFactory.CreateShop_Product_Action();
            int check = product_Action.AddShopProduct(shop_Product);
            if (check > 0)
            {
                var prditem = new ShopNum1_TbItem();
                prditem.Memlogid = MemLoginID;
                prditem.isTaobao = true;
                prditem.num_iid = Convert.ToDecimal(tbItem.num_iid);
                prditem.ShopName = TopClient.AgentUserNick;
                prditem.site_Id = shop_Product.Guid.ToString();
                tbItemOperate.InsertItem(prditem);
            }
        }

        /// <summary>
        ///     �����Ա���ͼƬ
        /// </summary>
        private string SaveTaobaoImgs(string num_iid, ShopNum1_TbSystem tbsystem)
        {
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
            param.Add("fields", "item_img,num_iid");
            param.Add("nick", TopClient.AgentUserNick);
            param.Add("num_iid", num_iid);
            string strXml = TopAPI.Post("taobao.item.get", TopClient.AgentSession, param);
            var parser = new Parser();
            var itemImgs = new List<TbItemImg>();
            var errItem = new ErrorRsp(); //����������

            parser.XmlToObject2(strXml, "item_get", "item/item_imgs/item_img", itemImgs, errItem);
                //�磺����XML����tbSellCats�ṹ
            if (errItem.IsError)
            {
                return null;
            }
            string muliimgs = string.Empty;
            if ((bool) tbsystem.tbImg)
            {
                for (int i = 0; i < itemImgs.Count; i++)
                {
                    FileItem.DownImage(itemImgs[i].url, shopimgpath); //����ͼƬ
                    muliimgs += shopimgpath + FileItem.GetUrlFileName(itemImgs[i].url) + ",";
                }
            }
            else
            {
                for (int i = 0; i < itemImgs.Count; i++)
                {
                    muliimgs += itemImgs[i].url + ",";
                }
            }
            if (muliimgs != string.Empty)
            {
                muliimgs = muliimgs.Substring(0, muliimgs.Length - 1).Replace("~/", "/");
            }
            return muliimgs;
        }

        //����ͼƬ������ͼ
        private void SimpleImg(string muliimgs)
        {
            string muliimgs25 = string.Empty;
            string muliimgs60 = string.Empty;
            string muliimgs100 = string.Empty;
            string muliimgs160 = string.Empty;
            string muliimgs300 = string.Empty;
            string fileType = string.Empty;
            if (muliimgs.IndexOf(",") != -1)
            {
                string[] muliimgeArray = muliimgs.Split(',');
                for (int i = 0; i < muliimgeArray.Length; i++)
                {
                    fileType = Path.GetExtension(muliimgeArray[i]).ToLower();
                    muliimgs25 = muliimgeArray[i].Replace(fileType, fileType + "_25x25" + fileType);
                    muliimgs60 = muliimgeArray[i].Replace(fileType, fileType + "_60x60" + fileType);
                    muliimgs100 = muliimgeArray[i].Replace(fileType, fileType + "_100x100" + fileType);
                    muliimgs160 = muliimgeArray[i].Replace(fileType, fileType + "_160x160" + fileType);
                    muliimgs300 = muliimgeArray[i].Replace(fileType, fileType + "_300x300" + fileType);
                    ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(muliimgeArray[i]),
                                                      HttpContext.Current.Server.MapPath(muliimgs25), 25, 25);
                    ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(muliimgeArray[i]),
                                                      HttpContext.Current.Server.MapPath(muliimgs60), 60, 60);
                    ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(muliimgeArray[i]),
                                                      HttpContext.Current.Server.MapPath(muliimgs100), 100, 100);
                    ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(muliimgeArray[i]),
                                                      HttpContext.Current.Server.MapPath(muliimgs160), 160, 160);
                    ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(muliimgeArray[i]),
                                                      HttpContext.Current.Server.MapPath(muliimgs300), 300, 300);
                }
            }
        }


        //��ͼƬ��ŵ������


        /// <summary>
        ///     ��ȡ��Ʒurl
        /// </summary>
        /// <param name="numiid"></param>
        /// <returns></returns>
        public string GetProductUrl(object numiid)
        {
            return "http://item.taobao.com/item.htm?id=" + numiid;
        }

        /// <summary>
        ///     ����Ʒ�б�
        /// </summary>
        private void BindProductList(string pageid)
        {
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
            string strXml = string.Empty;
            var err = new ErrorRsp();

            var tbItems = new List<TbItem>(); //������Ʒ
            param.Add("fields",
                      "approve_status,num_iid,title,nick,type,cid,pic_url,num,props,valid_thru,list_time,price,has_discount,has_invoice,has_warranty,has_showcase,modified,delist_time,postage_id,seller_cids,outer_id");
            var parser = new Parser();
            //title
            if (txtTitle.Text.Trim() != "")
            {
                param.Add("q", txtTitle.Text.Trim());
            }

            if (ddlDiscount.SelectedValue != "-1")
            {
                param.Add("has_discount", ddlDiscount.SelectedValue);
            }
            if (ddlshowcase.SelectedValue != "-1")
            {
                param.Add("has_showcase", ddlshowcase.SelectedValue);
            }
            if (DropDownListTwo.SelectedValue != "-1")
            {
                param.Add("seller_cids", DropDownListTwo.SelectedValue);
            }
            else
            {
                if (DropDownListOne.SelectedValue != "-1")
                {
                    param.Add("seller_cids", DropDownListOne.SelectedValue);
                }
            }

            //�����ҳ
            var pagelist = new PageList();

            pagelist.PageSize = 10;
            pagelist.PageID = int.Parse(pageid);


            //ÿҳ������ȡֵ��Χ:�����������;���ֵ��200��Ĭ��ֵ��40�� 
            param.Add("page_size", pagelist.PageSize.ToString());
            //ҳ�롣ȡֵ��Χ:�����������;Ĭ��ֵΪ1�������ص�һҳ���ݡ� 
            param.Add("page_no", pagelist.PageID.ToString());

            strXml = TopAPI.Post("taobao.items.onsale.get", TopClient.AgentSession, param);

            parser.XmlToObject2(strXml, "items_onsale_get", "items/item", tbItems, err); //�磺����XML������Ʒ�ṹ��

            int total = new Parser().XmlToTotalResults(strXml, "items_onsale_get");
            pagelist.RecordCount = total;
            if (err.IsError) //�жϴ���
            {
                if (err.code == "41")
                {
                    return;
                }
            }

            RepeaterProduct.DataSource = tbItems;
            RepeaterProduct.DataBind();
            //��ʾ��ҳ
            var pagelistHtmlCreate = new PageListBll();
            pagelistHtmlCreate.ShowRecordCount = true;
            pagelistDiv.InnerHtml = pagelistHtmlCreate.GetPageList(pagelist);
        }


        private void SaveShopCategory()
        {
            if (Session["shopcategory"] == null)
            {
                var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
                //�践�ص��ֶ��б�
                param.Add("fields", "cid,parent_cid,name,sort_order");
                param.Add("parent_cid", "0");
                param.Add("nick", TopClient.AgentUserNick);
                string strXml = TopAPI.Post("taobao.sellercats.list.get", TopClient.AgentSession, param);

                var tbSellCats = new List<TbItemCat>(); //���巵���Ա������Զ������

                var errItem = new ErrorRsp(); //����������
                var parser = new Parser();

                parser.XmlToObject2(strXml, "sellercats_list_get", "seller_cats/seller_cat", tbSellCats, errItem);
                //�磺����XML����tbSellCats�ṹ
                //  ViewState["shopcategory"] = tbSellCats;
                Session["shopcategory"] = tbSellCats;
            }
        }


        /// <summary>
        ///     ��ȡ�Ա������Զ������
        /// </summary>
        private void BindTbFirstCategroysCat()
        {
            if (Session["shopcategory"] != null)
            {
                DropDownListOne.Items.Clear();
                DropDownListOne.Items.Add(new ListItem("-ȫ��-", "-1"));
                var tbSellCats = (List<TbItemCat>) Session["shopcategory"];
                foreach (TbItemCat tbsellcat in tbSellCats)
                {
                    if (tbsellcat.parent_cid == "0")
                    {
                        var item1 = new ListItem();
                        item1.Value = tbsellcat.cid;
                        item1.Text = tbsellcat.name;
                        DropDownListOne.Items.Add(item1);
                    }
                }
            }
        }

        /// <summary>
        ///     �Ƿ�ͬ�����Ա�  ����session
        /// </summary>
        /// <returns></returns>
        protected string IsProductTaobao(string numiid)
        {
            if (ViewState["taobaoproduct"] == null)
            {
                var tbItemOperate = (ShopNum1_TbItem_Action) LogicTbFactory.CreateShopNum1_TbItem_Action();
                DataTable dt = tbItemOperate.GetAllItem(TopClient.AgentUserNick, MemLoginID);
                if (dt == null)
                {
                    return "<span style=\"color:red;\">δͬ��</span>";
                }
                ViewState["taobaoproduct"] = dt;
            }
            var dttemp = (DataTable) ViewState["taobaoproduct"];
            foreach (DataRow dr in dttemp.Rows)
            {
                if (numiid == dr["num_iid"].ToString())
                {
                    return "<span>��ͬ��<span>";
                }
            }

            return "<span style=\"color:red;\">δͬ��</span>";
        }

        /// <summary>
        ///     ����Ƿ���Ա�ͬ����
        /// </summary>
        /// <param name="numiid"></param>
        /// <returns></returns>
        private string GetTaoProductGuid(string numiid)
        {
            if (ViewState["taobaoproduct"] == null)
            {
                var tbItemOperate = (ShopNum1_TbItem_Action) LogicTbFactory.CreateShopNum1_TbItem_Action();
                DataTable dt = tbItemOperate.GetAllItem(TopClient.AgentUserNick, MemLoginID);
                ViewState["taobaoproduct"] = dt;
            }
            else
            {
                var dt = (DataTable) ViewState["taobaoproduct"];
                foreach (DataRow dr in dt.Rows)
                {
                    if (numiid == dr["num_iid"].ToString())
                    {
                        return dr["site_Id"].ToString();
                    }
                }
            }
            return "";
        }

        /// <summary>
        ///     ��ȡ���̷�������
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        protected string GetShopCategroyName(string cid)
        {
            string sellcids = string.Empty; //������Ʒ��������

            string[] cidparms = cid.Split(','); //�������

            if (cidparms.Length <= 0)
            {
                return "��";
            }
            else if (cidparms.Length == 1)
            {
                if (cidparms[0] == "" || cidparms[0] == "-1")
                {
                    return "��";
                }
            }

            if (Session["shopcategory"] != null)
            {
                var tbSellCats = (List<TbItemCat>) Session["shopcategory"];

                foreach (string cidparm in cidparms)
                {
                    if (cidparm == "" || cidparm == "-1")
                    {
                        continue;
                    }
                    foreach (TbItemCat tbsellcat in tbSellCats)
                    {
                        if (tbsellcat.cid == cidparm.Trim())
                        {
                            sellcids += tbsellcat.name + ",";
                            break;
                        }
                    }
                }
            }
            if (sellcids == "")
            {
                return "��";
            }
            else
            {
                return sellcids.Substring(0, sellcids.Length - 1);
            }
        }


        /// <summary>
        ///     �޸�������Ʒ
        /// </summary>
        /// <returns></returns>
        private bool UpdateSiteProduct(TbItem tbItem, Guid prodguid, ShopNum1_TbSystem tbsystem)
        {
            var product_Action = (Shop_Product_Action) LogicFactory.CreateShop_Product_Action();
            DataTable dataTable = product_Action.GetShopProductEdit("'" + prodguid.ToString() + "'",CookieCustomerCategory);
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return false;
            }
            var shop_Product = new ShopNum1_Shop_Product();
            shop_Product.Guid = prodguid;
            shop_Product.Name = tbItem.title;
            shop_Product.ProductNum = tbItem.outer_id;
            shop_Product.Score = 0;
            shop_Product.OrderID = Convert.ToInt32(dataTable.Rows[0]["OrderID"]);
            shop_Product.ShopPrice = decimal.Parse(tbItem.price);
            shop_Product.MarketPrice = decimal.Parse(tbItem.price);
            shop_Product.IsReal = Convert.ToInt32(dataTable.Rows[0]["IsReal"]);
            shop_Product.IsSell = RadioButtonIsSaleTrue.Checked ? 1 : 0; //��������
            try
            {
                shop_Product.RepertoryCount = int.Parse(tbItem.num);
            }
            catch
            {
                shop_Product.RepertoryCount = 22;
            }
            shop_Product.UnitName = dataTable.Rows[0]["UnitName"].ToString();
            shop_Product.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shop_Product.Detail = tbItem.desc;
            shop_Product.Instruction = tbItem.title;

            #region ��Ʒ�����Ʒ�����ȣ�������

            int isNew, isHot, isPromotion, IsShopRecommend;
            isNew = isHot = isPromotion = IsShopRecommend = 0;
            if (CheckBoxIsNew.Checked)
            {
                isNew = 1;
            }
            if (CheckBoxIsHot.Checked)
            {
                isHot = 1;
            }
            if (CheckBoxIsPromotion.Checked)
            {
                isPromotion = 1;
            }
            if (CheckBoxIsShopRecommend.Checked)
            {
                IsShopRecommend = 1;
            }
            shop_Product.IsShopNew = isNew;
            shop_Product.IsShopHot = isHot;
            shop_Product.IsShopPromotion = isPromotion;
            shop_Product.IsShopRecommend = IsShopRecommend;

            #endregion

            shop_Product.OriginalImage = tbItem.pic_url; //��Ʒ��ԭͼ
            shop_Product.ThumbImage = tbItem.pic_url; // WaterMark();
            shop_Product.SmallImage = tbItem.pic_url;
            string mulitimgs = SaveTaobaoImgs(tbItem.num_iid, tbsystem);
            shop_Product.MultiImages = mulitimgs;
            SimpleImg(mulitimgs);
            shop_Product.Description = tbItem.title;
            shop_Product.Keywords = tbItem.title;
            string IsAudit = ShopSettings.GetValue("AddProductIsAudit"); //�Ƿ���Ҫ���
            if (IsAudit == "0")
            {
                shop_Product.IsAudit = 1;
            }
            else
            {
                shop_Product.IsAudit = 0;
            }
            shop_Product.MemLoginID = MemLoginID;
            shop_Product.ShopName = GetShopName(MemLoginID);
            shop_Product.FeeType = 1;
            shop_Product.Post_fee = 0;
            shop_Product.Express_fee = 0;
            shop_Product.Ems_fee = 0;
            if (tbItem.freight_payer == "buyer")
            {
                shop_Product.FeeType = 0;
                shop_Product.Post_fee = decimal.Parse(tbItem.post_fee);
                shop_Product.Express_fee = decimal.Parse(tbItem.express_fee);
                shop_Product.Ems_fee = decimal.Parse(tbItem.ems_fee);
            }

            shop_Product.MinusFee = Convert.ToDecimal(dataTable.Rows[0]["MinusFee"]);
            shop_Product.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shop_Product.FeeTemplateID = Convert.ToInt32(dataTable.Rows[0]["FeeTemplateID"]);
            shop_Product.FeeTemplateName = dataTable.Rows[0]["FeeTemplateName"].ToString();
            //��վ����
            shop_Product.ProductCategoryCode = prodcategorycode;
            shop_Product.ProductCategoryName = ProductCategoryName;
            //���̷���
            shop_Product.ProductSeriesCode = shopproductcategorycode;
            shop_Product.ProductSeriesName = shopproductcategoryname;

            shop_Product.BrandGuid = new Guid(brandguid);
            shop_Product.BrandName = brandName;
            int check = product_Action.UpdateShopProduct(shop_Product);
            return true;
        }

        //ȡOrderID
        protected int GetOrderID()
        {
            var shop_CommonAction = (Shop_Common_Action) LogicFactory.CreateShop_Common_Action();
            string order_id = "OrderID", shopnum1_product = "ShopNum1_Shop_Product";
            return shop_CommonAction.ReturnMaxID(order_id, shopnum1_product) + 1;
        }

        /// <summary>
        ///     ������Ʒ������numiid��ȡ��Ʒ�������Ϣ
        /// </summary>
        /// <param name="numiid"></param>
        /// <returns></returns>
        private TbItem GetItemByNumiid(string numiid, ShopNum1_TbSystem tbsystem)
        {
            var param = new Dictionary<string, string>();
            param.Add("fields",
                      "approve_status,num_iid,title,nick,type,cid,pic_url,props,valid_thru,list_time,price,has_discount,has_invoice,has_warranty,has_showcase,modified,delist_time,postage_id,seller_cids,outer_id,num,desc,outer_id,is_virtual");
            param.Add("nick", TopClient.AgentUserNick);
            param.Add("num_iid", numiid);
            string strXml = TopAPI.Post("taobao.item.get", TopClient.AgentSession, param);
            var tbItem = new TbItem(); //������Ʒ
            var errItem = new ErrorRsp(); //����������
            var parser = new Parser();
            parser.XmlToObject2(strXml, "item_get", "item", tbItem, errItem);


            if ((bool) tbsystem.tbImg)
            {
                //����ͼƬ 
                if (tbItem.pic_url != "")
                {
                    // FileItem fileP = new FileItem(tbItem.pic_url, shopimgpath);
                    FileItem.DownImage(tbItem.pic_url, shopimgpath);
                    tbItem.pic_url = shopimgpath + FileItem.GetUrlFileName(tbItem.pic_url);

                    UpLoadImg(tbItem.pic_url);
                }
            }
            else
            {
                // tbItem.pic_url = "";
            }

            return tbItem;
        }

        /// <summary>
        ///     ��ȡ���õ�Ȩ��
        /// </summary>
        private ShopNum1_TbSystem GetTbSystemSet()
        {
            var tbSystemOperate = (ShopNum1_TbSystem_Action) LogicTbFactory.CreateShopNum1_TbSystem_Action();
            ShopNum1_TbSystem tbsytem = tbSystemOperate.GetTbSysem(MemLoginID, TopClient.AgentUserNick);
            return tbsytem;
        }

        //ˮӡ  ����ͼ  dddd
        private bool UpLoadImg(string strimgpath)
        {
            return true;
            //string name = Server.MapPath("~/ImgUpload/" + strimgpath);                  // �ͻ����ļ�·��
            //FileInfo file = new FileInfo(name);
            //// �ļ�����
            //string fileName = file.Name;
            //// ���������ļ�·��
            //string webFilePath = Server.MapPath("~/ImgUpload/" + fileName);
            //string imagepath = "//" + fileName;

            //if (File.Exists(webFilePath))
            //{
            //    //���ˮӡ ����ͼ�ϴ�ʧ�ܼ�����ʾ�ɹ�!
            //    try
            //    {
            //        #region �ж��Ƿ�����ˮӡͼƬ

            //        string strCheck = ShopSettings.GetValue("IfSetWaterMark");

            //        if (strCheck == "0")
            //        {
            //            //������ˮӡ
            //            // ʹ�� SaveAs ���������ļ�
            //        }
            //        else if (strCheck == "1")
            //        {
            //            //����ˮӡ
            //            //�������ˮӡ
            //            string o_webFilePath = Server.MapPath("~/ImgUpload/" + "O_" + fileName);

            //            File.Copy(name, o_webFilePath, true);
            //            //ˮӡ����
            //            string addText = ShopSettings.GetValue("WaterMarkWords");
            //            //ˮӡλ��
            //            string position = ShopSettings.GetValue("WordsWaterMarkPosition");
            //            //����
            //            string fontType = ShopSettings.GetValue("WaterMarkWordsFont");
            //            //�ִ�С
            //            float fontSize = Convert.ToSingle(ShopSettings.GetValue("WaterMarkWordsFontSize"));
            //            //�ֵ���ɫ
            //            string fontColor = ShopSettings.GetValue("WaterMarkWordsColor");
            //            ImageOperator.CreateWater(o_webFilePath, webFilePath, addText, position, fontType, fontSize, fontColor);

            //            File.Delete(o_webFilePath);

            //        }
            //        else if (strCheck == "2")
            //        {
            //            //���ͼƬˮӡ
            //            string o_webFilePath = Server.MapPath("~/ImgUpload/" + "O_" + fileName);
            //            File.Copy(name, o_webFilePath);
            //            //��ShopSettings.xml�ж�ˮӡ��ͼƬ��ַ
            //            //ˮӡͼƬ��ַ
            //            string waterSourcePath = Server.MapPath("~/ImgUpload/" + ShopSettings.GetValue("WaterMarkOriginalImge"));
            //            //ˮӡλ��
            //            string position = ShopSettings.GetValue("WaterMarkImagePosition");

            //            ImageOperator.CreateWaterPic(o_webFilePath, webFilePath, waterSourcePath, position);
            //            File.Delete(o_webFilePath);

            //        }
            //        #endregion
            //        //���뵽���ݿ���
            //        Add(fileName);
            //        string strOriginalImagePath = fileName;

            //        #region ȡ��Ҫ��������ͼ�ĳߴ�

            //        string xmlPath = Server.MapPath(Globals.ApplicationPath + "/Themes/Skin_Default/ImageSpec.xml");
            //        DataSet ds = new DataSet();
            //        ds.ReadXml(xmlPath);

            //        string strData = string.Empty;
            //        foreach (DataRow dataRow in ds.Tables[0].Rows)
            //        {

            //            if (dataRow["name"].ToString().Trim() == "Product")
            //            {
            //                strData = dataRow["Width"].ToString().Trim() + "*" + dataRow["Height"].ToString().Trim();
            //            }
            //        }
            //        string[] strArray = strData.Split('*');
            //        int width = Convert.ToInt32(strArray[0]);
            //        int height = Convert.ToInt32(strArray[1]);

            //        //��������ͼ
            //        string fileName_s = "s" + "_" + file.Name;        // ����ͼ�ļ�����

            //        // ������������ͼ·��
            //        string webFilePath_s = Server.MapPath("~/ImgUpload/" + fileName_s);
            //        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(webFilePath);
            //        ImageOperator.CreateThumbnail(webFilePath, webFilePath_s, width, height, "Cut");
            //        //��ӵ����ݿ�
            //        #endregion
            //        return AddImagePath(strOriginalImagePath, fileName_s);
            //    }
            //    catch
            //    {
            //        return true;
            //    }

            //}
            //else
            //{
            //    return false;
            //}
        }

        /// <summary>
        ///     ��ShopNum1_ImagePath���в�������
        /// </summary>
        /// <param name="originaImagePath"></param>
        /// <param name="otherImagepath"></param>
        protected bool AddImagePath(string originaImagePath, string otherImagepath)
        {
            //shopNum1_ImagePath imagePath = new ShopNum1_ImagePath();

            //imagePath.OriginalImagePath = originaImagePath;
            //imagePath.OtherImagePath = otherImagepath;
            //imagePath.CreateUser = this.ShopNum1LoginID;
            //imagePath.CreateTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //imagePath.ModifyUser = this.ShopNum1LoginID;
            //imagePath.ModifyTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //imagePath.IsDeleted = 0;
            //ShopNum1_ImagePath_Action imagePathAction = (ShopNum1_ImagePath_Action)LogicFactory.CreateShopNum1_ImagePath_Action();
            //int check = imagePathAction.Add(imagePath);
            //if (check > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }


        /// <summary>
        ///     �����ݿ��������
        /// </summary>
        protected void AddImg(string mulitimgs)
        {
            //int id = int.Parse(DropDownListImgCategory.SelectedValue) ;

            //string fileType = Path.GetExtension(mulitimgs).ToLower();
            //shopNum1_Shop_Image.Name = mulitimgs.Replace(fileType, "");
            //shopNum1_Shop_Image.ImageType = fileType;
            //shopNum1_Shop_Image.ImagePath = mulitimgs;
            //shopNum1_Shop_Image.CreateUser = MemLoginID;
            //shopNum1_Shop_Image.ImageCategoryID = id;
            //shopNum1_Shop_Image.ImageSize = (double)file.ContentLength;
            //shopNum1_Shop_Image.DisplaySize = w + "��" + h;
            //shop_Image_Action.Insert(shopNum1_Shop_Image);


            //ShopNum1_Image shopnum1_image = new ShopNum1_Image();
            //shopnum1_image.Guid = Guid.NewGuid();
            //shopnum1_image.Name = fileName.Substring(0, fileName.LastIndexOf('.'));
            //shopnum1_image.ImageType = new Guid("b0f6e545-cd10-4e83-8c96-2c1e143e4941");
            //shopnum1_image.ImagePath = fileName;
            //shopnum1_image.Description = "��";
            //shopnum1_image.UseTimes = 0;
            //shopnum1_image.ImageCategoryID = id;
            //shopnum1_image.CreateUser = this.ShopNum1LoginID;
            //shopnum1_image.CreateTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //shopnum1_image.ModifyUser = this.ShopNum1LoginID;
            //shopnum1_image.ModifyTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //shopnum1_image.IsDeleted = 0;

            //ShopNum1_Image_Action shopNum1_Image_Action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
            //int check = shopNum1_Image_Action.Add(shopnum1_image, id.ToString());
        }

        /// <summary>
        ///     ��ȡ��Ʒ��ͼ��������
        /// </summary>
        /// <param name="num_iid"></param>
        /// <returns></returns>
        private List<TbItemImg> SaveExternItemImgs(string num_iid)
        {
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
            param.Add("fields", "item_img,num_iid");
            param.Add("nick", TopClient.AgentUserNick);
            param.Add("num_iid", num_iid);
            string strXml = TopAPI.Post("taobao.item.get", TopClient.AgentSession, param);
            var parser = new Parser();
            var itemImgs = new List<TbItemImg>();
            var errItem = new ErrorRsp(); //����������

            parser.XmlToObject2(strXml, "item_get", "item/item_imgs/item_img", itemImgs, errItem);
                //�磺����XML����tbSellCats�ṹ
            if (errItem.IsError)
            {
                return null;
            }

            for (int i = 0; i < itemImgs.Count; i++)
            {
                // FileItem fileP = new FileItem(itemImgs[i].url);
                // itemImgs[i].url = FileItem.GetUrlFileName(itemImgs[i].url);
                // UpLoadImg(itemImgs[i].url);
            }
            return itemImgs;
        }

        #region  �����Ա�����������

        /// <summary>
        ///     ������Ʒ��ʶ��ȡ��������
        /// </summary>
        /// <param name="numiid"></param>
        /// <returns></returns>
        private List<TbSku> GetSkusByNumiid(string numiid)
        {
            var param = new Dictionary<string, string>();
            param.Add("fields", "sku_id,num_iid,properties,quantity,price,outer_id,status");
            param.Add("num_iids", numiid);
            string strXml = TopAPI.Post("taobao.item.skus.get", TopClient.AgentSession, param);
            var tbSkus = new List<TbSku>(); //������������
            var errItem = new ErrorRsp(); //����������
            var parser = new Parser();
            parser.XmlToObject2(strXml, "item_skus_get", "skus/sku", tbSkus, errItem);
            return tbSkus;
        }

        /// <summary>
        ///     �����Ʒ�Ĺ������ ���Ա�����������
        /// </summary>
        /// <param name="numiid"></param>
        /// <param name="prodGuid"></param>
        /// <returns></returns>
        private bool InsertProductSpecification(string numiid, Guid prodGuid)
        {
            var SpecProudct_Action =
                (ShopNum1_SpecProudct_Action) Factory.LogicFactory.CreateShopNum1_SpecProudct_Action();
            IShopNum1_SpecificationProductImage_Action specificationProductImgOperate =
                Factory.LogicFactory.CreateShopNum1_SpecificationProductImage_Action();
            var tbSkus = new List<TbSku>();
            ///��ȡ��������
            tbSkus = GetSkusByNumiid(numiid);
            if (tbSkus == null || tbSkus.Count == 0)
                return false;
            //ͼƬ����ͼ����

            //��ȡ����б�
            List<ShopNum1_SpecProudct> sproducts = GetProductSkus(tbSkus, prodGuid);


            if (sproducts != null && sproducts.Count > 0)
            {
                SpecProudct_Action.AddListSpecProducts(sproducts);
            }

            return true;
        }


        /// <summary>
        ///     �����Ա������Ի�ȡ���ֵ
        /// </summary>
        /// <param name="tbPropvalue"></param>
        /// <returns></returns>
        public string GetSpecDetailByTbProp(string tbPropvalue)
        {
            string specvalue = string.Empty;
            try
            {
                string[] tbProps = tbPropvalue.Split(';');
                foreach (string tbProp in tbProps)
                {
                    IShopNum1_Spec_Action specificationOperate = Factory.LogicFactory.CreateShopNum1_Spec_Action();
                    DataTable dt = specificationOperate.SpecDetailsGetByTbPropValue(tbProp);
                    if (dt != null && dt.Rows.Count != 0)
                        specvalue = specvalue + dt.Rows[0]["SpecificationGuid"] + ":" + dt.Rows[0]["Guid"] + ";";
                }

                return specvalue.Substring(0, specvalue.Length - 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                specvalue = string.Empty;
            }
            return specvalue;
        }


        /// <summary>
        ///     ��ȡ��Ʒ������������
        /// </summary>
        /// <param name="proptest"></param>
        /// <returns></returns>
        public List<ShopNum1_SpecProudct> GetProductSkus(List<TbSku> skus, Guid pguid)
        {
            var sproducts = new List<ShopNum1_SpecProudct>();
            for (int i = 0; i < skus.Count; i++)
            {
                var sproduct = new ShopNum1_SpecProudct();
                try
                {
                    //���������
                    string detail = GetSpecDetailByTbProp(skus[i].properties);
                    if (detail == string.Empty || detail == ";")
                    {
                        continue;
                    }
                    //��Ʒguid
                    sproduct.ProductGuid = pguid.ToString();
                    ///�۸�
                    sproduct.GoodsPrice = Convert.ToDecimal(skus[i].price);
                    //�����
                    sproduct.GoodsStock = skus[i].quantity;
                    //�����Ʒ����
                    sproduct.GoodsNumber = skus[i].outer_id;
                    //��������
                    sproduct.SalesCount = 0;
                    //���ع��ֵ��Ӧ
                    sproduct.SpecDetail = detail;
                    //�Ա���������
                    sproduct.TbProp = skus[i].properties;
                    sproduct.ShopID = MemLoginID;
                    sproduct.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sproducts.Add(sproduct);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }


            return sproducts;
        }

        #endregion

        #endregion

        #region ҳ�汾����

        private void DropDownListOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListTwo.Items.Clear();
            DropDownListTwo.Items.Add(new ListItem("-ȫ��-", "-1"));
            if (DropDownListOne.SelectedValue != "-1")
            {
                if (Session["shopcategory"] != null)
                {
                    var tbSellCats = (List<TbItemCat>) Session["shopcategory"];
                    foreach (TbItemCat tbsellcat in tbSellCats)
                    {
                        if (tbsellcat.parent_cid == DropDownListOne.SelectedValue)
                        {
                            var item1 = new ListItem();
                            item1.Value = tbsellcat.cid;
                            item1.Text = tbsellcat.name;
                            DropDownListTwo.Items.Add(item1);
                        }
                    }
                }
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            BindProductList("0");
        }


        /// <summary>
        ///     ���Ա���Ʒ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonbtnOk_Click(object sender, EventArgs e)
        {
            shopimgpath = Shop_Common_Action.GetShopImgPath(MemLoginID); ///ͼƬ·��
            ///��ȡȨ������


            ShopNum1_TbSystem tbsystem = GetTbSystemSet();
            if (tbsystem.isOpen == null)
            {
                tbsystem.isOpen = false;
            }
            if (!Convert.ToBoolean(tbsystem.isOpen))
            {
                ClientScript.RegisterStartupScript(typeof (Page), "msg",
                                                   "<script type='text/javascript'>alert('���Ѿ��ر���ͬ������')</script>");
                return;
            }

            prodcategorycode = GetDropDownListProductCategoryCode(); //ϵͳ��Ʒ����

            ProductCategoryName = GetDropDownListProductCategoryName(); //ϵͳ��Ʒ��������
            shopproductcategorycode = GetDropDownListProductSeriesCode(); //������Ʒ����

            shopproductcategoryname = GetDropDownListProductSeriesName(); //������Ʒ��������

            brandguid = DropDownListProductBrand.SelectedValue; //Ʒ�Ʊ�ʾguid

            brandName = DropDownListProductBrand.SelectedItem.Text; //��������


            var tbItemOperate = (ShopNum1_TbItem_Action) LogicTbFactory.CreateShopNum1_TbItem_Action();
            string taobaonumiids = CheckGuid.Value.Trim();
            string[] tabnumiids = taobaonumiids.Split(',');

            foreach (string tabaonumiid in tabnumiids)
            {
                string prodguid = GetTaoProductGuid(tabaonumiid);
                if (prodguid == "")
                {
                    TbItem tbitem = GetItemByNumiid(tabaonumiid, tbsystem);
                    //��Ʒ���뱾�����ݿ�
                    AddProduct(tbItemOperate, tbitem, tbsystem);
                }
                else
                {
                    TbItem tbitem = GetItemByNumiid(tabaonumiid, tbsystem);
                    UpdateSiteProduct(tbitem, new Guid(prodguid), tbsystem);
                }
            }

            ///������ݵ��̷���session
            Session.Remove("shopcategory");
            ViewState["taobaoproduct"] = null;
            CheckGuid.Value = "0";

            //���°󶨷�ҳ
            string pageid = "0";
            if (ViewState["pageid"] != null)
            {
                pageid = ViewState["pageid"].ToString();
            }
            BindProductList(pageid);

            MessageBox.Show("�����ɹ�!");
        }


        protected void DataListOrder_ItemCommand(object source, DataListCommandEventArgs e)
        {
        }


        protected void DataListOrder_ItemDataBound(object sender, DataListItemEventArgs e)
        {
        }

        #endregion

        #region   �󶨵�����DIV ����Ϣ

        #region ������Ʒ����

        protected void DropDownListProductSeriesCode1Bind()
        {
            DropDownListProductSeriesCode1.Items.Add(new ListItem("-��ѡ��-", "-1"));
            DropDownListProductSeriesCode2.Visible = false;
            DropDownListProductSeriesCode3.Visible = false;
            BindProductSeriesCode("0", DropDownListProductSeriesCode1);
        }

        private void DropDownListProductSeriesCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListProductSeriesCode2.Visible = false;
            DropDownListProductSeriesCode3.Visible = false;
            if (DropDownListProductSeriesCode1.SelectedValue != "-1")
            {
                BindProductSeriesCode(DropDownListProductSeriesCode1.SelectedValue.Split('/')[1],
                                      DropDownListProductSeriesCode2);
            }
        }

        private void DropDownListProductSeriesCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListProductSeriesCode3.Visible = false;
            if (DropDownListProductSeriesCode2.SelectedValue != "-1")
            {
                BindProductSeriesCode(DropDownListProductSeriesCode2.SelectedValue.Split('/')[1],
                                      DropDownListProductSeriesCode3);
            }
        }

        #endregion

        #region ��ƽ̨��Ʒ����

        protected void DropDownListProductCategoryCode1Bind()
        {
            DropDownListProductCategoryCode2.Visible = false;
            DropDownListProductCategoryCode3.Visible = false;
            BindProductCategoryCode("0", DropDownListProductCategoryCode1);
        }

        private void DropDownListProductCategoryCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListProductCategoryCode2.Visible = false;
            DropDownListProductCategoryCode3.Visible = false;
            if (DropDownListProductCategoryCode1.SelectedValue != "-1")
            {
                BindProductCategoryCode(DropDownListProductCategoryCode1.SelectedValue.Split('/')[1],
                                        DropDownListProductCategoryCode2);
            }
        }

        private void DropDownListProductCategoryCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListProductCategoryCode3.Visible = false;
            if (DropDownListProductCategoryCode2.SelectedValue != "-1")
            {
                BindProductCategoryCode(DropDownListProductCategoryCode2.SelectedValue.Split('/')[1],
                                        DropDownListProductCategoryCode3);
            }
        }

        private void DropDownListProductCategoryCode3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListProductCategoryCode3.SelectedValue != "-1")
            {
                DropDownListProductBrand.Visible = true;
                Bindbrand();
                UpdatePanelBrand.Update(); //Ʒ�Ƹ���
                //��Ʒ����
            }
            else
            {
            }
        }

        /// <summary>
        ///     ����վ�¼�����(��Ʒ��)
        /// </summary>
        /// <param name="fatherID"></param>
        /// <param name="DropDownListCategoryCode"></param>
        private void BindProductCategoryCode(string fatherID, DropDownList DropDownListCategoryCode)
        {
            var shopNum1_ProductCategory_Action =
                (ShopNum1_ProductCategory_Action) Factory.LogicFactory.CreateShopNum1_ProductCategory_Action();
            DataTable dataTable = shopNum1_ProductCategory_Action.SearchtProductCategory(Convert.ToInt16(fatherID), 0);
            DropDownListCategoryCode.Visible = true;
            DropDownListCategoryCode.Items.Clear();
            DropDownListCategoryCode.Items.Add(new ListItem("-��ѡ��-", "-1"));
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                DropDownListProductBrand.Visible = true;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DropDownListCategoryCode.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(),
                                                                    dataTable.Rows[i]["Code"] + "/" +
                                                                    dataTable.Rows[i]["ID"] + "/" +
                                                                    dataTable.Rows[i]["CategoryType"]));
                }

                Bindbrand();
                UpdatePanelBrand.Update(); //Ʒ�Ƹ���
            }
            else
            {
                DropDownListProductBrand.Visible = true;
                DropDownListCategoryCode.Visible = false;
                Bindbrand();
                UpdatePanelBrand.Update(); //Ʒ�Ƹ���
            }
        }

        #endregion

        /// <summary>
        ///     �󶨵����¼�����
        /// </summary>
        /// <param name="fatherID"></param>
        /// <param name="DropDownListCategoryCode"></param>
        private void BindProductSeriesCode(string fatherID, DropDownList DropDownListCategoryCode)
        {
            var productCategory_Action = (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
            productCategory_Action.TableName = "ShopNum1_Shop_ProductCategory";

            DataTable dataTable = productCategory_Action.GetShopProductCategoryCode(fatherID, MemLoginID);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                DropDownListCategoryCode.Visible = true;
                DropDownListCategoryCode.Items.Clear();
                DropDownListCategoryCode.Items.Add(new ListItem("-��ѡ��-", "-1"));
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DropDownListCategoryCode.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(),
                                                                    dataTable.Rows[i]["Code"] + "/" +
                                                                    dataTable.Rows[i]["ID"]));
                }
            }
        }

        //���ص���ѡ���code
        public string GetDropDownListProductSeriesCode()
        {
            if (DropDownListProductSeriesCode2.Visible && DropDownListProductSeriesCode2.SelectedValue != "-1")
            {
                return DropDownListProductSeriesCode2.SelectedValue.Split('/')[0];
            }
            else
            {
                if (DropDownListProductSeriesCode1.Visible && DropDownListProductSeriesCode1.SelectedValue != "-1")
                {
                    return DropDownListProductSeriesCode1.SelectedValue.Split('/')[0];
                }
                else
                {
                    return "-1";
                }
            }
        }


        //���ص���ѡ���Name
        public string GetDropDownListProductSeriesName()
        {
            if (DropDownListProductSeriesCode3.Visible && DropDownListProductSeriesCode3.SelectedValue != "-1")
            {
                return DropDownListProductSeriesCode1.SelectedItem.Text + "/" +
                       DropDownListProductSeriesCode2.SelectedItem.Text + "/" +
                       DropDownListProductSeriesCode3.SelectedItem.Text;
            }
            else
            {
                if (DropDownListProductSeriesCode2.Visible && DropDownListProductSeriesCode2.SelectedValue != "-1")
                {
                    return DropDownListProductSeriesCode1.SelectedItem.Text + "/" +
                           DropDownListProductSeriesCode2.SelectedItem.Text;
                }
                else
                {
                    if (DropDownListProductSeriesCode1.Visible &&
                        DropDownListProductSeriesCode1.SelectedValue != "-1")
                    {
                        return DropDownListProductSeriesCode1.SelectedItem.Text;
                    }
                    else
                    {
                        return "-1";
                    }
                }
            }
        }

        //������վѡ���code
        public string GetDropDownListProductCategoryCode()
        {
            if (DropDownListProductCategoryCode1.Visible && DropDownListProductCategoryCode1.SelectedValue != "-1")
            {
                string sss = DropDownListProductCategoryCode1.SelectedValue.Split('/')[0];
                return DropDownListProductCategoryCode1.SelectedValue.Split('/')[0];
            }
            else
            {
                return "-1";
            }
        }

        //������վѡ���code
        public string GetDropDownListProductCategoryType()
        {
            if (DropDownListProductCategoryCode1.Visible && DropDownListProductCategoryCode1.SelectedValue != "-1")
            {
                string sss = DropDownListProductCategoryCode1.SelectedValue.Split('/')[0];
                return DropDownListProductCategoryCode1.SelectedValue.Split('/')[2];
            }
            else
            {
                return "-1";
            }
        }

        //������վѡ���ID
        public string GetDropDownListProductCategoryID()
        {
            if (DropDownListProductCategoryCode3.Visible && DropDownListProductCategoryCode3.SelectedValue != "-1")
            {
                return DropDownListProductCategoryCode3.SelectedValue.Split('/')[1];
            }
            else
            {
                if (DropDownListProductCategoryCode2.Visible &&
                    DropDownListProductCategoryCode2.SelectedValue != "-1")
                {
                    return DropDownListProductCategoryCode2.SelectedValue.Split('/')[1];
                }
                else
                {
                    if (DropDownListProductCategoryCode1.Visible &&
                        DropDownListProductCategoryCode1.SelectedValue != "-1")
                    {
                        return DropDownListProductCategoryCode1.SelectedValue.Split('/')[1];
                    }
                    else
                    {
                        return "-1";
                    }
                }
            }
        }

        //������վѡ���Name
        public string GetDropDownListProductCategoryName()
        {
            if (DropDownListProductCategoryCode3.Visible && DropDownListProductCategoryCode3.SelectedValue != "-1")
            {
                return DropDownListProductCategoryCode1.SelectedItem.Text + "/" +
                       DropDownListProductCategoryCode2.SelectedItem.Text + "/" +
                       DropDownListProductCategoryCode3.SelectedItem.Text;
            }
            else
            {
                if (DropDownListProductCategoryCode2.Visible &&
                    DropDownListProductCategoryCode2.SelectedValue != "-1")
                {
                    return DropDownListProductCategoryCode1.SelectedItem.Text + "/" +
                           DropDownListProductCategoryCode2.SelectedItem.Text;
                }
                else
                {
                    if (DropDownListProductCategoryCode1.Visible &&
                        DropDownListProductCategoryCode1.SelectedValue != "-1")
                    {
                        return DropDownListProductCategoryCode1.SelectedItem.Text;
                    }
                    else
                    {
                        return "-1";
                    }
                }
            }
        }


        /// <summary>
        ///     ��Ʒ��
        /// </summary>
        private void Bindbrand()
        {
            var shopNum1_Brand_Action = (ShopNum1_Brand_Action) Factory.LogicFactory.CreateShopNum1_Brand_Action();
            DataTable datatableBrand = shopNum1_Brand_Action.dt_Select_BrandByCid(GetDropDownListProductCategoryType());

            if (datatableBrand.Rows.Count == 0 && datatableBrand != null)
            {
                DropDownListProductBrand.Items.Clear();
                DropDownListProductBrand.Items.Add(new ListItem("-��ѡ��-", "-1"));
                DropDownListProductBrand.Items.Add(new ListItem("����", "00000000-0000-0000-0000-000000000000"));
            }
            else
            {
                DropDownListProductBrand.Items.Clear();
                //DropDownListProductBrand.Enabled = false;
                DropDownListProductBrand.Items.Add(new ListItem("-��ѡ��-", "-1"));
                for (int i = 0; i < datatableBrand.Rows.Count; i++)
                {
                    DropDownListProductBrand.Items.Add(new ListItem(datatableBrand.Rows[i]["Name"].ToString(),
                                                                    datatableBrand.Rows[i]["Guid"].ToString()));
                }
                DropDownListProductBrand.SelectedIndex = 1;
                DropDownListProductBrand.Items.Add(new ListItem("����", "00000000-0000-0000-0000-000000000000"));
            }
        }


        /// ��ͼƬ����
        /// </summary>
        private void BindImageCategory()
        {
            DropDownListImgCategory.Items.Clear();
            var listItem1 = new ListItem();
            listItem1.Text = " -��ѡ��-";// LocalizationUtil.GetCommonMessage("Select");
            listItem1.Value = "-1";
            DropDownListImgCategory.Items.Add(listItem1);

            var imageCategory_Action = (Shop_ImageCategory_Action) LogicFactory.CreateShop_ImageCategory_Action();

            //ȡ��������
            DataTable dtable = imageCategory_Action.Select_AllType(MemLoginID);
            if (dtable == null)
            {
                return;
            }

            foreach (DataRow dr in dtable.Rows)
            {
                var listItem = new ListItem();

                listItem.Text = dr["Name"].ToString().Trim();
                listItem.Value = dr["ID"].ToString().Trim();

                DropDownListImgCategory.Items.Add(listItem);
            }
        }

        #endregion
    }
}