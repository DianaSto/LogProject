using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["username"]==null)
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void ButtonLogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }

    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        PontajeEntities entities = new PontajeEntities();
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
}