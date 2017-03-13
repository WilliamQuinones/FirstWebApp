<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FirstWebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
    
        <br />
    
        <br />
    
    </div>
        <div>

            <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
            <asp:CheckBox ID="Persist" runat="server" />

            Remember me<br />

            
            <asp:Label ID="Msg" ForeColor="red" runat="server" />
            <br />

        </div>

        <div>

            <asp:Button ID="Button1" runat="server" Text="Sign-in" OnClick="Button1_Click" />

        </div>
    </form>
</body>
</html>
