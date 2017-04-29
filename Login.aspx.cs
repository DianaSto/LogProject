using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    private string GetHashedText(string inputData)
    {
        byte[] tmpSource;
        byte[] tmpData;
        tmpSource = ASCIIEncoding.ASCII.GetBytes(inputData);
        tmpData = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        return Convert.ToBase64String(tmpData);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void TextBoxUsername_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBoxPassword_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void ButtonRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SJS4A6Q\SQLEXPRESS;Initial Catalog=Pontaje_v2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("select * from Users where username=@user and password=@pass", con);
        con.Open();
        string username = TextBoxUsername.Text;
        cmd.Parameters.AddWithValue("@user", username);
        cmd.Parameters.AddWithValue("@pass", GetHashedText(TextBoxPassword.Text));
        SqlDataReader re = cmd.ExecuteReader();
        if (re.Read())
        {
            Session["username"] = TextBoxUsername.Text;

            PontajeEntities pe = new PontajeEntities();
            
            int id_user = (from user in pe.Users where user.username == username select user.id).FirstOrDefault();
            int id_role= (from user in pe.Users where user.username == username select user.id_role).FirstOrDefault();
            string user_role= (from roles in pe.Roles where roles.id == id_role select roles.name).FirstOrDefault().ToString();
            if (user_role=="Admin")
            {
                Response.Redirect("AdminMain.aspx");
            }
            else if (user_role=="Normal user")
            {
                Response.Redirect("Main.aspx");
            }

            Session.RemoveAll();
        }
        else
        {
            Response.Write("Wrong password");
        }
        con.Close();
    }
}