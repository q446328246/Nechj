<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<asp:Repeater ID="RepeaterBrand" runat="server">
    <ItemTemplate>
    <%
         var dataSet = new DataSet();
                    dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Settings/ShopSetting.xml"));
                    DataRow dataRow = dataSet.Tables["ShopSetting"].Rows[0];
                    string INDEXURL = dataRow["shop2007"].ToString();
         %>
        <a href='<%=INDEXURL %>'
            target="_blank">
            <asp:Image ID="ImageBrand" onerror="javascript:this.src='/ImgUpload/noimg.jpg_100x100.jpg'" Width="100px" Height="50px" runat="server" ImageUrl='/ImgUpload/Main/2014_01/201401051024175.jpg' />
        </a>
        <a href='<%=INDEXURL %>'
            target="_blank">
            <asp:Image ID="Image1" onerror="javascript:this.src='/ImgUpload/noimg.jpg_100x100.jpg'" Width="100px" Height="50px" runat="server" ImageUrl='/ImgUpload/Main/2014_01/唐江LOGO.png' />
        </a>
        <a href='<%=INDEXURL %>'
            target="_blank">
            <asp:Image ID="Image2" onerror="javascript:this.src='/ImgUpload/noimg.jpg_100x100.jpg'" Width="100px" Height="50px" runat="server" ImageUrl='/ImgUpload/Main/2014_01/大唐公主.png' />
        </a>
    </ItemTemplate>
</asp:Repeater>
