using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_AlbumList : BaseShopWebControl
    {
        public static DataTable dt_Album_List = null;
        public static string pageDiv;
        public static string typeName;
        private HtmlInputHidden htmlInputHidden_0;
        private HtmlInputHidden htmlInputHidden_1;
        private HtmlInputHidden htmlInputHidden_2;
        private LinkButton linkButton_0;
        private string skinFilename = "S_AlbumList.ascx";
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;

        public S_AlbumList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int PageSize { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            htmlInputHidden_1 = (HtmlInputHidden) skin.FindControl("hidArryId");
            htmlInputHidden_2 = (HtmlInputHidden) skin.FindControl("hidPath");
            linkButton_0 = (LinkButton) skin.FindControl("LinkDel_Select");
            linkButton_0.Click += linkButton_0_Click;
            htmlInputHidden_0 = (HtmlInputHidden) skin.FindControl("hidShopId");
            string_1 = Common.Common.ReqStr("sort");
            string_3 = HttpUtility.HtmlDecode(Common.Common.ReqStr("name"));
            string_2 = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            string_4 = Common.Common.ReqStr("typeid");
            if (!Page.IsPostBack)
            {
                method_1();
                BindData();
                htmlInputHidden_0.Value = base.MemLoginID;
            }
        }

        protected void linkButton_0_Click(object sender, EventArgs e)
        {
            var shopImg = new List<ShopNum1_Shop_Image>();
            var action = (Shop_Image_Action) LogicFactory.CreateShop_Image_Action();
            string[] strArray = htmlInputHidden_1.Value.Split(new[] {','});
            string[] strArray2 = htmlInputHidden_2.Value.Split(new[] {','});
            int index = 0;
            while (true)
            {
                if (index >= strArray.Length)
                {
                    break;
                }
                var item = new ShopNum1_Shop_Image
                {
                    Id = Convert.ToInt32(strArray[index])
                };
                shopImg.Add(item);
                try
                {
                    string path = HttpContext.Current.Server.MapPath(strArray2[index]);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                catch
                {
                }
                index++;
            }
            if (action.DeleteSelectImg(shopImg) > 0)
            {
                MessageBox.Show("您成功删除" + strArray.Length + "张图片!");
                method_1();
            }
            else
            {
                MessageBox.Show("删除失败!");
            }
        }

        protected void BindData()
        {
            if ((((Common.Common.ReqStr("act") == "del") && (Common.Common.ReqStr("Imgpath") != "")) &&
                 (Common.Common.ReqStr("id") != "")) && (Common.Common.ReqStr("sign") == "del"))
            {
                var shopImg = new List<ShopNum1_Shop_Image>();
                var action = (Shop_Image_Action) LogicFactory.CreateShop_Image_Action();
                var item = new ShopNum1_Shop_Image
                {
                    Id = Convert.ToInt32(Common.Common.ReqStr("id"))
                };
                shopImg.Add(item);
                try
                {
                    string path = HttpContext.Current.Server.MapPath(Common.Common.ReqStr("Imgpath").Replace("-", "/"));
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        File.Delete(path + "_25x25.jpg");
                        File.Delete(path + "_60x60.jpg");
                        File.Delete(path + "_100x100.jpg");
                        File.Delete(path + "_160x160.jpg");
                        File.Delete(path + "_300x300.jpg");
                    }
                }
                catch
                {
                }
                if (action.DeleteSelectImg(shopImg) > 0)
                {
                    MessageBox.Show("您成功删除该图片!");
                    Page.Response.Redirect("/shop/ShopAdmin/S_AlbumList.aspx?typeid=" + Common.Common.ReqStr("typeid"));
                }
            }
        }

        protected void method_1()
        {
            int currentPage = Convert.ToInt32(string_2);
            var action = (Shop_ImageCategory_Action) LogicFactory.CreateShop_ImageCategory_Action();
            var action2 = (Shop_Image_Action) LogicFactory.CreateShop_Image_Action();
            typeName = action.Get_TypeName(string_4);
            DataTable table = action2.Select_List(PageSize, currentPage, 0, string_3, string_1, string_4,
                base.MemLoginID);
            var pl = new PageList1
            {
                PageSize = Convert.ToInt32(PageSize),
                PageID = currentPage
            };
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            pl.PageCount = pl.RecordCount/pl.PageSize;
            if (pl.PageCount < ((pl.RecordCount)/((double) pl.PageSize)))
            {
                pl.PageCount++;
            }
            if (currentPage > pl.PageCount)
            {
                currentPage = pl.PageCount;
            }
            pageDiv = new PageListBll("shop/ShopAdmin/S_AlbumList.aspx", true).GetPageListNew(pl);
            dt_Album_List = action2.Select_List(PageSize, currentPage, 1, string_3, string_1, string_4, base.MemLoginID);
        }
    }
}