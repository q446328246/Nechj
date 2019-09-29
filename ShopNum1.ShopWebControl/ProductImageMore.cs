using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ProductImageMore : BaseWebControl
    {
        private Image ProductBigImage;
        private Repeater RepeaterData;
        private string skinFilename = "ProductImageMore.ascx";

        public ProductImageMore()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            ProductBigImage = (Image) skin.FindControl("ProductBigImage");
            DataTable productDetail =
                ((Shop_Product_Action) LogicFactory.CreateShop_Product_Action()).GetProductDetail(
                    Page.Request.QueryString["guid"]);
            if (productDetail.Rows.Count > 0)
            {
                string[] strArray = productDetail.Rows[0]["Images"].ToString().Split(new[] {','});
                var table2 = new DataTable();
                table2.Columns.Add("imgurl", Type.GetType("string"));
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (i == 0)
                    {
                        ProductBigImage.ImageUrl = strArray[i];
                    }
                    table2.NewRow()["imgurl"] = strArray[i];
                }
                RepeaterData.DataSource = table2;
                RepeaterData.DataBind();
            }
        }
    }
}