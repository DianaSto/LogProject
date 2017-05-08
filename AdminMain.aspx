﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminMain.aspx.cs" Inherits="AdminMain" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
     <link href="Theme/Style.css" rel="stylesheet" type="text/css" />
    <div class="Base">
    <form id="form1" runat="server"  class="Main_Div">
 
   
        <h1>
        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal">
            <Items>
                <asp:MenuItem Text="Log work" Value="0"></asp:MenuItem>
                <asp:MenuItem Text="Manage users" Value="1"></asp:MenuItem>
                <asp:MenuItem Selected="True" Text="Manage projects" Value="2"></asp:MenuItem>
            </Items>
            <staticmenuitemstyle BorderWidth="10px" BorderColor="#6189df"  forecolor="Black"/>
        </asp:Menu>
        </h1>

      <div runat="server" id="ScrollList" class="Main_Menu_div">
      <asp:MultiView ID="multiTabs" runat="server" ActiveViewIndex="0">
           
          <asp:View ID="ViewPontaje" runat="server">

                
               
            <asp:GridView ID="GridViewPontaje" CssClass="grid" runat="server" AutoGenerateColumns="false"  PageSize="10" AllowPaging="true" DataSourceID="SqlDataSourceLogs" OnRowCommand="GridView_Logs">
                <EmptyDataRowStyle CssClass="EmptyData" />
                <EmptyDataTemplate>

                    <div>
                        No Data Available
                    </div>

                    <script>
                        $(".EmptyData").parents("table").css("border-width", "0px").prop("border", "0");
                    </script>

               </EmptyDataTemplate>

               <Columns>

                 <asp:BoundField DataField="name" HeaderText="Name" ItemStyle-Width="30%"/>
                 <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-Width="50%"/>

                 <asp:TemplateField ShowHeader="False">
                     <ItemTemplate>
                         <asp:Button ID="ButtonStart" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="Start" Text="Start working" ItemStyle-Width="10%" cssClass="Main_btn"></asp:Button>
                     </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="ButtonStop" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="Stop" Text="Stop working" ItemStyle-Width="10%" cssClass="Main_btn" />
                    </ItemTemplate>
                </asp:TemplateField>

              </Columns>
            
            </asp:GridView>


            <asp:SqlDataSource ID="SqlDataSourceLogs" runat="server" ConnectionString="<%$ ConnectionStrings:Pontaje_v2ConnectionString %>" SelectCommand="SELECT * FROM [Projects]">
            </asp:SqlDataSource>

          </asp:View>

            
          <asp:View ID="ViewUsers" runat="server">
            
              

               <asp:GridView ID="GridViewUsers" runat="server" CssClass="grid" PageSize="10" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AllowPaging="true" DataKeyNames="id" DataSourceID="SqlDataSourceUsers">
                   <Columns>
                      
                       <asp:BoundField DataField="first_name" HeaderText="First name" SortExpression="first_name" ItemStyle-Width="15%"/>
                       <asp:BoundField DataField="last_name" HeaderText="Last name" SortExpression="last_name" ItemStyle-Width="15%"/>
                       <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" ItemStyle-Width="25%" />
                       <asp:BoundField DataField="username" HeaderText="Username" SortExpression="username" ItemStyle-Width="25%"/>

                       <asp:TemplateField ItemStyle-CssClass="TemplateFieldOneColumn" HeaderText="Role" ItemStyle-Width="15%">

                         <ItemTemplate>
                             <asp:Label runat="server" Text='<% #GetLabelText(Eval("id_role")) %>' />
                         </ItemTemplate>

                       </asp:TemplateField>
                      
                   </Columns>

               </asp:GridView>

                 <br />
                 <br />

               
               <asp:TextBox ID="TextBoxUsername" Placeholder="USERNAME" runat="server" CssClass="Main_login_textbox"></asp:TextBox>
               <asp:Button ID="ButtonGrantAdminRights" runat="server" OnClick="ButtonGrantAdminRights_Click" Text="Grant Admin Rights" CssClass="GrantAdminRights_btn" />
               <asp:Button ID="ButtonRevokeAdminRights" runat="server" OnClick="ButtonRevokeAdminRights_Click" Text="Revoke Admin Rights" CssClass="RevokeAdminRights_btn"/>

               <asp:SqlDataSource ID="SqlDataSourceUsers" runat="server" ConnectionString="<%$ ConnectionStrings:Pontaje_v2ConnectionString %>" SelectCommand="SELECT * FROM [Users]"
                  DeleteCommand="delete from [Users] where [id]=@id" >

               </asp:SqlDataSource>

          </asp:View>

                          
         <asp:View ID="ViewProjects" runat="server">

                 
                                
                 <asp:ScriptManager ID="ScriptManager1" runat="server">
                 </asp:ScriptManager>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server"  >

                     <ContentTemplate>
                   
                        <asp:GridView ID="GridViewProjects" runat="server" CssClass="grid" PageSize="10" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AllowPaging="true" AutoGenerateEditButton="True" DataKeyNames="id" DataSourceID="SqlDataSource1" >
                     

                            <EmptyDataRowStyle CssClass="EmptyData" />
                            <EmptyDataTemplate>

                                <div>

                                        No Data Available

                                </div>
                                     
                                <script>
                                     $(".EmptyData").parents("table").css("border-width", "0px").prop("border", "0");
                                </script>

                            </EmptyDataTemplate>
                    
                            <Columns>
                        
                                 <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" ItemStyle-Width="30%"/>
                                 <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" ItemStyle-Width="70%" />
                            </Columns>

                        </asp:GridView>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Pontaje_v2ConnectionString %>" SelectCommand="SELECT * FROM [Projects]"
                         UpdateCommand="Update [Projects] set [name]=@name, [description]=@description where [id]=@id" DeleteCommand="delete from [Projects] where [id]=@id" >

                         </asp:SqlDataSource>

                
                                <br />
                                <br />
                                <br />
 
                                 
                           
                            <asp:TextBox ID="TextBoxName" Placeholder="PROJECT NAME" runat="server" CssClass="NewProject_name_textbox"></asp:TextBox>
                            <p>
                                <br/>
                            <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine" Placeholder="DESCRIPTION" CssClass="NewProject_description_textbox"></asp:TextBox>
                            </p>
                    
                            <asp:Button ID="ButtonSave" runat="server" Text="ADD NEW PROJECT" Enabled="True"  OnClick="ButtonSave_Click" CssClass="AddProject_btn" />
                            <asp:Button ID="ButtonCancel" runat="server" Text="CLEAR"  OnClick="ButtonCancel_Click" CssClass="Clear_btn" />
                             
                     </ContentTemplate>

                     <Triggers >
                
                         <asp:PostBackTrigger ControlID="ButtonSave"  />
                         <asp:PostBackTrigger ControlID="ButtonCancel"  />

                    </Triggers>

                </asp:UpdatePanel>

         </asp:View>
             


      </asp:MultiView>
  </div>
        
           <div class="Main_footer" runat="server">
            <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" cssClass="Main_login_btn"/>
           </div>
       
 </form>       
 </div>
</body>
</html>


