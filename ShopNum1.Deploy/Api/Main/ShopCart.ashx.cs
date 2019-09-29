using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Data;


namespace ShopNum1.Deploy.Api.Main
{
    /// <summary>
    /// ShopCart 的摘要说明
    /// </summary>
    public class ShopCart : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string strguid = ShopNum1.Common.Common.ReqStr("guid");
            string strnum = ShopNum1.Common.Common.ReqStr("num");
            string strprice = ShopNum1.Common.Common.ReqStr("pirce");
            string strpguid = ShopNum1.Common.Common.ReqStr("pguid");
            string strMemloginId = HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("mid"));
            var cartAction = (ShopNum1_Cart_Action)LogicFactory.CreateShopNum1_Cart_Action();
            DataTable shopcart1 = new DataTable();


           
            shopcart1= cartAction.SelecetCatgrogryID(strguid);
            string shop_category_id=shopcart1.Rows[0]["shop_category_id"].ToString();
            DataTable SelecetShop_ProductPrice = cartAction.SelecetShop_ProductPrice(strpguid, shop_category_id);
                
            if (shop_category_id=="5"||shop_category_id=="6")
            {
                DataTable smaxnumber = cartAction.SelecetMaxnumber(strpguid,shop_category_id);
                if (Convert.ToInt32( smaxnumber.Rows[0]["maxnumber"]) >= Convert.ToInt32( strnum))
                {
                    if (strguid != "" && strnum != "" && strprice != "" && strpguid != "")
                       {
                var listCart = new List<ShopNum1_Shop_Cart>();
                var tempCart = new ShopNum1_Shop_Cart();
                tempCart.Guid = new Guid(ShopNum1.Common.Common.ReqStr("guid"));
                tempCart.BuyPrice =Convert.ToDecimal( SelecetShop_ProductPrice.Rows[0]["ShopPrice"]);
                tempCart.BuyNumber = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("num"));
                listCart.Add(tempCart);
                //Shop_Product_Action productAction = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
                //int limitBuyCount = productAction.GetLimitBuyCount(ShopNum1.Common.ShopNum1.Common.Common.ReqStr("pguid"));
                //if (limitBuyCount < tempCart.BuyNumber)
                //{
                //    if (limitBuyCount != 0)
                //    {
                //        context.Response.Write(limitBuyCount);
                //        return;
                //    }
                //}
                
                cartAction.Update(listCart);
                context.Response.Write("ok");
            }
            else if (strguid != "" & ShopNum1.Common.Common.ReqStr("sign") == "address")
            {
                Thread.Sleep(200);
                var address_action = (ShopNum1_Address_Action)LogicFactory.CreateShopNum1_Address_Action();
                address_action.ChangeDefaultAddress(strMemloginId, strguid);
                context.Response.Write("ok");
            }
                }
                else
                {
                    context.Response.Write("最大购买数量不可以超过" + Convert.ToInt32(smaxnumber.Rows[0]["maxnumber"])+"个!");
                }
            }
            else
            {
                if (strguid != "" && strnum != "" && strprice != "" && strpguid != "")
                {
                    var listCart = new List<ShopNum1_Shop_Cart>();
                    var tempCart = new ShopNum1_Shop_Cart();
                    tempCart.Guid = new Guid(ShopNum1.Common.Common.ReqStr("guid"));
                    tempCart.BuyPrice = Convert.ToDecimal(SelecetShop_ProductPrice.Rows[0]["ShopPrice"]);
                    tempCart.BuyNumber = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("num"));
                    listCart.Add(tempCart);
                    //Shop_Product_Action productAction = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
                    //int limitBuyCount = productAction.GetLimitBuyCount(ShopNum1.Common.ShopNum1.Common.Common.ReqStr("pguid"));
                    //if (limitBuyCount < tempCart.BuyNumber)
                    //{
                    //    if (limitBuyCount != 0)
                    //    {
                    //        context.Response.Write(limitBuyCount);
                    //        return;
                    //    }
                    //}

                    cartAction.Update(listCart);
                    context.Response.Write("ok");
                }
                else if (strguid != "" & ShopNum1.Common.Common.ReqStr("sign") == "address")
                {
                    Thread.Sleep(200);
                    var address_action = (ShopNum1_Address_Action)LogicFactory.CreateShopNum1_Address_Action();
                    address_action.ChangeDefaultAddress(strMemloginId, strguid);
                    context.Response.Write("ok");
                }
            }
            
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}