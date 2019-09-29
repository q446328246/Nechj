using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    public class S_GroupProductOperate : BaseShopWebControl
    {
        private readonly ShopNum1_Group_Product shopNum1_Group_Product_0 = new ShopNum1_Group_Product();
        private readonly Shop_GroupProduct_Action shop_GroupProduct_Action_0 = new Shop_GroupProduct_Action();
        private HtmlImage GroupPic;
        private Button btnSub;
        private FileUpload fileUpload;
        private HtmlInputHidden hidAid;
        private HtmlInputHidden hidAname;
        private HtmlInputHidden hidGuid;
        private string skinFilename = "S_GroupProductOperate.ascx";
        private HtmlGenericControl spanstock;
        private HtmlTextArea txtGroupIntroduce;
        private HtmlInputText txtGroupName;
        private HtmlInputText txtGroupPrice;
        private HtmlInputText txtGroupStock;
        private HtmlInputText txtLimtNum;
        private HtmlInputText txtVitualNum;

        public S_GroupProductOperate()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            shopNum1_Group_Product_0.Aid = Convert.ToInt32(hidAid.Value);
            shopNum1_Group_Product_0.ProductGuId = hidGuid.Value;
            shopNum1_Group_Product_0.Name = txtGroupName.Value;
            shopNum1_Group_Product_0.GroupStock = Convert.ToInt32(txtGroupStock.Value);
            shopNum1_Group_Product_0.GroupPrice = Convert.ToDecimal(txtGroupPrice.Value);
            string input = txtGroupIntroduce.Value;
            string pattern = "<(?!img|br|a|p|/p).*?>";
            input = Regex.Replace(input, pattern, string.Empty, RegexOptions.IgnoreCase);
            shopNum1_Group_Product_0.Introduce = input;
            shopNum1_Group_Product_0.ShopName = Common.Common.GetNameById("shopname", "shopnum1_shopinfo",
                " and memloginid='" + base.MemLoginID + "'");
            shopNum1_Group_Product_0.MemLoginId = base.MemLoginID;
            shopNum1_Group_Product_0.Aname = hidAname.Value;
            if (ShopSettings.GetValue("AddSpellBuyProductIsAudit") == "0")
            {
                shopNum1_Group_Product_0.State = 1;
            }
            else
            {
                shopNum1_Group_Product_0.State = 0;
            }
            if (fileUpload.HasFile)
            {
                string fileName = Operator.FilterString(fileUpload.PostedFile.FileName);
                string str5 = Common.Common.GetNameById("ShopId", "shopnum1_shopinfo",
                    " and memloginid='" + base.MemLoginID + "'");
                if (
                    !Directory.Exists(
                        HttpContext.Current.Server.MapPath("/ImgUpload/shopImage/" + DateTime.Now.ToString("yyyy") +
                                                           "/shop" + str5 + "/")))
                {
                    Directory.CreateDirectory(
                        HttpContext.Current.Server.MapPath("/ImgUpload/shopImage/" + DateTime.Now.ToString("yyyy") +
                                                           "/shop" + str5 + "/"));
                }
                var info = new FileInfo(fileName);
                string str6 = DateTime.Now.ToString("yyyyMMddHHmmss") + info.Extension;
                string filename =
                    HttpContext.Current.Server.MapPath("/ImgUpload/shopImage/" + DateTime.Now.ToString("yyyy") + "/shop" +
                                                       str5 + "/tg" + str6);
                fileUpload.SaveAs(filename);
                string path = "/ImgUpload/shopImage/" + DateTime.Now.ToString("yyyy") + "/shop" + str5 + "/tg" + str6;
                string str9 = path + "_60x60.jpg";
                string str10 = path + "_100x100.jpg";
                string str11 = path + "_160x160.jpg";
                string str12 = path + "_300x300.jpg";
                shopNum1_Group_Product_0.GroupImg = path;
                shopNum1_Group_Product_0.GroupSmallImg = str10;
                ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(path),
                    HttpContext.Current.Server.MapPath(str9), 60, 60);
                ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(path),
                    HttpContext.Current.Server.MapPath(str10), 100, 100);
                ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(path),
                    HttpContext.Current.Server.MapPath(str11), 160, 160);
                ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(path),
                    HttpContext.Current.Server.MapPath(str12), 300, 300);
                if (Common.Common.ReqStr("id") == "")
                {
                    shop_GroupProduct_Action_0.AddGroupProduct(shopNum1_Group_Product_0);
                }
                else
                {
                    shopNum1_Group_Product_0.Id = Convert.ToInt32(Common.Common.ReqStr("id"));
                    shop_GroupProduct_Action_0.UpdateGroupProduct(shopNum1_Group_Product_0);
                }
            }
            else if (Common.Common.ReqStr("id") == "")
            {
                shopNum1_Group_Product_0.GroupImg = "";
                shopNum1_Group_Product_0.GroupSmallImg = "";
                shop_GroupProduct_Action_0.AddGroupProduct(shopNum1_Group_Product_0);
            }
            else
            {
                shopNum1_Group_Product_0.Id = Convert.ToInt32(Common.Common.ReqStr("id"));
                shop_GroupProduct_Action_0.UpdateGroupProduct(shopNum1_Group_Product_0);
            }
            Page.Response.Redirect("S_GroupProduct.aspx");
        }

        protected override void InitializeSkin(Control skin)
        {
            spanstock = (HtmlGenericControl) skin.FindControl("spanstock");
            btnSub = (Button) skin.FindControl("btnSub");
            btnSub.Click += btnSub_Click;
            hidGuid = (HtmlInputHidden) skin.FindControl("hidGuid");
            hidAid = (HtmlInputHidden) skin.FindControl("hidAid");
            hidAname = (HtmlInputHidden) skin.FindControl("hidAname");
            txtGroupName = (HtmlInputText) skin.FindControl("txtGroupName");
            txtGroupPrice = (HtmlInputText) skin.FindControl("txtGroupPrice");
            txtGroupStock = (HtmlInputText) skin.FindControl("txtGroupStock");
            txtVitualNum = (HtmlInputText) skin.FindControl("txtVitualNum");
            txtLimtNum = (HtmlInputText) skin.FindControl("txtLimtNum");
            txtGroupIntroduce = (HtmlTextArea) skin.FindControl("txtGroupIntroduce");
            fileUpload = (FileUpload) skin.FindControl("fileUpload");
            GroupPic = (HtmlImage) skin.FindControl("GroupPic");
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            if (Common.Common.ReqStr("id") != "")
            {
                DataTable groupProductById = shop_GroupProduct_Action_0.GetGroupProductById(Common.Common.ReqStr("id"),
                    base.MemLoginID);
                if (groupProductById.Rows.Count > 0)
                {
                    hidAid.Value = groupProductById.Rows[0]["aid"].ToString();
                    hidGuid.Value = groupProductById.Rows[0]["productguid"].ToString();
                    txtGroupName.Value = groupProductById.Rows[0]["name"].ToString();
                    txtGroupPrice.Value = groupProductById.Rows[0]["GroupPrice"].ToString();
                    txtGroupStock.Value = groupProductById.Rows[0]["GroupStock"].ToString();
                    txtGroupIntroduce.Value = groupProductById.Rows[0]["introduce"].ToString();
                    GroupPic.Src = groupProductById.Rows[0]["groupsmallimg"].ToString();
                }
            }
        }
    }
}