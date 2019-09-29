using System;
using System.Collections;
using System.Data;
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
    public class S_Album_2 : BaseShopWebControl
    {
        private HiddenField HiddenAlbumPic;
        private RadioButtonList RadioButtonListIfSetWaterMark;
        private Button btnSave;
        private HtmlInputHidden hidCheck;
        private HtmlInputHidden hidImg_potisiton;
        private HtmlInputHidden hidPath;
        private HtmlInputHidden hidSelectFont;
        private HtmlInputHidden hidTxt_potisiton;
        private HtmlImage imgsrc;
        private HtmlSelect selectfont;
        private string skinFilename = "S_Album_2.ascx";
        private string string_1 = string.Empty;
        private string string_2;
        private HtmlInputText txtColor;
        private HtmlInputText txtFontSize;
        private HtmlInputText txtFontTxt;
        private HtmlInputText txtImageWaterMarkClarity;

        public S_Album_2()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var set = new DataSet();
                set.ReadXml(Page.Server.MapPath(hidPath.Value));
                DataRow row = set.Tables["Setting"].Rows[0];
                row["IfSetWaterMark"] = hidCheck.Value;
                try
                {
                    string path = HiddenAlbumPic.Value + "_60x60.jpg";
                    if (
                        ImageOperator.CreateThumbnailAutoAlbum(HttpContext.Current.Server.MapPath(HiddenAlbumPic.Value),
                            HttpContext.Current.Server.MapPath(path), 60, 60) != 0)
                    {
                        row["WaterMarkOriginalImge"] = path;
                    }
                    else
                    {
                        row["WaterMarkOriginalImge"] = HiddenAlbumPic.Value;
                    }
                    imgsrc.Src = row["WaterMarkOriginalImge"].ToString();
                }
                catch
                {
                }
                row["WaterMarkImagePosition"] = hidImg_potisiton.Value;
                row["ImageWaterMarkClarity"] = txtImageWaterMarkClarity.Value;
                row["WaterMarkWords"] = txtFontTxt.Value;
                row["WaterMarkWordsFont"] = hidSelectFont.Value;
                row["WaterMarkWordsFontSize"] = txtFontSize.Value;
                row["WaterMarkWordsColor"] = txtColor.Value;
                row["WordsWaterMarkPosition"] = hidTxt_potisiton.Value;
                set.AcceptChanges();
                set.WriteXml(Page.Server.MapPath(hidPath.Value));
                BindData();
                MessageBox.Show("修改成功！");
            }
            catch (Exception exception)
            {
                Page.Response.Write(exception.Message);
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            hidPath = (HtmlInputHidden) skin.FindControl("hidPath");
            hidSelectFont = (HtmlInputHidden) skin.FindControl("hidSelectFont");
            hidCheck = (HtmlInputHidden) skin.FindControl("hidCheck");
            hidImg_potisiton = (HtmlInputHidden) skin.FindControl("hidImg_potisiton");
            hidTxt_potisiton = (HtmlInputHidden) skin.FindControl("hidTxt_potisiton");
            imgsrc = (HtmlImage) skin.FindControl("imgsrc");
            txtFontSize = (HtmlInputText) skin.FindControl("txtFontSize");
            txtFontTxt = (HtmlInputText) skin.FindControl("txtFontTxt");
            txtColor = (HtmlInputText) skin.FindControl("txtColor");
            txtImageWaterMarkClarity = (HtmlInputText) skin.FindControl("txtImageWaterMarkClarity");
            RadioButtonListIfSetWaterMark = (RadioButtonList) skin.FindControl("RadioButtonListIfSetWaterMark");
            HiddenAlbumPic = (HiddenField) skin.FindControl("HiddenAlbumPic");
            selectfont = (HtmlSelect) skin.FindControl("selectfont");
            string_1 = "";
            btnSave = (Button) skin.FindControl("btnSave");
            btnSave.Click += btnSave_Click;
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            try
            {
                DataTable memLoginInfo =
                    ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetMemLoginInfo(base.MemLoginID);
                if (((memLoginInfo != null) && (memLoginInfo.Rows.Count > 0)) && (hidPath.Value == ""))
                {
                    string str = memLoginInfo.Rows[0]["ShopID"].ToString();
                    string str2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                    new XmlDataSource();
                    string str3 = "/Shop/Shop/" + str2.Replace("-", "/") + "/shop" + str + "/Site_Settings.xml";
                    string_2 = str3;
                    hidPath.Value = string_2;
                }
                if (hidPath.Value != "")
                {
                    var set = new DataSet();
                    set.ReadXml(Page.Server.MapPath(hidPath.Value));
                    DataRow row = set.Tables["Setting"].Rows[0];
                    hidCheck.Value = row["IfSetWaterMark"].ToString();
                    imgsrc.Src = row["WaterMarkOriginalImge"].ToString();
                    HiddenAlbumPic.Value = row["WaterMarkOriginalImge"].ToString();
                    hidImg_potisiton.Value = row["WaterMarkImagePosition"].ToString();
                    txtImageWaterMarkClarity.Value = row["ImageWaterMarkClarity"].ToString();
                    txtFontTxt.Value = row["WaterMarkWords"].ToString();
                    txtFontSize.Value = row["WaterMarkWordsFontSize"].ToString();
                    txtColor.Value = row["WaterMarkWordsColor"].ToString();
                    hidTxt_potisiton.Value = row["WordsWaterMarkPosition"].ToString();
                    hidSelectFont.Value = row["WaterMarkWordsFont"].ToString();
                    ArrayList list = WaterMarkFont.Font();
                    for (int i = 0; i < list.Count; i++)
                    {
                        selectfont.Items.Add(list[i].ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                Page.Response.Write(exception.Message);
            }
        }
    }
}