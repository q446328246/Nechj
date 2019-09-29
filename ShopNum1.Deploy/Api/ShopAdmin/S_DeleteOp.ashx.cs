
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Interface;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Api.ShopAdmin
{
    /// <summary>
    /// S_DeleteOp 的摘要说明
    /// </summary>
    public class S_DeleteOp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (ShopNum1.Common.Common.ReqStr("type") != "" && HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
                {
                    string strType = ShopNum1.Common.Common.ReqStr("type");
                    var News_Action = (Shop_News_Action)LogicFactory.CreateShop_News_Action();
                    var Video_Action = (Shop_Video_Action)LogicFactory.CreateShop_Video_Action();
                    var ShopLink_Action = (Shop_ShopLink_Action)LogicFactory.CreateShop_ShopLink_Action();

                    var Coupon_Action = (Shop_Coupon_Action)LogicFactory.CreateShop_Coupon_Action();

                    var Shop_ScoreProduct_Action =
                        (ShopNum1_Shop_ScoreProduct_Action)
                        ShopNum1.Factory.LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();

                    var ScoreOrderInfo_Action =
                        (ShopNum1_ScoreOrderInfo_Action)
                        ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();

                    var ZtcApply_Action =
                        (ShopNum1_ZtcApply_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ZtcApply_Action();

                    var ZtcGoods_Action =
                        (ShopNum1_ZtcGoods_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ZtcGoods_Action();


                    var NewsCategory_Action = (Shop_NewsCategory_Action)LogicFactory.CreateShop_NewsCategory_Action();


                    var VideoCategory_Action = (Shop_VideoCategory_Action)LogicFactory.CreateShop_VideoCategory_Action();


                    var AdvancePaymentApplyLog_Action =
                        (ShopNum1_AdvancePaymentApplyLog_Action)
                        ShopNum1.Factory.LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();


                    string strDelid = context.Request.QueryString["delid"].Replace("''", "'");
                    switch (strType)
                    {
                        case "ShopNews": //删除店铺资讯
                            News_Action.DeleteNews(strDelid);
                            context.Response.Write("ok");
                            break;
                        case "ShopVideo": //删除店铺视频
                            Video_Action.DeleteVideoInfo(strDelid);
                            context.Response.Write("ok");
                            break;
                        case "ShopLink": //删除友情链接
                            ShopLink_Action.Delete(strDelid);
                            context.Response.Write("ok");
                            break;
                        case "ShopCoupon": //删除优惠券
                            Coupon_Action.Delete(strDelid);
                            context.Response.Write("ok");
                            break;
                        case "ShopSEO": //删除seo
                            context.Response.Write(DeleteSeoXml(strDelid));
                            break;
                        case "ScoreProduct": //删除红包商品
                            Shop_ScoreProduct_Action.Delete(strDelid);
                            context.Response.Write("ok");
                            break;
                        case "ScoreOrderInfo": //删除红包订单
                            try
                            {
                                ScoreOrderInfo_Action.DeleteProductNew(strDelid);
                                ScoreOrderInfo_Action.Delete(strDelid);
                                context.Response.Write("ok");
                            }
                            catch (Exception ex)
                            {
                            }

                            break;
                        case "ZtcApply": //删除直通车申请
                            ZtcApply_Action.Delete(strDelid);
                            context.Response.Write("ok");
                            break;
                        case "ZtcGoods": //删除直通车商品
                            ZtcGoods_Action.Delete(strDelid);
                            context.Response.Write("ok");
                            break;
                        case "Shop_NewsCategory": //删除资讯分类
                            NewsCategory_Action.DeleteNewsCategory(strDelid);
                            context.Response.Write("ok");
                            break;
                        case "Shop_VideoCategory": //删除视频分类
                            VideoCategory_Action.DeleteVideoCategory(strDelid);
                            context.Response.Write("ok");
                            break;
                        case "PaymentApplyLog": //删除充值
                            AdvancePaymentApplyLog_Action.Delete("'" + strDelid + "'");
                            context.Response.Write("ok");
                            break;

                        case "delpic": //删除图片
                            if (strDelid != "")
                            {
                                var listSpecValue = new List<ShopNum1_Shop_Image>();
                                var Image_Action = (Shop_Image_Action)LogicFactory.CreateShop_Image_Action();
                                string[] arryId = strDelid.Split(',');
                                string[] arryImg = ShopNum1.Common.Common.ReqStr("path").Split(',');
                                for (int i = 0; i < arryId.Length; i++)
                                {
                                    var si = new ShopNum1_Shop_Image();
                                    si.Id = Convert.ToInt32(arryId[i]);
                                    listSpecValue.Add(si);

                                    //string webFilePath = HttpContext.Current.Server.MapPath(arryImg[i].Replace("$path$", "ImgUpload"));
                                    //if (File.Exists(webFilePath))
                                    //{
                                    //    File.Delete(webFilePath); 
                                    //}
                                }
                                int x = Image_Action.DeleteSelectImg(listSpecValue);
                                if (x > 0)
                                {
                                    context.Response.Write("ok");
                                }
                                else
                                {
                                    context.Response.Write("error");
                                }
                            }
                            else
                            {
                                string webFilePath =
                                    HttpContext.Current.Server.MapPath(ShopNum1.Common.Common.ReqStr("path").Replace("-", "/"));
                                if (File.Exists(webFilePath))
                                {
                                    File.Delete(webFilePath);
                                    context.Response.Write("ok");
                                }
                            }
                            break;
                    }
                }
            }
            catch
            {
                context.Response.Write("error");
            }
        }


        public bool IsReusable
        {
            get { return false; }
        }

        public string DeleteSeoXml(string pages)
        {
            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            //会员登录ID
            string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
            string SetPath = string.Empty;
            var companyInfoAction = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
            DataTable dataTable = companyInfoAction.GetMemLoginInfo(MemberLoginID);
            string shopid = dataTable.Rows[0]["ShopID"].ToString();

            string OpenTime = DateTime.Parse(dataTable.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            SetPath = "~/Shop/Shop/" + OpenTime.Replace("-", "/") + "/shop" + shopid + "/xml/SetMeto.xml";

            IShopNum1_ExtendSiteMota_Action ExtendSiteMota =
                ShopNum1.Factory.LogicFactory.CreateShopNum1_ExtendSiteMota_Action();
            if (ExtendSiteMota.delete(pages, SetPath) > 0)
            {
                MessageBox.Show("删除成功！");
                return "ok";
            }
            return "error";
        }
    }
}