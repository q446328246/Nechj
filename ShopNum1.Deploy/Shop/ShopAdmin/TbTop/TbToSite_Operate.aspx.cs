using System;
using System.Collections.Generic;
using System.Data;
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

namespace ShopNum1.Deploy.Shop.ShopAdmin.TbTop
{
    public partial class TbToSite_Operate : Page
    {
        private readonly List<ShopNum1_TbSellCat> tbSellCats = new List<ShopNum1_TbSellCat>();
        private string ShopName; //��������

        //������ƷͼƬ·��
        private string shopimgpath = string.Empty;

        /// <summary>
        ///     ��Ա��
        /// </summary>
        private string MemLoginID { get; set; }

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

                bool isExisit = CheckMemberID(MemLoginID);
                if (!isExisit)
                {
                    Response.Redirect("TbAuthorization.aspx");
                }


                //����Ʒ��ҳ��
                GetProductPageCount();
            }

            if (!TopClient.IsAgentLogin)
            {
                Response.Redirect("TbAuthorization.aspx");
            }
            if (!TopClient.isSessionTimeOut(Page, "agent"))
            {
                Response.Redirect("TbAuthorization.aspx");
            }
        }

        /// <summary>
        ///     ��ȡ�Ա�����Ʒ(�ϼܵ�)
        /// </summary>
        /// <returns></returns>
        private bool UpdateProductCount()
        {
            var tbItemOperate = (ShopNum1_TbItem_Action) LogicTbFactory.CreateShopNum1_TbItem_Action();
            int pageCount = GetNewTbItemPageCount();
            //if (pageCount > 1)
            //{
            //    this.ClientScript.RegisterStartupScript(typeof(Page), "msg", "<script type='text/javascript'>alert(\"�������Ա���Ʒ���ݹ��࣬�����鿴�Ա���Ʒ����ͬ��!\")</script>");
            //    return false;
            //}
            for (int j = 0; j <= pageCount; j++)
            {
                var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
                param.Add("fields", "num_iid,cid,pic_url,num");
                param.Add("page_no", j.ToString());
                param.Add("page_size", "200");


                string strXml = TopAPI.Post("taobao.items.onsale.get", TopClient.AgentSession, param);

                var tbItemCounts = new List<TbItem>(); //������Ʒnumiid����
                var errItem = new ErrorRsp(); //����������
                var parser = new Parser();


                parser.XmlToObject2(strXml, "items_onsale_get", "items/item", tbItemCounts, errItem); //�磺����XML������Ʒ�ṹ��
                if (errItem.IsError)
                {
                    continue;
                }
                for (int i = 0; i < tbItemCounts.Count; i++)
                {
                    tbItemOperate.UpdateProductCount(tbItemCounts[i].num_iid, MemLoginID, tbItemCounts[i].num);
                }
            }


            return true;
        }


        /// <summary>
        ///     ��ȡ��Ʒ�ϼܵķ�ҳ����
        /// </summary>
        /// <returns></returns>
        private int GetNewTbItemPageCount()
        {
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
            param.Add("fields", "approve_status,num_iid,title,nick,type,cid,pic_url");
            string strXml = TopAPI.Post("taobao.items.onsale.get", TopClient.AgentSession, param);
            var parser = new Parser();
            int allCount = parser.XmlToTotalResults(strXml, "items_onsale_get");
            try
            {
                return (int) Math.Ceiling((double) (allCount/200));
            }
            catch
            {
                return 1;
            }
        }


        /// <summary>
        ///     �޸�������Ʒ
        /// </summary>
        /// <returns></returns>
        private bool UpdateAllTbItems()
        {
            var tbItemOperate = (ShopNum1_TbItem_Action) LogicTbFactory.CreateShopNum1_TbItem_Action();
            int pageCount = GetNewTbItemPageCount();

            for (int j = 0; j <= pageCount; j++)
            {
                var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
                param.Add("fields", "title,num,pic_url,price,num_iid");
                param.Add("page_no", j.ToString());
                param.Add("page_size", "200");
                string strXml = TopAPI.Post("taobao.items.onsale.get", TopClient.AgentSession, param);
                var tbItemCounts = new List<TbItem>(); //������Ʒnumiid����
                var errItem = new ErrorRsp(); //����������
                var parser = new Parser();
                parser.XmlToObject2(strXml, "items_onsale_get", "items/item", tbItemCounts, errItem); //�磺����XML������Ʒ�ṹ��
                if (errItem.IsError)
                {
                    continue;
                }
                for (int i = 0; i < tbItemCounts.Count; i++)
                {
                    tbItemOperate.UpdateProductItems(tbItemCounts[i].num_iid, MemLoginID, tbItemCounts[i].num,
                                                     tbItemCounts[i].title, tbItemCounts[i].price);
                }
            }
            return true;
        }


        /// <summary>
        ///     �����Ա��Ĳ�Ʒ����ֵiid��ȡ������Ʒ��ʶ
        /// </summary>
        /// <param name="numiid"></param>
        /// <returns></returns>
        private string GetSiteIdByNumiid(decimal numiid)
        {
            var tbItemOperate = (ShopNum1_TbItem_Action) LogicTbFactory.CreateShopNum1_TbItem_Action();
            return tbItemOperate.checkItemExists(numiid);
        }

        /// <summary>
        ///     ��ȡ���õ�Ȩ��
        /// </summary>
        private ShopNum1_TbSystem GetTbSystemSet()
        {
            var tbSystemOperate = (ShopNum1_TbSystem_Action) LogicTbFactory.CreateShopNum1_TbSystem_Action();
            return tbSystemOperate.GetTbSysem(MemLoginID, TopClient.AgentUserNick);
        }


        protected void btnLead_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// ������������
            /// </summary>
            Func<string, bool> fOperate = a =>
                {
                    switch (a)
                    {
                            ////������Ʒ����
                        case "sellcat":
                            return GetTbSellCat();
                            //������Ʒ���
                        case "updatecount":
                            return UpdateProductCount();
                            //���±��������Ա���Ʒ
                        case "updateitem":
                            return UpdateAllTbItems();
                        default:
                            return false;
                    }
                };

            if (radSort.Checked)
            {
                ///��Ʒ����
                if (fOperate("sellcat"))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MSG", "alert(\"�����ɹ�\")", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MSG", "alert(\"����ʧ��\")", true);
                }
            }
                ///������Ʒ
            else if (radUpdateCount.Checked)
            {
                if (fOperate("updatecount"))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MSG", "alert(\"�����ɹ�\")", true);
                }
                else
                {
                    //  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MSG", "alert(\"����ʧ��\")", true);
                }
            }

                ///��������Ʒ
            else if (radDownNew.Checked)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "show", "showMsg();", true);
            }

                ///����������Ʒ
            else if (radUpdate.Checked)
            {
                if (fOperate("updateitem"))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MSG", "alert(\"�����ɹ�\")", true);
                }
                else
                {
                    // ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MSG", "alert(\"����ʧ��\")", true);
                }
            }
        }


        /// <summary>
        ///     ��Ʒ����
        /// </summary>
        /// <param name="numiid"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        private List<TbSku> GetItemSkus(string numiid, string cid)
        {
            ///�õ�������Ʒ��Ϣ  -
            ///��������
            var itemSkus = new List<TbSku>();
            //���Զ�Ӧ��ͼƬ
            var itemPropImgs = new List<TbPropImg>();
            var param = new Dictionary<string, string>(); //APIӦ�ü��������
            param.Add("fields", "cid,title,price,num,pic_url,sku");
            param.Add("num_iid", numiid);
            param.Add("nick", TopClient.AgentUserNick);
            string strXml = TopAPI.Post("taobao.item.get", TopClient.AgentSession, param);
            var errItem = new ErrorRsp(); //����������
            var parser = new Parser();

            //����������Item����
            parser.XmlToObject2(strXml, "item_get", "item/prop_imgs/prop_img", itemPropImgs);
            parser.XmlToObject2(strXml, "item_get", "item/skus/sku", itemSkus);

            if (errItem.IsError) //�ж��Ƿ�������������������򷵻ص���һҳ
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof (Page), "error",
                                                        string.Format(
                                                            "alert(\"������룺{0}\\r����ԭ��{1}\\r����������{2}-{3}\");history.go(-1);",
                                                            errItem.code, errItem.msg, errItem.sub_code, errItem.sub_msg),
                                                        true);
                return null;
            }


            ///����������ֵת����Ӧ������
            foreach (TbSku sku in itemSkus) //��ȡsku�������ı�
            {
                sku.outer_id = sku.outer_id.Replace("&sbquo;", ","); //��ԭ sku�̼ұ�� ת���ַ�

                //��ȡ��׼��Ŀ����ֵ  ---  sku���Ե�����ֵ   ��
                var skuParam = new Dictionary<string, string>(); //APIӦ�ü��������
                skuParam.Add("fields", "cid,pid,prop_name,vid,name,name_alias,status,sort_order");
                //��Ҫ���ص��ֶΡ�Ŀǰ֧���У�cid,pid,prop_name,vid,name,name_alias,status,sort_order 
                skuParam.Add("cid", cid); //ָ����ǰ��Ʒcid --- Ҷ����ĿID ,ͨ��taobao.itemcats.get���Ҷ����ĿID 
                skuParam.Add("pvs", sku.properties);
                //ָ��sku��Ӧ��pvs  --  ���Ժ�����ֵ id������ʽ����(pid1;pid2)��(pid1:vid1;pid2:vid2)��(pid1;pid2:vid2) 
                strXml = TopAPI.Post("taobao.itempropvalues.get", skuParam);

                var skuErr = new ErrorRsp();
                var prop_values = new List<TbPropValue>();

                parser.XmlToObject2(strXml, "itempropvalues_get", "prop_values/prop_value", prop_values, skuErr);

                sku.propertiesText = "";
                if (skuErr.IsError == false)
                {
                    foreach (TbPropValue propValue in prop_values) //����֪����������������
                    {
                        sku.propertiesText += "&nbsp;" + propValue.name;
                    }
                }
                else
                {
                    sku.propertiesText = "<a title=\"" + skuErr.msg + "\">��������(" + skuErr.code + ")</a>";
                }
            }
            return itemSkus;
        }


        //����Ʒҳ��
        public void GetProductPageCount()
        {
            RadioButtonList1.Items.Clear();
            int pageCount = GetNewTbItemPageCount();
            if (pageCount <= 0)
            {
                LabelNoCount.Visible = true;
                RadioButtonList1.Visible = false;
            }
            else
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    RadioButtonList1.Items.Add(new ListItem("��" + i + "ҳ", i.ToString()));
                }
            }
        }

        //������Ʒ
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (GetNewTbItem())
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof (Page), "truea", "alert(\"�����ɹ�\");", true);
            }
        }

        /// <summary>
        ///     ��ȡ�Ա�����Ʒ(�ϼܵ�)
        /// </summary>
        /// <returns></returns>
        private bool GetNewTbItem()
        {
            var tbItemOperate = (ShopNum1_TbItem_Action) LogicTbFactory.CreateShopNum1_TbItem_Action();
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
            param.Add("fields", "num_iid,cid,pic_url,num");
            string page = HiddenFieldradioButton.Value.Trim();
            param.Add("page_no", page);
            param.Add("page_size", "200");
            string strXml = TopAPI.Post("taobao.items.onsale.get", TopClient.AgentSession, param);
            var tbItems = new List<ShopNum1_TbItem>(); //������Ʒ
            var errItem = new ErrorRsp(); //����������
            var parser = new Parser();
            parser.XmlToObject2(strXml, "items_onsale_get", "items/item", tbItems, errItem); //�磺����XML������Ʒ�ṹ��
            if (errItem.IsError)
            {
                return false;
            }


            for (int i = 0; i < tbItems.Count; i++)
            {
                string siteId = tbItemOperate.CheckItemByTb(tbItems[i].num_iid.ToString(), MemLoginID,
                                                            TopClient.AgentUserNick);
                if (siteId == "0")
                {
                    var tbitem = new ShopNum1_TbItem();
                    tbitem = GetItemByNumiid(tbItems[i].num_iid.ToString());
                    var itemImgs = new List<TbItemImg>();

                    ///�����ͼ
                    if ((bool) GetTbSystemSet().tbImg)
                    {
                        itemImgs = SaveExternItemImgs(tbItems[i].num_iid.ToString());
                    }

                    //�򱾵����ݿ��������
                    InsertSiteItem(tbItemOperate, tbitem, itemImgs);
                }
            }

            return true;
        }

        /// <summary>
        ///     ������Ʒ������numiid��ȡ��Ʒ�������Ϣ
        /// </summary>
        /// <param name="numiid"></param>
        /// <returns></returns>
        private ShopNum1_TbItem GetItemByNumiid(string numiid)
        {
            var param = new Dictionary<string, string>();
            param.Add("fields", "num_iid,title,type,pic_url,num,list_time,price,seller_cids,desc,outer_id,is_virtual");
            param.Add("nick", TopClient.AgentUserNick);
            param.Add("num_iid", numiid);
            string strXml = TopAPI.Post("taobao.item.get", TopClient.AgentSession, param);
            var tbItem = new ShopNum1_TbItem(); //������Ʒ
            var errItem = new ErrorRsp(); //����������
            var parser = new Parser();
            parser.XmlToObject2(strXml, "item_get", "item", tbItem, errItem);


            if ((bool) GetTbSystemSet().tbImg)
            {
                //����ͼƬ 
                if (tbItem.pic_url != "")
                {
                    //��ѯ������Ϣ����ȡ�洢ͼƬ·��
                    var shopInfoList_Action =
                        (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
                    DataTable dataTable = shopInfoList_Action.GetShopOpentimeByMemLoginID(MemLoginID);
                    string StrRegedate = dataTable.Rows[0]["OpenTime"].ToString();
                    string ShopId = dataTable.Rows[0]["ShopID"].ToString();
                    string userImgPath = "~/ImgUpload/" +
                                         Convert.ToDateTime(StrRegedate).ToString("yyyy/MM/dd").Replace('-', '/') +
                                         "/Shop" +
                                         ShopId;
                    string paths = Server.MapPath(userImgPath);
                    var fileP = new FileItem();

                    string msg = string.Empty;
                    bool b = false;
                    try
                    {
                        b = fileP.DownImage(tbItem.pic_url, paths, out msg);
                    }
                    catch (Exception)
                    {
                        b = false;
                    }


                    if (b)
                    {
                        tbItem.pic_url = msg;
                        UpLoadImg(tbItem.pic_url);
                    }
                    //tbItem.pic_url = ShopNum1.TbTopCommon.FileItem.GetUrlFileName(tbItem.pic_url);
                }
            }
            return tbItem;
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

            // this.Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "msg", "alert('" + strXml + "')", true);
            parser.XmlToObject2(strXml, "item_get", "item/item_imgs/item_img", itemImgs, errItem);
                //�磺����XML����tbSellCats�ṹ
            if (errItem.IsError)
            {
                return null;
            }

            for (int i = 0; i < itemImgs.Count; i++)
            {
                var fileP = new FileItem(itemImgs[i].url);
                itemImgs[i].url = FileItem.GetUrlFileName(itemImgs[i].url);
                UpLoadImg(itemImgs[i].url);
            }
            return itemImgs;
        }

        /// <summary>
        ///     �򱾵������Ʒ
        /// </summary>
        /// <param name="tbItemOperate"></param>
        /// <param name="tbItem"></param>
        private void InsertSiteItem(ShopNum1_TbItem_Action tbItemOperate, ShopNum1_TbItem tbItem,
                                    List<TbItemImg> tbItemImgs)
        {
            //string siteId = tbItemOperate.CheckItemByTb(tbItem.num_iid.ToString(), AgentLoginID, TopClient.AgentUserNick);
            decimal siteSellcid = 1; ///��Ʒ����
            if (tbItem.seller_cids != "-1" && tbItem.seller_cids != "-1,")
            {
                try
                {
                    siteSellcid = GetSiteId(decimal.Parse(tbItem.seller_cids.Split(',')[1]));
                }
                catch (Exception ex)
                {
                    siteSellcid = 1;
                }
            }

            #region �����Ʒ

            var shop_Product = new ShopNum1_Shop_Product();
            shop_Product.Guid = Guid.NewGuid();
            shop_Product.Name = tbItem.title;
            shop_Product.ProductNum = tbItem.num.ToString();
            shop_Product.Score = 0;
            shop_Product.OrderID = ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_Shop_Product") + 1;
            shop_Product.ShopPrice = Convert.ToDecimal(tbItem.price);
            shop_Product.MarketPrice = 0;
            shop_Product.IsReal = 1;
            shop_Product.IsSell = 1; //��������
            //if (!string.IsNullOrEmpty(TextBoxRepertoryCount.Text))
            //{
            shop_Product.RepertoryCount = (int) tbItem.num;
            //}
            //else
            //{
            //    shop_Product.RepertoryCount = 0;
            //}
            shop_Product.IsSaled = 1;
            shop_Product.UnitName = "";
            shop_Product.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shop_Product.Detail = tbItem.desc;
            shop_Product.Instruction = "";
            shop_Product.IsNew = 1;
            shop_Product.IsHot = 1;
            shop_Product.IsPromotion = 1;


            if (!string.IsNullOrEmpty(tbItem.pic_url))
            {
                ////��ѯ������Ϣ����ȡ�洢ͼƬ·��
                //ShopNum1_ShopInfoList_Action shopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
                //DataTable dataTable = shopInfoList_Action.GetShopOpentimeByMemLoginID(MemLoginID);
                //string StrRegedate = dataTable.Rows[0]["OpenTime"].ToString();
                //string ShopId = dataTable.Rows[0]["ShopID"].ToString();
                //string userImgPath = "~/ImgUpload/" + Convert.ToDateTime(StrRegedate).ToString("yyyy/MM/dd").Replace('-', '/') + "/Shop" + ShopId;

                shop_Product.OriginalImage = tbItem.pic_url; //�õĶ���ԭͼ
            }
            else
            {
                shop_Product.OriginalImage = "";
            }

            //if (IsPanicBuy + IsSpellBuy > 0)
            //{   //������ƴ����Ʒ
            shop_Product.ThumbImage = "";
            //}
            //else
            //{
            //    //ˮӡͼƬ������ͼ
            //    shop_Product.ThumbImage = TextBoxOrganizImg.Text;// WaterMark();
            //}

            shop_Product.MultiImages = GetMultiImageTable();
            shop_Product.Description = tbItem.title; //��ϸҳ����
            shop_Product.Keywords = tbItem.title; //��ϸҳ�����ؼ���
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
            shop_Product.ShopName = GetShopName();

            shop_Product.FeeType = 0; //���óе���
            shop_Product.Post_fee = 0;
            shop_Product.Express_fee = 0;
            shop_Product.Ems_fee = 0;
            shop_Product.MinusFee = 0;
            shop_Product.FeeTemplateID = 0;
            shop_Product.FeeTemplateName = "";

            //��վ����
            shop_Product.ProductCategoryCode = !(bool) GetTbSystemSet().tbSellCat ? "1" : siteSellcid.ToString();
            ;
            shop_Product.ProductCategoryName = "";
            //���̷���
            shop_Product.ProductSeriesCode = !(bool) GetTbSystemSet().tbSellCat ? "1" : siteSellcid.ToString();
            ;
            shop_Product.ProductSeriesName = "";

            shop_Product.BrandGuid = Guid.Empty;
            shop_Product.BrandName = "";
            var product_Action = (Shop_Product_Action) ShopFactory.LogicFactory.CreateShop_Product_Action();
            int check = product_Action.AddShopProduct(shop_Product);
            if (check > 0)
            {
            }
            else
            {
                ////��ʾ������Ϣ
                //this.MessageShow.ShowMessage("AddNo");
                //this.MessageShow.Visible = true;
            }

            #endregion �����Ʒ

            ////����м���ϵ
            // tbItemOperate.InsertAgentItem(tbItem.num_iid.ToString(), product.Guid.ToString(), "0", MemLoginID, TopClient.AgentUserNick);
        }

        /// <summary>
        ///     ��ȡ��վ Ŀ¼����ĿId
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        private decimal GetSiteId(decimal cid)
        {
            var sellcatOperate = (ShopNum1_TbSellCat_Action) LogicTbFactory.CreateShopNum1_TbSellCat_Action();
            ///mmmm
            return sellcatOperate.CheckSellCatByTb(TopClient.AgentUserNick, cid.ToString(), MemLoginID);
        }

        private void AddImgCategory()
        {
            #region ���

            string name, description, fatherID, user;
            int categoryLevel;
            string family = "";

            name = "�Ա���ƷͼTop";
            description = "���Ա������ص���Ʒͼ";
            fatherID = "0";
            user = MemLoginID;


            //���Ϊ��������
            categoryLevel = 1;


            var imageCategory_Action =
                (ShopNum1_ImageCategory_Action) LogicFactory.CreateShopNum1_ImageCategory_Action();

            int check = 0;
            check = imageCategory_Action.Insert(name, description, categoryLevel.ToString(), fatherID, family, user);
            //����

            #endregion
        }

        /// <summary>
        ///     �����ݿ��������
        /// </summary>
        protected void Add(string fileName)
        {
            var shop_Image = new ShopNum1_Shop_Image();
            shop_Image.Name = "";
            shop_Image.ImageType = "1";
            shop_Image.ImagePath = fileName;
            shop_Image.UseTimes = 0;
            shop_Image.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shop_Image.CreateUser = MemLoginID;
            shop_Image.ImageCategoryID = 1;
            var image_Action = (Shop_Image_Action) ShopFactory.LogicFactory.CreateShop_Image_Action();

            int check = image_Action.Insert(shop_Image);

            if (check > 0)
            {
                Page.Response.Write("<script>alert('��ӳɹ���'); window .location='Image_List.aspx'</script>");
            }
            else
            {
                MessageBox.Show("���ʧ�ܣ�");
            }
        }

        ///// <summary>
        ///// ��Shop_ImagePath���в�������
        ///// </summary>
        ///// <param name="originaImagePath"></param>
        ///// <param name="otherImagepath"></param>
        //protected void AddImagePath(string originaImagePath, string otherImagepath)
        //{
        //    ShopNum1_Shop_ImagePath imagePath = new ShopNum1_Shop_ImagePath();

        //    imagePath.OriginalImagePath = originaImagePath;
        //    imagePath.OtherImagePath = otherImagepath;
        //    imagePath.CreateUser = MemLoginID;
        //    imagePath.CreateTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //    imagePath.ModifyUser = MemLoginID;
        //    imagePath.ModifyTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //    imagePath.MemLoginID = MemLoginID;

        //    Shop_ImagePath_Action imagePathAction = (Shop_ImagePath_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ImagePath_Action();
        //    int check = imagePathAction.Add(imagePath);
        //    if (check > 0)
        //    {
        //        Page.Response.Write("<script>alert('��ӳɹ���'); window .location='Image_List.aspx'</script>");
        //    }
        //    else
        //    {

        //    }
        //}


        /// <summary>
        ///     ��Ʒ��ͼ
        /// </summary>
        /// <returns></returns>
        protected string GetMultiImageTable()
        {
            string strTemp = "";
            if (ViewState["dataMultiImage"] != null)
            {
                var tempDataTalbe = (DataTable) ViewState["dataMultiImage"];

                if (tempDataTalbe.Rows.Count > 0)
                {
                    for (int i = 0; i < tempDataTalbe.Rows.Count; i++)
                    {
                        strTemp += tempDataTalbe.Rows[i]["OriginalImge"] + ",";
                    }
                    if (strTemp.Length > 0)
                    {
                        strTemp = strTemp.Substring(0, strTemp.Length - 1);
                    }
                }
            }
            return strTemp;
        }

        /// <summary>
        ///     ��ȡ��������
        /// </summary>
        /// <returns></returns>
        protected string GetShopName()
        {
            var product_Action = (Shop_ShopInfo_Action) ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
            DataTable dataTable = product_Action.GetMemLoginInfo(MemLoginID);
            return dataTable.Rows[0]["ShopName"].ToString();
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
            IShopNum1_SpecProudct_Action SpecificationProudctOperate =
                LogicFactory.CreateShopNum1_SpecProudct_Action();
            IShopNum1_SpecificationProductImage_Action specificationProductImgOperate =
                LogicFactory.CreateShopNum1_SpecificationProductImage_Action();
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
                SpecificationProudctOperate.AddListSpecProducts(sproducts);
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
                    IShopNum1_Spec_Action specificationOperate = LogicFactory.CreateShopNum1_Spec_Action();
                    DataTable dt = specificationOperate.SpecDetailsGetByTbPropValue(tbProp);
                    if (dt != null && dt.Rows.Count != 0)
                        specvalue = specvalue + dt.Rows[0]["SpecificationGuid"] + ":" + dt.Rows[0]["Guid"] + ";";
                }

                return specvalue.Substring(0, specvalue.Length - 1);
            }
            catch (Exception ex)
            {
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
                    //
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

        #region    //ˮӡ  ����ͼ

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
            //            string addText = shopSettings.GetValue(filePath, "WaterMarkWords");
            //            //ˮӡλ��
            //            string position = shopSettings.GetValue(filePath, "WordsWaterMarkPosition");
            //            //����
            //            string fontType = shopSettings.GetValue(filePath, "WaterMarkWordsFont");
            //            //�ִ�С
            //            float fontSize = Convert.ToSingle(shopSettings.GetValue(filePath, "WaterMarkWordsFontSize"));
            //            //�ֵ���ɫ
            //            string fontColor = shopSettings.GetValue(filePath, "WaterMarkWordsColor");
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
            //            string waterSourcePath = Server.MapPath("~/ImgUpload/" + shopSettings.GetValue(filePath, "WaterMarkOriginalImge"));
            //            //ˮӡλ��
            //            string position = shopSettings.GetValue(filePath, "WaterMarkImagePosition");

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

        #endregion

        #region   �����Ա���Ʒ����

        /// <summary>
        ///     ��ȡ�Ա������Զ������
        /// </summary>
        private bool GetTbSellCat()
        {
            ///��ȡ������ĿId
            var commaction = (Shop_Common_Action) ShopFactory.LogicFactory.CreateShop_Common_Action();
            var productCategoryAction =
                (Shop_ProductCategory_Action) ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
            //�践�ص��ֶ��б�
            param.Add("fields", "cid,parent_cid,name,pic_url,sort_order,created,modified");
            param.Add("nick", TopClient.AgentUserNick);
            string strXml = TopAPI.Post("taobao.sellercats.list.get", TopClient.AgentSession, param);
            var tbSellCats = new List<TbItemCat>(); //���巵���Ա������Զ������

            var errItem = new ErrorRsp(); //����������
            var parser = new Parser();
            parser.XmlToObject2(strXml, "sellercats_list_get", "seller_cats/seller_cat", tbSellCats, errItem);
            //�磺����XML����tbSellCats�ṹ
            var sellcatOperate = (ShopNum1_TbSellCat_Action) LogicTbFactory.CreateShopNum1_TbSellCat_Action();
            if (tbSellCats == null)
                return true;
            foreach (TbItemCat tbcat in tbSellCats)
            {
                decimal sitecid = CheckTbCidExists(Convert.ToDecimal(tbcat.cid));

                var sellcat = new ShopNum1_TbSellCat();
                sellcat.modified = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sellcat.created = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ///�Ȳ�������
                if (tbcat.parent_cid == "0")
                {
                    ///ȷ���Ƿ�ִ�в���
                    if (sitecid == 0)
                    {
                        sellcat.site_cid = 0;

                        sellcat.site_parent_cid = 0;
                        sellcat.shopname = TopClient.AgentUserNick;
                        sellcat.isTaobao = true;
                        sellcat.MemloginId = MemLoginID;
                        sellcat.cid = Convert.ToDecimal(tbcat.cid);
                        sellcat.parent_cid = 0;
                        sellcat.sort_order = 0;
                        sellcat.pic_url = "";
                        sellcat.name = tbcat.name;
                        ///�򱾵����ݿ����
                        InsertSiteSellCat(sellcat, "0");
                        sellcat.site_cid = commaction.ReturnMaxID("ID", "ShopNum1_Shop_ProductCategory");
                        ///��Ϊ���������� ���Գɹ���Ӻ�����
                        ///�����м�� 
                        sellcatOperate.InsertSellCat(sellcat);
                    }
                        ///ִ�и��²���
                    else
                    {
                        sellcat.site_cid = sitecid;
                        sellcat.pic_url = "";
                        sellcat.shopname = TopClient.AgentUserNick;
                        sellcat.MemloginId = MemLoginID;
                        sellcat.name = tbcat.name;
                        sellcat.parent_cid = 0;
                        sellcat.site_parent_cid = 0;
                        sellcat.cid = decimal.Parse(tbcat.cid);
                        sellcat.sort_order = 0;
                        UpdateSiteSellCat(sellcat, '0');
                        sellcatOperate.UpdateSellCat(sellcat);
                    }
                }
                else
                {
                    ///ȷ���Ƿ�ִ�в���
                    if (sitecid == 0)
                    {
                        sellcat.site_parent_cid = CheckTbCidExists(Convert.ToDecimal(tbcat.parent_cid));
                        sellcat.shopname = TopClient.AgentUserNick;
                        sellcat.isTaobao = true;
                        sellcat.MemloginId = MemLoginID;
                        sellcat.cid = Convert.ToDecimal(tbcat.cid);
                        sellcat.parent_cid = Convert.ToDecimal(tbcat.parent_cid);
                        ;
                        sellcat.sort_order = 0;
                        sellcat.pic_url = "";
                        sellcat.name = tbcat.name;
                        ///�򱾵����ݿ���� �ڶ���Ŀ¼
                        InsertSiteSellCat(sellcat, "1");

                        sellcat.site_cid = commaction.ReturnMaxID("ID", "ShopNum1_Shop_ProductCategory");
                        ///�����м��
                        sellcatOperate.InsertSellCat(sellcat);
                    }
                        ///ִ�и��²���
                    else
                    {
                        sellcat.site_cid = sitecid;
                        sellcat.site_parent_cid = CheckTbCidExists(Convert.ToDecimal(tbcat.parent_cid));
                        sellcat.shopname = TopClient.AgentUserNick;
                        sellcat.isTaobao = true;
                        sellcat.MemloginId = MemLoginID;
                        sellcat.cid = Convert.ToDecimal(tbcat.cid);
                        sellcat.parent_cid = decimal.Parse(tbcat.parent_cid);
                        sellcat.sort_order = 0;
                        sellcat.pic_url = "";
                        sellcat.name = tbcat.name;
                        sellcatOperate.UpdateSellCat(sellcat);
                        UpdateSiteSellCat(sellcat, '1');
                    }
                }
            }

            //// �Ա����ɾ��
            //DataTable dt = sellcatOperate.GetAllCidByShopName(TopClient.AgentUserNick, MemLoginID);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    bool checkRef = true;
            //    foreach (TbItemCat sellcat in tbSellCats)
            //    {
            //        if (dt.Rows[i]["cid"].ToString() == sellcat.cid)
            //        {
            //            checkRef = false;
            //            break;
            //        }

            //    }

            //    if (checkRef)
            //    {
            //        sellcatOperate.DeleteSellCat(TopClient.AgentUserNick, MemLoginID, decimal.Parse(dt.Rows[i]["cid"].ToString()), 0);
            //    }

            //}
            return true;
        }


        /// <summary>
        ///     ����Ա��Ƿ�ɾ�������   ɾ������true û��ɾ������false
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        private bool CheckSellCatTbDel(decimal cid)
        {
            foreach (ShopNum1_TbSellCat sellcat in tbSellCats)
            {
                if (cid == sellcat.cid)
                    return true;
            }
            return false;
        }

        /// <summary>
        ///     ���  �Ա��ͱ��� Ŀ¼�Ƿ����Ĺ�ϵ
        /// </summary>
        /// <param name="sellCat"></param>
        /// <returns></returns>
        private decimal CheckTbCidExists(decimal cid)
        {
            var sellcatOperate =
                (ShopNum1_TbSellCat_Action) LogicTbFactory.CreateShopNum1_TbSellCat_Action();
            decimal id = sellcatOperate.CheckSellCat(TopClient.AgentUserNick, cid.ToString(), MemLoginID, "0");
            return id;
        }


        /// <summary>
        ///     �򱾵����ݿ����Ŀ¼
        /// </summary>
        /// <param name="sellCat"></param>
        private void InsertSiteSellCat(ShopNum1_TbSellCat sellCat, string mark)
        {
            #region ���

            var productCategoryAction =
                (Shop_ProductCategory_Action) ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
            var productCategory = new ShopNum1_Shop_ProductCategory();
            productCategory.Name = sellCat.name;
            productCategory.FatherID = mark == "0" ? 0 : (int) CheckTbCidExists(sellCat.parent_cid);
            productCategory.Keywords = sellCat.name;
            productCategory.Description = sellCat.name;
            productCategory.OrderID = (int) sellCat.sort_order;
            productCategory.IsShow = 1;

            productCategory.MemLoginID = MemLoginID;
            //���Ϊ��������
            productCategory.CategoryLevel = mark == "0" ? 1 : 2;
            if (productCategory.FatherID == 0)
            {
                productCategory.CategoryLevel = 1;
            }
            productCategoryAction.TableName = "ShopNum1_Shop_ProductCategory";
            int check = 0;
            check = productCategoryAction.Add(productCategory);
            //����
            if (check > 0)
            {
            }
            else
            {
                ////��ʾ������Ϣ
            }

            #endregion
        }


        /// <summary>
        ///     �޸ı������ݿ�Ŀ¼
        /// </summary>
        /// <param name="sellCat"></param>
        private void UpdateSiteSellCat(ShopNum1_TbSellCat sellCat, char mark)
        {
            #region �༭

            var productCategoryAction =
                (Shop_ProductCategory_Action) ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
            var productCategory = new ShopNum1_Shop_ProductCategory();
            productCategory.ID = (int) CheckTbCidExists(sellCat.cid);
            productCategory.Name = sellCat.name;
            productCategory.FatherID = mark == '0' ? 0 : (int) CheckTbCidExists(sellCat.parent_cid);
            productCategory.Keywords = sellCat.name;
            productCategory.Description = sellCat.name;
            productCategory.OrderID = Convert.ToInt32(sellCat.sort_order);
            productCategory.IsShow = 1;
            productCategory.MemLoginID = MemLoginID;

            productCategoryAction.TableName = "ShopNum1_Shop_ProductCategory";
            //�õ�����
            //�ȸ���һ���ո���ַ����������4���ո񣬾���3������Ϊ2���ո�Ϊ1��

            productCategory.CategoryLevel = mark == '0' ? 1 : 2;

            int check = 0;
            check = productCategoryAction.Update(productCategory);
            //����
            if (check > 0)
            {
            }
            else
            {
            }

            #endregion
        }

        #endregion
    }
}