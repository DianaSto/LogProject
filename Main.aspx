<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

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
                <asp:MenuItem  Selected="True" Text="Log work" Value="0"></asp:MenuItem>
                <asp:MenuItem  Text="Calendar" Value="1"></asp:MenuItem>
                <asp:MenuItem  Text="Reports" Value="2"></asp:MenuItem>
                 
            </Items>
             <staticmenuitemstyle BorderWidth="10px" BorderColor="#6189df"  forecolor="Black"/>
        </asp:Menu>
           </h1>   
      
    
         
           
        <div runat="server" id="ScrollList" class="Main_Menu_div">
        <asp:MultiView ID="multiTabs" runat="server" ActiveViewIndex="0" >
                
              
         <asp:View ID="ViewPontaje" runat="server" >

            

        
        <asp:GridView ID="gvProjects" CssClass="grid" runat="server" AutoGenerateColumns="false"  RowStyle-Wrap="true" PageSize="10" AllowPaging="true" DataSourceID="SqlDataSourceLogs" OnRowCommand="GridView_RowCommand">

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
              
                 <asp:BoundField DataField="name" HeaderText="Name"  ItemStyle-Width="30%" />
                 <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-Width="50%"/>

                 <asp:TemplateField ShowHeader="False" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Button ID="ButtonStart" runat="server" CommandName="Start"  CommandArgument='<%# Eval("id") %>'  Text="Start working" CssClass="Main_btn"></asp:Button>
                     </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField ShowHeader="False" HeaderStyle-Width="50%" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Button ID="ButtonStop" runat="server" CommandName="Stop"  CommandArgument='<%# Eval("id") %>'  Text="Stop working" CssClass="Main_btn" />
                    </ItemTemplate>
                </asp:TemplateField>
             </Columns>
            
         </asp:GridView>
        
        
         <asp:SqlDataSource ID="SqlDataSourceLogs" runat="server" ConnectionString="<%$ ConnectionStrings:Pontaje_v2ConnectionString %>" SelectCommand="SELECT * FROM [Projects]">
         </asp:SqlDataSource>
        
        </asp:View>

            <asp:View ID="ViewCalendar" runat="server">
                <asp:Calendar ID="CalendarEvents"  OnDayRender="AttachEvents" runat="server"
                    Width="100%" Height="100%">
                    <TodayDayStyle ForeColor="White" BackColor="#FFCC66"></TodayDayStyle>
        <SelectorStyle BackColor="#FFCC66"></SelectorStyle>
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC"></NextPrevStyle>
        <DayHeaderStyle Height="1px" BackColor="#FFCC66"></DayHeaderStyle>
        <SelectedDayStyle Font-Bold="True" BackColor="#CCCCFF"></SelectedDayStyle>
        <TitleStyle Font-Size="9pt" Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></TitleStyle>
        <OtherMonthDayStyle ForeColor="#CC9966"></OtherMonthDayStyle>
                    

                </asp:Calendar>
            
            </asp:View>

            <asp:View ID="ViewReports" runat="server">
                <asp:Chart ID="Chart1" runat="server">
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
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
