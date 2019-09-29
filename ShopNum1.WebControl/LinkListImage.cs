using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class LinkListImage : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "LinkListImage.ascx";

        public LinkListImage()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int ShowCount { get; set; }

        public void BindData()
        {
            DataTable linkListImage =
                ((ShopNum1_Link_Action) LogicFactory.CreateShopNum1_Link_Action()).GetLinkListImage(ShowCount.ToString());
            if ((linkListImage != null) && (linkListImage.Rows.Count > 0))
            {
                RepeaterData.DataSource = linkListImage.DefaultView;
                RepeaterData.DataBind();
                var image = (HtmlImage) RepeaterData.Items[RepeaterData.Items.Count - 1].FindControl("img1");
                image.Style.Add(HtmlTextWriterStyle.Margin, "0");
            }
        }

        public static string GetSubstr(object title, int length, bool isEllipsis)
        {
            string str = title.ToString();
            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }
            if (isEllipsis)
            {
                str = str + "...";
            }
            return str;
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        public static string LinkUrl(string string_1)
        {
            if (string_1.Contains("http://"))
            {
                return string_1;
            }
            return GetPageName.RetDomainUrl(string_1 ?? "");
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