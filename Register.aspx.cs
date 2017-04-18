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
        using (SqlCommand sc = new SqlCommand("insert into Users values(@firstname, @lastname, @email, @username, @password)", con))
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
                sc.ExecuteNonQuery();

                PontajeEntities pe = new PontajeEntities();
                int id_user = (from user in pe.Users where user.username == username select user.id).FirstOrDefault();
                int number_users = (from user in pe.Users select user).Count();
                if (number_users == 1)
                {
                    SqlCommand sc1 = new SqlCommand("insert into UsersToRoles values(@userId, 1)", con);
                    sc1.Parameters.AddWithValue("@userId", id_user);
                    sc1.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand sc1 = new SqlCommand("insert into UsersToRoles values(@userId, 2)", con);
                    sc1.Parameters.AddWithValue("@userId", id_user);
                    sc1.ExecuteNonQuery();
                }
                Response.Redirect("Login.aspx");

            }
            con.Close();
        }
    }

}