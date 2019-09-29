using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;

namespace ShopNum1.Common
{
    public class Num1WebControlCommon
    {
        public string AgentAppendPage(Page currentPage, int Pagecount, int Pageindex)
        {
            var builder = new StringBuilder();
            DataRow shopSettingRow = ShopSettings.ShopSettingRow;
            if (HttpContext.Current.Request.ApplicationPath.ToLower().IndexOf("/admin") != -1)
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='" +
                               currentPage.Request.CurrentExecutionFilePath + "?AgentLoginID=" +
                               HttpContext.Current.Request.QueryString["AgentLoginID"] +
                               "&&page='+ this.options[this.selectedIndex].value \">");
            }
            else if (bool.Parse(shopSettingRow["OverrideUrl"].ToString()))
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='" +
                               GetPageName.AgentGetPage("?page='+ this.options[this.selectedIndex].value") + "\">");
            }
            else
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='" +
                               currentPage.Request.CurrentExecutionFilePath + "?AgentLoginID=" +
                               HttpContext.Current.Request.QueryString["AgentLoginID"] +
                               "&&page='+ this.options[this.selectedIndex].value \">");
            }
            for (int i = 1; i <= Pagecount; i++)
            {
                if (Pageindex == i)
                {
                    builder.Append(string.Concat(new object[] {"<option value='", i, "' selected>", i, "</option>"}));
                }
                else
                {
                    builder.Append(string.Concat(new object[] {"<option value='", i, "'>", i, "</option>"}));
                }
            }
            builder.Append("</select>");
            return builder.ToString();
        }

        public string AgentAppendPage(Page currentPage, int Pagecount, int Pageindex, string otherParam)
        {
            var builder = new StringBuilder();
            DataRow shopSettingRow = ShopSettings.ShopSettingRow;
            if (HttpContext.Current.Request.ApplicationPath.ToLower().IndexOf("/admin") != -1)
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='" +
                               currentPage.Request.CurrentExecutionFilePath + "?AgentLoginID=" +
                               HttpContext.Current.Request.QueryString["AgentLoginID"] +
                               "&&page='+ this.options[this.selectedIndex].value+'" + otherParam + "' \">");
            }
            else if (bool.Parse(shopSettingRow["OverrideUrl"].ToString()))
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='" +
                               GetPageName.AgentGetPage("?page='+ this.options[this.selectedIndex].value+'" + otherParam) +
                               "' \">");
            }
            else
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='" +
                               currentPage.Request.CurrentExecutionFilePath + "?AgentLoginID=" +
                               HttpContext.Current.Request.QueryString["AgentLoginID"] +
                               "&&page='+ this.options[this.selectedIndex].value+'" + otherParam + "' \">");
            }
            for (int i = 1; i <= Pagecount; i++)
            {
                if (Pageindex == i)
                {
                    builder.Append(string.Concat(new object[] {"<option value='", i, "' selected>", i, "</option>"}));
                }
                else
                {
                    builder.Append(string.Concat(new object[] {"<option value='", i, "'>", i, "</option>"}));
                }
            }
            builder.Append("</select>");
            return builder.ToString();
        }

        public string AppendPage(Page currentPage, int Pagecount, int Pageindex)
        {
            var builder = new StringBuilder();
            DataRow shopSettingRow = ShopSettings.ShopSettingRow;
            if ((HttpContext.Current.Request.ApplicationPath.ToLower().IndexOf("/admin") != -1) ||
                (HttpContext.Current.Request.Path.ToLower().IndexOf("admin/") != -1))
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" lang=\"" +
                               currentPage.Request.CurrentExecutionFilePath + "\">");
            }
            else if (bool.Parse(shopSettingRow["OverrideUrl"].ToString()))
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" lang=\"" +
                               currentPage.Request.CurrentExecutionFilePath + "\">");
            }
            else
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" lang=\"" +
                               currentPage.Request.CurrentExecutionFilePath + "\">");
            }
            for (int i = 1; i <= Pagecount; i++)
            {
                if (Pageindex == i)
                {
                    builder.Append(string.Concat(new object[] {"<option value='", i, "' selected>", i, "</option>"}));
                }
                else
                {
                    builder.Append(string.Concat(new object[] {"<option value='", i, "'>", i, "</option>"}));
                }
            }
            builder.Append("</select>");
            return builder.ToString();
        }

        public string AppendPage(Page currentPage, int Pagecount, int Pageindex, string otherParam)
        {
            var builder = new StringBuilder();
            DataRow shopSettingRow = ShopSettings.ShopSettingRow;
            if ((HttpContext.Current.Request.ApplicationPath.ToLower().IndexOf("/admin") != -1) ||
                (HttpContext.Current.Request.Path.ToLower().IndexOf("admin/") != -1))
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\">");
            }
            else if (bool.Parse(shopSettingRow["OverrideUrl"].ToString()))
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\">");
            }
            else
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\">");
            }
            for (int i = 1; i <= Pagecount; i++)
            {
                if (Pageindex == i)
                {
                    builder.Append(string.Concat(new object[] {"<option value='", i, "' selected>", i, "</option>"}));
                }
                else
                {
                    builder.Append(string.Concat(new object[] {"<option value='", i, "'>", i, "</option>"}));
                }
            }
            builder.Append("</select>");
            return builder.ToString();
        }

        public string AppendPage(Page currentPage, string guid, int Pagecount, int Pageindex)
        {
            var builder = new StringBuilder();
            DataRow shopSettingRow = ShopSettings.ShopSettingRow;
            if ((HttpContext.Current.Request.ApplicationPath.ToLower().IndexOf("/admin") != -1) ||
                (HttpContext.Current.Request.Path.ToLower().IndexOf("admin/") != -1))
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location.href='" +
                               currentPage.Request.CurrentExecutionFilePath + "?guid=" + guid +
                               "&page='+ this.options[this.selectedIndex].value \">");
            }
            else if (bool.Parse(shopSettingRow["OverrideUrl"].ToString()))
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location.href='" +
                               GetPageName.GetPage("?guid=" + guid + "&page='+ this.options[this.selectedIndex].value") +
                               "\">");
            }
            else
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location..href='" +
                               currentPage.Request.CurrentExecutionFilePath + "?guid=" + guid +
                               "&page='+ this.options[this.selectedIndex].value \">");
            }
            for (int i = 1; i <= Pagecount; i++)
            {
                if (Pageindex == i)
                {
                    builder.Append(string.Concat(new object[] {"<option value='", i, "' selected>", i, "</option>"}));
                }
                else
                {
                    builder.Append(string.Concat(new object[] {"<option value='", i, "'>", i, "</option>"}));
                }
            }
            builder.Append("</select>");
            return builder.ToString();
        }

        public string AppendPage2(Page currentPage, int Pagecount, int Pageindex, string otherParam)
        {
            var builder = new StringBuilder();
            DataRow shopSettingRow = ShopSettings.ShopSettingRow;
            if ((HttpContext.Current.Request.ApplicationPath.ToLower().IndexOf("/admin") != -1) ||
                (HttpContext.Current.Request.Path.ToLower().IndexOf("admin/") != -1))
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='" +
                               currentPage.Request.CurrentExecutionFilePath +
                               "?page='+ this.options[this.selectedIndex].value+'" + otherParam + "' \">");
            }
            else if (bool.Parse(shopSettingRow["OverrideUrl"].ToString()))
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='" +
                               GetPageName.GetPage("?page='+ this.options[this.selectedIndex].value+'" + otherParam) +
                               "' \">");
            }
            else
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='" +
                               currentPage.Request.CurrentExecutionFilePath +
                               "?page='+ this.options[this.selectedIndex].value+'" + otherParam + "' \">");
            }
            for (int i = 1; i <= Pagecount; i++)
            {
                if (Pageindex == i)
                {
                    builder.Append(string.Concat(new object[] {"<option value='", i, "' selected>", i, "</option>"}));
                }
                else
                {
                    builder.Append(string.Concat(new object[] {"<option value='", i, "'>", i, "</option>"}));
                }
            }
            builder.Append("</select>");
            return builder.ToString();
        }

        public string AppendPageVideo(string strUrl, int Pagecount, int Pageindex)
        {
            var builder = new StringBuilder();
            DataRow shopSettingRow = ShopSettings.ShopSettingRow;
            if ((strUrl.ToLower().IndexOf("/admin") != -1) || (strUrl.ToLower().IndexOf("admin/") != -1))
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location.href='" +
                               strUrl + "&page='+ this.options[this.selectedIndex].value \">");
            }
            else
            {
                builder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location..href='" +
                               strUrl + "&page='+ this.options[this.selectedIndex].value \">");
            }
            for (int i = 1; i <= Pagecount; i++)
            {
                if (Pageindex == i)
                {
                    builder.Append(string.Concat(new object[] {"<option value='", i, "' selected>", i, "</option>"}));
                }
                else
                {
                    builder.Append(string.Concat(new object[] {"<option value='", i, "'>", i, "</option>"}));
                }
            }
            builder.Append("</select>");
            return builder.ToString();
        }

        public string GetPageMessage(int pdsDataSoucreCount, int pageCount, int pageSize, int currentPage)
        {
            return
                string.Concat(new object[]
                    {"共", pdsDataSoucreCount, "条记录，共", pageCount, "页，每页", pageSize, "条，第", currentPage, "页"});
        }
    }
}