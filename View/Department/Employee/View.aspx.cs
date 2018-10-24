using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Department_Employee_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Catalogue Item Code", typeof(String));
        dt.Columns.Add("Description", typeof(String));
        dt.Columns.Add("Quantity", typeof(String));
        dt.Rows.Add("C010", "Clips Double 2", "10");
        dt.Rows.Add("S002", "Pad Postit", "25");
        dt.Rows.Add("C096", "Tray in/out", "55");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}