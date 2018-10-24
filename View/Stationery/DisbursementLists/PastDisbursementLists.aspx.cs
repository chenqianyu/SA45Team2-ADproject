using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Stationery_PastDisbursementLists : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            List<string> DepartmentName = DisbursementController.SelectDepartmentName();
            List<string> DepartmentId = DisbursementController.SelectDepartmentName();
            for (int i = 0; i < DepartmentName.Count; i++)
            {
                ddlDepartment.Items.Insert(i, new ListItem(DepartmentName[i], DepartmentId[i]));
            }
            ddlDepartment.Items.Insert(0, new ListItem("All","All"));
            gvDisbursement.DataSource = DisbursementController.ViewDisbursementIndex(ddlDepartment.SelectedItem.ToString());
            gvDisbursement.DataBind();

        }
   

    }
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string a = ddlDepartment.SelectedItem.ToString();
        gvDisbursement.DataSource = DisbursementController.ViewDisbursementIndex(a);
        gvDisbursement.DataBind();
    }

    protected void PassSession(object sender, EventArgs e)
    {
        bool change = sender.GetType().Name.Equals("Button");
        if (change == true)
        {
            if (((Button)sender).CommandName == "Button")
            {

                var argument = ((Button)sender).CommandArgument;
                Session["Department_Name"] = argument.ToString();
                Response.Redirect("~/View/Stationery/DisbursementLists/DetailsOfPastItem.aspx");
            }
        }


    }

    protected void linkpickdate_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
    }
    protected void linkpickdate2_Click(object sender, EventArgs e)
    {
        Calendar2.Visible = true;
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        CalanderText.Text = Calendar1.SelectedDate.ToLongDateString();
        Calendar1.Visible = false;
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        TextBox2.Text = Calendar2.SelectedDate.ToLongDateString();
        Calendar2.Visible = false;
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvDisbursement.DataSource = DisbursementController.ViewDisbursementIndex(ddlDepartment.SelectedItem.ToString());
        gvDisbursement.DataBind();
    }
}
