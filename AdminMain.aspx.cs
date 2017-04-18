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
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        int index = Int32.Parse(e.Item.Value);
        multiTabs.ActiveViewIndex = index;
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
        //Response.Redirect("AdminMain.aspx");
    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        //    PontajeEntities pe = new PontajeEntities();
        //    Project proiect = new Project();
        //    proiect.name = TextBoxName.Text;
        //    proiect.description = TextBoxDescription.Text;
        //    pe.Projects.Add(proiect);
        //    pe.SaveChanges();


        using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SJS4A6Q\SQLEXPRESS;Initial Catalog=Pontaje_v2;Integrated Security=True"))
        using (SqlCommand sc = new SqlCommand("insert into Projects values(@name, @description)", con))
        {
            con.Open();
           
            sc.Parameters.AddWithValue("@firstname", TextBoxName.Text);
            sc.Parameters.AddWithValue("@lastname", TextBoxDescription.Text);
          
           
                sc.ExecuteNonQuery();

              

            
            con.Close();
        }
    }






}