using System;
using System.Data;
using System.IO;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Image_List_Select : PageBase, IRequiresSessionState
    {
        private readonly string string_7 = (ShopUrlOperate.GetSiteDomain() + "/main/admin/Image_List_Select.aspx");
        protected char charSapce = '　';

        private int int_0;
        protected string strSapce = "　　";

        private string string_4;
        private string string_5;
        private string string_6;
        public string ImageSpec { get; set; }

        public int ShowCount { get; set; }

        protected void BindImage(string strImageType)
        {
            if (int_0 <= 0)
            {
                int_0 = 1;
            }
            var pl = new PageList1
                {
                    PageSize = ShowCount,
                    PageID = int_0
                };
            var action = (ShopNum1_Image_Action) LogicFactory.CreateShopNum1_Image_Action();
            DataTable table2 = action.SearchImageByType(string_5, string_4, 0, string_6, ShowCount.ToString(),
                                                        int_0.ToString(), "1");
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table2.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            method_6(Convert.ToInt32((pl.RecordCount/pl.PageSize)) + 1);
            pageDiv.InnerHtml =
                new PageListBll("main/admin/Image_List_Select", true, "2")
                    {
                        ShowRecordCount = true,
                        ShowPageCount = true,
                        ShowPageIndex = true,
                        ShowNoRecordInfo = false,
                        ShowNumListButton = true,
                        PrevPageText = "<<上一页",
                        NextPageText = "下一页>> "
                    }.GetPageListVk(pl);
            DataTable table = action.SearchImageByType(string_5, string_4, 0, string_6, ShowCount.ToString(),
                                                       int_0.ToString(), "0");
            if ((table != null) && (table.Rows.Count > 0))
            {
                DataListShow.DataSource = table;
                DataListShow.DataBind();
            }
        }

        protected void BindImageCategory()
        {
            DropDownListImgCategory1.Items.Clear();
            var item = new ListItem
                {
                    Text = "-全部-",
                    Value = "0"
                };
            DropDownListImgCategory1.Items.Add(item);
            var action = (ShopNum1_ImageCategory_Action) LogicFactory.CreateShopNum1_ImageCategory_Action();
            foreach (DataRow row in action.Search(0).DefaultView.Table.Rows)
            {
                var item2 = new ListItem();
                if (Common.Common.ReqStr("category") == row["ID"].ToString())
                {
                    item2.Selected = true;
                }
                item2.Text = row["Name"].ToString().Trim();
                item2.Value = row["ID"].ToString().Trim();
                DropDownListImgCategory1.Items.Add(item2);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()));
                if (table.Rows.Count > 0)
                {
                    method_5(table);
                }
            }
        }

        protected void ButtonDel_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Image_Action) LogicFactory.CreateShopNum1_Image_Action();
            string str = this.HiddenImgPath.Value;
            try
            {
                string path = string.Empty;
                string str3 = string.Empty;
                string str4 = string.Empty;
                string str5 = string.Empty;
                if (str.IndexOf(",") != -1)
                {
                    string[] strArray = str.Split(new[] {','});
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        path = base.Server.MapPath(strArray[i]);
                        str3 = path.Substring(0, path.LastIndexOf("/") + 1);
                        str4 = path.Substring(path.LastIndexOf("/") + 1, (path.Length - path.LastIndexOf("/")) - 1);
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                    }
                }
                else
                {
                    path = str;
                    str3 = path.Substring(0, path.LastIndexOf("/") + 1);
                    str4 = path.Substring(path.LastIndexOf("/") + 1, (path.Length - path.LastIndexOf("/")) - 1);
                    str5 = str3 + "s_" + str4;
                    path = base.Server.MapPath(path);
                    str5 = base.Server.MapPath(str5);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
            catch
            {
            }
            if (action.Delete(CheckGuid.Value) > 0)
            {
                MessageBox.Show("删除成功！");
                Page.Response.Redirect(
                    string.Concat(new object[]
                        {
                            string_7, "?name=", TextBoxSName.Text.Trim(), "&category=",
                            DropDownListImgCategory1.SelectedValue, "&size=", ShowCount.ToString(), "&pageid=", 1
                        }));
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(
                string.Concat(new object[]
                    {
                        string_7, "?name=", TextBoxSName.Text.Trim(), "&category=", DropDownListImgCategory1.SelectedValue,
                        "&size=", ShowCount.ToString(), "&pageid=", 1
                    }));
        }

        protected void DropDownListImgCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Format("Image_List_Select.aspx?category={0}&PageID=1",
                                                 DropDownListImgCategory1.SelectedValue));
        }

        protected void DropDownListNumSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Format("Image_List_Select.aspx?PageID={0}",
                                                 DropDownListNumSelect.SelectedValue));
        }

        private void method_5(DataTable dt)
        {
            var action = (ShopNum1_ImageCategory_Action) LogicFactory.CreateShopNum1_ImageCategory_Action();
            foreach (DataRow row in dt.Rows)
            {
                var item = new ListItem();
                string str = string.Empty;
                for (int i = 0; i < (Convert.ToInt32(row["CategoryLevel"].ToString()) - 1); i++)
                {
                    str = str + strSapce;
                }
                str = str + row["Name"].ToString().Trim();
                item.Text = str;
                item.Value = row["ID"].ToString().Trim();
                DropDownListImgCategory1.Items.Add(item);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()));
                if (table.Rows.Count > 0)
                {
                    method_5(table);
                }
            }
        }

        private void method_6(int int_2)
        {
            DropDownListNumSelect.Items.Clear();
            for (int i = 1; i <= int_2; i++)
            {
                var item = new ListItem
                    {
                        Text = i.ToString(),
                        Value = i.ToString()
                    };
                DropDownListNumSelect.Items.Add(item);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            int_0 = (Page.Request.QueryString["pageid"] == null) ? 1 : int.Parse(Page.Request.QueryString["pageid"]);
            string_4 = (Page.Request.QueryString["name"] == null) ? "" : Page.Request.QueryString["name"];
            string_5 = (Page.Request.QueryString["type"] == null) ? "-1" : Page.Request.QueryString["type"];
            string_6 = (Page.Request.QueryString["category"] == null) ? "0" : Page.Request.QueryString["category"];
            ShowCount = (Page.Request.QueryString["size"] == null) ? 0x18 : int.Parse(Page.Request.QueryString["size"]);
            if (!Page.IsPostBack)
            {
                BindImageCategory();
                BindImage("-1");
                if (base.Request.QueryString["PageID"] != null)
                {
                    DropDownListNumSelect.SelectedValue = base.Request.QueryString["PageID"];
                }
            }
        }
    }
}