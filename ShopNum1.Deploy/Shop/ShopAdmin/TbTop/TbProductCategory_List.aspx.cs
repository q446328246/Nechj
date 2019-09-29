/************************************************************
Design:By t(�ƽ�����)
WebSite:http://www.t.com
ShopNum1 WebSite:http://www.shopnum1.cn
Coder:WFK
Date:2008-12-21
************************************************************/

using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.TbTopCommon;
using LogicFactory = ShopNum1.ShopFactory.LogicFactory;

namespace ShopNum1.Deploy.Shop.ShopAdmin.TbTop
{
    public partial class TbProductCategory_List : Page
    {
        private string ShopName; //��������
        public string strid = "-1";

        /// <summary>
        ///     ��Ա��
        /// </summary>
        public string MemLoginID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                //�˳�
                GetUrl.RedirectTopLogin();
            }
            else
            {
                HttpCookie cookieShopMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
                string MemberType = decodedCookieShopMemberLogin.Values["MemberType"];
                if (MemberType != "2")
                {
                    //�˳�
                    GetUrl.RedirectTopLogin();
                    return;
                }
                //��Ա��¼ID
                MemLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
            }

            bool isExisit = CheckMemberID(MemLoginID);
            if (!isExisit)
            {
                Response.Redirect("TbAuthorization.aspx");
            }

            if (!TopClient.IsAgentLogin)
            {
                Response.Redirect("TbAuthorization.aspx");
            }
            if (!TopClient.isSessionTimeOut(Page, "agent"))
            {
                Response.Redirect("TbAuthorization.aspx");
            }

            if (!Page.IsPostBack)
            {
                BindTreeView();
                //if (CheckAgentPower() == 0)
                //{
                //    LabelMessage2.Visible = true;
                //    this.ButtonAdd.Enabled = false;
                //    this.ButtonAdd.Enabled = false;
                //}

                //BindProductCategory();
                //if (ButtonNodeOperate.ToolTip == "NoExpand")
                //{
                //    this.TreeViewData.CollapseAll();
                //}
            }

            if (ButtonNodeOperate.ToolTip == "NoExpand")
            {
                TreeViewData.CollapseAll();
            }
            //TopClient.isSessionTimeOut(this.Page, "agent");
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("TbProductCategory_Operate.aspx");
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            TreeNodeCollection tc = TreeViewData.Nodes;
            GetNode(tc);
        }

        /// <summary>
        ///     ��Ʒ����ĸ��ڵ�
        /// </summary>
        private void BindTreeView()
        {
            var productCategory_Action = (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
            productCategory_Action.TableName = "ShopNum1_Shop_ProductCategory";

            DataTable dataTable = productCategory_Action.GetShopProductCategoryCode("0", MemLoginID);

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var Nodes = new TreeNode();
                    Nodes.Text = dataRow["Name"] + "<span style='color:Red;font-size:12px;margin-left:20px;'>" +
                                 CheckSellCat(Convert.ToInt32(dataRow["ID"])) + "<span>";
                    Nodes.Value = dataRow["ID"].ToString();
                    Nodes.Expanded = false;
                    SearchCategory(Nodes, dataRow["ID"].ToString());
                    TreeViewData.Nodes.Add(Nodes);
                }
            }
        }

        private void SearchCategory(TreeNode Nodes, string ID)
        {
            var productCategory_Action = (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
            productCategory_Action.TableName = "ShopNum1_Shop_ProductCategory";

            DataTable dataTable = productCategory_Action.GetShopProductCategoryCode(ID, MemLoginID);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var node = new TreeNode();
                node.Value = dataRow["ID"].ToString();
                node.Text = dataRow["Name"].ToString();
                node.Expanded = false;
                SearchCategory(node, dataRow["ID"].ToString());
                Nodes.ChildNodes.Add(node);
            }
        }

        public void GetNode(TreeNodeCollection tc)
        {
            foreach (TreeNode treeNode in tc)
            {
                if (treeNode.Checked)
                {
                    Response.Redirect("TbProductCategory_Operate.aspx?id=" + treeNode.Value + "");
                }
                GetNode(treeNode.ChildNodes);
            }
        }


        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            TreeNodeCollection tc = TreeViewData.Nodes;
            GetNodeDel(tc);
            if (strid == "-1")
            {
                MessageBox.Show("��ѡ��Ҫɾ���ļ�¼!");
            }
            else
            {
                var productCategory_Action =
                    (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
                productCategory_Action.TableName = "ShopNum1_Shop_ProductCategory";
                if (productCategory_Action.DeleteProductCategoryCode(strid, MemLoginID) > 0)
                {
                    //��ʾɾ����Ϣ
                    MessageBox.Show("ɾ���ɹ���");
                    TreeViewData.Nodes.Clear();
                    BindTreeView();
                }
                else
                {
                    //��ʾɾ����Ϣ
                    MessageBox.Show("ɾ��ʧ�ܣ�");
                }
            }
        }

        private void GetNodeDel(TreeNodeCollection tc)
        {
            foreach (TreeNode treeNode in tc)
            {
                if (treeNode.Checked)
                {
                    strid = treeNode.Value;
                }
                GetNodeDel(treeNode.ChildNodes);
            }
        }


        protected void ButtonNodeOperate_Click(object sender, EventArgs e)
        {
            ExpendAll();
        }

        public void ExpendAll()
        {
            if (ButtonNodeOperate.ToolTip == "NoExpand")
            {
                TreeViewData.ExpandAll();
                ButtonNodeOperate.Text = "ȫ���۵�";
                ButtonNodeOperate.ToolTip = "Expand";
            }
            else
            {
                TreeViewData.CollapseAll();
                ButtonNodeOperate.Text = "ȫ��չ��";
                ButtonNodeOperate.ToolTip = "NoExpand";
            }
        }

        private bool CheckMemberID(string MemLoginID)
        {
            try
            {
                ShopName =
                    HttpUtility.UrlDecode(
                        HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["visitor_nick"]);
            }
            catch
            {
                ShopName = "";
            }

            var tbSystem = (ShopNum1_TbSystem_Action) LogicTbFactory.CreateShopNum1_TbSystem_Action();
            if (tbSystem.GetTbSysem(MemLoginID, ShopName) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///     �������Ƿ����
        /// </summary>
        private string CheckSellCat(int id)
        {
            //if (!TopClient.isAdminSessionTrue)
            //{
            //    return "δ��Ȩ";
            //}
            var sellCatOperate =
                (ShopNum1_TbSellCat_Action) LogicTbFactory.CreateShopNum1_TbSellCat_Action();
            DataTable dt = sellCatOperate.GetSellCat(id);
            if (sellCatOperate.CheckSiteSellCat(id) == 0)
            {
                return "δͬ��";
            }
            else
            {
                bool isTaobao = Convert.ToBoolean(dt.Rows[0]["isTaobao"]);
                if (isTaobao)
                {
                    return "��ͬ��(��)";
                }
                else
                {
                    return "��ͬ��";
                }
            }
        }
    }
}