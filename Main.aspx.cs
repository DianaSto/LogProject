using System.Web.UI.DataVisualization.Charting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MindFusion.Scheduling;


public partial class Main : System.Web.UI.Page
{
    PontajeEntities entities = new PontajeEntities();
     Dictionary<Pontaje,string> data = new Dictionary<Pontaje,string>();
    //List<Pontaje> data = new List<Pontaje>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["username"]==null)
        {
            Response.Redirect("Login.aspx");
        }
       
        var name = Session["username"];
        var id_user = (from user in entities.Users where user.username == name.ToString() select user.id).FirstOrDefault();
       /* var pontaje= (from pontaj in entities.Pontajes where pontaj.id_user == id_user select pontaj).ToList();
        foreach (var p in pontaje)
        {
            data.Add(p);
        }*/
         var data_logged_work = (from pontaj in entities.Pontajes where pontaj.id_user == id_user select pontaj).ToList();
         foreach (var dlw in data_logged_work)
         {
             var proj = (from project in entities.Projects where project.id == dlw.id_project select project.name).FirstOrDefault();
             data.Add(dlw, proj);
         }
        getChartData();
    }

    protected void ButtonLogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }

    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
      
        var name = Session["username"];
        var id_user = (from user in entities.Users where user.username == name.ToString() select user.id).FirstOrDefault();
        int id_project = 0;
        int.TryParse(e.CommandArgument as string, out id_project);
        Pontaje pontaj = new Pontaje();
        DateTime localDate = DateTime.Now;
        int ui = Convert.ToInt32(id_user);
        pontaj.id_user = ui;
        pontaj.id_project = id_project;
        pontaj.start_time = localDate;

        switch (e.CommandName)
        {
            
            case "Start":
                {
                    Pontaje pontaj_for_finish_time_setting = (from p in entities.Pontajes where p.id_user == ui  && p.finish_time == null  select p).FirstOrDefault();
                    if (pontaj_for_finish_time_setting != null)
                    {
                        pontaj_for_finish_time_setting.finish_time = localDate;
                    }
                    entities.Pontajes.Add(pontaj);
                    entities.SaveChanges();
                    Response.Write("Work started");
                    break;
                }
            case "Stop":
                {
                    
                    Pontaje pontaj_for_finish_time_setting = (from p in entities.Pontajes where p.id_user==ui  && p.id_project==id_project && p.finish_time== null  select p).FirstOrDefault();
                    if (pontaj_for_finish_time_setting != null)
                    {
                        pontaj_for_finish_time_setting.finish_time = localDate;
                        entities.SaveChanges();
                        Response.Write("Work ended");
                    }
                   
                    break;
                }
        }
      
    }


    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        int index = Int32.Parse(e.Item.Value);
        multiTabs.ActiveViewIndex = index;
    }

    private void getChartData()
    {
       
        var name = Session["username"];
        var id_user = (from user in entities.Users where user.username == name.ToString() select user.id).FirstOrDefault();
        var data= entities.GetHoursPerProjectforUser(id_user);
        Series series = Chart1.Series["Series1"];
        foreach (var x in data)
        {
            series.Points.AddXY(x.name, x.worked_hours);
        }
    }

    protected void AttachEvents(object sender, DayRenderEventArgs e)
    {
        
        DateTime day;
       // var name = Session["username"];
       // var id_user = (from user in entities.Users where user.username == name.ToString() select user.id).FirstOrDefault();
        foreach (var p in data)
        { 
           // var proj= (from project in entities.Projects where project.id == p.id_project select project.name).FirstOrDefault();
            day = (DateTime)p.Key.start_time;
            
            if (day.Date == e.Day.Date)
            {
                e.Cell.Controls.Add(new LiteralControl("<p>" + p.Value + "\n" + p.Key.Hours_worked +"hours <p>"));
                e.Cell.Font.Bold = true;
            }
        }
    }
}