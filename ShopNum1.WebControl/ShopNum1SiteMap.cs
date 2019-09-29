using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ShopNum1SiteMap : BaseWebControl
    {
        private SiteMapPath siteMapPath;
        private string skinFilename = "ShopNum1SiteMap.ascx";

        public ShopNum1SiteMap()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            siteMapPath = (SiteMapPath) skin.FindControl("siteMapPath");
            SiteMap.SiteMapResolve += method_0;
            if (!Page.IsPostBack)
            {
            }
        }

        private SiteMapNode method_0(object object_0, SiteMapResolveEventArgs siteMapResolveEventArgs_0)
        {
            SiteMapNode node = null;
            SiteMapNode node2;
            SiteMapNode node3;
            if (SiteMap.CurrentNode == null)
            {
                return node;
            }
            node = SiteMap.CurrentNode.Clone(true);
            var nodes = new SiteMapNodeCollection();
            var action = (ShopNum1_SiteMap_Action) LogicFactory.CreateShopNum1_SiteMap_Action();
            string guid = string.Empty;
            string title = string.Empty;
            if (SiteMap.CurrentNode.Url == (Globals.ApplicationPath + "/GuidBuyList.aspx"))
            {
                if (HttpContext.Current.Request.QueryString["guid"] != null)
                {
                    guid = (HttpContext.Current.Request.QueryString["guid"] == null)
                        ? "0"
                        : HttpContext.Current.Request.QueryString["guid"];
                    title = action.Search("ShopNum1_GuidInfo", guid);
                }
                node2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "GuidBuyList.aspx", title)
                {
                    ParentNode = node
                };
                nodes.Add(node2);
                node.ChildNodes = nodes;
                return node2;
            }
            if (SiteMap.CurrentNode.Url == (Globals.ApplicationPath + "/OrganizBuyDetail.aspx"))
            {
                if (HttpContext.Current.Request.QueryString["guid"] != null)
                {
                    guid = (HttpContext.Current.Request.QueryString["guid"] == null)
                        ? "0"
                        : HttpContext.Current.Request.QueryString["guid"];
                    title = action.SearchOrganizBuyInfoName(guid);
                }
                node2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "OrganizBuyDetail.aspx", title)
                {
                    ParentNode = node
                };
                node3 = node;
                node3.Url = Globals.ApplicationPath + "/OrganizBuyList.aspx";
                nodes.Add(node2);
                node.ChildNodes = nodes;
                return node2;
            }
            if (SiteMap.CurrentNode.Url == (Globals.ApplicationPath + "/AuctionInfoDetail.aspx"))
            {
                if (HttpContext.Current.Request.QueryString["guid"] != null)
                {
                    guid = (HttpContext.Current.Request.QueryString["guid"] == null)
                        ? "0"
                        : HttpContext.Current.Request.QueryString["guid"];
                    title = action.Search("ShopNum1_AuctionInfo", guid);
                }
                node2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "AuctionInfoDetail.aspx", title)
                {
                    ParentNode = node
                };
                node3 = node;
                node3.Url = Globals.ApplicationPath + "/AuctionInfoList.aspx";
                nodes.Add(node2);
                node.ChildNodes = nodes;
                return node2;
            }
            if (SiteMap.CurrentNode.Url == (Globals.ApplicationPath + "/LongAuctionInfoDetail.aspx"))
            {
                if (HttpContext.Current.Request.QueryString["guid"] != null)
                {
                    guid = (HttpContext.Current.Request.QueryString["guid"] == null)
                        ? "0"
                        : HttpContext.Current.Request.QueryString["guid"];
                    title = action.Search("ShopNum1_LongAuctionInfo", guid);
                }
                node2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "LongAuctionInfoDetail.aspx",
                    title)
                {
                    ParentNode = node
                };
                node3 = node;
                node3.Url = Globals.ApplicationPath + "/LongAuctionInfoList.aspx";
                nodes.Add(node2);
                node.ChildNodes = nodes;
                return node2;
            }
            if (SiteMap.CurrentNode.Url == (Globals.ApplicationPath + "/ArticleDetail.aspx"))
            {
                if (HttpContext.Current.Request.QueryString["guid"] != null)
                {
                    guid = (HttpContext.Current.Request.QueryString["guid"] == null)
                        ? "0"
                        : HttpContext.Current.Request.QueryString["guid"];
                    title = action.SearchTitle("ShopNum1_Article", guid);
                }
                node2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "ArticleDetail.aspx", title)
                {
                    ParentNode = node
                };
                node3 = node;
                node3.Url = Globals.ApplicationPath + "/ArticleList.aspx";
                nodes.Add(node2);
                node.ChildNodes = nodes;
                return node2;
            }
            if (SiteMap.CurrentNode.Url == (Globals.ApplicationPath + "/HelpList.aspx"))
            {
                if (HttpContext.Current.Request.QueryString["guid"] != null)
                {
                    guid = (HttpContext.Current.Request.QueryString["guid"] == null)
                        ? "0"
                        : HttpContext.Current.Request.QueryString["guid"];
                    title = action.SearchTitle("ShopNum1_Help", guid);
                }
                node2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "HelpList.aspx", title)
                {
                    ParentNode = node
                };
                node3 = node;
                node3.Url = Globals.ApplicationPath + "/HelpList.aspx";
                nodes.Add(node2);
                node.ChildNodes = nodes;
                return node2;
            }
            if (SiteMap.CurrentNode.Url == (Globals.ApplicationPath + "/AnnouncementDetail.aspx"))
            {
                if (HttpContext.Current.Request.QueryString["guid"] != null)
                {
                    guid = (HttpContext.Current.Request.QueryString["guid"] == null)
                        ? "0"
                        : HttpContext.Current.Request.QueryString["guid"];
                    title = action.SearchTitle("ShopNum1_Announcement", guid);
                }
                node2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "AnnouncementDetail.aspx", title)
                {
                    ParentNode = node
                };
                node3 = node;
                node3.Url = Globals.ApplicationPath + "/AnnouncementDetail.aspx";
                nodes.Add(node2);
                node.ChildNodes = nodes;
                return node2;
            }
            if (SiteMap.CurrentNode.Url == (Globals.ApplicationPath + "/ProductListCategory.aspx"))
            {
                if (HttpContext.Current.Request.QueryString["id"] != null)
                {
                    guid = (HttpContext.Current.Request.QueryString["id"] == null)
                        ? "0"
                        : HttpContext.Current.Request.QueryString["id"];
                    title = action.SearchNameByID("ShopNum1_ProductCategory", guid);
                }
                node2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "ProductListCategory.aspx", title)
                {
                    ParentNode = node
                };
                node3 = node;
                node3.Url = Globals.ApplicationPath + "/ProductListCategory.aspx";
                nodes.Add(node2);
                node.ChildNodes = nodes;
                return node2;
            }
            if (SiteMap.CurrentNode.Url == (Globals.ApplicationPath + "/BrandDetail.aspx"))
            {
                if (HttpContext.Current.Request.QueryString["BrandGuid"] != null)
                {
                    guid = (HttpContext.Current.Request.QueryString["BrandGuid"] == null)
                        ? "0"
                        : HttpContext.Current.Request.QueryString["BrandGuid"];
                    title = action.Search("ShopNum1_Brand", guid);
                }
                node2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "BrandDetail.aspx", title)
                {
                    ParentNode = node
                };
                node3 = node;
                node3.Url = Globals.ApplicationPath + "/BrandList.aspx";
                nodes.Add(node2);
                node.ChildNodes = nodes;
                return node2;
            }
            if (!(SiteMap.CurrentNode.Url == (Globals.ApplicationPath + "/ProductDetail.aspx")))
            {
                return node;
            }
            if (HttpContext.Current.Request.QueryString["guid"] != null)
            {
                guid = (HttpContext.Current.Request.QueryString["guid"] == null)
                    ? "0"
                    : HttpContext.Current.Request.QueryString["guid"];
                title = action.Search("ShopNum1_Product", guid);
            }
            node2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "ProductDetail.aspx", title)
            {
                ParentNode = node
            };
            node3 = node;
            node3.Url = Globals.ApplicationPath + "/ProductListRecommand.aspx";
            nodes.Add(node2);
            node.ChildNodes = nodes;
            return node2;
        }
    }
}