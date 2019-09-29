using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopChartArea : PageBase, IRequiresSessionState
    {
        protected DataTable AreaTable = null;

        protected DataTable GetAreaTable()
        {
            DataRow row2;
            var action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
            var action2 = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            action.TableName="ShopNum1_Region";
            DataTable table = action.SearchtDispatchRegion(0, 0);
            DataTable table2 = method_5();
            if ((table != null) && (table.Rows.Count > 0))
            {
                foreach (DataRow row in table.Rows)
                {
                    string code = row["Code"].ToString();
                    string str2 = action2.GetShopCountByCode(code).ToString();
                    string str3 = row["Name"].ToString();
                    string str4 = row["ID"].ToString();
                    row2 = table2.NewRow();
                    row2["regionname"] = str3;
                    row2["id"] = str4;
                    row2["shopcount"] = str2;
                    table2.Rows.Add(row2);
                }
                return table2;
            }
            row2 = table2.NewRow();
            row2["regionname"] = "È«¹ú";
            row2["id"] = "1";
            row2["shopcount"] = "0";
            table2.Rows.Add(row2);
            return table2;
        }

        private DataTable method_5()
        {
            var table = new DataTable();
            table.Columns.Add("regionname", typeof (string));
            table.Columns.Add("id", typeof (string));
            table.Columns.Add("shopcount", typeof (string));
            return table;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            AreaTable = GetAreaTable();
        }
    }
}