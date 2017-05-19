using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;



public partial class AdminMain : System.Web.UI.Page
{
    PontajeEntities entities = new PontajeEntities();
    Dictionary<Pontaje, string> data = new Dictionary<Pontaje, string>();

    protected void Page_Load(object sender, EventArgs e)
    {

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

    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        int index = Int32.Parse(e.Item.Value);
        multiTabs.ActiveViewIndex = index;
        GridViewPontaje.DataBind();
    }

    protected void GridView_Logs(object sender, GridViewCommandEventArgs e)
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
                    Pontaje pontaj_for_finish_time_setting = (from p in entities.Pontajes where p.id_user == ui && p.finish_time == null select p).FirstOrDefault();
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

                    Pontaje pontaj_for_finish_time_setting = (from p in entities.Pontajes where p.id_user == ui && p.id_project == id_project && p.finish_time == null select p).FirstOrDefault();
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


    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        var tbs = new List<System.Web.UI.WebControls.TextBox>() { TextBoxName, TextBoxDescription };
        foreach (var textBox in tbs)
        {
            textBox.Text = "";
        }
    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        PontajeEntities pe = new PontajeEntities();
        Project proiect = new Project();
        proiect.name = TextBoxName.Text;
        proiect.description = TextBoxDescription.Text;
        pe.Projects.Add(proiect);
        try
        {
            pe.SaveChanges();
        }
        catch (Exception err)
        {
            Response.Write("The project name can have a maximum of 50 characters, while the project description 255.");
        }
        GridViewProjects.DataBind();
        GridViewPontaje.DataBind();
      
    }




    protected void ButtonGrantAdminRights_Click(object sender, EventArgs e)
    {
        PontajeEntities pe = new PontajeEntities();
        var user = (from u in pe.Users where u.username == TextBoxUsername.Text select u).FirstOrDefault();
        if (user != null)
        {
            user.id_role = 1;
            pe.SaveChanges();
            GridViewUsers.DataBind();
        }
        else
        {
            Response.Write("Username does not exist!");
        }
    }

    protected void ButtonRevokeAdminRights_Click(object sender, EventArgs e)
    {
        PontajeEntities pe = new PontajeEntities();
        var user = (from u in pe.Users where u.username == TextBoxUsername.Text select u).FirstOrDefault();
        if (user != null)
        {
            user.id_role = 2;
            pe.SaveChanges();
            GridViewUsers.DataBind();
        }
        else
        {
            Response.Write("Username does not exist!");
        }
    }

    public string GetLabelText(object dataItem)
    {
        string text = "";
        int? val = dataItem as int?;
        switch (val)
        {
            case 1:
                text = "Admin";
                break;
            case 2:
                text = "Normal user";
                break;

        }
        return text;
    }

    protected void ButtonLogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
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
                e.Cell.Controls.Add(new LiteralControl("<p>" + p.Value + "\n" + p.Key.Hours_worked + "hours <p>"));
                e.Cell.Font.Bold = true;
            }
        }
    }
}