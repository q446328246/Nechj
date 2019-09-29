using System;
using System.Data;
using System.IO;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Xml;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SetMap : PageBase, IRequiresSessionState
    {
        public void AddWebSiteMap(string path)
        {
            XmlWriter writer = XmlWriter.Create(path);
            writer.WriteComment("动态生成的站点地图");
            writer.WriteStartElement("urlset");
            writer.WriteEndElement();
            writer.Close();
        }

        public void BindDropDownList(DropDownList DropDownListChangefreq, DropDownList DropDownListPriority)
        {
            DropDownListChangefreq.Items.Clear();
            DropDownListPriority.Items.Clear();
            DropDownListChangefreq.Items.Add(new ListItem("一直更新", "always"));
            DropDownListChangefreq.Items.Add(new ListItem("小时", "hourly"));
            DropDownListChangefreq.Items.Add(new ListItem("日", "daily"));
            DropDownListChangefreq.Items.Add(new ListItem("周", "weekly"));
            DropDownListChangefreq.Items.Add(new ListItem("月", "mothly"));
            DropDownListChangefreq.Items.Add(new ListItem("年", "yearly"));
            DropDownListChangefreq.Items.Add(new ListItem("不更新", "never"));
            DropDownListPriority.Items.Add(new ListItem("1.0", "1.0"));
            for (int i = 9; i > 0; i--)
            {
                DropDownListPriority.Items.Add(new ListItem("0." + i.ToString(), "0." + i.ToString()));
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            string path = base.Server.MapPath("~/SiteMap.xml");
            File.Delete(path);
            this.AddWebSiteMap(base.Server.MapPath("~/SiteMap.xml"));
            XmlDocument document = new XmlDocument();
            document.Load(path);
            XmlNode documentElement = document.DocumentElement;
            XmlAttribute node = document.CreateAttribute("xmlns");
            node.Value = "http://www.sitemaps.org/schemas/sitemap/0.9";
            documentElement.Attributes.Append(node);
            document.Save(path);
            XmlDocument document2 = new XmlDocument();
            document2.Load(path);
            DataSet set = new DataSet();
            set.ReadXml(base.Server.MapPath("~/Settings/ShopSetting.xml"));
            DataRow row = set.Tables["ShopSetting"].Rows[0];
            string str2 = row["OverrideUrl"].ToString();
            XmlNode node2 = document2.DocumentElement;
            if (node2 != null)
            {
                int num;
                string str3 = DateTime.Now.ToShortDateString();
                string siteDomain = ShopSettings.siteDomain;
                ShopNum1_ExtendSiteMapXml_Action action = (ShopNum1_ExtendSiteMapXml_Action)LogicFactory.CreateShopNum1_ExtendSiteMapXml_Action();
                XmlElement newChild = smethod_0(document2, "http://" + siteDomain, str3, this.DropDownListDefaultChangefreq.SelectedValue, this.DropDownListDefaultPriority.SelectedValue);
                node2.InsertAfter(newChild, node2.LastChild);
                DataTable table = action.SearchProductCategoryID();
                for (num = 0; num < table.Rows.Count; num++)
                {
                    if (str2 == "true")
                    {
                        newChild = smethod_0(document2, "http://" + siteDomain + "/productlist/" + table.Rows[num]["Code"].ToString() + ".html", str3, this.DropDownListProductCategroyChangefreq.SelectedValue, this.DropDownListProductCategroyPriority.SelectedValue);
                    }
                    else
                    {
                        newChild = smethod_0(document2, "http://" + siteDomain + "/productlist.aspx?Code=" + table.Rows[num]["Code"].ToString(), str3, this.DropDownListProductCategroyChangefreq.SelectedValue, this.DropDownListProductCategroyPriority.SelectedValue);
                    }
                    node2.InsertAfter(newChild, node2.LastChild);
                }
                DataTable table4 = action.SearchArticleCategoryID();
                for (num = 0; num < table4.Rows.Count; num++)
                {
                    if (str2 == "true")
                    {
                        newChild = smethod_0(document2, "http://" + siteDomain + "/articlelist/" + table4.Rows[num]["ID"].ToString() + ".html", str3, this.DropDownListArticleCategroyChangefreq.SelectedValue, this.DropDownListArticleCategroyPriority.SelectedValue);
                    }
                    else
                    {
                        newChild = smethod_0(document2, "http://" + siteDomain + "/articlelist.aspx?id=" + table4.Rows[num]["ID"].ToString(), str3, this.DropDownListArticleCategroyChangefreq.SelectedValue, this.DropDownListArticleCategroyPriority.SelectedValue);
                    }
                    node2.InsertAfter(newChild, node2.LastChild);
                }
                DataTable table2 = action.SearchArticle();
                for (num = 0; num < table2.Rows.Count; num++)
                {
                    if (str2 == "true")
                    {
                        newChild = smethod_0(document2, "http://" + siteDomain + "/ArticleDetail/" + table2.Rows[num]["Guid"].ToString() + ".html", str3, this.DropDownListArticleChangefreq.SelectedValue, this.DropDownListArticlePriority.SelectedValue);
                    }
                    else
                    {
                        newChild = smethod_0(document2, "http://" + siteDomain + "/ArticleDetail.aspx?guid=" + table2.Rows[num]["Guid"].ToString(), str3, this.DropDownListArticleChangefreq.SelectedValue, this.DropDownListArticlePriority.SelectedValue);
                    }
                    node2.InsertAfter(newChild, node2.LastChild);
                }
                DataTable table3 = action.SearchSupplyDemandCatagoryCode();
                for (num = 0; num < table3.Rows.Count; num++)
                {
                    if (str2 == "true")
                    {
                        newChild = smethod_0(document2, "http://" + siteDomain + "/supplylist/" + table3.Rows[num]["Code"].ToString() + ".html", str3, this.DropDownListSupplyDemandChangefreq.SelectedValue, this.DropDownListSupplyDemandPriority.SelectedValue);
                    }
                    else
                    {
                        newChild = smethod_0(document2, "http://" + siteDomain + "/supplylist.aspx?Code=" + table3.Rows[num]["Code"].ToString(), str3, this.DropDownListSupplyDemandChangefreq.SelectedValue, this.DropDownListSupplyDemandPriority.SelectedValue);
                    }
                    node2.InsertAfter(newChild, node2.LastChild);
                }
                string[] files = Directory.GetFiles(base.Server.MapPath("~/"), "*.aspx");
                for (num = 0; num < files.Length; num++)
                {
                    if (str2 == "true")
                    {
                        newChild = smethod_0(document2, "http://" + siteDomain + "/" + files[num].Substring(files[num].LastIndexOf('\\') + 1).Replace("aspx", "html"), str3, this.DropDownListOtherChangefreq.SelectedValue, this.DropDownListOtherChangefreq.SelectedValue);
                    }
                    else
                    {
                        newChild = smethod_0(document2, "http://" + siteDomain + "/" + files[num].Substring(files[num].LastIndexOf('\\') + 1), str3, this.DropDownListOtherChangefreq.SelectedValue, this.DropDownListOtherChangefreq.SelectedValue);
                    }
                    node2.InsertAfter(newChild, node2.LastChild);
                }
                document2.Save(path);
                this.LiteralURL.Text = "站点地图生成成功，点击浏览<a href=\"http://" + ShopSettings.siteDomain + "/sitemap.xml\" target=\"_blank\" >http://" + ShopSettings.siteDomain + "/sitemap.xml</a>";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.BindDropDownList(this.DropDownListDefaultChangefreq, this.DropDownListDefaultPriority);
                this.BindDropDownList(this.DropDownListProductCategroyChangefreq, this.DropDownListProductCategroyPriority);
                this.BindDropDownList(this.DropDownListArticleCategroyChangefreq, this.DropDownListArticleCategroyPriority);
                this.BindDropDownList(this.DropDownListArticleChangefreq, this.DropDownListArticlePriority);
                this.BindDropDownList(this.DropDownListOtherChangefreq, this.DropDownListOtherPriority);
                this.BindDropDownList(this.DropDownListSupplyDemandChangefreq, this.DropDownListSupplyDemandPriority);
            }
        }

        private static XmlElement smethod_0(XmlDocument xmlDocument_0, string string_4, string string_5, string string_6, string string_7)
        {
            XmlElement element = xmlDocument_0.CreateElement("url");
            XmlElement newChild = xmlDocument_0.CreateElement("loc");
            newChild.InnerText = string_4;
            element.AppendChild(newChild);
            XmlElement element3 = xmlDocument_0.CreateElement("lastmod");
            element3.InnerText = string_5;
            element.AppendChild(element3);
            XmlElement element4 = xmlDocument_0.CreateElement("changefreq");
            element4.InnerText = string_6;
            element.AppendChild(element4);
            XmlElement element5 = xmlDocument_0.CreateElement("priority");
            element5.InnerText = string_7;
            element.AppendChild(element5);
            return element;
        }
    }
}