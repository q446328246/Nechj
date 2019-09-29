using System;
using System.Data;
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
    public class S_ShowShopPhoto : BaseMemberWebControl
    {
        private Button ButtonChaxData;
        private DropDownList DropDownListType;
        private Repeater RepeaterShow;
        private HtmlInputHidden hidImgCategoryID;
        private HtmlInputHidden hidShopId;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_ShowShopPhoto.ascx";
        private HtmlInputText txtImageName;

        public S_ShowShopPhoto()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        public void BindImageCategory()
        {
            DataTable table =
                ((Shop_ImageCategory_Action) LogicFactory.CreateShop_ImageCategory_Action()).dt_Album_Import(
                    base.MemLoginID);
            hidShopId.Value = base.MemLoginID;
            DropDownListType.Items.Clear();
            new ListItem();
            if ((table != null) && (table.Rows.Count > 0))
            {
                foreach (DataRow row in table.Rows)
                {
                    string str = Common.Common.ReqStr("st");
                    var item = new ListItem();
                    if (str == row["ID"].ToString())
                    {
                        item.Selected = true;
                    }
                    item.Text = row["Name"].ToString();
                    item.Value = row["ID"].ToString();
                    DropDownListType.Items.Add(item);
                }
                if (Common.Common.ReqStr("st") == "")
                {
                    hidImgCategoryID.Value = table.Rows[0]["ID"].ToString();
                }
                else
                {
                    hidImgCategoryID.Value = Common.Common.ReqStr("st");
                }
            }
        }

        protected void ButtonChaxData_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            ButtonChaxData = (Button) skin.FindControl("ButtonChaxData");
            ButtonChaxData.Click += ButtonChaxData_Click;
            txtImageName = (HtmlInputText) skin.FindControl("txtImageName");
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            DropDownListType = (DropDownList) skin.FindControl("DropDownListType");
            hidShopId = (HtmlInputHidden) skin.FindControl("hidShopId");
            hidImgCategoryID = (HtmlInputHidden) skin.FindControl("hidImgCategoryID");
            BindImageCategory();
            BindData();
        }

        protected void BindData()
        {
            var action = (Shop_Image_Action) LogicFactory.CreateShop_Image_Action();
            string str = string.Empty;
            string str2 = HttpUtility.HtmlDecode(Common.Common.ReqStr("imgname"));
            if (!string.IsNullOrEmpty(str2.Trim()))
            {
                str = str + "  AND  Name  LIKE   '%" + str2 + "%'   ";
                txtImageName.Value = str2;
            }
            if (Common.Common.ReqStr("st") != "")
            {
                str = str + "  AND  ImageCategoryID  ='" + Common.Common.ReqStr("st") + "'   ";
            }
            else
            {
                str = str + "  AND  ImageCategoryID  ='" + hidImgCategoryID.Value + "'   ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = "  AND   1=1   " + str + "     AND  CreateUser='" + base.MemLoginID + "'  ",
                Currentpage = pageid,
                Resultnum = "0",
                PageSize = PageSize
            };
            DataTable table = action.Select_List(commonModel);
            var pl = new PageList1
            {
                PageSize = Convert.ToInt32(PageSize),
                PageID = Convert.ToInt32(pageid)
            };
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml =
                new PageListBll("Shop/ShopAdmin/S_ShowShopPhoto.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.Select_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }
    }
}