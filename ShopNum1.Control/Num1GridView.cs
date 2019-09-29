using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Image = System.Web.UI.WebControls.Image;

namespace ShopNum1.Control
{
    [DefaultProperty("EditText2"), ToolboxData("<{0}:Num1GridView runat=server></{0}:Num1GridView>")]
    public class Num1GridView : GridView
    {
        private readonly System.Web.UI.WebControls.Button button_0 = new System.Web.UI.WebControls.Button();
        private readonly Label label_0 = new Label();
        private readonly TextBox textBox_0 = new TextBox();
        protected int? _recordCount = null;
        private bool bool_1;
        private int int_0 = -1;
        private int int_1;
        private string string_0 = "确实要删除指定的记录吗？";
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3;
        private string string_4;
        private string string_9 = string.Empty;

        public Num1GridView()
        {
            AutoGenerateColumns = false;
            PageSize = 10;
        }

        public bool AddSequenceColumn { get; set; }

        [Description("是否启用多列排序功能"), DefaultValue("true"), Category("排序")]
        public bool AllowMultiColumnSorting
        {
            get
            {
                object obj2 = ViewState["EnableMultiColumnSorting"];
                return ((obj2 != null) && bool.Parse(obj2.ToString()));
            }
            set
            {
                AllowSorting = true;
                ViewState["EnableMultiColumnSorting"] = value;
            }
        }

        public override object DataSource
        {
            get { return base.DataSource; }
            set
            {
                base.DataSource = value;
                if (value != null)
                {
                    if (DataSource is DataSet)
                    {
                        int_1 = ((DataSet) DataSource).Tables[0].Rows.Count;
                    }
                    if (DataSource is ICollection)
                    {
                        int_1 = ((ICollection) DataSource).Count;
                    }
                    if (DataSource is DataTable)
                    {
                        int_1 = ((DataTable) DataSource).Rows.Count;
                    }
                    if (DataSource is DataView)
                    {
                        int_1 = ((DataView) DataSource).Table.Rows.Count;
                    }
                }
            }
        }

        public bool Del { get; set; }

        public string DeletePromptText
        {
            get { return string_0; }
            set { string_0 = value; }
        }

        public bool Edit { get; set; }

        public string EditText1 { get; set; }

        public string EditText2 { get; set; }

        public string EditText3 { get; set; }

        public bool FixHeader
        {
            get { return bool_1; }
            set { bool_1 = value; }
        }

        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                {
                    ViewState["sortDirection"] = SortDirection.Ascending;
                }
                return (SortDirection) ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        public override int PageSize
        {
            get { return base.PageSize; }
            set { base.PageSize = value; }
        }

        [Category("扩展"), Description("自定义分页样式"), DefaultValue("")]
        public Paging.PagingStyleCollection PagingStyle { get; set; }

        [Description("升序时显示图标"), Category("排序"), DefaultValue(""),
         Editor("System.Web.UI.Design.UrlEditor", typeof (UITypeEditor))]
        public string SortAscImageUrl
        {
            get
            {
                object obj2 = ViewState["SortImageAsc"];
                return ((obj2 != null) ? obj2.ToString() : "");
            }
            set { ViewState["SortImageAsc"] = value; }
        }

        [Description("降序时显示图标"), DefaultValue(""), Category("排序"),
         Editor("System.Web.UI.Design.UrlEditor", typeof (UITypeEditor))]
        public string SortDescImageUrl
        {
            get
            {
                object obj2 = ViewState["SortImageDesc"];
                return ((obj2 != null) ? obj2.ToString() : "");
            }
            set { ViewState["SortImageDesc"] = value; }
        }

        public string SortExpressionCust { get; set; }

        public string TableName
        {
            get { return string_9; }
            set { string_9 = value; }
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            if (textBox_0.Text.Trim() == "")
            {
                label_0.Visible = true;
                label_0.Text = "请填写转到页数";
                textBox_0.Text = "0";
            }
            else
            {
                try
                {
                    int.Parse(textBox_0.Text.Trim());
                }
                catch (Exception)
                {
                    label_0.Visible = true;
                    label_0.Text = "请填写真实的页码";
                    textBox_0.Text = "0";
                }
            }
            if (int.Parse(textBox_0.Text.Trim()) < 1)
            {
                textBox_0.Text = "1";
            }
            label_0.Visible = true;
            button_0.CommandName = "Page";
            button_0.CommandArgument = textBox_0.Text.Trim();
        }

        protected void DisplaySortOrderImages(string sortExpression, GridViewRow dgItem)
        {
            string[] sortColumns = null;
            if ((sortExpression != string.Empty) && (sortExpression != null))
            {
                sortColumns = sortExpression.Split(",".ToCharArray());
            }
            for (int i = 0; i < dgItem.Cells.Count; i++)
            {
                if ((dgItem.Cells[i].Controls.Count > 0) && (dgItem.Cells[i].Controls[0] is LinkButton))
                {
                    string str;
                    int num2;
                    string commandArgument = ((LinkButton) dgItem.Cells[i].Controls[0]).CommandArgument;
                    SearchSortExpression(sortColumns, commandArgument, out str, out num2);
                    if (num2 > 0)
                    {
                        string str3 = str.Equals("ASC") ? SortAscImageUrl : SortDescImageUrl;
                        if (str3 != string.Empty)
                        {
                            var child = new Image
                                {
                                    ImageUrl = str3
                                };
                            dgItem.Cells[i].Controls.Add(child);
                        }
                        else if (AllowMultiColumnSorting)
                        {
                            var literal = new Literal
                                {
                                    Text = num2.ToString()
                                };
                            dgItem.Cells[i].Controls.Add(literal);
                        }
                    }
                }
            }
        }

        protected string GetSortExpression(GridViewSortEventArgs gridViewSortEventArgs_0)
        {
            string[] sortColumns = null;
            string sortExpression = gridViewSortEventArgs_0.SortExpression;
            if ((sortExpression != string.Empty) && (sortExpression != null))
            {
                sortColumns = sortExpression.Split(",".ToCharArray());
            }
            if ((sortExpression.IndexOf(gridViewSortEventArgs_0.SortExpression) > 0) ||
                sortExpression.StartsWith(gridViewSortEventArgs_0.SortExpression))
            {
                sortExpression = ModifySortExpression(sortColumns, gridViewSortEventArgs_0.SortExpression);
            }
            else
            {
                sortExpression = sortExpression + ("," + gridViewSortEventArgs_0.SortExpression + " ASC ");
            }
            return sortExpression.TrimStart(",".ToCharArray()).TrimEnd(",".ToCharArray());
        }

        private void method_0(object sender, EventArgs e)
        {
            ((LinkButton) sender).CssClass = "cur";
            PageSize = 20;
        }

        private void method_1(object sender, EventArgs e)
        {
            ((LinkButton) sender).CssClass = "cur";
            PageSize = 10;
        }

        private void method_2(object sender, EventArgs e)
        {
            ((LinkButton) sender).CssClass = "cur";
            PageSize = 50;
        }

        protected string ModifySortExpression(string[] sortColumns, string sortExpression)
        {
            string str = sortExpression + " ASC";
            string str2 = sortExpression + " DESC";
            for (int i = 0; i < sortColumns.Length; i++)
            {
                if (str.Equals(sortColumns[i]))
                {
                    sortColumns[i] = str2;
                }
                else if (str2.Equals(sortColumns[i]))
                {
                    Array.Clear(sortColumns, i, 1);
                }
            }
            return string.Join(",", sortColumns).Replace(",,", ",").TrimStart(",".ToCharArray());
        }

        protected void ods_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.ReturnValue is IListSource)
            {
                _recordCount = ((IListSource) e.ReturnValue).GetList().Count;
            }
        }

        protected override void OnInit(EventArgs eventArgs_0)
        {
            base.OnInit(eventArgs_0);
            string_1 = "Num1GridViewShow_sri";
            string_2 = "Num1GridViewShow_sr";
            string_3 = "Num1GridViewShow_mout";
            string_4 = "Num1GridViewShow_mover";
            for (int i = 0; i < Columns.Count; i++)
            {
                int_0 = i;
            }
        }

        protected override void OnLoad(EventArgs eventArgs_0)
        {
            if (!Page.ClientScript.IsClientScriptBlockRegistered("gridFunctions"))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(),UniqueID + "_rowFunc",
                                               "<script language=\"Javascript\" type=\"text/javascript\">var oldcolor;function Num1GridViewShow_mout(rowEl){for(var i=0;i<rowEl.cells.length;i++){rowEl.cells[i].style.backgroundColor=oldcolor;}}function Num1GridViewShow_mover(rowEl){for(var i=0;i<rowEl.cells.length;i++){oldcolor = rowEl.cells[i].style.backgroundColor;rowEl.cells[i].style.backgroundColor=\"#ebeef5\";}}</script>");
            }
            var source = Parent.FindControl(DataSourceID) as ObjectDataSource;
            if (source != null)
            {
                source.Selected += ods_Selected;
            }
            base.OnLoad(eventArgs_0);
        }

        protected override void OnRowCreated(GridViewRowEventArgs gridViewRowEventArgs_0)
        {
            int num;
            if (gridViewRowEventArgs_0.Row.RowType == DataControlRowType.Header)
            {
                DisplaySortOrderImages(SortExpressionCust, gridViewRowEventArgs_0.Row);
                CreateRow(0, 0, DataControlRowType.EmptyDataRow, DataControlRowState.Normal);
            }
            if (AllowPaging)
            {
                var dataSource = DataSource as IEnumerable;
                if (dataSource != null)
                {
                    IEnumerator enumerator = dataSource.GetEnumerator();
                    num = 0;
                    while (enumerator.MoveNext())
                    {
                        num++;
                    }
                    Page.Visible = num > 0;
                }
            }
            if ((gridViewRowEventArgs_0.Row.RowType == DataControlRowType.Header) && bool_1)
            {
                foreach (TableCell cell2 in gridViewRowEventArgs_0.Row.Cells)
                {
                    cell2.CssClass = "fhc";
                }
                var cell3 = new TableCell
                    {
                        Text = "操作列"
                    };
                gridViewRowEventArgs_0.Row.Cells.Add(cell3);
            }
            else if ((gridViewRowEventArgs_0.Row.RowType == DataControlRowType.Pager) && AllowPaging)
            {
                var child = new LinkButton();
                var button2 = new LinkButton();
                var button4 = new LinkButton();
                var button5 = new LinkButton();
                child.CausesValidation = false;
                button2.CausesValidation = false;
                button4.CausesValidation = false;
                button5.CausesValidation = false;
                var cell = new TableCell();
                gridViewRowEventArgs_0.Row.Controls.Clear();
                cell.Height = 30;
                cell.Controls.Add(new LiteralControl("<div class=\"btnlist\">"));
                var control = new HtmlGenericControl("div");
                control.Attributes.Add("class", "fnum");
                control.Controls.Add(new LiteralControl(" 每页显示数量："));
                var button6 = new LinkButton
                    {
                        Text = "10",
                        ID = "linkBtnTen",
                        CausesValidation = false
                    };
                button6.Click += method_1;
                control.Controls.Add(button6);
                var button7 = new LinkButton
                    {
                        Text = "20",
                        ID = "linkBtnTwenty",
                        CausesValidation = false
                    };
                button7.Click += method_0;
                control.Controls.Add(button7);
                var button8 = new LinkButton
                    {
                        Text = "50",
                        ID = "linkBtnForty",
                        CausesValidation = false
                    };
                button8.Click += method_2;
                control.Controls.Add(button8);
                cell.Controls.Add(control);
                cell.Controls.Add(new LiteralControl("<div class=\"fpage\"> <span style=\"padding-right: 10px;\">第"));
                int num2 = PageIndex + 1;
                cell.Controls.Add(new LiteralControl("<font >" + num2.ToString() + "</font>"));
                cell.Controls.Add(new LiteralControl("页"));
                cell.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                cell.Controls.Add(new LiteralControl("当前页共"));
                num2 = PageIndex + 1;
                if (num2.ToString() == PageCount.ToString())
                {
                    cell.Controls.Add(new LiteralControl("<font >" + Rows.Count + "</font>"));
                }
                else
                {
                    cell.Controls.Add(new LiteralControl("<font >" + PageSize + "</font>"));
                }
                cell.Controls.Add(new LiteralControl("条数据</span>"));
                cell.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                cell.Controls.Add(new LiteralControl("共"));
                cell.Controls.Add(new LiteralControl("<font >" + PageCount.ToString() + "</font>"));
                cell.Controls.Add(new LiteralControl("页</span>"));
                cell.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
                if (!string.IsNullOrEmpty(PagerSettings.FirstPageImageUrl))
                {
                    child.Text = "<<";
                }
                else
                {
                    child.Text = PagerSettings.FirstPageText;
                }
                child.CommandName = "Page";
                child.CommandArgument = "First";
                child.Font.Underline = false;
                if (!string.IsNullOrEmpty(PagerSettings.PreviousPageImageUrl))
                {
                    button2.Text = "<img src='" + base.ResolveUrl(PagerSettings.PreviousPageImageUrl) + "' border='0'/>";
                }
                else
                {
                    button2.Text = "<<上一页";
                }
                button2.CommandName = "Page";
                button2.CommandArgument = "Prev";
                button2.Font.Underline = false;
                button2.CssClass = "gred_prev";
                button4.Text = "下一页>>";
                button4.CommandName = "Page";
                button4.CommandArgument = "Next";
                button4.Font.Underline = false;
                button4.CssClass = "gred_prev";
                button5.Text = ">>";
                button5.CommandName = "Page";
                button5.CommandArgument = "Last";
                button5.Font.Underline = false;
                if (PageIndex <= 0)
                {
                    button2.Enabled = false;
                    child.Enabled = false;
                }
                else
                {
                    button2.Enabled = true;
                    child.Enabled = true;
                }
                num2 = PageIndex + 1;
                if (num2.ToString() != "1")
                {
                    cell.Controls.Add(child);
                    cell.Controls.Add(button2);
                }
                int num3 = PagerSettings.PageButtonCount/2;
                int num4 = ((PagerSettings.PageButtonCount%2) == 0) ? (num3 - 1) : num3;
                for (num = 0; num < PageCount; num++)
                {
                    if ((PageCount <= PagerSettings.PageButtonCount) ||
                        (((num >= (PageIndex - num4)) ||
                          (((PageCount - 1) - num) <= (PagerSettings.PageButtonCount - 1))) &&
                         ((num <= (PageIndex + num3)) || (num <= (PagerSettings.PageButtonCount - 1)))))
                    {
                        if (num == PageIndex)
                        {
                            num2 = num + 1;
                            cell.Controls.Add(new LiteralControl("<span class=\"cur\">" + num2.ToString() + "</span>"));
                        }
                        else
                        {
                            var button3 = new LinkButton();
                            num2 = num + 1;
                            button3.Text = num2.ToString();
                            button3.CommandName = "Page";
                            button3.CommandArgument = (num + 1).ToString();
                            button3.CausesValidation = false;
                            cell.Controls.Add(button3);
                        }
                    }
                }
                if (PageIndex >= (PageCount - 1))
                {
                    button5.Enabled = false;
                    button4.Enabled = false;
                }
                else
                {
                    button5.Enabled = true;
                    button4.Enabled = true;
                    cell.Controls.Add(button4);
                    cell.Controls.Add(button5);
                }
                cell.ColumnSpan = Columns.Count;
                cell.Controls.Add(new LiteralControl("到第"));
                textBox_0.Width = 0x23;
                textBox_0.Text = "";
                cell.Controls.Add(textBox_0);
                label_0.Visible = false;
                label_0.ForeColor = ColorTranslator.FromHtml("red");
                label_0.Width = 20;
                cell.Controls.Add(label_0);
                cell.Controls.Add(new LiteralControl("页"));
                button_0.Text = "确定";
                button_0.CssClass = "quedbtn";
                cell.Controls.Add(button_0);
                cell.Controls.Add(new LiteralControl("</div>"));
                cell.Controls.Add(new LiteralControl("<div class=\"clear\"></div>"));
                cell.Controls.Add(new LiteralControl("</div>"));
                gridViewRowEventArgs_0.Row.Controls.Add(cell);
                button_0.Click += button_0_Click;
                button_0.CausesValidation = false;
            }
            base.OnRowCreated(gridViewRowEventArgs_0);
        }

        protected override void OnRowDataBound(GridViewRowEventArgs gridViewRowEventArgs_0)
        {
            if (AllowPaging)
            {
                var dataSource = DataSource as IEnumerable;
                if (dataSource != null)
                {
                    IEnumerator enumerator = dataSource.GetEnumerator();
                    int num = 0;
                    while (enumerator.MoveNext())
                    {
                        num++;
                    }
                    Page.Visible = num > 0;
                }
            }

            //string[] array = new string[] { -2147483648.ToString(), -79228162514264337593543950335M.ToString(), -79228162514264337593543950335M.ToString("0.00"), -79228162514264337593543950335M.ToString("0.000"), -79228162514264337593543950335M.ToString("0.0000"), DateTime.MinValue.ToString(), DateTime.MinValue.ToShortDateString(), DateTime.MinValue.ToString("yyyy年M月d日"), DateTime.MinValue.ToString("yyyy年MM月dd日") };
            //foreach (TableCell cell in gridViewRowEventArgs_0.Row.Cells)
            //{
            //    if (Array.IndexOf<string>(array, cell.Text) >= 0)
            //    {
            //        cell.Text = "";
            //    }
            //}

            if (gridViewRowEventArgs_0.Row.RowType == DataControlRowType.DataRow)
            {
                gridViewRowEventArgs_0.Row.Style.Add("cursor", "default");
                gridViewRowEventArgs_0.Row.Attributes["onmouseover"] = string_4 + "(this)";
                gridViewRowEventArgs_0.Row.Attributes["onmouseout"] = string_3 + "(this)";
                if (int_0 >= 0)
                {
                    try
                    {
                        var button = (ImageButton) gridViewRowEventArgs_0.Row.Cells[0].FindControl("imb_Delete");
                        button.Attributes.Add("onclick", "return confirm('" + string_0 + "');");
                        button.CommandArgument = gridViewRowEventArgs_0.Row.RowIndex.ToString();
                        if (!Del)
                        {
                            button.Visible = false;
                        }
                        else
                        {
                            button.Visible = true;
                        }
                    }
                    catch
                    {
                    }
                    var image = (HtmlImage) gridViewRowEventArgs_0.Row.FindControl("htmlEdit");
                    if (image != null)
                    {
                        try
                        {
                            var num4 =
                                (int) DataKeys[Convert.ToInt32(gridViewRowEventArgs_0.Row.RowIndex.ToString())].Value;
                            image.Attributes.Add("onclick",
                                                 string.Concat(new object[]
                                                     {EditText1, num4, EditText2, PageIndex, EditText3}));
                        }
                        catch
                        {
                            var num5 =
                                (long) DataKeys[Convert.ToInt32(gridViewRowEventArgs_0.Row.RowIndex.ToString())].Value;
                            image.Attributes.Add("onclick",
                                                 string.Concat(new object[]
                                                     {EditText1, num5, EditText2, PageIndex, EditText3}));
                        }
                    }
                    if (!Edit)
                    {
                        if (image != null)
                        {
                            image.Visible = false;
                        }
                    }
                    else if (image != null)
                    {
                        image.Visible = true;
                    }
                }
            }
            base.OnRowDataBound(gridViewRowEventArgs_0);
        }

        protected override void OnRowDeleted(GridViewDeletedEventArgs gridViewDeletedEventArgs_0)
        {
            if ((Rows.Count == 1) && (PageIndex > 0))
            {
                PageIndex--;
            }
            base.OnRowDeleted(gridViewDeletedEventArgs_0);
        }

        protected override void OnSorting(GridViewSortEventArgs gridViewSortEventArgs_0)
        {
            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                gridViewSortEventArgs_0.SortExpression = gridViewSortEventArgs_0.SortExpression + " DESC";
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                gridViewSortEventArgs_0.SortExpression = gridViewSortEventArgs_0.SortExpression + " ASC";
            }
            base.OnSorting(gridViewSortEventArgs_0);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (!base.DesignMode)
            {
                if ((Rows.Count == 0) || (Rows[0].RowType == DataControlRowType.EmptyDataRow))
                {
                    RenderEmptyContent(writer);
                }
                else
                {
                    CssClass = "gridview_m";
                    base.Render(writer);
                }
            }
            else
            {
                CssClass = "gridview_m";
                base.Render(writer);
            }
        }

        protected virtual void RenderEmptyContent(HtmlTextWriter writer)
        {
            if (!base.DesignMode)
            {
                var builder = new StringBuilder();
                int num = 0;
                builder.Append(
                    "<table cellspacing=\"0\" cellpadding=\"4\" border=\"0\" style=\"background-color:White;border-color:#DEDFDE;border-width:1px;border-style:None;width:98%;border-collapse:collapse;\" id=\"num1GridViewShow\" descendingimageurl=\"~/images/SortDesc.gif\" ascendingimageurl=\"~/images/SortAsc.gif\" rules=\"cols\" class=\"gridview_m\" >");
                builder.Append("<tr align=\"center\" style=\"color: White;\" class=\"list_header\" >");
                foreach (DataControlField field in Columns)
                {
                    if (field.Visible && (field.ItemStyle.CssClass != "hidden"))
                    {
                        if (field.HeaderText != "")
                        {
                            builder.Append("<th scope=\"col\">" + field.HeaderText + "</th>");
                        }
                        num++;
                    }
                }
                builder.Append("</tr>");
                builder.Append("<tr>");
                EmptyDataText = "无查询的记录！";
                builder.Append("<td colspan=\"" + num.ToString() +
                               "\" align=\"center\"  height=\"30\" ><strong style=\"font-size:13px;\">" + EmptyDataText +
                               "</strong></td>");
                builder.Append("</tr>");
                builder.Append("<tr>");
                builder.Append("<thcolspan=\"" + num.ToString() + "\" height=\"30\"></th>");
                builder.Append("</tr>");
                builder.Append("</table>");
                new LiteralControl(builder.ToString()).RenderControl(writer);
            }
        }

        protected void SearchSortExpression(string[] sortColumns, string sortColumn, out string sortOrder,
                                            out int sortOrderNo)
        {
            sortOrder = "";
            sortOrderNo = 1;
            if (sortColumns == null)
            {
                if (GridViewSortDirection == SortDirection.Ascending)
                {
                    sortOrder = "DESC";
                }
                else
                {
                    sortOrder = "ASC";
                }
            }
            else
            {
                for (int i = 0; i < sortColumns.Length; i++)
                {
                    if (sortColumns[i].StartsWith(sortColumn))
                    {
                        sortOrderNo = i + 1;
                        if (AllowMultiColumnSorting)
                        {
                            if (GridViewSortDirection == SortDirection.Ascending)
                            {
                                sortOrder = "DESC";
                            }
                            else
                            {
                                sortOrder = "ASC";
                            }
                        }
                        else if (GridViewSortDirection == SortDirection.Ascending)
                        {
                            sortOrder = "DESC";
                        }
                        else
                        {
                            sortOrder = "ASC";
                        }
                    }
                }
            }
        }
    }
}