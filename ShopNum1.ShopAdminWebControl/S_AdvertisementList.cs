using System;
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

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_AdvertisementList : BaseShopWebControl
    {
        private Button ButtonSearch;
        private HtmlInputHidden hid_Seletfile;
        private HtmlInputHidden hid_SeletfileValue;
        private Repeater rep_AddvertismentList;
        private HtmlSelect sel_File;
        private string skinFilename = "S_AdvertisementList.ascx";
        private HtmlInputText txt_FileName;

        public S_AdvertisementList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string OpenTime { get; set; }

        public string SetPath { get; set; }

        public string shopid { get; set; }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void GetFileList()
        {
            string[] files =
                Directory.GetFiles(
                    HttpContext.Current.Server.MapPath("~/shop/shop/" + OpenTime.Replace("-", "/") + "/shop" + shopid +
                                                       "/Themes/Skin_Default/"), "*.aspx");
            sel_File.Items.Clear();
            var item = new ListItem
            {
                Text = "-全部-",
                Value = "-1"
            };
            sel_File.Items.Add(item);
            for (int i = 0; i < files.Length; i++)
            {
                var item2 = new ListItem
                {
                    Text = files[i].Substring(files[i].LastIndexOf('\\') + 1),
                    Value = files[i].Substring(files[i].LastIndexOf('\\') + 1)
                };
                sel_File.Items.Add(item2);
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            rep_AddvertismentList = (Repeater) skin.FindControl("rep_AddvertismentList");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
            sel_File = (HtmlSelect) skin.FindControl("sel_File");
            hid_Seletfile = (HtmlInputHidden) skin.FindControl("hid_Seletfile");
            hid_SeletfileValue = (HtmlInputHidden) skin.FindControl("hid_SeletfileValue");
            txt_FileName = (HtmlInputText) skin.FindControl("txt_FileName");
            DataTable memLoginInfo =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetMemLoginInfo(base.MemLoginID);
            shopid = memLoginInfo.Rows[0]["ShopID"].ToString();
            OpenTime = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            SetPath = "~/Shop/Shop/" + OpenTime.Replace("-", "/") + "/shop" + shopid +
                      "/Themes/Skin_Default/Advertisement.xml";
            GetFileList();
            BindData();
        }

        protected void BindData()
        {
            var action = (Shop_Advertisement_Action) LogicFactory.CreateShop_Advertisement_Action();
            action.StrPath = SetPath;
            DataTable table = action.Search(Operator.FilterString(txt_FileName.Value), hid_SeletfileValue.Value);
            rep_AddvertismentList.DataSource = table;
            rep_AddvertismentList.DataBind();
        }
    }
}