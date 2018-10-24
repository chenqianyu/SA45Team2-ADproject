using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adproject_team2_Default : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DDLcatagory1.DataSource = SqlDataSource1;
            DDLcatagory1.DataBind();
            DDLcatagory1.Items.Insert(0, new ListItem("All", "All"));
            string a = DDLcatagory1.SelectedValue.ToString();
            GVcatagory1.DataSource = ItemCatalogController.Someting(a);
            GVcatagory1.DataBind();
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["ItemNo"] = String.Empty;
        Response.Redirect("~/View/Stationery/inventory/inventoryDetails.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string Item_no = GridView1.SelectedRow.Cells[0].Text;

    }
    protected void PassSession(object sender, EventArgs e)
    {
            bool change = sender.GetType().Name.Equals("Button");
            if (change == true)
            {
                if (((Button)sender).CommandName == "Button")
                {
                    var argument = ((Button)sender).CommandArgument;
                    Session["ItemNo"] = argument.ToString();
                    Response.Redirect("~/View/Stationery/inventory/inventoryDetails.aspx");
                }
            }
           

    }
    //protected void PassSession(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "Button")
    //    {
    //        //Get the row that contains this button
    //        //GridViewRow gvr = (GridViewRow)btn.NamingContainer;
    //        var argument = e.CommandArgument;
    //        Session["ItemNo"] = argument.ToString();

    //        Response.Redirect("~/Stationery/inventory/inventoryDetails.aspx");
    //    }

    //}

    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {

        string a = DDLcatagory1.SelectedValue.ToString();

        GVcatagory1.DataSource = ItemCatalogController.Someting(a);
        GVcatagory1.DataBind();

    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GVcatagory1.PageIndex = ((GridViewPageEventArgs)e).NewPageIndex;
        string a = DDLcatagory1.SelectedValue.ToString();
        GVcatagory1.DataSource = ItemCatalogController.Someting(a);
        GVcatagory1.DataBind();
    }


    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}
