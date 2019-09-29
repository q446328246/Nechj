using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MemberChartArea : PageBase, IRequiresSessionState
    {
        protected DataTable AreaTable = null;

        protected DataTable GetAreaTable()
        {
            DataRow row3;
            var action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
            var action2 = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            action.TableName="ShopNum1_Region";
            DataTable table = action.SearchtDispatchRegion(0, 0);
            DataTable table2 = method_5();
            if ((table != null) && (table.Rows.Count > 0))
            {
                foreach (DataRow row2 in table.Rows)
                {
                    string code = row2["Code"].ToString();
                    string str3 = action2.GetMemberCountByCode(code, "0").ToString();
                    string str4 = row2["Name"].ToString();
                    string str5 = row2["ID"].ToString();
                    row3 = table2.NewRow();
                    row3["regionname"] = str4;
                    row3["id"] = str5;
                    row3["membercount"] = str3;
                    table2.Rows.Add(row3);
                }
                string str = action2.GetMemberCountByCode("0", "1").ToString();
                DataRow row = table2.NewRow();
                row["regionname"] = "其它";
                row["id"] = "1";
                row["membercount"] = str;
                table2.Rows.Add(row);
                return table2;
            }
            row3 = table2.NewRow();
            row3["regionname"] = "全国";
            row3["id"] = "1";
            row3["membercount"] = "0";
            table2.Rows.Add(row3);
            return table2;
        }

        private DataTable method_5()
        {
            var table = new DataTable();
            table.Columns.Add("regionname", typeof (string));
            table.Columns.Add("id", typeof (string));
            table.Columns.Add("membercount", typeof (string));
            return table;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            AreaTable = GetAreaTable();
        }
    }
}