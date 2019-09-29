using System;
using System.Data;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

//using System.Web.HttpContext;


namespace ShopNum1.Deploy.Main.Api
{
    /// <summary>
    /// Address 的摘要说明
    /// </summary>
    public class Address : IHttpHandler
    {

        private static readonly ShopNum1.Interface.IShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action =
                LogicFactory.CreateShopNum1_ShopInfoList_Action();

        private readonly ShopNum1_DispatchRegion_Action dispatchRegion_Action =
            (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();

        private string type;

        public void ProcessRequest(HttpContext context)
        {
            type = context.Request["type"];
            if (type == null)
            {
                return;
            }
            switch (type.ToLower().Trim())
            {
                //查询城市 SearchCity.
                case "searchcity":
                    string shengid = context.Request["shengid"].Trim();
                    context.Response.Write(Search(shengid, 0));
                    break;
                //查询区域 SearchArea.
                case "searcharea":

                    string cityid = context.Request["cityid"].Trim();
                    context.Response.Write(Search(cityid, 1));
                    break;

                //查询区域 SearchArea.
                case "searcharea1":

                    string cityid1 = context.Request["cityid"].Trim();
                    context.Response.Write(SearchArea(cityid1));
                    break;

                //查询区域 addresscode.
                case "addresscode":

                    string addresscode = context.Request["addresscode"].Trim();
                    context.Response.Write(SearchShopUrl(addresscode));
                    break;
                default:
                    break;
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }


        /// <summary>
        ///   查询
        /// </summary>
        /// <param name="ShengID"></param>
        /// <param name="type">0:获取城市 1：获取地区</param>
        /// <returns></returns>
        private string Search(string ShengID, int type)
        {
            string all_data = string.Empty;
            //获取数据
            dispatchRegion_Action.TableName = "ShopNum1_DispatchRegion";
            DataTable dataTable = dispatchRegion_Action.SearchtDispatchRegion(Convert.ToInt32(ShengID), 0);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                    if (type == 0)
                    {
                        all_data +=
                            "<li><div id=\"AllArea\" onmouseleave=\"city2_hidden(this)\"  ><span style=\"height:30px; line-height:30px;\" onmouseover=\"city2_show(this)\" cityid='" +
                            dataTable.Rows[j]["ID"] + "'>" + dataTable.Rows[j]["Name"] +
                            "</span><div id=\"DivArea\" class=\"hidden\"><div class=\"prefecture\"><ul class=\"san clearfix\" id='area" +
                            dataTable.Rows[j]["ID"] + "'></ul></div> </div></div></li>";
                    }
                    else if (type == 1)
                    {
                        all_data += "<li><a href='" + ShopUrlOperate.GetDeShopUrl(dataTable.Rows[j]["Code"].ToString()) +
                                    "'>" + dataTable.Rows[j]["Name"] + "</a> </li>";
                    }
                }

                //MessageBox.Show(all_data);

                return all_data;
            }
            else
            {
                return "";
            }
        }


        private string SearchArea(string CityID)
        {
            string all_data = string.Empty;
            //获取数据
            //dispatchRegion_Action.TableName = "ShopNum1_DispatchRegion";
            var city_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
            DataTable dataTable = city_Action.Search(Convert.ToInt32(CityID), 0);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                    all_data += "<li><a href='" + ShopUrlOperate.GetDeShopUrl(dataTable.Rows[j]["AddressCode"].ToString()) +
                                "'>" + dataTable.Rows[j]["CityName"] + "</a> </li>";
                }

                return all_data;
            }
            else
            {
                return "";
            }
        }

        private string SearchShopUrl(string addresscode)
        {
            string all_data = string.Empty;
            //获取数据
            var shopInfoList = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
            string shopurl = shopInfoList.GetShopURLByAddressCode(addresscode);
            string domain = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
            if (shopurl != null && shopurl != "")
            {
                all_data = "http://" + shopurl + domain;
                return all_data;
            }
            else
            {
                return "";
            }
        }
    }
}