using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void Button_Insert_Click(object sender, EventArgs e)
    {
        SqlDataSource1.InsertParameters["Name"].DefaultValue =
            ((TextBox)GridView1.FooterRow.FindControl("TextBox_InsertName")).Text;

        SqlDataSource1.InsertParameters["Info"].DefaultValue =
            ((TextBox)GridView1.FooterRow.FindControl("TextBox_InsertInfo")).Text;

        SqlDataSource1.Insert();
    }
}