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
        using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SJS4A6Q\SQLEXPRESS;Initial Catalog=Pontaje_v2;Integrated Security=True"))
        using (SqlCommand sc = new SqlCommand("insert into Users values(@firstname, @lastname, @email, @username, @password, @role)", con))
        {
            con.Open();
            string username = TextBoxUsername.Text;
            sc.Parameters.AddWithValue("@firstname", TextBoxFirstName.Text);
            sc.Parameters.AddWithValue("@lastname", TextBoxLastName.Text);
            sc.Parameters.AddWithValue("@email", TextBoxEmail.Text);
            sc.Parameters.AddWithValue("@username", username);
            SqlCommand check_username = new SqlCommand("select count (*) from Users where username= @username",con);
            check_username.Parameters.AddWithValue("@username", TextBoxUsername.Text);
            int count = Convert.ToInt32(check_username.ExecuteScalar());
            sc.Parameters.AddWithValue("@password", GetHashedText(TextBoxPassword.Text));
            if (count != 0)
            {
                Response.Write("Username already exists!");
            }
            else
            {
                

                PontajeEntities pe = new PontajeEntities();
               
                int number_users = (from user in pe.Users select user).Count();
                if (number_users == 0)
                {
                    sc.Parameters.AddWithValue("@role", 1);
                   
                }
                else
                {
                    sc.Parameters.AddWithValue("@role", 2);
                   
                }
                sc.ExecuteNonQuery();
                Response.Redirect("Login.aspx");

            }
            con.Close();
        }
    }

}