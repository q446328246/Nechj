using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Api
{
    /// <summary>
    /// GetProductType 的摘要说明
    /// </summary>
    public class GetProductType : PageBase, IHttpHandler, IRequiresSessionState
    {

        new public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            var shopNum1_ProductCategory_Action =
                (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
            var shopNum1_ShopInfoList_Action =
                (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
            if (context.Request.QueryString["parentid"] != null)
            {
                //获取子栏目数据操作
                string strid = context.Request.QueryString["parentid"];
                DataTable dataTable = shopNum1_ProductCategory_Action.SearchtProductCategory(Convert.ToInt32(strid), 0);
                context.Response.Write(GetJson(dataTable));
            }
            else if (context.Request.QueryString["isshow"] != null)
            {
                //是否显示操作
                string strreq = context.Request.QueryString["isshow"];
                int i = shopNum1_ProductCategory_Action.UpdateIsshow(strreq.Split('-')[1], strreq.Split('-')[0]);
                context.Response.Write(i.ToString());
            }
            else if (context.Request.QueryString["vd"] != null)
            {
                //批量保存分类名称和排序编号操作
                string strreq = HttpUtility.HtmlDecode(context.Request.QueryString["vd"]);
                if (strreq.IndexOf(",") != -1)
                {
                    string[] str = strreq.Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        shopNum1_ProductCategory_Action.UpdateOrderName(str[i].Split('|')[1], str[i].Split('|')[2],
                                                                        str[i].Split('|')[0]);
                    }
                }
                else
                {
                    shopNum1_ProductCategory_Action.UpdateOrderName(strreq.Split('|')[1], strreq.Split('|')[2],
                                                                    strreq.Split('|')[0]);
                }
                context.Response.Write("ok");
            }
            else if (context.Request.QueryString["savedata"] != null)
            {
                //保存分类操作
                string strreq = HttpUtility.HtmlDecode(context.Request.QueryString["savedata"]);
                shopNum1_ProductCategory_Action.UpdateOrderName(strreq.Split('|')[0], strreq.Split('|')[2],
                                                                strreq.Split('|')[1]);
                context.Response.Write("ok");
            }
            else if (context.Request.QueryString["delectid"] != null)
            {
                //删除分类操作
                int vflag = -1; //当vflag等于0时，该分类可以删除；当vflag等于1时,该分类不能删除;当vflag等于2时,删除部分分类。

                var sbId = new StringBuilder();
                string strreq = context.Request.QueryString["delectid"];
                DataTable dataTable = shopNum1_ProductCategory_Action.SearchtTypeId(Convert.ToInt32(strreq), 0);
                //获取分类表相关的分类编号
                DataTable dt = shopNum1_ShopInfoList_Action.GetTypeCategoryId(); //获取店铺所有分类编号

                DataTable dt_three = null; //获取三级菜单
                if (shopNum1_ShopInfoList_Action.CheckType(strreq) == "")
                {
                    if (dataTable.Rows.Count == 0)
                    {
                        shopNum1_ProductCategory_Action.DeleteTypeC(strreq);
                        DeleteSpecification(strreq);
                        vflag = 0;
                    }
                    else
                    {
                        bool bvflag = true;
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            bool bflag = true;
                            dt_three =
                                shopNum1_ProductCategory_Action.SearchtTypeId(Convert.ToInt32(dataTable.Rows[i]["id"]), 0);
                            string strId = dataTable.Rows[i]["id"].ToString();
                            if (dt.Select("shopcategoryid='" + dataTable.Rows[i]["id"] + "'").Length == 0)
                            {
                                for (int j = 0; j < dt_three.Rows.Count; j++)
                                {
                                    if (dt.Select("shopcategoryid='" + dt_three.Rows[j]["id"] + "'").Length == 0)
                                    {
                                        DeleteSpecification(dt_three.Rows[j]["id"].ToString());
                                        shopNum1_ProductCategory_Action.DeleteTypeC(dt_three.Rows[j]["id"].ToString());
                                        sbId.Append(dt_three.Rows[j]["id"] + ",");
                                        vflag = 2;
                                    }
                                    else
                                    {
                                        bvflag = false;
                                        bflag = false;
                                    }
                                }
                            }
                            else
                            {
                                bflag = false;
                                bvflag = false;
                                //为何要执行这段    当该分类不能删除时要判断其子分类是否可以删除
                                for (int j = 0; j < dt_three.Rows.Count; j++)
                                {
                                    if (dt.Select("shopcategoryid='" + dt_three.Rows[j]["id"] + "'").Length == 0)
                                    {
                                        shopNum1_ProductCategory_Action.DeleteTypeC(dt_three.Rows[j]["id"].ToString());
                                        DeleteSpecification(dt_three.Rows[j]["id"].ToString());
                                        sbId.Append(dt_three.Rows[j]["id"] + ",");
                                        vflag = 2;
                                    }
                                }
                            }

                            if (bflag)
                            {
                                shopNum1_ProductCategory_Action.DeleteTypeC(dataTable.Rows[i]["id"].ToString());
                                DeleteSpecification(dataTable.Rows[i]["id"].ToString());
                                sbId.Append(dataTable.Rows[i]["id"] + ",");
                                vflag = 2;
                            }
                        }
                        if (bvflag)
                        {
                            shopNum1_ProductCategory_Action.DeleteTypeC(strreq);
                            vflag = 0;
                        }
                    }
                    HttpCookie cookie = context.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                    #region  操作日志部分

                    var operateLog = new ShopNum1_OperateLog();
                    operateLog.Record = "管理员删除商品分类";
                    operateLog.OperatorID = cookie2.Values["LoginID"].ToString();
                    operateLog.IP = Globals.IPAddress;
                    operateLog.PageName = "ShopNum1_ProductCategory_List.aspx";
                    operateLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    int log = OperateLog(operateLog);

                    #endregion
                }
                else
                {
                    vflag = 1;
                }
                if (vflag == 0)
                    context.Response.Write("ok|0");
                else if (vflag == 1)
                    context.Response.Write("deny|0");
                else
                    context.Response.Write("deny|" + sbId);
            }
        }

        new public bool IsReusable
        {
            get { return false; }
        }

        /// <summary>
        ///   删除产品规格
        /// </summary>
        private void DeleteSpecification(string strId)
        {
            var SpecificationProudctCategoryAction =
                (ShopNum1_SpecificationProudctCategory_Action)
                LogicFactory.CreateShopNum1_SpecificationProudctCategory_Action();
            SpecificationProudctCategoryAction.DeleteByProductCategoryID(strId);
        }

        /// <summary>
        ///   将datatable转换成json数组
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetJson(DataTable dt)
        {
            var sbJson = new StringBuilder();
            sbJson.Append("[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sbJson.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        sbJson.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + dt.Rows[i][j] + "\",");
                    }
                    sbJson.Remove(sbJson.Length - 1, 1);
                    sbJson.Append("},");
                }
            }
            sbJson.Remove(sbJson.Length - 1, 1);
            sbJson.Append("]");
            return sbJson.ToString();
        }
    }
}