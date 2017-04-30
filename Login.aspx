<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:TextBox ID="TextBoxUsername" Placeholder="Username" runat="server" OnTextChanged="TextBoxUsername_TextChanged"></asp:TextBox>
        <p>
            <asp:TextBox ID="TextBoxPassword" TextMode="Password" Placeholder="Password" runat="server" OnTextChanged="TextBoxPassword_TextChanged"></asp:TextBox>
        </p>
        <asp:Button ID="ButtonLogin" runat="server"  Height="30px" Text="Login" Width="90px" OnClick="ButtonLogin_Click" />
        <p>
            <asp:Button ID="ButtonRegister" runat="server" Height="30px" Text="Register"  Width="90px" OnClick="ButtonRegister_Click"/>

        </p>
        <p>
            <asp:Label ID="LabelWrong" runat="server" Text="Wrong username or password" Visible="False"></asp:Label>
        </p>
    </form>
</body>
</html>
