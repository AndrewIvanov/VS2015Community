using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();

            string checkuser = "select count(*) from UserData where UserName='"+ TextBoxUsername.Text +"'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (temp == 1)
            {
                Response.Write("Username already exists");
            }

            conn.Close();
        }
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();

            string insertQuery = "insert into UserData (Username,Email,Password,Country) values (@Uname ,@email, @password ,@country)";
            SqlCommand com = new SqlCommand(insertQuery, conn);
            com.Parameters.AddWithValue("@Uname", TextBoxUsername.Text);
            com.Parameters.AddWithValue("@email", TextBoxEmail.Text);
            com.Parameters.AddWithValue("@password", TextBoxPassword.Text);
            com.Parameters.AddWithValue("@country", TextBoxRPassword.Text);

            com.ExecuteNonQuery();
            Response.Redirect("Manager.aspx");
            Response.Write("Registration is successful!");

            conn.Close();
            //Response.Write("SUCCESS!!!!!! nnghdgfngfdndgfasngdfndffdm");
        }
        catch(Exception ex)
        {
            Response.Write("Error:" + ex.ToString());
        }
    }
}