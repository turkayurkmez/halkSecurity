using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //XSS: Cross Site Scripting

    }

    protected void ButtonEnter_Click(object sender, EventArgs e)
    {

    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\Mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True");
        SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Employees WHERE FirstName='" + TextBoxUsername.Text + "' AND LastName='" + TextBoxPassword.Text + "'", sqlConnection);
        sqlConnection.Open();
        var reader = sqlCommand.ExecuteReader();
        if (reader.Read())
        {
            Label1.Text = "Giriş yapıldı";
        }
        else
        {
            Label1.Text = "Hatalı Giriş";
        }
        sqlConnection.Close();
    }
}