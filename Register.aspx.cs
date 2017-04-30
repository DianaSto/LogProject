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


public partial class Register : System.Web.UI.Page
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

    protected void ButtonRegister_Click(object sender, EventArgs e)
    {
        LabelMismatch.Visible = false;
        LabelUsernameExists.Visible = false;
        PontajeEntities pe = new PontajeEntities();
        User user = new User();
        user.first_name = TextBoxFirstName.Text;
        user.last_name = TextBoxLastName.Text;
        user.email = TextBoxEmail.Text;
        user.username = TextBoxUsername.Text;
        user.password = GetHashedText(TextBoxPassword.Text);
        var check_username = (from u in pe.Users where u.username == TextBoxUsername.Text select u).Count();
        if (check_username == 1)
        {
            LabelUsernameExists.Visible = true;
        }
        else
        {
            if (TextBoxUsername.Text != TextBoxConfirmPassword.Text)
            {
                LabelMismatch.Visible = true;
            }
            else
            {
                int number_users = (from u in pe.Users select u).Count();
                if (number_users == 0)
                {
                    user.id_role = 1;

                }
                else
                {
                    user.id_role = 2;

                }
                pe.Users.Add(user);
                pe.SaveChanges();
                Response.Redirect("Login.aspx");
            }
           
        }
    }

}