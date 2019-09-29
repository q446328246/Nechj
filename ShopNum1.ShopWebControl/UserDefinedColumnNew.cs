﻿using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class UserDefinedColumnNew : BaseWebControl
    {
        private Literal LiteralMenu;
        //private Literal Literallogo;
        private Repeater RepeaterShow;
        private string skinFilename = "UserDefinedColumn.ascx";
        private string string_1 = string.Empty;

        public UserDefinedColumnNew()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public int ShowCount { get; set; }

        public string ChangeIfOpen(string ifOpen)
        {
            if (ifOpen == "0")
            {
                return "_self";
            }
            return "_blank";
        }

        public string GetUrl()
        {
            DataTable shopIDByMemLoginID =
                LogicFactory.CreateShopNum1_ShopInfoList_Action().GetShopIDByMemLoginID(MemLoginID);
            string str = string.Empty;
            string str2 = string.Empty;
            if (shopIDByMemLoginID.Rows.Count > 0)
            {
                str = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
                str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
            }
            return ("http://" + str + str2);
        }
        public static string GetUrl(object object_0, string ShopID, int category)
        {
            if (object_0.ToString().IndexOf("http://") != -1)
            {
                return object_0.ToString() + "?category=" + category;
            }
            ShopID = ShopID.ToLower().Replace(ShopSettings.GetValue("PersonShopUrl"), "");
            string shopURLByShopID =
                ((ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action()).GetShopURLByShopID(
                    ShopID);
            string str3 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf('.'));
            return ("http://" + shopURLByShopID + str3 + "/" +
                    object_0.ToString().Replace(".aspx", "").Replace(".html", "") +
                    (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName + "?category=" + category : ".aspx?category=" + category));
        }
       

        protected override void InitializeSkin(Control skin)
        {
            string_1 = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(string_1);
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
           // Literallogo = (Literal) skin.FindControl("Literallogo");
            LiteralMenu = (Literal) skin.FindControl("LiteralMenu");
            if (!Page.IsPostBack)
            {
            }
            BindData();
            method_1();
        }

        protected void BindData()
        {
            DataTable userDefinedColumnList =
                ((Shop_UserDefinedColumn_Action) ShopFactory.LogicFactory.CreateShop_UserDefinedColumn_Action())
                    .GetUserDefinedColumnList(MemLoginID, "1");
            var builder = new StringBuilder();
            builder.Append("<ul>");
            string str = Page.Request.RawUrl.ToLower();
            for (int i = 0; i < userDefinedColumnList.Rows.Count; i++)
            {
                if (i < userDefinedColumnList.Rows.Count)
                {
                    string url = GetUrl(userDefinedColumnList.Rows[i]["LinkAddress"], string_1, Convert.ToInt32(CookieCustomerCategory));
                    string str4 = userDefinedColumnList.Rows[i]["Name"].ToString();
                    string str3 = ChangeIfOpen(userDefinedColumnList.Rows[i]["IfOpen"].ToString());
                    if (str == "/default.aspx")
                    {
                        str = "/default";
                    }
                    if (url.IndexOf("?") != -1)
                    {
                        if (url.ToLower().IndexOf(str) != -1)
                        {
                            builder.Append(
                                string.Concat(new object[]
                                {
                                    "<li> <a id=\"stab_", i, "\"  class=\"cur\" href=\"", url, "&select=", i,
                                    "&tab\" target=\"", str3, "\" >", str4, "</a></li>"
                                }));
                        }
                        else
                        {
                            builder.Append(
                                string.Concat(new object[]
                                {
                                    "<li ><a id=\"stab_", i, "\" href=\"", url, "&select=", i, "&tab\" target=\"",
                                    str3
                                    , "\" >", str4, "</a></li>"
                                }));
                        }
                    }
                    else if (url.ToLower().IndexOf(str) != -1)
                    {
                        builder.Append(
                            string.Concat(new object[]
                            {
                                "<li> <a id=\"stab_", i, "\"  class=\"cur\" href=\"", url, "&select=", i,
                                "&tab\" target=\"", str3, "\" >", str4, "</a></li>"
                            }));
                    }
                    else
                    {
                        builder.Append(
                            string.Concat(new object[]
                            {
                                "<li ><a id=\"stab_", i, "\" href=\"", url, "&select=", i, "&tab\" target=\"", str3,
                                "\" >", str4, "</a></li>"
                            }));
                    }
                }
            }
            builder.Append("</ul>");
            LiteralMenu.Text = builder.ToString();
        }

        protected void method_1()
        {
            DataTable memLoginInfo =
                ((Shop_ShopInfo_Action) ShopFactory.LogicFactory.CreateShop_ShopInfo_Action()).GetMemLoginInfo(
                    MemLoginID);
            if (memLoginInfo.Rows.Count > 0)
            {
                string str = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                string str2 = str.Split(new[] {'-'})[0];
                string str3 = str.Split(new[] {'-'})[1];
                string str4 = str.Split(new[] {'-'})[2];
                new XmlDataSource();
                string path = "~/Shop/Shop/" + str2 + "/" + str3 + "/" + str4 + "/" +
                              ShopSettings.GetValue("PersonShopUrl") + string_1 + "/Site_Settings.xml";
                var set = new DataSet();
                set.ReadXml(Page.Server.MapPath(path));
                DataRow row = set.Tables["Setting"].Rows[0];
               // Literallogo.Text = "<a href=\"" + GetUrl() + "\" target=\"_blank\"><img id=\"ImageOriginalImge\" src=\"" +
                                //   row["ShopScroll"].ToString().Replace("~", "") + "\"/></a>";
            }
        }

        public DataTable Top(DataTable dt, int count)
        {
            int num3 = (dt.Rows.Count > count) ? count : dt.Rows.Count;
            DataTable table = dt.Clone();
            for (int i = 0; i < num3; i++)
            {
                DataRow row = table.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    row[j] = dt.Rows[i][j].ToString();
                }
                table.Rows.Add(row);
            }
            return table;
        }
    }
}