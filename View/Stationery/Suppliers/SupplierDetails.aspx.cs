using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Stationery_Suppliers_SupplierDetails : System.Web.UI.Page
{
 
    string detail;
    string supplier_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    BindGrid();
        //}
        detail = Convert.ToString(Session["Detail"]);
        if (!IsPostBack)
        {
                supplier_ID = detail;
                Supplier supplier = SupplierController.SelectSupplierByID(supplier_ID);
            if (supplier != null)
            {
                TextBox7.Text = supplier.Supplier_ID;
                TextBox8.Text = supplier.Supplier_Name;
                TextBox9.Text = supplier.Contact_Name;
                TextBox10.Text = Convert.ToString(supplier.Phone); ;
                TextBox11.Text = supplier.Address;
                TextBox12.Text = supplier.Email;
            }
           
        }
    }

    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string supplier_ID = TextBox7.Text;
            string supplier_Name = TextBox8.Text;
            string contact_Name = TextBox9.Text;
            int phone = Int32.Parse(TextBox10.Text);
            string address = TextBox11.Text;
            string email = TextBox12.Text;
            SupplierController.EditSupplier(supplier_Name, supplier_ID, contact_Name, phone, address, email);
            Response.Redirect("~/View/Stationery/Suppliers/MaintainSuppliers.aspx");
        }
    }
}

