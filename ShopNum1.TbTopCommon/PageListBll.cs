using System.Text;
using System.Web;

namespace ShopNum1.TbTopCommon
{
    public class PageListBll
    {
        private readonly string string_1;

        public PageListBll()
        {
            PageName = "?PageID={0}";
            string_1 = "";
            FirstPageText = "<<";
            PrevPageText = "<";
            NextPageText = ">";
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
                    string str = string_1;
                    string_1 = str + HttpContext.Current.Request.Params.Keys[i] + "=" +
                               HttpUtility.UrlEncode(
                                   HttpContext.Current.Request.Params[HttpContext.Current.Request.Params.Keys[i]]) + "&";
                }
            }
            PageName = "?" + string_1 + "PageID={0}";
        }

        public PageListBll(string pageHref)
        {
            PageName = "?PageID={0}";
            string_1 = "";
            FirstPageText = "<<";
            PrevPageText = "<";
            NextPageText = ">";
            LastPageText = ">>";
            NumericButtonCount = 10;
            ShowNoRecordInfo = true;
            ShowPageIndex = true;
            ShowPageCount = true;
            ShowRecordCount = true;
            ShowPageListButton = true;
            ShowNumListButton = true;
            PageName = pageHref;
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

        public string GetPageList(PageList pageList_0)
        {
            int num;
            var builder = new StringBuilder("");
            if (pageList_0.RecordCount == 0)
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
                        builder.Append("&nbsp;Record <b>0</b>");
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
            pageList_0.PageCount = pageList_0.RecordCount/pageList_0.PageSize;
            if (pageList_0.PageCount < ((pageList_0.RecordCount)/((double) pageList_0.PageSize)))
            {
                pageList_0.PageCount++;
            }
            builder.Append("<div class=\"PageInfo\" align=\"left\">\r");
            if (ShowPageIndex)
            {
                if (pageList_0.PageID == 0)
                {
                    num = pageList_0.PageID + 1;
                    builder.Append("第<b>" + num + "</b>页&nbsp;");
                }
                else
                {
                    builder.Append("第<b>" + pageList_0.PageID + "</b>页&nbsp;");
                }
            }
            if (ShowPageCount)
            {
                builder.Append("&nbsp;共<b>" + pageList_0.PageCount + "</b>页");
            }
            if (ShowRecordCount)
            {
                builder.Append("&nbsp;&nbsp;共<b>" + pageList_0.RecordCount + "</b>条数据");
            }
            if (ShowPageListButton)
            {
                if (pageList_0.PageID == 1)
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
                if (pageList_0.PageID == 1)
                {
                    builder.Append(string.Format("&nbsp;{0}&nbsp;", PrevPageText));
                }
                else
                {
                    num = pageList_0.PageID - 1;
                    builder.Append(
                        string.Format(
                            "&nbsp;<a  onclick='PageClick(" + num +
                            ")' href=\"javascript:void(0)\">{0}</a>&nbsp;", PrevPageText));
                }
            }
            if (ShowNumListButton)
            {
                builder.Append("&nbsp;&nbsp;<span class=\"PageNumButton\"> ");
                int num3 = pageList_0.PageID - (NumericButtonCount/2);
                if (num3 < 1)
                {
                    num3 = 1;
                }
                for (int i = num3; i < (num3 + NumericButtonCount); i++)
                {
                    if (i > pageList_0.PageCount)
                    {
                        break;
                    }
                    if (i == pageList_0.PageID)
                    {
                        builder.Append("&nbsp;<label class=\"PageIndex\">" + i + "</label>&nbsp;");
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
                if (pageList_0.PageID == pageList_0.PageCount)
                {
                    builder.Append(string.Format("&nbsp;{0}&nbsp;", NextPageText));
                }
                else
                {
                    num = pageList_0.PageID + 1;
                    builder.Append(
                        string.Format(
                            "&nbsp;<a onclick='PageClick(" + num +
                            ")' href=\"javascript:void(0)\">{0}</a>&nbsp;", NextPageText));
                }
                if (pageList_0.PageID == pageList_0.PageCount)
                {
                    builder.Append(string.Format("&nbsp;{0}", LastPageText));
                }
                else
                {
                    builder.Append(
                        string.Format(
                            "&nbsp;<a  onclick='PageClick(" + pageList_0.PageCount +
                            ")' href=\"javascript:void(0)\">{0}</a>", LastPageText));
                }
            }
            builder.Append("\r<input id=\"pageid\" name=\"pageid\" value=\"0\" type=\"hidden\" />");
            builder.Append("\r</div>");
            return builder.ToString();
        }
    }
}