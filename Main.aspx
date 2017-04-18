<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Successfully logged in as normal user
    </div>
        <asp:GridView ID="gvProjects" CssClass="Grid" runat="server" AutoGenerateColumns="false"  PageSize="10" AllowPaging="true" DataSourceID="dsProjects" OnRowCommand="GridView_RowCommand">
            <Columns>
                 <asp:BoundField DataField="name" HeaderText="Name" />
                 <asp:BoundField DataField="description" HeaderText="Description" />

                 <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="ButtonStart" runat="server" CommandName="Start"  CommandArgument='<%# Eval("id") %>'  Text="Start working" ></asp:Button>
                     </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="ButtonStop" runat="server" CommandName="Stop"  CommandArgument='<%# Eval("id") %>'  Text="Stop working" />
                    </ItemTemplate>
                </asp:TemplateField>
             </Columns>
            
         </asp:GridView>

        <asp:ObjectDataSource ID="dsProjects" runat="server" EnablePaging="true" SelectMethod="GetProjects"
            SelectCountMethod="GetProjectsCount" TypeName="Projects" MaximumRowsParameterName="maxRows"
            StartRowIndexParameterName="startIndex">

        </asp:ObjectDataSource>
        <p>
            <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" />
        </p>
    </form>
</body>
</html>
