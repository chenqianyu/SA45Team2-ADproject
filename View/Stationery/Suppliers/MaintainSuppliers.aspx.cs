
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Threading;
using System.Web.UI.WebControls;

public partial class Stationery_Suppliers_MaintainSuppliers : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        LoginUserInfo u = (LoginUserInfo)Session[Utility.CurrentlyLoginUserInfo];
        Label1.Text = u.Role + "/" + u.EmpId + "/" + u.UserName + "/" + u.DepartmentId + "/" + u.DepartmentName + "/" + u.LoginStatus;
        // Label1.Text =
        //    Convert.ToString(Session[Utility.CurrentlyLoginUserDepartment]) + "Thin Thin";
        if (!IsPostBack)
        {
            SupplierController sc = new SupplierController();
            GridView1.DataSource = sc.SupplierList();
            GridView1.DataBind();
        }
    }

    protected void PassSession(object sender, System.EventArgs e)
    {
        if (((Button)sender).CommandName.Equals("Edit"))
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            var arguement = btn.CommandArgument;
            Session["Detail"] = arguement.ToString();
            Response.Redirect("~/View/Stationery/Suppliers/SupplierDetails.aspx");
        }
    }


}