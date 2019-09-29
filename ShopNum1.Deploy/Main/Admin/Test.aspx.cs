using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Test : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BuildCart();
                BindData();
            }
        }

        public void AddCart(string name)
        {
            if (HttpContext.Current.Session["order"] == null)
            {
                BuildCart();
            }
            else
            {
                var order = HttpContext.Current.Session["order"] as DataTable;
                if (ExistProduct(order, name))
                {
                    UpdateSession(order, name);
                }
            }
        }

        protected void btnAddNewRow_Click(object sender, EventArgs e)
        {
            DataTable table = DefineDataTableSchema(hfRptColumns.Value);
            foreach (RepeaterItem item in rptTest.Items)
            {
                DataRow row = table.NewRow();
                row["name"] = ((TextBox) item.FindControl("txtExpenseAmount")).Text;
                table.Rows.Add(row);
            }
            DataRow row2 = table.NewRow();
            table.Rows.Add(row2);
            HttpContext.Current.Session["order"] = table;
            rptTest.DataSource = table;
            rptTest.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string s = string.Empty;
            foreach (RepeaterItem item in rptTest.Items)
            {
                var box = (TextBox) item.FindControl("txtExpenseAmount");
                s = s + box.Text;
                AddCart(box.Text);
            }
            base.Response.Write(s);
            BindData();
        }

        public void BuildCart()
        {
            if (HttpContext.Current.Session["order"] == null)
            {
                var table = new DataTable();
                table.Columns.Add("name");
                HttpContext.Current.Session["order"] = table;
            }
        }

        public DataTable DefineDataTableSchema(string columns)
        {
            var table = new DataTable();
            foreach (string str in columns.Split(new[] {','}))
            {
                table.Columns.Add(str);
            }
            return table;
        }

        public void Delete(string name)
        {
            if (HttpContext.Current.Session["order"] != null)
            {
                DataTable car = GetCar();
                for (int i = 0; i < car.Rows.Count; i++)
                {
                    if (car.Rows[i]["name"].ToString() == name)
                    {
                        car.Rows[i].Delete();
                    }
                }
                HttpContext.Current.Session["order"] = car;
            }
        }

        public bool ExistProduct(DataTable order, string name)
        {
            //using ()
            //{
            IEnumerator enumerator = order.Rows.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    var current = (DataRow) enumerator.Current;
                    if (current["name"].ToString().Equals(name))
                    {
                        return false;
                    }
                    return true;
                }
            //}
            return true;
        }

        public DataTable GetCar()
        {
            if (HttpContext.Current.Session["order"] != null)
            {
                return (HttpContext.Current.Session["order"] as DataTable);
            }
            return null;
        }

        private void BindData()
        {
            DataTable car = GetCar();
            rptTest.DataSource = car;
            rptTest.DataBind();
        }



        protected void rptTest_OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                Delete(e.CommandArgument.ToString());
                BindData();
                base.Response.Write("<script>alert('" + e.CommandArgument + "');</script>");
            }
        }

        public void UpdateSession(DataTable order, string strname)
        {
            DataRow row = order.NewRow();
            row[0] = strname;
            order.Rows.Add(row);
            HttpContext.Current.Session["order"] = order;
        }
    }
}