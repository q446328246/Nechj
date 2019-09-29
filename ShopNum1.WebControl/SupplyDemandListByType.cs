using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class SupplyDemandListByType : BaseWebControl
    {
        private Repeater RepeaterShow;
        private Repeater RepeaterTitle;
        private string skinFilename = "SupplyDemandListByType.ascx";

        public SupplyDemandListByType()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string CfTitle { get; set; }

        public string Code { get; set; }

        public string Href { get; set; }

        public bool IsShowRepeaterTitle { get; set; }

        public string Release { get; set; }

        public int ShowCount { get; set; }

        public void BindData()
        {
            var table = new DataTable();
            table.Columns.Add("Href", Type.GetType("System.String"));
            table.Columns.Add("CfTitle", Type.GetType("System.String"));
            table.Columns.Add("Release", Type.GetType("System.String"));
            DataRow row = table.NewRow();
            row["Href"] = Href;
            row["CfTitle"] = CfTitle;
            row["Release"] = Release;
            table.Rows.Add(row);
            RepeaterTitle.DataSource = table;
            RepeaterTitle.DataBind();
            DataTable table2 =
                ((ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action())
                    .SearchByType(Code, ShowCount.ToString());
            RepeaterShow.DataSource = table2;
            RepeaterShow.DataBind();
        }

        public static string GetSubstr(object title, int length, bool isEllipsis)
        {
            string str = title.ToString();
            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }
            if (isEllipsis)
            {
                str = str + "...";
            }
            return str;
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            RepeaterTitle = (Repeater) skin.FindControl("RepeaterTitle");
            BindData();
        }
    }
}