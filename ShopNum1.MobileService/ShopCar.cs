using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.MobileService
{
    public class ShopCar : System.Web.UI.Control
    {
        public string MemberLoginID { get; set; }

        public string MemberType { get; set; }

        public string ShopName { get; set; }

        private readonly IShopNum1_SpecProudctDetail_Action ishopNum1_SpecProudctDetail_Action_0 =
         LogicFactory.CreateShopNum1_SpecProudctDetail_Action();

        private readonly IShopNum1_SpecProudct_Action ishopNum1_SpecProudct_Action_0 =
            LogicFactory.CreateShopNum1_SpecProudct_Action();

        private readonly IShopNum1_Spec_Action ishopNum1_Spec_Action_0 = LogicFactory.CreateShopNum1_Spec_Action();

        //MyMemLoginID 买家ID
        //category  专区号
        
        //Num  购买数量
        //guid   商品GUID

    //      public  string AddShopCar(string MyMemLoginID, string category, string Num, string guid)
    //    {


    //        string MemRankGuid = null;
    //        string MemLinkCategory = null;
            
    //        //判断是否登陆，若没有登陆取会员等级为普通用户的Guid

    //        string memberrankguid =
    //          ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMberRankGuid(MyMemLoginID);
    //        MemRankGuid = memberrankguid;

    //        //根据会员等级的Guid以及可看属性获得专区板块ID字符串
    //        DataTable linkCategory = LogicFactory.CreateMemberRank_LinkCategory_Action().GetRankLinkCategoryByID(MemRankGuid, "2");

    //        DataTable product = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetAllShop_Product(guid, category);


    //        MemLinkCategory = linkCategory.Rows[0]["Category_ID"].ToString();
    //        if (!MemLinkCategory.Contains(category))
    //        {
    //            return "您的会员等级权限不足!";
    //        }
    //        else
    //        {
    //            var cd = (ShopNum1_Cart_Action)LogicFactory.CreateShopNum1_Cart_Action();

    //            MemberLoginID = MyMemLoginID;

    //            if (cd.SelectShopCar(MemberLoginID).Rows.Count > 0)
    //            {
    //                if (Convert.ToString(cd.SelectShopCar(MemberLoginID).Rows[0]["shop_category_id"]) != category.ToString())
    //                {
    //                    return "不可添加多个不同专区到购物车!";
    //                }
    //                else if (product.Rows[0]["MemLoginID"].ToString() != Convert.ToString(cd.SelectShopCar(MemberLoginID).Rows[0]["ShopID"]))
    //                {
    //                    return "不可添加不同店铺商品到购物车!";
    //                }

    //                else
    //                {



    //                    bool flag = false;
    //                    //try
    //                    //{
    //                    //    if (int.Parse(Num) > 0)
    //                    //    {
    //                    //        flag = true;
    //                    //    }
    //                    //    else
    //                    //    {
    //                    //        return "请正确填写购买数量!";
    //                    //    }
    //                    //    if (int.Parse(product.Rows[0]["RepertoryCount"].ToString()) < int.Parse(Num))
    //                    //    {
    //                    //        return "商品库存不足！";
                                
    //                    //    }
    //                    //    if (product.Rows[0]["MemLoginID"].ToString() == MyMemLoginID)
    //                    //    {
    //                    //        return "您不能添加自己的商品！";
                               
    //                    //    }

    //                    //}
    //                    //catch (Exception)
    //                    //{
    //                    //    return"请正确填写购买数量!";
    //                    //}
    //                    if (flag)
    //                    {
    //                        DataTable specificationByProduct;
    //                        decimal a;
    //                        decimal b;
    //                        decimal c;
    //                        decimal dee;
    //                        if (Convert.ToDecimal(product.Rows[0]["RepertoryCount"].ToString()) == 0)
    //                        {

    //                            a = Convert.ToDecimal(product.Rows[0]["Score_max_hv"].ToString()) * (-1);
    //                        }
    //                        else
    //                        {

    //                            a = Convert.ToDecimal(product.Rows[0]["Score_hv"].ToString());
    //                        }
    //                        if (Convert.ToDecimal(product.Rows[0]["Score_pv_a"].ToString()) == 0)
    //                        {
    //                            b = Convert.ToDecimal(product.Rows[0]["Score_cv"].ToString()) * (-1);
    //                        }
    //                        else
    //                        {
    //                            b = Convert.ToDecimal(product.Rows[0]["Score_pv_a"].ToString());
    //                        }
    //                        c = Convert.ToDecimal(product.Rows[0]["Score_dv"].ToString()) * (-1);
    //                        dee = Convert.ToDecimal(product.Rows[0]["Score_pv_cv"].ToString());
    //                        var shopcart = new ShopNum1_Shop_Cart
    //                        {
    //                            Guid = Guid.NewGuid(),
    //                            MemLoginID = MyMemLoginID,
    //                            ProductGuid = new Guid(guid),
    //                            OriginalImge = product.Rows[0]["OriginalImage"].ToString(),
    //                            Name = product.Rows[0]["Name"].ToString(),
    //                            RepertoryNumber = product.Rows[0]["ProductNum"].ToString(),
    //                            BuyNumber = int.Parse(Num),
    //                            MarketPrice = decimal.Parse(product.Rows[0]["MarketPrice"].ToString()),
    //                            shop_category_id = Convert.ToInt32(category),
    //                            Score_dv = c,
    //                            Score_hv = a,
    //                            Score_pv_a = b,
    //                            Size = product.Rows[0]["Size"].ToString(),
    //                            Color = product.Rows[0]["Color"].ToString(),
    //                            Score_pv_cv = dee,
    //                            Score_pv_b = Convert.ToDecimal(product.Rows[0]["Color"].ToString()),
    //                            GoodsWeight = Convert.ToDecimal(product.Rows[0]["GoodsWeight"].ToString())
    //                        };
    //                        string text = product.Rows[0]["ShopPrice"].ToString();
    //                        if (!string.IsNullOrEmpty(guid))
    //                        {
    //                            specificationByProduct =
    //                                ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(guid,
    //                                    guid.Replace(":", ",")
    //                                        .Replace(";", "|")
    //                                        .TrimEnd(new[] { ';' })
    //                                        .TrimEnd(new[] { '|' }));
    //                            if (((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0)) &&
    //                                (specificationByProduct.Rows[0]["GoodsPrice"].ToString() != ""))
    //                            {
    //                                text = specificationByProduct.Rows[0]["GoodsPrice"].ToString();
    //                            }
    //                        }
    //                        shopcart.ShopPrice = decimal.Parse(text);
    //                        shopcart.Attributes = product.Rows[0]["setStock"].ToString();
    //                        if (!string.IsNullOrEmpty(guid))
    //                        {
    //                            specificationByProduct =
    //                                ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(guid,
    //                                    guid.Replace(":", ",")
    //                                        .Replace(";", "|")
    //                                        .TrimEnd(new[] { ';' })
    //                                        .TrimEnd(new[] { '|' }));
    //                            if ((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0))
    //                            {
    //                                shopcart.BuyPrice = Convert.ToDecimal(specificationByProduct.Rows[0]["GoodsPrice"].ToString());
    //                            }
    //                            else
    //                            {
    //                                shopcart.BuyPrice = decimal.Parse(product.Rows[0]["ShopPrice"].ToString());
    //                            }
    //                        }
    //                        else
    //                        {
    //                            shopcart.BuyPrice = decimal.Parse(product.Rows[0]["ShopPrice"].ToString());
    //                        }
    //                        if (false)
    //                        {
    //                            if (product.Rows[0]["IsSaled"].ToString() == "1")
    //                            {
    //                                shopcart.BuyPrice = decimal.Parse(product.Rows[0]["groupprice"].ToString());
    //                            }
    //                            else if (product.Rows[0]["IsSaled"].ToString() == "2")
    //                            {
    //                                decimal d = Convert.ToDecimal(product.Rows[0]["ShopPrice"].ToString()) * Convert.ToDecimal(product.Rows[0]["discount"].ToString());
    //                                shopcart.BuyPrice = Math.Round(d, 2);
    //                            }
    //                        }
    //                        if ("11" == "抢 购 价：")
    //                        {

    //                        }
    //                        shopcart.IsShipment = 0;
    //                        shopcart.IsReal = int.Parse(product.Rows[0]["IsReal"].ToString());
    //                        shopcart.ExtensionAttriutes = "";
    //                        shopcart.IsJoinActivity = 0;
    //                        shopcart.CartType = Convert.ToInt32(product.Rows[0]["IsSaled"].ToString());
    //                        shopcart.IsPresent = 0;
    //                        shopcart.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    //                        shopcart.DetailedSpecifications = "";
    //                        shopcart.ShopID = product.Rows[0]["MemLoginID"].ToString();
    //                        shopcart.SellName = product.Rows[0]["ShopName"].ToString();
    //                        shopcart.FeeType = int.Parse(product.Rows[0]["FeeType"].ToString());
    //                        shopcart.shop_category_id = Convert.ToInt32(category);
    //                        if (product.Rows[0]["setstock"].ToString().Length > 1)
    //                        {
    //                            if (product.Rows[0]["setstock"].ToString().Trim(new[] { ';' }) != "0")
    //                            {
    //                                shopcart.SpecificationValue =
    //                                    product.Rows[0]["setstock"].ToString().Trim(new[] { ';' }).Replace(":", ",").Replace(";", "|");
    //                            }
    //                            //if (HiddenFieldSpecName.Value.Trim(new[] { ';' }) != "0")
    //                            //{
    //                            //shopcart.SpecificationName =
    //                            //    HiddenFieldSpecName.Value.TrimEnd(new[] { ';' }).Replace("/", "-").TrimEnd(new[] { '0' });

    //                            shopcart.SpecificationName = "";   //看不懂 随意定的
    //                            //}
    //                        }
    //                        if (product.Rows[0]["FeeType"].ToString() == "1")
    //                        {
    //                            shopcart.Post_fee = 0;
    //                            shopcart.Ems_fee = 0;
    //                            shopcart.Express_fee = 0;
    //                        }
    //                        else
    //                        {
    //                            shopcart.Post_fee = decimal.Parse(product.Rows[0]["Post_fee"].ToString());
    //                            shopcart.Ems_fee = decimal.Parse(product.Rows[0]["Ems_fee"].ToString());
    //                            shopcart.Express_fee = decimal.Parse(product.Rows[0]["Express_fee"].ToString());
    //                        }
    //                        var action = (ShopNum1_Cart_Action)LogicFactory.CreateShopNum1_Cart_Action();
    //                        int num = 0;
    //                        if (shopcart.SellName != "")
    //                        {
    //                            num = action.AddCart(shopcart);
    //                        }
    //                        else
    //                        {
    //                            num = 1;
    //                        }
    //                        if (num > 0)
    //                        {
    //                            Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart1"));
    //                            return "添加成功!";
    //                        }
    //                        else
    //                        {
    //                            return "添加失败!";
    //                        }
                           
    //                    }
    //                    else
    //                    {
    //                        return "1";
    //                    }
    //                }
                    
    //            }
    //            else
    //            {
    //                return "1";

    //            //    bool flag = false;
    //            //    try
    //            //    {
    //            //        if (int.Parse(Num) > 0)
    //            //        {
    //            //            flag = true;
    //            //        }
    //            //        else
    //            //        {
    //            //            return "请正确填写购买数量!";
    //            //        }
    //            //        if (int.Parse(product.Rows[0]["RepertoryCount"].ToString()) < int.Parse(Num))
    //            //        {
    //            //            return "商品库存不足！" ;
                            
    //            //        }
    //            //        if (product.Rows[0]["MemLoginID"].ToString() == MyMemLoginID)
    //            //        {
    //            //              return "您不能添加自己的商品！";
                            
    //            //        }
    //            //    }
    //            //    catch (Exception)
    //            //    {
    //            //        return "请正确填写购买数量!";
    //            //    }
    //            //    if (flag)
    //            //    {
    //            //        DataTable specificationByProduct;
    //            //        decimal a;
    //            //        decimal b;
    //            //        decimal c;
    //            //        decimal dee;
    //            //        if (Convert.ToDecimal(product.Rows[0]["RepertoryCount"].ToString()) == 0)
    //            //        {

    //            //            a = Convert.ToDecimal(product.Rows[0]["Score_max_hv"].ToString()) * (-1);
    //            //        }
    //            //        else
    //            //        {

    //            //            a = Convert.ToDecimal(product.Rows[0]["Score_hv"].ToString());
    //            //        }
    //            //        if (Convert.ToDecimal(product.Rows[0]["Score_pv_a"].ToString()) == 0)
    //            //        {
    //            //            b = Convert.ToDecimal(product.Rows[0]["Score_cv"].ToString()) * (-1);
    //            //        }
    //            //        else
    //            //        {
    //            //            b = Convert.ToDecimal(product.Rows[0]["Score_pv_a"].ToString());
    //            //        }
    //            //        c = Convert.ToDecimal(product.Rows[0]["Score_dv"].ToString()) * (-1);
    //            //        dee = Convert.ToDecimal(product.Rows[0]["Score_pv_cv"].ToString());
    //            //        var shopcart = new ShopNum1_Shop_Cart
    //            //        {
    //            //            Guid = Guid.NewGuid(),
    //            //            MemLoginID = MyMemLoginID,
    //            //            ProductGuid = new Guid(guid),
    //            //            OriginalImge = product.Rows[0]["OriginalImage"].ToString(),
    //            //            Name = product.Rows[0]["Name"].ToString(),
    //            //            RepertoryNumber = product.Rows[0]["ProductNum"].ToString(),
    //            //            BuyNumber = int.Parse(Num),
    //            //            MarketPrice = decimal.Parse(product.Rows[0]["MarketPrice"].ToString()),
    //            //            shop_category_id = Convert.ToInt32(category),
    //            //            Score_dv = c,
    //            //            Score_hv = a,
    //            //            Score_pv_a = b,
    //            //            Size = product.Rows[0]["Size"].ToString(),
    //            //            Color = product.Rows[0]["Color"].ToString(),
    //            //            Score_pv_cv = dee,
    //            //            Score_pv_b = Convert.ToDecimal(product.Rows[0]["Color"].ToString()),
    //            //            GoodsWeight = Convert.ToDecimal(product.Rows[0]["GoodsWeight"].ToString())
    //            //        };
    //            //        string text = product.Rows[0]["ShopPrice"].ToString();
    //            //        if (!string.IsNullOrEmpty(guid))
    //            //        {
    //            //            specificationByProduct =
    //            //                ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(guid,
    //            //                    guid.Replace(":", ",")
    //            //                        .Replace(";", "|")
    //            //                        .TrimEnd(new[] { ';' })
    //            //                        .TrimEnd(new[] { '|' }));
    //            //            if (((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0)) &&
    //            //                (specificationByProduct.Rows[0]["GoodsPrice"].ToString() != ""))
    //            //            {
    //            //                text = specificationByProduct.Rows[0]["GoodsPrice"].ToString();
    //            //            }
    //            //        }
    //            //        shopcart.ShopPrice = decimal.Parse(text);
    //            //        shopcart.Attributes = product.Rows[0]["setStock"].ToString();
    //            //        if (!string.IsNullOrEmpty(guid))
    //            //        {
    //            //            specificationByProduct =
    //            //                ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(guid,
    //            //                    guid.Replace(":", ",")
    //            //                        .Replace(";", "|")
    //            //                        .TrimEnd(new[] { ';' })
    //            //                        .TrimEnd(new[] { '|' }));
    //            //            if ((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0))
    //            //            {
    //            //                shopcart.BuyPrice = Convert.ToDecimal(specificationByProduct.Rows[0]["GoodsPrice"].ToString());
    //            //            }
    //            //            else
    //            //            {
    //            //                shopcart.BuyPrice = decimal.Parse(product.Rows[0]["ShopPrice"].ToString());
    //            //            }
    //            //        }
    //            //        else
    //            //        {
    //            //            shopcart.BuyPrice = decimal.Parse(product.Rows[0]["ShopPrice"].ToString());
    //            //        }
    //            //        if (false)
    //            //        {
    //            //            if (product.Rows[0]["IsSaled"].ToString() == "1")
    //            //            {
    //            //                shopcart.BuyPrice = decimal.Parse(product.Rows[0]["groupprice"].ToString());
    //            //            }
    //            //            else if (product.Rows[0]["IsSaled"].ToString() == "2")
    //            //            {
    //            //                decimal d = Convert.ToDecimal(product.Rows[0]["ShopPrice"].ToString()) * Convert.ToDecimal(product.Rows[0]["discount"].ToString());
    //            //                shopcart.BuyPrice = Math.Round(d, 2);
    //            //            }
    //            //        }
    //            //        if ("11" == "抢 购 价：")
    //            //        {

    //            //        }
    //            //        shopcart.IsShipment = 0;
    //            //        shopcart.IsReal = int.Parse(product.Rows[0]["IsReal"].ToString());
    //            //        shopcart.ExtensionAttriutes = "";
    //            //        shopcart.IsJoinActivity = 0;
    //            //        shopcart.CartType = Convert.ToInt32(product.Rows[0]["IsSaled"].ToString());
    //            //        shopcart.IsPresent = 0;
    //            //        shopcart.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    //            //        shopcart.DetailedSpecifications = "";
    //            //        shopcart.ShopID = product.Rows[0]["MemLoginID"].ToString();
    //            //        shopcart.SellName = product.Rows[0]["ShopName"].ToString();
    //            //        shopcart.FeeType = int.Parse(product.Rows[0]["FeeType"].ToString());
    //            //        shopcart.shop_category_id = Convert.ToInt32(category);
    //            //        if (product.Rows[0]["setstock"].ToString().Length > 1)
    //            //        {
    //            //            if (product.Rows[0]["setstock"].ToString().Trim(new[] { ';' }) != "0")
    //            //            {
    //            //                shopcart.SpecificationValue =
    //            //                    product.Rows[0]["setstock"].ToString().Trim(new[] { ';' }).Replace(":", ",").Replace(";", "|");
    //            //            }
    //            //            //if (HiddenFieldSpecName.Value.Trim(new[] { ';' }) != "0")
    //            //            //{
    //            //            //shopcart.SpecificationName =
    //            //            //    HiddenFieldSpecName.Value.TrimEnd(new[] { ';' }).Replace("/", "-").TrimEnd(new[] { '0' });

    //            //            shopcart.SpecificationName = "";   //看不懂 随意定的
    //            //            //}
    //            //        }
    //            //        if (product.Rows[0]["FeeType"].ToString() == "1")
    //            //        {
    //            //            shopcart.Post_fee = 0;
    //            //            shopcart.Ems_fee = 0;
    //            //            shopcart.Express_fee = 0;
    //            //        }
    //            //        else
    //            //        {
    //            //            shopcart.Post_fee = decimal.Parse(product.Rows[0]["Post_fee"].ToString());
    //            //            shopcart.Ems_fee = decimal.Parse(product.Rows[0]["Ems_fee"].ToString());
    //            //            shopcart.Express_fee = decimal.Parse(product.Rows[0]["Express_fee"].ToString());
    //            //        }
    //            //        var action = (ShopNum1_Cart_Action)LogicFactory.CreateShopNum1_Cart_Action();
    //            //        int num = 0;
    //            //        if (shopcart.SellName != "")
    //            //        {
    //            //            num = action.AddCart(shopcart);
    //            //        }
    //            //        else
    //            //        {
    //            //            num = 1;
    //            //        }
    //            //        if (num > 0)
    //            //        {
    //            //            Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart1"));
    //            //            return "添加成功!";
    //            //        }
    //            //        else
    //            //        {
    //            //             return "添加失败!" ;
    //            //        }

    //            //    }
    //            //}


    //        }
    //    }
    //}
    }
}
