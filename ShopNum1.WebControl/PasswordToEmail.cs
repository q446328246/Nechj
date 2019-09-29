using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class PasswordToEmail : BaseWebControl
    {
        private LinkButton LinkButtonEmail;
        private string skinFilename = "PasswordReminderUrl.ascx";

        public PasswordToEmail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void GetUrl(string email)
        {
            int num = Convert.ToInt32(email.LastIndexOf(".")) - Convert.ToInt32(email.LastIndexOf("@"));
            string str = email.Substring(email.LastIndexOf("@") + 1, num - 1);
            DataTable xmlDataTable = GetXmlDataTable();
            if ((xmlDataTable != null) && (xmlDataTable.Rows.Count > 0))
            {
                for (int i = 0; i < xmlDataTable.Rows.Count; i++)
                {
                    if (xmlDataTable.Rows[i]["sign"].ToString() == str)
                    {
                        if (xmlDataTable.Rows[i]["url"].ToString().Contains("http://") ||
                            xmlDataTable.Rows[i]["url"].ToString().Contains("https://"))
                        {
                            LinkButtonEmail.PostBackUrl = xmlDataTable.Rows[i]["url"].ToString();
                        }
                        else
                        {
                            LinkButtonEmail.PostBackUrl = "http://" + xmlDataTable.Rows[i]["url"];
                        }
                    }
                }
            }
        }

        public DataTable GetXmlDataTable()
        {
            var set = new DataSet();
            set.ReadXml(Page.Server.MapPath("~/Settings/email.xml"));
            if ((set == null) || (set.Tables.Count == 0))
            {
                return null;
            }
            return set.Tables[0];
        }

        protected override void InitializeSkin(Control skin)
        {
            LinkButtonEmail = (LinkButton) skin.FindControl("LinkButtonEmail");
            if (!Page.IsPostBack && (Page.Request.QueryString["email"] != null))
            {
                GetUrl(Page.Request.QueryString["email"]);
            }
        }
    }
}