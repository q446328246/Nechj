using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ScoreOrder : BaseWebControl
    {
        private DropDownList DropDownListAddress1;
        private TextBox TextBoxMemLoginID;
        private TextBox TextBoxNumber;
        private string skinFilename = "ScoreOrder.ascx";

        public ScoreOrder()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void DropDownListAddress1Bind()
        {
            DropDownListAddress1.Items.Clear();
            DropDownListAddress1.Items.Add(new ListItem("-请选择-", "-1"));
            BindData("0", DropDownListAddress1);
        }

        protected override void InitializeSkin(Control skin)
        {
            TextBoxNumber = (TextBox) skin.FindControl("TextBoxNumber");
            TextBoxMemLoginID = (TextBox) skin.FindControl("TextBoxMemLoginID");
            DropDownListAddress1 = (DropDownList) skin.FindControl("DropDownListAddress1");
            DropDownListAddress1Bind();
        }

        protected void BindData(string string_1, DropDownList dropDownList_1)
        {
            DataTable regionFatherID =
                ((Shop_Category_Action) LogicFactory.CreateShop_Category_Action()).GetRegionFatherID(string_1);
            for (int i = 0; i < regionFatherID.Rows.Count; i++)
            {
                dropDownList_1.Items.Add(new ListItem(regionFatherID.Rows[i]["Name"].ToString(),
                    regionFatherID.Rows[i]["Code"] + "/" +
                    regionFatherID.Rows[i]["ID"]));
            }
        }
    }
}