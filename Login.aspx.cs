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
        PontajeEntities pe = new PontajeEntities();
        string username = TextBoxUsername.Text;
        string password = GetHashedText(TextBoxPassword.Text);
        var u=(from user in pe.Users where user.username==username && user.password == password select user).FirstOrDefault();
        if (u != null)
        {
            Session["username"] = TextBoxUsername.Text;
            int id_user = (from user in pe.Users where user.username == username select user.id).FirstOrDefault();
            int id_role = (from user in pe.Users where user.username == username select user.id_role).FirstOrDefault();
            string user_role = (from roles in pe.Roles where roles.id == id_role select roles.name).FirstOrDefault().ToString();
            if (user_role == "Admin")
            {
                Response.Redirect("AdminMain.aspx");
            }
            else if (user_role == "Normal user")
            {
                Response.Redirect("Main.aspx");
            }

            Session.RemoveAll();
        }
        else
        {
            LabelWrong.Visible = true;
        }
    }
}