<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <link href="Theme/Style.css" rel="stylesheet" type="text/css" />
    <div class="Base">
    <div class="Register_div">
    <form id="form1" runat="server" class="Register_Form">
    
        <h1>Register</h1>
       
        <asp:TextBox ID="TextBoxFirstName" placeholder="First Name" runat="server" CssClass="Register_TextFields"></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidatorFirstName" runat="server"
          ControlToValidate="TextBoxFirstName"
          ErrorMessage="Required field."
          ForeColor="Red">
        </asp:RequiredFieldValidator>
        <p>
            <asp:TextBox ID="TextBoxLastName" placeholder="Last Name" runat="server" CssClass="Register_TextFields"></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidatorLastName" runat="server"
            ControlToValidate ="TextBoxLastName"
            ErrorMessage="Required field."
            ForeColor="Red">
        </asp:RequiredFieldValidator>
        </p>
        <asp:TextBox ID="TextBoxEmail" placeholder="Email" runat="server" CssClass="Register_TextFields"></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidatorEmail" runat="server"
          ControlToValidate="TextBoxEmail"
          ErrorMessage="Required field."
          ForeColor="Red">
        </asp:RequiredFieldValidator>
        <p>
            <asp:TextBox ID="TextBoxUsername" placeholder="Username" runat="server" CssClass="Register_TextFields"></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidatorUsername" runat="server"
            ControlToValidate="TextBoxUsername"
            ErrorMessage="Required field."
            ForeColor="Red">
        </asp:RequiredFieldValidator>
            <asp:Label ID="LabelUsernameExists" runat="server" Text="Username already exists!" Visible="False" CssClass="Register_lbl"></asp:Label>
        </p>
        <asp:TextBox ID="TextBoxPassword" placeholder="Password" TextMode="Password" runat="server" CssClass="Register_TextFields"></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidatorPassword" runat="server"
          ControlToValidate="TextBoxPassword"
          ErrorMessage="Required field."
          ForeColor="Red">
        </asp:RequiredFieldValidator>
        <p>
            <asp:TextBox ID="TextBoxConfirmPassword" placeholder="Confirm Password" TextMode="Password" runat="server" CssClass="Register_TextFields" ></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidatorConfirmPassword" runat="server"
          ControlToValidate="TextBoxConfirmPassword"
          ErrorMessage="Required field."
          ForeColor="Red">
        </asp:RequiredFieldValidator>
            <asp:Label ID="LabelMismatch" runat="server" Text="Password mismatch!" Visible="False" CssClass="Register_lbl"></asp:Label>
            <br/>
        </p>
        <p>
            <asp:Button ID="ButtonRegister" runat="server"  Text="REGISTER" Width="124px"  OnClick="ButtonRegister_Click" CssClass="Register_button"/>
        </p>
    </form>
    </div>
    </div>
</body>
</html>
