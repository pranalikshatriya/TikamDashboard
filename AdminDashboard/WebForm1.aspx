<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AdminDashboard.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" ></asp:CheckBoxList>
            <asp:Button ID="Button1" Text="Disable Slots" OnClick="Button1_Click" runat="server"/>
        </div>
        
    </form>
</body>
</html>
