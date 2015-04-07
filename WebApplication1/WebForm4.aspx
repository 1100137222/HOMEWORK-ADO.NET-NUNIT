<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="WebApplication1.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查詢(ExecuteReader)" />
        <br />
        <asp:GridView ID="gvResult" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="464px">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <hr />
        ID:<asp:TextBox ID="txtID" runat="server" Enabled="false"></asp:TextBox>
        Name:<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        Age:<asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
        StudentNumber:<asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
        StudentAddress:<asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>   
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增(ExecuteScalar)" />


        <br />
        ID:<asp:TextBox ID="txtE_ID" runat="server"></asp:TextBox>
        Name:<asp:TextBox ID="txtE_Name" runat="server"></asp:TextBox>
        Age:<asp:TextBox ID="txtE_Age" runat="server"></asp:TextBox>
        StudentNumber:<asp:TextBox ID="txtE_Number" runat="server"></asp:TextBox>
        StudentAddress:<asp:TextBox ID="txtE_Address" runat="server"></asp:TextBox> 
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="修改(ExecuteNonQuery)" />


    </div>
    </form>
</body>
</html>
