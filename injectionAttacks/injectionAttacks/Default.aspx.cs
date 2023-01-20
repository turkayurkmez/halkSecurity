using System;
using System.Web.UI;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //XSS: Cross Site Scripting

    }

    protected void ButtonEnter_Click(object sender, EventArgs e)
    {
        LabelOutput.Text = TextBoxInput.Text;
    }
}