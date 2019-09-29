using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class W_ShopReplyImgTxtList : BaseShopWebControl
    {
        private Repeater rep_rule;
        private string skinFilename = "W_ShopReplyImgTxtList.ascx";

        public W_ShopReplyImgTxtList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void BindReplyImgText()
        {
            IShopNum1_Weixin_ReplyRule_Active active = new ShopNum1_Weixin_ReplyRule_Active();
            DataSet set = active.SelectReplyRule(base.MemLoginID, 1);
            if (set.Tables.Count != 0)
            {
                DataTable table = set.Tables[0];
                table.Columns.Add("keyword", typeof (string));
                table.Columns.Add("content", typeof (string));
                foreach (DataRow row in table.Rows)
                {
                    DataRow[] rowArray = set.Tables[1].Select(string.Format("ruleid = '{0}'", row["ID"]));
                    DataRow[] rowArray2 = set.Tables[2].Select(string.Format("ruleid = '{0}'", row["ID"]));
                    var builder = new StringBuilder();
                    foreach (DataRow row2 in rowArray)
                    {
                        builder.AppendFormat("{0} ", row2["KeyWord"]);
                    }
                    string str = (rowArray2.Length != 0) ? rowArray2[0]["Title"].ToString() : string.Empty;
                    if (str.Length > 20)
                    {
                        str = str.Substring(0, 20) + "...";
                    }
                    string str2 = builder.ToString().Trim();
                    row["keyword"] = (str2.Length > 8) ? (str2.Substring(0, 8) + "...") : str2;
                    row["content"] = (str.Length > 12) ? (str.Substring(0, 12) + "...") : str;
                }
                rep_rule.DataSource = table;
                rep_rule.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            rep_rule = (Repeater) skin.FindControl("rep_rule");
            BindReplyImgText();
        }
    }
}