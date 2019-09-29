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
        private string ShopName; //店铺名称

        //店铺商品图片路径
        private string shopimgpath = string.Empty;

        /// <summary>
        ///     会员名
        /// </summary>
        private string MemLoginID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //验证会员中心的cookies
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                //退出
                GetUrl.RedirectTopLogin();
            }
            else
            {
                HttpCookie cookieMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieMemberLogin = HttpSecureCookie.Decode(cookieMemberLogin);
                string MemberType = decodedCookieMemberLogin.Values["MemberType"];
                if (MemberType != "2")
                {
                    //退出
                    GetUrl.RedirectTopLogin();
                    return;
                }
                //会员登录ID
                MemLoginID = decodedCookieMemberLogin.Values["MemLoginID"];

                bool isExisit = CheckMemberID(MemLoginID);
                if (!isExisit)
                {
                    Response.Redirect("TbAuthorization.aspx");
                }


                //绑定商品分页数
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
        ///     获取淘宝新商品(上架的)
        /// </summary>
        /// <returns></returns>
        private bool UpdateProductCount()
        {
            var tbItemOperate = (ShopNum1_TbItem_Action) LogicTbFactory.CreateShopNum1_TbItem_Action();
            int pageCount = GetNewTbItemPageCount();
            //if (pageCount > 1)
            //{
            //    this.ClientScript.RegisterStartupScript(typeof(Page), "msg", "<script type='text/javascript'>alert(\"由于您淘宝商品数据过多，请点击查看淘宝商品进行同步!\")</script>");
            //    return false;
            //}
            for (int j = 0; j <= pageCount; j++)
            {
                var param = new Dictionary<string, string>(); //定义 API应用级输入参数
                param.Add("fields", "num_iid,cid,pic_url,num");
                param.Add("page_no", j.ToString());
                param.Add("page_size", "200");


                string strXml = TopAPI.Post("taobao.items.onsale.get", TopClient.AgentSession, param);

                var tbItemCounts = new List<TbItem>(); //定义商品numiid数量
                var errItem = new ErrorRsp(); //定义错误对象
                var parser = new Parser();


                parser.XmlToObject2(strXml, "items_onsale_get", "items/item", tbItemCounts, errItem); //如：解析XML对象到商品结构中
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
        ///     获取新品上架的分页数量
        /// </summary>
        /// <returns></returns>
        private int GetNewTbItemPageCount()
        {
            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
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
        ///     修改已有商品
        /// </summary>
        /// <returns></returns>
        private bool UpdateAllTbItems()
        {
            var tbItemOperate = (ShopNum1_TbItem_Action) LogicTbFactory.CreateShopNum1_TbItem_Action();
            int pageCount = GetNewTbItemPageCount();

            for (int j = 0; j <= pageCount; j++)
            {
                var param = new Dictionary<string, string>(); //定义 API应用级输入参数
                param.Add("fields", "title,num,pic_url,price,num_iid");
                param.Add("page_no", j.ToString());
                param.Add("page_size", "200");
                string strXml = TopAPI.Post("taobao.items.onsale.get", TopClient.AgentSession, param);
                var tbItemCounts = new List<TbItem>(); //定义商品numiid数量
                var errItem = new ErrorRsp(); //定义错误对象
                var parser = new Parser();
                parser.XmlToObject2(strXml, "items_onsale_get", "items/item", tbItemCounts, errItem); //如：解析XML对象到商品结构中
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
        ///     根据淘宝的产品的数值iid获取本地商品标识
        /// </summary>
        /// <param name="numiid"></param>
        /// <returns></returns>
        private string GetSiteIdByNumiid(decimal numiid)
        {
            var tbItemOperate = (ShopNum1_TbItem_Action) LogicTbFactory.CreateShopNum1_TbItem_Action();
            return tbItemOperate.checkItemExists(numiid);
        }

        /// <summary>
        ///     获取设置的权限
        /// </summary>
        private ShopNum1_TbSystem GetTbSystemSet()
        {
            var tbSystemOperate = (ShopNum1_TbSystem_Action) LogicTbFactory.CreateShopNum1_TbSystem_Action();
            return tbSystemOperate.GetTbSysem(MemLoginID, TopClient.AgentUserNick);
        }


        protected void btnLead_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// 操作各种类型
            /// </summary>
            Func<string, bool> fOperate = a =>
                {
                    switch (a)
                    {
                            ////导入商品分类
                        case "sellcat":
                            return GetTbSellCat();
                            //更新商品库存
                        case "updatecount":
                            return UpdateProductCount();
                            //更新本地现有淘宝商品
                        case "updateitem":
                            return UpdateAllTbItems();
                        default:
                            return false;
                    }
                };

            if (radSort.Checked)
            {
                ///商品分类
                if (fOperate("sellcat"))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MSG", "alert(\"操作成功\")", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MSG", "alert(\"操作失败\")", true);
                }
            }
                ///更新商品
            else if (radUpdateCount.Checked)
            {
                if (fOperate("updatecount"))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MSG", "alert(\"操作成功\")", true);
                }
                else
                {
                    //  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MSG", "alert(\"操作失败\")", true);
                }
            }

                ///导入新商品
            else if (radDownNew.Checked)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "show", "showMsg();", true);
            }

                ///更新现有商品
            else if (radUpdate.Checked)
            {
                if (fOperate("updateitem"))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MSG", "alert(\"操作成功\")", true);
                }
                else
                {
                    // ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MSG", "alert(\"操作失败\")", true);
                }
            }
        }


        /// <summary>
        ///     商品属性
        /// </summary>
        /// <param name="numiid"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        private List<TbSku> GetItemSkus(string numiid, string cid)
        {
            ///得到单个商品信息  -
            ///销售属性
            var itemSkus = new List<TbSku>();
            //属性对应的图片
            var itemPropImgs = new List<TbPropImg>();
            var param = new Dictionary<string, string>(); //API应用级输入参数
            param.Add("fields", "cid,title,price,num,pic_url,sku");
            param.Add("num_iid", numiid);
            param.Add("nick", TopClient.AgentUserNick);
            string strXml = TopAPI.Post("taobao.item.get", TopClient.AgentSession, param);
            var errItem = new ErrorRsp(); //定义错误对象
            var parser = new Parser();

            //解析完整的Item对象
            parser.XmlToObject2(strXml, "item_get", "item/prop_imgs/prop_img", itemPropImgs);
            parser.XmlToObject2(strXml, "item_get", "item/skus/sku", itemSkus);

            if (errItem.IsError) //判断是否发生错误，如果发生错误，则返回到上一页
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof (Page), "error",
                                                        string.Format(
                                                            "alert(\"错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");history.go(-1);",
                                                            errItem.code, errItem.msg, errItem.sub_code, errItem.sub_msg),
                                                        true);
                return null;
            }


            ///将销售属性值转化对应的名称
            foreach (TbSku sku in itemSkus) //获取sku的属性文本
            {
                sku.outer_id = sku.outer_id.Replace("&sbquo;", ","); //还原 sku商家编号 转义字符

                //获取标准类目属性值  ---  sku属性的属性值   详
                var skuParam = new Dictionary<string, string>(); //API应用级输入参数
                skuParam.Add("fields", "cid,pid,prop_name,vid,name,name_alias,status,sort_order");
                //需要返回的字段。目前支持有：cid,pid,prop_name,vid,name,name_alias,status,sort_order 
                skuParam.Add("cid", cid); //指定当前商品cid --- 叶子类目ID ,通过taobao.itemcats.get获得叶子类目ID 
                skuParam.Add("pvs", sku.properties);
                //指定sku对应的pvs  --  属性和属性值 id串，格式例如(pid1;pid2)或(pid1:vid1;pid2:vid2)或(pid1;pid2:vid2) 
                strXml = TopAPI.Post("taobao.itempropvalues.get", skuParam);

                var skuErr = new ErrorRsp();
                var prop_values = new List<TbPropValue>();

                parser.XmlToObject2(strXml, "itempropvalues_get", "prop_values/prop_value", prop_values, skuErr);

                sku.propertiesText = "";
                if (skuErr.IsError == false)
                {
                    foreach (TbPropValue propValue in prop_values) //把已知的属性性连接起来
                    {
                        sku.propertiesText += "&nbsp;" + propValue.name;
                    }
                }
                else
                {
                    sku.propertiesText = "<a title=\"" + skuErr.msg + "\">发生错误(" + skuErr.code + ")</a>";
                }
            }
            return itemSkus;
        }


        //绑定商品页数
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
                    RadioButtonList1.Items.Add(new ListItem("第" + i + "页", i.ToString()));
                }
            }
        }

        //导入商品
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (GetNewTbItem())
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof (Page), "truea", "alert(\"操作成功\");", true);
            }
        }

        /// <summary>
        ///     获取淘宝新商品(上架的)
        /// </summary>
        /// <returns></returns>
        private bool GetNewTbItem()
        {
            var tbItemOperate = (ShopNum1_TbItem_Action) LogicTbFactory.CreateShopNum1_TbItem_Action();
            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
            param.Add("fields", "num_iid,cid,pic_url,num");
            string page = HiddenFieldradioButton.Value.Trim();
            param.Add("page_no", page);
            param.Add("page_size", "200");
            string strXml = TopAPI.Post("taobao.items.onsale.get", TopClient.AgentSession, param);
            var tbItems = new List<ShopNum1_TbItem>(); //定义商品
            var errItem = new ErrorRsp(); //定义错误对象
            var parser = new Parser();
            parser.XmlToObject2(strXml, "items_onsale_get", "items/item", tbItems, errItem); //如：解析XML对象到商品结构中
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

                    ///保存多图
                    if ((bool) GetTbSystemSet().tbImg)
                    {
                        itemImgs = SaveExternItemImgs(tbItems[i].num_iid.ToString());
                    }

                    //向本地数据库添加数据
                    InsertSiteItem(tbItemOperate, tbitem, itemImgs);
                }
            }

            return true;
        }

        /// <summary>
        ///     根据商品的数字numiid获取商品的相关信息
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
            var tbItem = new ShopNum1_TbItem(); //定义商品
            var errItem = new ErrorRsp(); //定义错误对象
            var parser = new Parser();
            parser.XmlToObject2(strXml, "item_get", "item", tbItem, errItem);


            if ((bool) GetTbSystemSet().tbImg)
            {
                //操作图片 
                if (tbItem.pic_url != "")
                {
                    //查询店铺信息，获取存储图片路径
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
        ///     获取产品多图，并下载
        /// </summary>
        /// <param name="num_iid"></param>
        /// <returns></returns>
        private List<TbItemImg> SaveExternItemImgs(string num_iid)
        {
            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
            param.Add("fields", "item_img,num_iid");
            param.Add("nick", TopClient.AgentUserNick);
            param.Add("num_iid", num_iid);
            string strXml = TopAPI.Post("taobao.item.get", TopClient.AgentSession, param);
            var parser = new Parser();

            var itemImgs = new List<TbItemImg>();
            var errItem = new ErrorRsp(); //定义错误对象

            // this.Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "msg", "alert('" + strXml + "')", true);
            parser.XmlToObject2(strXml, "item_get", "item/item_imgs/item_img", itemImgs, errItem);
                //如：解析XML对象到tbSellCats结构
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
        ///     向本地添加商品
        /// </summary>
        /// <param name="tbItemOperate"></param>
        /// <param name="tbItem"></param>
        private void InsertSiteItem(ShopNum1_TbItem_Action tbItemOperate, ShopNum1_TbItem tbItem,
                                    List<TbItemImg> tbItemImgs)
        {
            //string siteId = tbItemOperate.CheckItemByTb(tbItem.num_iid.ToString(), AgentLoginID, TopClient.AgentUserNick);
            decimal siteSellcid = 1; ///商品分类
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

            #region 添加商品

            var shop_Product = new ShopNum1_Shop_Product();
            shop_Product.Guid = Guid.NewGuid();
            shop_Product.Name = tbItem.title;
            shop_Product.ProductNum = tbItem.num.ToString();
            shop_Product.Score = 0;
            shop_Product.OrderID = ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_Shop_Product") + 1;
            shop_Product.ShopPrice = Convert.ToDecimal(tbItem.price);
            shop_Product.MarketPrice = 0;
            shop_Product.IsReal = 1;
            shop_Product.IsSell = 1; //允许销售
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
                ////查询店铺信息，获取存储图片路径
                //ShopNum1_ShopInfoList_Action shopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
                //DataTable dataTable = shopInfoList_Action.GetShopOpentimeByMemLoginID(MemLoginID);
                //string StrRegedate = dataTable.Rows[0]["OpenTime"].ToString();
                //string ShopId = dataTable.Rows[0]["ShopID"].ToString();
                //string userImgPath = "~/ImgUpload/" + Convert.ToDateTime(StrRegedate).ToString("yyyy/MM/dd").Replace('-', '/') + "/Shop" + ShopId;

                shop_Product.OriginalImage = tbItem.pic_url; //用的都是原图
            }
            else
            {
                shop_Product.OriginalImage = "";
            }

            //if (IsPanicBuy + IsSpellBuy > 0)
            //{   //抢购和拼够商品
            shop_Product.ThumbImage = "";
            //}
            //else
            //{
            //    //水印图片做缩率图
            //    shop_Product.ThumbImage = TextBoxOrganizImg.Text;// WaterMark();
            //}

            shop_Product.MultiImages = GetMultiImageTable();
            shop_Product.Description = tbItem.title; //详细页描述
            shop_Product.Keywords = tbItem.title; //详细页搜索关键字
            string IsAudit = ShopSettings.GetValue("AddProductIsAudit"); //是否需要审核
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

            shop_Product.FeeType = 0; //费用承担方
            shop_Product.Post_fee = 0;
            shop_Product.Express_fee = 0;
            shop_Product.Ems_fee = 0;
            shop_Product.MinusFee = 0;
            shop_Product.FeeTemplateID = 0;
            shop_Product.FeeTemplateName = "";

            //主站分类
            shop_Product.ProductCategoryCode = !(bool) GetTbSystemSet().tbSellCat ? "1" : siteSellcid.ToString();
            ;
            shop_Product.ProductCategoryName = "";
            //店铺分类
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
                ////显示操作信息
                //this.MessageShow.ShowMessage("AddNo");
                //this.MessageShow.Visible = true;
            }

            #endregion 添加商品

            ////添加中间表关系
            // tbItemOperate.InsertAgentItem(tbItem.num_iid.ToString(), product.Guid.ToString(), "0", MemLoginID, TopClient.AgentUserNick);
        }

        /// <summary>
        ///     获取网站 目录父类目Id
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
            #region 添加

            string name, description, fatherID, user;
            int categoryLevel;
            string family = "";

            name = "淘宝商品图Top";
            description = "从淘宝网下载的商品图";
            fatherID = "0";
            user = MemLoginID;


            //如果为顶级分类
            categoryLevel = 1;


            var imageCategory_Action =
                (ShopNum1_ImageCategory_Action) LogicFactory.CreateShopNum1_ImageCategory_Action();

            int check = 0;
            check = imageCategory_Action.Insert(name, description, categoryLevel.ToString(), fatherID, family, user);
            //更新

            #endregion
        }

        /// <summary>
        ///     向数据库插入数据
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
                Page.Response.Write("<script>alert('添加成功！'); window .location='Image_List.aspx'</script>");
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
        }

        ///// <summary>
        ///// 向Shop_ImagePath表中插入数据
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
        //        Page.Response.Write("<script>alert('添加成功！'); window .location='Image_List.aspx'</script>");
        //    }
        //    else
        //    {

        //    }
        //}


        /// <summary>
        ///     商品多图
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
        ///     获取店铺名字
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

        #region  操作淘宝的销售属性

        /// <summary>
        ///     根据商品标识获取销售属性
        /// </summary>
        /// <param name="numiid"></param>
        /// <returns></returns>
        private List<TbSku> GetSkusByNumiid(string numiid)
        {
            var param = new Dictionary<string, string>();
            param.Add("fields", "sku_id,num_iid,properties,quantity,price,outer_id,status");
            param.Add("num_iids", numiid);
            string strXml = TopAPI.Post("taobao.item.skus.get", TopClient.AgentSession, param);
            var tbSkus = new List<TbSku>(); //定义销售属性
            var errItem = new ErrorRsp(); //定义错误对象
            var parser = new Parser();
            parser.XmlToObject2(strXml, "item_skus_get", "skus/sku", tbSkus, errItem);

            return tbSkus;
        }

        /// <summary>
        ///     添加商品的规格属性 既淘宝的销售属性
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
            ///获取销售属性
            tbSkus = GetSkusByNumiid(numiid);
            if (tbSkus == null || tbSkus.Count == 0)
                return false;
            //图片规格多图处理


            //获取规格列表
            List<ShopNum1_SpecProudct> sproducts = GetProductSkus(tbSkus, prodGuid);


            if (sproducts != null && sproducts.Count > 0)
            {
                SpecificationProudctOperate.AddListSpecProducts(sproducts);
            }

            return true;
        }


        /// <summary>
        ///     根据淘宝的属性获取规格值
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
        ///     获取商品的销售属性组
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
                    //规格属性组
                    string detail = GetSpecDetailByTbProp(skus[i].properties);
                    if (detail == string.Empty || detail == ";")
                    {
                        continue;
                    }
                    //商品guid
                    sproduct.ProductGuid = pguid.ToString();
                    ///价格
                    sproduct.GoodsPrice = Convert.ToDecimal(skus[i].price);
                    //规格库存
                    sproduct.GoodsStock = skus[i].quantity;
                    //规格商品编码
                    sproduct.GoodsNumber = skus[i].outer_id;
                    //
                    sproduct.SalesCount = 0;
                    //本地规格值对应
                    sproduct.SpecDetail = detail;
                    //淘宝销售属性
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

        #region    //水印  缩略图

        //水印  缩略图  dddd
        private bool UpLoadImg(string strimgpath)
        {
            return true;
            //string name = Server.MapPath("~/ImgUpload/" + strimgpath);                  // 客户端文件路径
            //FileInfo file = new FileInfo(name);
            //// 文件名称
            //string fileName = file.Name;
            //// 服务器端文件路径
            //string webFilePath = Server.MapPath("~/ImgUpload/" + fileName);
            //string imagepath = "//" + fileName;

            //if (File.Exists(webFilePath))
            //{
            //    //如果水印 缩略图上传失败继续显示成功!
            //    try
            //    {
            //        #region 判断是否生成水印图片

            //        string strCheck = ShopSettings.GetValue("IfSetWaterMark");
            //        if (strCheck == "0")
            //        {
            //            //不生成水印
            //            // 使用 SaveAs 方法保存文件
            //        }
            //        else if (strCheck == "1")
            //        {
            //            //生成水印
            //            //添加文字水印
            //            string o_webFilePath = Server.MapPath("~/ImgUpload/" + "O_" + fileName);

            //            File.Copy(name, o_webFilePath, true);
            //            //水印文字
            //            string addText = shopSettings.GetValue(filePath, "WaterMarkWords");
            //            //水印位置
            //            string position = shopSettings.GetValue(filePath, "WordsWaterMarkPosition");
            //            //字体
            //            string fontType = shopSettings.GetValue(filePath, "WaterMarkWordsFont");
            //            //字大小
            //            float fontSize = Convert.ToSingle(shopSettings.GetValue(filePath, "WaterMarkWordsFontSize"));
            //            //字的颜色
            //            string fontColor = shopSettings.GetValue(filePath, "WaterMarkWordsColor");
            //            ImageOperator.CreateWater(o_webFilePath, webFilePath, addText, position, fontType, fontSize, fontColor);

            //            File.Delete(o_webFilePath);

            //        }
            //        else if (strCheck == "2")
            //        {
            //            //添加图片水印
            //            string o_webFilePath = Server.MapPath("~/ImgUpload/" + "O_" + fileName);
            //            File.Copy(name, o_webFilePath);
            //            //从ShopSettings.xml中读水印的图片地址
            //            //水印图片地址
            //            string waterSourcePath = Server.MapPath("~/ImgUpload/" + shopSettings.GetValue(filePath, "WaterMarkOriginalImge"));
            //            //水印位置
            //            string position = shopSettings.GetValue(filePath, "WaterMarkImagePosition");

            //            ImageOperator.CreateWaterPic(o_webFilePath, webFilePath, waterSourcePath, position);
            //            File.Delete(o_webFilePath);

            //        }
            //        #endregion
            //        //插入到数据库中
            //        Add(fileName);
            //        string strOriginalImagePath = fileName;

            //        #region 取得要生成缩略图的尺寸

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

            //        //生成缩略图
            //        string fileName_s = "s" + "_" + file.Name;        // 缩略图文件名称

            //        // 服务器端缩略图路径
            //        string webFilePath_s = Server.MapPath("~/ImgUpload/" + fileName_s);
            //        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(webFilePath);
            //        ImageOperator.CreateThumbnail(webFilePath, webFilePath_s, width, height, "Cut");
            //        //添加到数据库
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

        #region   操作淘宝商品分类

        /// <summary>
        ///     获取淘宝店铺自定义分类
        /// </summary>
        private bool GetTbSellCat()
        {
            ///获取本地类目Id
            var commaction = (Shop_Common_Action) ShopFactory.LogicFactory.CreateShop_Common_Action();
            var productCategoryAction =
                (Shop_ProductCategory_Action) ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
            //需返回的字段列表。
            param.Add("fields", "cid,parent_cid,name,pic_url,sort_order,created,modified");
            param.Add("nick", TopClient.AgentUserNick);
            string strXml = TopAPI.Post("taobao.sellercats.list.get", TopClient.AgentSession, param);
            var tbSellCats = new List<TbItemCat>(); //定义返回淘宝店铺自定义分类

            var errItem = new ErrorRsp(); //定义错误对象
            var parser = new Parser();
            parser.XmlToObject2(strXml, "sellercats_list_get", "seller_cats/seller_cat", tbSellCats, errItem);
            //如：解析XML对象到tbSellCats结构
            var sellcatOperate = (ShopNum1_TbSellCat_Action) LogicTbFactory.CreateShopNum1_TbSellCat_Action();
            if (tbSellCats == null)
                return true;
            foreach (TbItemCat tbcat in tbSellCats)
            {
                decimal sitecid = CheckTbCidExists(Convert.ToDecimal(tbcat.cid));

                var sellcat = new ShopNum1_TbSellCat();
                sellcat.modified = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sellcat.created = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ///先操作父类
                if (tbcat.parent_cid == "0")
                {
                    ///确定是否执行插入
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
                        ///向本地数据库更新
                        InsertSiteSellCat(sellcat, "0");
                        sellcat.site_cid = commaction.ReturnMaxID("ID", "ShopNum1_Shop_ProductCategory");
                        ///因为是自增长列 所以成功添加后来加
                        ///更新中间表 
                        sellcatOperate.InsertSellCat(sellcat);
                    }
                        ///执行更新操作
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
                    ///确定是否执行插入
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
                        ///向本地数据库更新 第二级目录
                        InsertSiteSellCat(sellcat, "1");

                        sellcat.site_cid = commaction.ReturnMaxID("ID", "ShopNum1_Shop_ProductCategory");
                        ///更新中间表
                        sellcatOperate.InsertSellCat(sellcat);
                    }
                        ///执行更新操作
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

            //// 淘宝检查删除
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
        ///     检查淘宝是否删除过类别   删除返回true 没有删除返回false
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
        ///     检查  淘宝和本地 目录是否建立的关系
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
        ///     向本地数据库插入目录
        /// </summary>
        /// <param name="sellCat"></param>
        private void InsertSiteSellCat(ShopNum1_TbSellCat sellCat, string mark)
        {
            #region 添加

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
            //如果为顶级分类
            productCategory.CategoryLevel = mark == "0" ? 1 : 2;
            if (productCategory.FatherID == 0)
            {
                productCategory.CategoryLevel = 1;
            }
            productCategoryAction.TableName = "ShopNum1_Shop_ProductCategory";
            int check = 0;
            check = productCategoryAction.Add(productCategory);
            //更新
            if (check > 0)
            {
            }
            else
            {
                ////显示操作信息
            }

            #endregion
        }


        /// <summary>
        ///     修改本地数据库目录
        /// </summary>
        /// <param name="sellCat"></param>
        private void UpdateSiteSellCat(ShopNum1_TbSellCat sellCat, char mark)
        {
            #region 编辑

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
            //得到级别
            //先根据一个空格分字符串，如果有4个空格，就是3级，因为2个空格为1级

            productCategory.CategoryLevel = mark == '0' ? 1 : 2;

            int check = 0;
            check = productCategoryAction.Update(productCategory);
            //更新
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