using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Common;
using System.Data;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_ReplaceOrder : System.Web.UI.UserControl
    {
        
             
        public string pageid { get; set; }

        public string PageSize { get; set; }

        public string type { get; set; }
         public string MemberLoginID { get; set; }
         public string strgz { get; set; }

         protected void Btn_Select_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");

            type = (Common.Common.ReqStr("type") == "") ? "0" : Common.Common.ReqStr("type");

            string sd = HttpContext.Current.Request.QueryString["sd"];
            string ed = HttpContext.Current.Request.QueryString["ed"];
            if (type == "0")
            {
                if (sd != null && sd != "" ) 
                {
                    strgz = " and CreateTime>'" + sd + "' ";
                    if (ed != null && ed != "")
                    {
                        strgz = strgz + " and CreateTime<'" + ed + "' ";
                    }
                }
                
                BindData();
            }
        }

        protected void BindData()
        {
             HttpCookie cookie2 = Page.Request.Cookies["MemberLoginCookie"];
                    HttpCookie cookie3 = HttpSecureCookie.Decode(cookie2);
                MemberLoginID = cookie3.Values["MemLoginID"];
                ShopNum1_ScoreModifyLog_Action action = (ShopNum1_ScoreModifyLog_Action)LogicFactory.CreateShopNum1_ScoreModifyLog_Action();

            DataTable cccc = action.GetMemLoginNOBYMemLoginID(MemberLoginID);
            string memloginno = cccc.Rows[0]["MemLoginNO"].ToString();
            string str = string.Empty;
            if (!string.IsNullOrEmpty(strgz))
            {
                str = str + strgz;
            }
            str = str + "   AND  MemloginID='" + MemberLoginID + "'";
            var commonModel = new CommonPageModel
            {
                Condition = "   " + str + "",
                Currentpage = pageid,
                Resultnum = "0",
                PageSize = PageSize
            };
            DataTable table = action.Select_GPS_List(commonModel);
            var pl = new PageList1
            {
                PageSize = Convert.ToInt32(PageSize),
                PageID = Convert.ToInt32(pageid)
            };
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml = new PageListBll("main/member/M_ReplaceAll.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = null;
            table2 = action.Select_GPS_List(commonModel);
            DataTable dt2 = new DataTable();
            dt2 = table2.Copy();
            dt2.Rows.Clear();
            for (int i = 0; i < table2.Rows.Count; i++)
            {
            //    if (table2.Rows[i]["MemLoginIDGuid"].ToString().ToUpper() == "197B6B51-3EB3-452E-BD03-D560577A34D2")
            //    {
            //        DataTable table22 = action.SelectMberGUID(table2.Rows[i]["Superiorss"].ToString());
            //        if (table22.Rows[0]["MemberRankGuid"].ToString().ToUpper() == "A6DA75AD-E1AC-4DF8-99AD-980294A16581")
            //        {
                        
            //        }
            //        else
            //        {

            //            dt2.ImportRow(table2.Rows[i]);
            //        }
            //    }
            //    else
            //    {
            //        if (table2.Rows[i]["MemLoginIDGuid"].ToString().ToUpper() == "A6DA75AD-E1AC-4DF8-99AD-980294A16581")
            //        {
                        
            //        }
            //        else
            //        {
                dt2.ImportRow(table2.Rows[i]);
            //        }
            //    }
            }

            RepeaterShow.DataSource = dt2.DefaultView;
            RepeaterShow.DataBind();
        }

       
    
        }
    }

