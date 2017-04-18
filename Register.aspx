<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:TextBox ID="TextBoxFirstName" placeholder="First Name" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidatorFirstName" runat="server"
          ControlToValidate="TextBoxFirstName"
          ErrorMessage="Required field."
          ForeColor="Red">
        </asp:RequiredFieldValidator>
        <p>
            <asp:TextBox ID="TextBoxLastName" placeholder="Last Name" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidatorLastName" runat="server"
            ControlToValidate ="TextBoxLastName"
            ErrorMessage="Required field."
            ForeColor="Red">
        </asp:RequiredFieldValidator>
        </p>
        <asp:TextBox ID="TextBoxEmail" placeholder="Email" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidatorEmail" runat="server"
          ControlToValidate="TextBoxEmail"
          ErrorMessage="Required field."
          ForeColor="Red">
        </asp:RequiredFieldValidator>
        <p>
            <asp:TextBox ID="TextBoxUsername" placeholder="Username" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidatorUsername" runat="server"
            ControlToValidate="TextBoxUsername"
            ErrorMessage="Required field."
            ForeColor="Red">
        </asp:RequiredFieldValidator>
        </p>
        <asp:TextBox ID="TextBoxPassword" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidatorPassword" runat="server"
          ControlToValidate="TextBoxPassword"
          ErrorMessage="Required field."
          ForeColor="Red">
        </asp:RequiredFieldValidator>
        <p>
            <asp:TextBox ID="TextBoxConfirmPassword" placeholder="Confirm Password" TextMode="Password" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidatorConfirmPassword" runat="server"
          ControlToValidate="TextBoxPassword"
          ErrorMessage="Required field."
          ForeColor="Red">
        </asp:RequiredFieldValidator>
        </p>
        <asp:CompareValidator runat="server" ID="Comp1" ControlToValidate="textBoxPassword" ControlToCompare="TextBoxConfirmPassword" Text="Password mismatch" />
        <p>
            <asp:Button ID="ButtonRegister" runat="server" OnClick="ButtonRegister_Click" Text="Register" Width="124px" />
        </p>
    </form>
</body>
</html>
