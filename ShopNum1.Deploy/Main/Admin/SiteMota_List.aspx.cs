using System;
using System.Collections;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Xml;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SiteMota_List : PageBase, IRequiresSessionState
    {
        public XmlDocument xmlDoc;

        public void Bind()
        {
            Num1GridViewShow.DataBind();
        }

        protected void butSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("SiteMota_Operate.aspx?PageName=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (delete(CheckGuid.Value) == 1)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "É¾³ýSEOÉèÖÃ³É¹¦",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "SiteMota_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                Bind();
                MessageBox.Show("É¾³ý³É¹¦");
            }
            else
            {
                MessageBox.Show("É¾³ýÊ§°Ü");
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string commandArgument = button.CommandArgument;
            if (delete(commandArgument) == 1)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "É¾³ýSEOÉèÖÃ³É¹¦",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "SiteMota_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                Bind();
                MessageBox.Show("É¾³ý³É¹¦");
            }
            else
            {
                MessageBox.Show("É¾³ýÊ§°Ü");
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SiteMota_Operate.aspx?PageName=" + CheckGuid.Value.Replace('.', '/'));
        }

        public int delete(string PageName)
        {
            if (PageName.IndexOf(",") == -1)
            {
                PageName = PageName + ",";
            }
            string[] strArray = PageName.Replace("'", "").Split(new[] {','});
            LoadXml();
            XmlNodeList childNodes = xmlDoc.SelectSingleNode("SiteMeta").ChildNodes;
            for (int i = 0; i < strArray.Length; i++)
            {
                //using ()
                //{
                IEnumerator enumerator = childNodes.GetEnumerator();
                    XmlNode current;
                    while (enumerator.MoveNext())
                    {
                        current = (XmlNode) enumerator.Current;
                        var element = (XmlElement) current;
                        if (element.GetAttribute("PageName") == strArray[i])
                        {
                            goto Label_00A9;
                        }
                    }
                    continue;
                    Label_00A9:
                    xmlDoc.SelectSingleNode("SiteMeta").RemoveChild(current);
                //}
            }
            try
            {
                xmlDoc.Save(GetPath());
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string GetPath()
        {
            string path = "~/Settings/SetMeto.xml";
            return HttpContext.Current.Server.MapPath(path);
        }

        public void LoadXml()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(GetPath());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                Bind();
            }
        }
    }
}