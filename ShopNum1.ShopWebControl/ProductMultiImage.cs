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
    public class ProductMultiImage : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "ProductMultiImage.ascx";
        private string string_1;

        public ProductMultiImage()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ProductGuid { get; set; }

        protected void Bind()
        {
            DataTable productDetail =
                ((Shop_Product_Action) LogicFactory.CreateShop_Product_Action()).GetProductDetail(string_1);
            if (productDetail.Rows.Count > 0)
            {
                string[] strArray = productDetail.Rows[0]["multiimages"].ToString().Split(new[] {','});
                var table2 = new DataTable();
                var column = new DataColumn
                {
                    ColumnName = "imgurl",
                    DataType = Type.GetType("System.String")
                };
                table2.Columns.Add(column);
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] != "")
                    {
                        DataRow row = table2.NewRow();
                        row["imgurl"] = strArray[i];
                        table2.Rows.Add(row);
                    }
                }
                RepeaterData.DataSource = table2;
                RepeaterData.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            string_1 = (Page.Request.QueryString["guid"] == null)
                ? ProductGuid
                : Page.Request.QueryString["guid"].Replace("'", "");
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            Bind();
        }
    }
}