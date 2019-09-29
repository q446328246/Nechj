using System.Text;
using System.Web;

namespace ShopNum1.Common
{
    public class PageListBll
    {
        private readonly string pageLink;

        public PageListBll()
        {
            PageName = "?PageID={0}";
            pageLink = "";
            FirstPageText = "<<";
            PrevPageText = "<上一页";
            NextPageText = "下一页>";
            LastPageText = ">>";
            NumericButtonCount = 10;
            ShowNoRecordInfo = true;
            ShowPageIndex = true;
            ShowPageCount = true;
            ShowRecordCount = true;
            ShowPageListButton = true;
            ShowNumListButton = true;
            for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
            {
                if (HttpContext.Current.Request.Params.Keys[i].ToLower() != "pageid")
                {
                    //string pageLink = this.pageLink;
                    pageLink = pageLink + HttpContext.Current.Request.Params.Keys[i] + "=" +
                               HttpUtility.UrlEncode(
                                   HttpContext.Current.Request.Params[HttpContext.Current.Request.Params.Keys[i]]) +
                               "&";
                }
            }
            PageName = "?" + pageLink + "PageID={0}";
        }

        public PageListBll(string pname, bool isHttpPost)
        {
            PageName = "?PageID={0}";
            pageLink = "";
            FirstPageText = "<<";
            PrevPageText = "<上一页";
            NextPageText = "下一页>";
            LastPageText = ">>";
            NumericButtonCount = 10;
            ShowNoRecordInfo = true;
            ShowPageIndex = true;
            ShowPageCount = true;
            ShowRecordCount = true;
            ShowPageListButton = true;
            ShowNumListButton = true;
            string str = string.Empty;
            if (pname.IndexOf(".aspx") != -1)
            {
                str = "http://" + HttpContext.Current.Request.Url.Host + "/" + pname;
            }
            else
            {
                str = "http://" + HttpContext.Current.Request.Url.Host + "/" + pname +
                      (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx");
            }
            for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
            {
                if (HttpContext.Current.Request.QueryString.AllKeys[i] != "category")
                {
                    if (((HttpContext.Current.Request.Params.Keys[i] != null) &&
                         ((HttpContext.Current.Request.Params.Keys[i].ToLower() != "pageid") &&
                          (HttpContext.Current.Request.Params.Keys[i].ToLower() != "shopid")
                          )) &&
                        (HttpContext.Current.Request.Params[HttpContext.Current.Request.Params.Keys[i]] != null))
                    {
                        //string pageLink = this.pageLink;
                        pageLink = pageLink + HttpContext.Current.Request.Params.Keys[i] + "=" +
                                   HttpUtility.UrlEncode(
                                       HttpContext.Current.Request.Params[HttpContext.Current.Request.Params.Keys[i]]) +
                                   "&";
                    }
                }
                else
                {
                    pageLink = pageLink + HttpContext.Current.Request.QueryString.AllKeys[i] + "=" +
                                   HttpUtility.UrlEncode(
                                       HttpContext.Current.Request.QueryString[i].ToString()) +
                                   "&";
                }

                //pageLink = "category=" + HttpContext.Current.Request.QueryString["category"];
            }
            if (isHttpPost)
            {
                PageName = str + "?" + pageLink + "&PageID={0}";
            }
            else
            {
                PageName = "?" + pageLink + "&PageID={0}";
            }
        }

        public PageListBll(string pname, bool isHttpPost, string type)
        {
            PageName = "?PageID={0}";
            pageLink = "";
            FirstPageText = "<<";
            PrevPageText = "<上一页";
            NextPageText = "下一页>";
            LastPageText = ">>";
            NumericButtonCount = 10;
            ShowNoRecordInfo = true;
            ShowPageIndex = true;
            ShowPageCount = true;
            ShowRecordCount = true;
            ShowPageListButton = true;
            ShowNumListButton = true;
            string str = string.Empty;
            if (type == "1")
            {
                str = "http://" + HttpContext.Current.Request.Url.Host + "/" + pname +
                      (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx");
            }
            if (type == "2")
            {
                str = "http://" + HttpContext.Current.Request.Url.Host + "/" + pname + ".aspx";
            }
            for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
            {
                if (((HttpContext.Current.Request.Params.Keys[i] != null) &&
                     ((HttpContext.Current.Request.Params.Keys[i].ToLower() != "pageid") &&
                      (HttpContext.Current.Request.Params.Keys[i].ToLower() != "shopid"))) &&
                    (HttpContext.Current.Request.Params[HttpContext.Current.Request.Params.Keys[i]] != null))
                {
                    //string pageLink = this.pageLink;
                    pageLink = pageLink + HttpContext.Current.Request.Params.Keys[i] + "=" +
                               HttpUtility.UrlEncode(
                                   HttpContext.Current.Request.Params[HttpContext.Current.Request.Params.Keys[i]]) +
                               "&";
                }
            }
            if (isHttpPost)
            {
                PageName = str + "?" + pageLink + "PageID={0}";
            }
            else
            {
                PageName = "?" + pageLink + "PageID={0}";
            }
        }

        public string FirstPageText { get; set; }

        public string LastPageText { get; set; }

        public string NextPageText { get; set; }

        public int NumericButtonCount { get; set; }

        public string PageName { get; set; }

        public string PrevPageText { get; set; }

        public bool ShowNoRecordInfo { get; set; }

        public bool ShowNumListButton { get; set; }

        public bool ShowPageCount { get; set; }

        public bool ShowPageIndex { get; set; }

        public bool ShowPageListButton { get; set; }

        public bool ShowRecordCount { get; set; }

        public string GetPageList(PageList1 pl)
        {
            int num;
            var builder = new StringBuilder("");
            if (pl.RecordCount == 0)
            {
                if (ShowNoRecordInfo)
                {
                    builder.Append("<div class=\"PageInfo\" align=\"left\">\r");
                    if (ShowPageIndex)
                    {
                        builder.Append("第<b>1</b>页&nbsp;");
                    }
                    if (ShowPageCount)
                    {
                        builder.Append("&nbsp;共<b>1</b>页");
                    }
                    if (ShowRecordCount)
                    {
                        builder.Append("&nbsp;&nbsp;Record <b>0</b>");
                    }
                    if (ShowPageListButton)
                    {
                        builder.Append(string.Format("&nbsp;&nbsp;&nbsp;&nbsp;{0}&nbsp;&nbsp;", FirstPageText));
                        builder.Append(string.Format("&nbsp;&nbsp;{0}&nbsp;&nbsp;", PrevPageText));
                        builder.Append(string.Format("&nbsp;&nbsp;{0}&nbsp;&nbsp;", NextPageText));
                        builder.Append(string.Format("&nbsp;&nbsp;{0}", LastPageText));
                    }
                    builder.Append("\r</div>");
                }
                return builder.ToString();
            }
            pl.PageCount = pl.RecordCount/pl.PageSize;
            if (pl.PageCount < ((pl.RecordCount)/((double) pl.PageSize)))
            {
                pl.PageCount++;
            }
            builder.Append("<div class=\"PageInfo\" align=\"left\">\r");
            if (ShowPageIndex)
            {
                if (pl.PageID == 0)
                {
                    num = pl.PageID + 1;
                    builder.Append("第<b>" + num.ToString() + "</b>页&nbsp;");
                }
                else
                {
                    builder.Append("第<b>" + pl.PageID.ToString() + "</b>页&nbsp;");
                }
            }
            if (ShowPageCount)
            {
                builder.Append("&nbsp;共<b>" + pl.PageCount + "</b>页");
            }
            if (ShowRecordCount)
            {
                builder.Append("&nbsp;&nbsp;共<b>" + pl.RecordCount.ToString() + "</b>条数据");
            }
            if (ShowPageListButton)
            {
                if (pl.PageID == 1)
                {
                    builder.Append(string.Format("&nbsp;&nbsp;&nbsp;&nbsp;{0}&nbsp;", FirstPageText));
                }
                else
                {
                    builder.Append(
                        string.Format(
                            "&nbsp;&nbsp;&nbsp;&nbsp;<a  onclick='PageClick(" + 1 +
                            ")' href=\"javascript:void(0)\">{0}</a>&nbsp;", FirstPageText));
                }
                if (pl.PageID == 1)
                {
                    builder.Append(string.Format("&nbsp;{0}&nbsp;", PrevPageText));
                }
                else
                {
                    num = pl.PageID - 1;
                    builder.Append(
                        string.Format(
                            "&nbsp;<a  onclick='PageClick(" + num.ToString() +
                            ")' href=\"javascript:void(0)\">{0}</a>&nbsp;", PrevPageText));
                }
            }
            if (ShowNumListButton)
            {
                builder.Append("&nbsp;&nbsp;<span class=\"PageNumButton\"> ");
                int num2 = pl.PageID - (NumericButtonCount/2);
                if (num2 < 1)
                {
                    num2 = 1;
                }
                for (int i = num2; i < (num2 + NumericButtonCount); i++)
                {
                    if (i > pl.PageCount)
                    {
                        break;
                    }
                    if (i == pl.PageID)
                    {
                        builder.Append("&nbsp;<label class=\"PageIndex\">" + i.ToString() + "</label>&nbsp;");
                    }
                    else
                    {
                        builder.Append(
                            string.Concat(new object[]
                                {
                                    "&nbsp;<a  onclick='PageClick(", i, ")' href=\"javascript:void(0)\">", i.ToString(),
                                    "</a>&nbsp;"
                                }));
                    }
                }
                builder.Append("</span>");
            }
            if (ShowPageListButton)
            {
                if (pl.PageID == pl.PageCount)
                {
                    builder.Append(string.Format("&nbsp;{0}&nbsp;", NextPageText));
                }
                else
                {
                    num = pl.PageID + 1;
                    builder.Append(
                        string.Format(
                            "&nbsp;<a onclick='PageClick(" + num.ToString() +
                            ")' href=\"javascript:void(0)\">{0}</a>&nbsp;", NextPageText));
                }
                if (pl.PageID == pl.PageCount)
                {
                    builder.Append(string.Format("&nbsp;{0}", LastPageText));
                }
                else
                {
                    builder.Append(
                        string.Format(
                            "&nbsp;<a  onclick='PageClick(" + pl.PageCount.ToString() +
                            ")' href=\"javascript:void(0)\">{0}</a>", LastPageText));
                }
            }
            builder.Append("\r<input id=\"pageid\" name=\"pageid\" value=\"0\" type=\"hidden\" />");
            builder.Append("\r</div>");
            return builder.ToString();
        }

        public string GetPageListNew(PageList1 pl)
        {
            int num2;
            var builder = new StringBuilder();
            builder.Append("<span class=\"page_1\">");
            pl.PageCount = pl.RecordCount/pl.PageSize;
            if ((pl.RecordCount == 0) || (pl.PageCount == 0))
            {
                return "";
            }
            if (pl.PageCount < ((pl.RecordCount)/((double) pl.PageSize)))
            {
                pl.PageCount++;
            }
            if (pl.PageID < 0)
            {
                pl.PageID = 0;
            }
            if (pl.PageID > pl.PageCount)
            {
                pl.PageID = pl.PageCount;
            }
            if (pl.PageID != 1)
            {
                builder.Append(
                    string.Format("<a  class=\"afy1\" href=\"" + string.Format(PageName, pl.PageID - 1) + "\">{0}</a>",
                                  "<img src=\"images/fyxiangmu_l.gif\" width=\"6\" height=\"9\"  border=\"0\"/>"));
            }
            int num = 1;
            if (pl.PageCount < 5)
            {
                for (num2 = num; num2 <= pl.PageCount; num2++)
                {
                    if (num2 == pl.PageID)
                    {
                        builder.Append("<a class=\"afy011\" href=\"javascript:void(0)\">" + num2.ToString() + "</a>");
                    }
                    else
                    {
                        builder.Append("<a href=\"" + string.Format(PageName, num2) + "\" class=\"afy\">" +
                                       num2.ToString() + "</a>");
                    }
                }
            }
            else if (pl.PageID < 5)
            {
                int num3 = pl.PageID + 2;
                if (num3 > (pl.PageCount - 1))
                {
                    num3 = pl.PageCount - 1;
                }
                for (num2 = num; num2 <= num3; num2++)
                {
                    if (num2 == pl.PageID)
                    {
                        builder.Append("<a href=\"javascript:void(0)\" class=\"afy011\">" + num2.ToString() + "</a>");
                    }
                    else
                    {
                        builder.Append("<a href=\"" + string.Format(PageName, num2) + "\" class=\"afy\">" +
                                       num2.ToString() + "</a>");
                    }
                }
                builder.Append("<span  class=\"diandian\">...</span>");
                builder.Append(
                    string.Concat(new object[]
                        {"<a href=\"", string.Format(PageName, pl.PageCount), "\" class=\"afy\">", pl.PageCount, "</a>"}));
            }
            else
            {
                int num4;
                builder.Append(
                    string.Concat(new object[]
                        {"<a href=\"", string.Format(PageName, 1), "\" class=\"afy\">", 1, "</a>"}));
                builder.Append("<span class=\"diandian\">...</span>");
                if (pl.PageID > pl.PageCount)
                {
                    pl.PageID = pl.PageCount;
                }
                if ((pl.PageID + 3) > pl.PageCount)
                {
                    for (num4 = pl.PageID - 2; num4 <= pl.PageCount; num4++)
                    {
                        if (num4 == pl.PageID)
                        {
                            builder.Append("<a  href=\"javascript:void(0)\" class=\"afy011\">" + num4.ToString() +
                                           "</a>");
                        }
                        else
                        {
                            builder.Append("<a href=\"" + string.Format(PageName, num4) + "\" class=\"afy\">" +
                                           num4.ToString() + "</a>");
                        }
                    }
                }
                else
                {
                    for (num4 = pl.PageID - 2; num4 <= (pl.PageID + 2); num4++)
                    {
                        if (num4 == pl.PageID)
                        {
                            builder.Append("<a class=\"afy011\" href=\"javascript:void(0)\" >" + num4.ToString() +
                                           "</a>");
                        }
                        else
                        {
                            builder.Append("<a href=\"" + string.Format(PageName, num4) + "\" class=\"afy\">" +
                                           num4.ToString() + "</a>");
                        }
                    }
                    builder.Append("<span  class=\"diandian\">...</span>");
                    builder.Append(
                        string.Concat(new object[]
                            {
                                "<a href=\"", string.Format(PageName, pl.PageCount), "\" class=\"afy\">", pl.PageCount,
                                "</a>"
                            }));
                }
            }
            if (pl.PageID != pl.PageCount)
            {
                builder.Append(
                    string.Format("<a class=\"afy1\" href=\"" + string.Format(PageName, pl.PageID + 1) + "\">{0}</a>",
                                  "<img src=\"images/fyxiangmu.gif\" width=\"6\" height=\"9\"  border=\"0\"/>"));
            }
            builder.Append("</span>");
            builder.Append(
                string.Concat(new object[]
                    {
                        "<span class=\"spanfy page_2\">&nbsp;共<b>", pl.PageCount,
                        "</b>页&nbsp;到第</span><span class=\"page_3\"><input type=\"text\" name=\"searchpage\" id=\"txtIndex\" class=\"xwb\" value=\""
                        , pl.PageID, "\" /></span><span class=\"page_4\"> 页 </span>"
                    }));
            builder.Append(
                "<span class=\"page_5\"><div class=\"qudbtn\"><a href=\"javascript:void(0)\" onclick=\"ontoPage(this)\"/>确定</a></div></span>");
            return builder.ToString();
        }

        public string GetPageListNew_two(PageList1 pl)
        {
            int num2;
            var builder = new StringBuilder();
            builder.Append("<span class=\"page_1\">");
            pl.PageCount = pl.RecordCount / pl.PageSize;
            if ((pl.RecordCount == 0) || (pl.PageCount == 0))
            {
                return "";
            }
            if (pl.PageCount < ((pl.RecordCount) / ((double)pl.PageSize)))
            {
                pl.PageCount++;
            }
            if (pl.PageID < 0)
            {
                pl.PageID = 0;
            }
            if (pl.PageID > pl.PageCount)
            {
                pl.PageID = pl.PageCount;
            }
            if (pl.PageID != 1)
            {
                builder.Append(
                    string.Format("<a  class=\"afy1\" href=\"" + string.Format(PageName, pl.PageID - 1) + "\">{0}</a>",
                                  "<img src=\"images/fyxiangmu_l.gif\" width=\"6\" height=\"9\"  border=\"0\"/>"));
            }
            int num = 1;
            if (pl.PageCount < 5)
            {
                for (num2 = num; num2 <= pl.PageCount; num2++)
                {
                    if (num2 == pl.PageID)
                    {
                       
                        builder.Append("<a href=\"" + string.Format(PageName, num2) + "\" class=\"afy011\">" +
                                       num2.ToString() + "</a>");
                    }
                    else
                    {
                        builder.Append("<a href=\"" + string.Format(PageName, num2) + "\" class=\"afy\">" +
                                       num2.ToString() + "</a>");
                    }
                }
            }
            else if (pl.PageID < 5)
            {
                int num3 = pl.PageID + 2;
                if (num3 > (pl.PageCount - 1))
                {
                    num3 = pl.PageCount - 1;
                }
                for (num2 = num; num2 <= num3; num2++)
                {
                    if (num2 == pl.PageID)
                    {
                        
                        builder.Append("<a href=\"" + string.Format(PageName, num2) + "\" class=\"afy011\">" +
                                       num2.ToString() + "</a>");
                    }
                    else
                    {
                        builder.Append("<a href=\"" + string.Format(PageName, num2) + "\" class=\"afy\">" +
                                       num2.ToString() + "</a>");
                    }
                }
                builder.Append("<span  class=\"diandian\">...</span>");
                builder.Append(
                    string.Concat(new object[] { "<a href=\"", string.Format(PageName, pl.PageCount), "\" class=\"afy\">", pl.PageCount, "</a>" }));
            }
            else
            {
                int num4;
                builder.Append(
                    string.Concat(new object[] { "<a href=\"", string.Format(PageName, 1), "\" class=\"afy\">", 1, "</a>" }));
                builder.Append("<span class=\"diandian\">...</span>");
                if (pl.PageID > pl.PageCount)
                {
                    pl.PageID = pl.PageCount;
                }
                if ((pl.PageID + 3) > pl.PageCount)
                {
                    for (num4 = pl.PageID - 2; num4 <= pl.PageCount; num4++)
                    {
                        if (num4 == pl.PageID)
                        {
                            
                            builder.Append("<a href=\"" + string.Format(PageName, num4) + "\" class=\"afy011\">" +
                                          num4.ToString() + "</a>");
                        }
                        else
                        {
                            builder.Append("<a href=\"" + string.Format(PageName, num4) + "\" class=\"afy\">" +
                                           num4.ToString() + "</a>");
                        }
                    }
                }
                else
                {
                    for (num4 = pl.PageID - 2; num4 <= (pl.PageID + 2); num4++)
                    {
                        if (num4 == pl.PageID)
                        {
                           
                            builder.Append("<a href=\"" + string.Format(PageName, num4) + "\" class=\"afy011\">" +
                                           num4.ToString() + "</a>");
                        }
                        else
                        {
                            builder.Append("<a href=\"" + string.Format(PageName, num4) + "\" class=\"afy\">" +
                                           num4.ToString() + "</a>");
                        }
                    }
                    builder.Append("<span  class=\"diandian\">...</span>");
                    builder.Append(
                        string.Concat(new object[]
                            {
                                "<a href=\"", string.Format(PageName, pl.PageCount), "\" class=\"afy\">", pl.PageCount,
                                "</a>"
                            }));
                }
            }
            if (pl.PageID != pl.PageCount)
            {
                builder.Append(
                    string.Format("<a class=\"afy1\" href=\"" + string.Format(PageName, pl.PageID + 1) + "\">{0}</a>",
                                  "<img src=\"images/fyxiangmu.gif\" width=\"6\" height=\"9\"  border=\"0\"/>"));
            }
            builder.Append("</span>");
            builder.Append(
                string.Concat(new object[]
                    {
                        "<span class=\"spanfy page_2\">&nbsp;共<b>", pl.PageCount,
                        "</b>页&nbsp;到第</span><span class=\"page_3\"><input type=\"text\" name=\"searchpage\" id=\"txtIndex\" class=\"xwb\" value=\""
                        , pl.PageID, "\" /></span><span class=\"page_4\"> 页 </span>"
                    }));
            builder.Append(
                "<span class=\"page_5\"><div class=\"qudbtn\"><a href=\"javascript:void(0)\" onclick=\"ontoPage(this)\"/>确定</a></div></span>");
            return builder.ToString();
        }

        public string GetPageListNewManage(PageList1 pl2)
        {
            int num3;
            var builder = new StringBuilder();
            pl2.PageCount = pl2.RecordCount/pl2.PageSize;
            if ((pl2.RecordCount == 0) || (pl2.PageCount == 0))
            {
                return "";
            }
            if (pl2.PageCount < ((pl2.RecordCount)/((double) pl2.PageSize)))
            {
                pl2.PageCount++;
            }
            if (pl2.PageID < 0)
            {
                pl2.PageID = 0;
            }
            if (pl2.PageID > pl2.PageCount)
            {
                pl2.PageID = pl2.PageCount;
            }
            builder.Append("<span style=\"padding-right: 10px;\">第<font>" + pl2.PageID + "</font>页&nbsp;&nbsp;");
            if (pl2.PageID == pl2.PageCount)
            {
                builder.Append("当前页共<font>" + ((pl2.RecordCount - ((pl2.PageID - 1)*pl2.PageSize))).ToString() +
                               "</font>条数据");
            }
            else
            {
                builder.Append("当前页共<font>" + pl2.PageSize + "</font>条数据");
            }
            builder.Append("&nbsp;&nbsp;共<font class=\"pagecount\">" + pl2.PageCount + "</font>页</span>");
            if (pl2.PageID != 1)
            {
                builder.Append(
                    string.Format(
                        "<a  style=\"text-decoration:none;\" href=\"" + string.Format(PageName, 1) + "\">{0}</a>", "<<"));
                builder.Append(
                    string.Format(
                        "<a  class=\"gred_prev\" style=\"text-decoration:none;\" href=\"" +
                        string.Format(PageName, pl2.PageID - 1) + "\">{0}</a>", "<<上一页"));
            }
            int num2 = 1;
            if (pl2.PageCount < 5)
            {
                for (num3 = num2; num3 <= pl2.PageCount; num3++)
                {
                    if (num3 == pl2.PageID)
                    {
                        builder.Append("<span class=\"cur\">" + num3.ToString() + "</span>");
                    }
                    else
                    {
                        builder.Append("<a href=\"" + string.Format(PageName, num3) + "\">" + num3.ToString() + "</a>");
                    }
                }
            }
            else if (pl2.PageID < 5)
            {
                int num4 = pl2.PageID + 2;
                if (num4 > (pl2.PageCount - 1))
                {
                    num4 = pl2.PageCount - 1;
                }
                for (num3 = num2; num3 <= num4; num3++)
                {
                    if (num3 == pl2.PageID)
                    {
                        builder.Append("<span class=\"cur\">" + num3.ToString() + "</span>");
                    }
                    else
                    {
                        builder.Append("<a href=\"" + string.Format(PageName, num3) + "\">" + num3.ToString() + "</a>");
                    }
                }
                builder.Append("<span  class=\"diandian\">...</span>");
            }
            else
            {
                int num5;
                builder.Append("<span  class=\"diandian\">...</span>");
                if (pl2.PageID > pl2.PageCount)
                {
                    pl2.PageID = pl2.PageCount;
                }
                if ((pl2.PageID + 3) > pl2.PageCount)
                {
                    for (num5 = pl2.PageID - 2; num5 <= pl2.PageCount; num5++)
                    {
                        if (num5 == pl2.PageID)
                        {
                            builder.Append("<span class=\"cur\">" + num5.ToString() + "</span>");
                        }
                        else
                        {
                            builder.Append("<a href=\"" + string.Format(PageName, num5) + "\">" + num5.ToString() +
                                           "</a>");
                        }
                    }
                }
                else
                {
                    for (num5 = pl2.PageID - 2; num5 <= (pl2.PageID + 2); num5++)
                    {
                        if (num5 == pl2.PageID)
                        {
                            builder.Append("<a class=\"cur\" href=\"javascript:void(0)\" >" + num5.ToString() + "</a>");
                        }
                        else
                        {
                            builder.Append("<a href=\"" + string.Format(PageName, num5) + "\">" + num5.ToString() +
                                           "</a>");
                        }
                    }
                    builder.Append("<span  class=\"diandian\">...</span>");
                }
            }
            if (pl2.PageID != pl2.PageCount)
            {
                builder.Append(
                    string.Format(
                        "<a class=\"gred_prev\" href=\"" + string.Format(PageName, pl2.PageID + 1) + "\">{0}</a>",
                        "下一页>>"));
                builder.Append(string.Format("<a href=\"" + string.Format(PageName, pl2.PageCount) + "\">{0}</a>", ">>"));
            }
            builder.Append(
                "到第<input type=\"text\" style=\"width:35px;\" onkeyup=\"NumTxt_Int(this)\" name=\"vjpage\" value=\"" +
                pl2.PageID + "\">页<input class=\"quedbtn\" type=\"button\" value=\"确定\" name=\"surepage\">");
            return builder.ToString();
        }

        public string GetPageListNextPrev(PageList1 pl)
        {
            var builder = new StringBuilder();
            builder.Append("<span class=\"page_2\">");
            pl.PageCount = pl.RecordCount/pl.PageSize;
            if ((pl.RecordCount == 0) || (pl.PageCount == 0))
            {
                return "";
            }
            if (pl.PageCount < ((pl.RecordCount)/((double) pl.PageSize)))
            {
                pl.PageCount++;
            }
            if (pl.PageID < 0)
            {
                pl.PageID = 0;
            }
            if (pl.PageID > pl.PageCount)
            {
                pl.PageID = pl.PageCount;
            }
            if (pl.PageID != 1)
            {
                builder.Append(string.Format("<a  class=\"afy1\" href=\"" + string.Format(PageName, 1) + "\">{0}</a>",
                                             "首页"));
                builder.Append(
                    string.Format("<a  class=\"afy1\" href=\"" + string.Format(PageName, pl.PageID - 1) + "\">{0}</a>",
                                  "上一页"));
            }
            if ((pl.PageID != pl.PageCount) && (pl.PageID != 1))
            {
                builder.Append(
                    string.Format("<a  class=\"afy1\" href=\"" + string.Format(PageName, pl.PageID - 1) + "\">{0}</a>",
                                  "下一页"));
                builder.Append(
                    string.Format("<a  class=\"afy1\" href=\"" + string.Format(PageName, pl.PageCount) + "\">{0}</a>",
                                  "末页"));
            }
            builder.Append("</span>");
            return builder.ToString();
        }

        public string GetPageListVk(PageList1 pl)
        {
            var builder = new StringBuilder("");
            if (pl.RecordCount == 0)
            {
                if (ShowNoRecordInfo)
                {
                    builder.Append("<div class=\"black2\">\r");
                    if (ShowPageListButton)
                    {
                        builder.Append(" <span class=\"disabled\">< </span>");
                        builder.Append("<span class=\"current\">0</span>");
                        builder.Append(" <span class=\"disabled\"> > </span>");
                    }
                    builder.Append("\r</div>");
                }
                return builder.ToString();
            }
            pl.PageCount = pl.RecordCount/pl.PageSize;
            if (pl.PageCount < ((pl.RecordCount)/((double) pl.PageSize)))
            {
                pl.PageCount++;
            }
            builder.Append("<div class=\"black2\">\r");
            if (ShowPageIndex)
            {
                builder.Append("第<b>" + pl.PageID.ToString() + "</b>页&nbsp;");
            }
            if (ShowPageCount)
            {
                builder.Append("&nbsp;共<b>" + pl.PageCount + "</b>页");
            }
            if (ShowRecordCount)
            {
                builder.Append("&nbsp;&nbsp;共<b>" + pl.RecordCount.ToString() + "</b>条数据");
            }
            if (pl.PageID < 0)
            {
                pl.PageID = 0;
            }
            if (pl.PageID > pl.PageCount)
            {
                pl.PageID = pl.PageCount;
            }
            if (ShowPageListButton)
            {
                if (pl.PageID == 1)
                {
                    builder.Append("<span class=\"disabled\">" + PrevPageText + "</span>");
                }
                else
                {
                    builder.Append(
                        string.Format(
                            "<a  class=\"PrevPage\" href=\"" + string.Format(PageName, pl.PageID - 1) + "\">{0}</a>",
                            PrevPageText));
                }
            }
            if (ShowNumListButton)
            {
                int num3;
                int num2 = 1;
                if (pl.PageCount < 5)
                {
                    for (num3 = num2; num3 <= pl.PageCount; num3++)
                    {
                        if (num3 == pl.PageID)
                        {
                            builder.Append("<span class=\"current\">" + num3.ToString() + "</span>");
                        }
                        else
                        {
                            builder.Append("<a href=\"" + string.Format(PageName, num3) + "\">" + num3.ToString() +
                                           "</a>");
                        }
                    }
                }
                else if (pl.PageID < 5)
                {
                    int num4 = pl.PageID + 2;
                    if (num4 > (pl.PageCount - 1))
                    {
                        num4 = pl.PageCount - 1;
                    }
                    for (num3 = num2; num3 <= num4; num3++)
                    {
                        if (num3 == pl.PageID)
                        {
                            builder.Append("<span class=\"current\">" + num3.ToString() + "</span>");
                        }
                        else
                        {
                            builder.Append("<a href=\"" + string.Format(PageName, num3) + "\">" + num3.ToString() +
                                           "</a>");
                        }
                    }
                    builder.Append("<span class=\"diandian\">...</span>");
                    builder.Append(
                        string.Concat(new object[]
                            {"<a href=\"", string.Format(PageName, pl.PageCount), "\">", pl.PageCount, "</a>"}));
                }
                else
                {
                    int num5;
                    builder.Append(
                        string.Concat(new object[] {"<a href=\"", string.Format(PageName, 1), "\">", 1, "</a>"}));
                    builder.Append("<span class=\"diandian\">...</span>");
                    if (pl.PageID > pl.PageCount)
                    {
                        pl.PageID = pl.PageCount;
                    }
                    if ((pl.PageID + 3) > pl.PageCount)
                    {
                        for (num5 = pl.PageID - 2; num5 <= pl.PageCount; num5++)
                        {
                            if (num5 == pl.PageID)
                            {
                                builder.Append("<span class=\"current\">" + num5.ToString() + "</span>");
                            }
                            else
                            {
                                builder.Append("<a href=\"" + string.Format(PageName, num5) + "\">" + num5.ToString() +
                                               "</a>");
                            }
                        }
                    }
                    else
                    {
                        for (num5 = pl.PageID - 2; num5 <= (pl.PageID + 2); num5++)
                        {
                            if (num5 == pl.PageID)
                            {
                                builder.Append("<span class=\"current\">" + num5.ToString() + "</span>");
                            }
                            else
                            {
                                builder.Append("<a href=\"" + string.Format(PageName, num5) + "\">" + num5.ToString() +
                                               "</a>");
                            }
                        }
                        builder.Append("<span  class=\"diandian\">...</span>");
                        builder.Append(
                            string.Concat(new object[]
                                {"<a href=\"", string.Format(PageName, pl.PageCount), "\">", pl.PageCount, "</a>"}));
                    }
                }
            }
            if (ShowPageListButton)
            {
                if (pl.PageID == pl.PageCount)
                {
                    builder.Append("<span class=\"disabled\">" + NextPageText + "</span>");
                }
                else
                {
                    builder.Append(
                        string.Format(
                            "<a class=\"nextpage\" href=\"" + string.Format(PageName, pl.PageID + 1) + "\">{0}</a>",
                            NextPageText));
                }
            }
            builder.Append("\r</div>");
            return builder.ToString();
        }
    }
}