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
        SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Employees WHERE FirstName=@name AND LastName=@password", sqlConnection);
        sqlCommand.Parameters.AddWithValue("@name", TextBoxUsername.Text);
        sqlCommand.Parameters.AddWithValue("@password", TextBoxPassword.Text);

        sqlConnection.Open();
        var reader = sqlCommand.ExecuteReader();
        Label1.Text = reader.Read() ? "Giriş yapıldı" : "Hatalı Giriş";
        sqlConnection.Close();


        /*
         * XSRF : Cross Site Request Forgery
         * İstek gönderen ile oturum açan istemcinin FARKLI olduğunu nasıl anlarım?
         * Anti Forgery Token
         */
    }
}