using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Xml;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SiteMota_Operate : PageBase, IRequiresSessionState
    {
        public XmlDocument xmlDoc;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["pagename"] == null)
                                        ? "0"
                                        : base.Request.QueryString["pagename"].Replace("'", "");
            if (!base.IsPostBack && (hiddenFieldGuid.Value != "0"))
            {
                hiddenFieldGuid.Value = hiddenFieldGuid.Value.Replace('/', '.');
                TextBoxPageName.Enabled = false;
                ButtonConfirm.Text = "更新";
                GetEditInfo();
            }
        }

        public void Add()
        {
            if (check(TextBoxPageName.Text))
            {
                LoadXml();
                XmlNode node = xmlDoc.SelectSingleNode("SiteMeta");
                XmlElement newChild = xmlDoc.CreateElement("Meta");
                newChild.SetAttribute("PageName", TextBoxPageName.Text);
                newChild.SetAttribute("Title", TextBoxFileName.Text);
                newChild.SetAttribute("KeyWords", TextBoxDivID.Text);
                newChild.SetAttribute("Description", TextBoxExplain.Text);
                node.AppendChild(newChild);
                try
                {
                    xmlDoc.Save(GetPath());
                    MessageShow.ShowMessage("AddYes");
                    MessageShow.Visible = true;
                }
                catch (Exception)
                {
                    MessageShow.ShowMessage("AddNo");
                    MessageShow.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("该页面已存在");
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SiteMota_List.aspx");
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (hiddenFieldGuid.Value != "0")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "编辑SEO操作",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "SiteMota_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                edit();
                base.Response.Redirect("SiteMota_List.aspx");
            }
            else
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "添加SEO操作",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "SiteMota_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Add();
            }
        }

        public bool check(string PageName)
        {
            var set = new DataSet();
            set.ReadXml(GetPath());
            if (set.Tables[0].Select("PageName = '" + PageName + "'").Length > 0)
            {
                return false;
            }
            return true;
        }

        public void edit()
        {
            LoadXml();
            //using ()
                //{
                IEnumerator enumerator = xmlDoc.SelectSingleNode("SiteMeta").ChildNodes.GetEnumerator();
                XmlElement element;
                while (enumerator.MoveNext())
                {
                    var current = (XmlNode) enumerator.Current;
                    element = (XmlElement) current;
                    if (element.GetAttribute("PageName") == TextBoxPageName.Text)
                    {
                        goto Label_0068;
                    }
                }
                goto Label_00D9;
                Label_0068:
                element.SetAttribute("PageName", TextBoxPageName.Text);
                element.SetAttribute("Title", TextBoxFileName.Text);
                element.SetAttribute("KeyWords", TextBoxDivID.Text);
                element.SetAttribute("Description", TextBoxExplain.Text);
            //}
            Label_00D9:
            ;
            try
            {
                xmlDoc.Save(GetPath());
                MessageShow.ShowMessage("EditYes");
            }
            catch (Exception)
            {
            }
        }

        public void GetEditInfo()
        {
            DataRow row = SelectByID(hiddenFieldGuid.Value).Rows[0];
            TextBoxPageName.Text = row["PageName"].ToString();
            TextBoxFileName.Text = row["Title"].ToString();
            TextBoxDivID.Text = row["KeyWords"].ToString();
            TextBoxExplain.Text = row["Description"].ToString();
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



        public DataTable SelectByID(string PageName)
        {
            var set = new DataSet();
            set.ReadXml(GetPath());
            DataRow[] source = set.Tables[0].Select("PageName = '" + PageName + "'");
            if (source.Length > 0)
            {
                return source.CopyToDataTable<DataRow>();
            }
            return null;
        }
    }
}