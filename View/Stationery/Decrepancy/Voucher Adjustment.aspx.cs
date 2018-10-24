using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SA45Team02_SSIS;

public partial class Stationery_decrepancy_Decrepancy : System.Web.UI.Page
{
   

    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadPage();
        }
    }

    public void loadPage()
    {
        ddlItemCode.DataSource = AdjustmentController.RetrieveItemCatalogsList();
        ddlItemCode.DataTextField = "Item_No";
        ddlItemCode.DataValueField = "Item_No";
        ddlItemCode.DataBind();

        ddlItemCode.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlItemCode.SelectedIndex = 0;

        int empID = 12; // read user login emp id

        gvAdj.DataSource = AdjustmentController.AdjustmentsPending(empID);
        gvAdj.DataBind();

        if (gvAdj.Rows.Count == 0)
        {
            lbStatus.Text = "You have no pending adjustment vouchers pending for acknowledgement";
        }
    }

    public void clearDdl()
    {
        ddlItemCode.SelectedIndex = 0;
        lbDescription.Text = "";
        lbUnitOfMeasure.Text = "";
        tbQty.Text = "";
        tbRemarks.Text = "";
        lbValue.Text = "";

        tbQty.Enabled = false;
    }

    public void computeValue(int qty)
    {
        decimal itemPrice = AdjustmentController.RetrieveItemCatalogByItemNo(ddlItemCode.SelectedValue).Price;

        decimal value = qty * itemPrice;
        lbValue.Text = value.ToString();
    }

    protected void ddlItemCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lbDescription.Text = AdjustmentController.RetrieveItemCatalogByItemNo(ddlItemCode.SelectedValue.ToString()).Description;
            lbUnitOfMeasure.Text = AdjustmentController.RetrieveItemCatalogByItemNo(ddlItemCode.SelectedValue.ToString()).Unit_of_Measure;
            tbQty.Enabled = true;
        }
        catch (InvalidOperationException ex)
        {
            lbDescription.Text = "";
            lbUnitOfMeasure.Text = "";
            clearDdl();
        }

    }

    protected void tbQty_TextChanged(object sender, EventArgs e)
    {
        string inputValue = tbQty.Text;
        int qty;

        if (Int32.TryParse(inputValue, out qty)) // number validation
        {
            if (ddlItemCode.SelectedIndex != 0)
            {
                computeValue(qty);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox",
                "<script language='javascript'>alert('" + "Please enter a valid number." + "');</script>");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string itemNo = ddlItemCode.SelectedValue;
        int empID = 12;  // read from login emp id
        DateTime date = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
        string remarks = tbRemarks.Text;
        int qty = Convert.ToInt32(tbQty.Text);
        int aQty = -qty;

        ItemCatalog itemToupdate = AdjustmentController.RetrieveItemCatalogByItemNo(itemNo);
        int inventoryQty = itemToupdate.Total_Qty;

        // Check whether qty is more than Inventory qty
        if (qty > inventoryQty)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox",
            "<script language='javascript'>alert('" + "Please enter a valid quantity. Quantity cannot be higher than existing quantity of " + inventoryQty + "');</script>");

        }
        else
        {
            // Add new adjustment entry
            AdjustmentController.AddAdjustment(itemNo, empID, date, remarks, aQty);

            // Deduct Inventory Qty
            AdjustmentController.DecreaseInventory(itemToupdate, qty);

            // Send email to supervisor or manager
            decimal value = Convert.ToDecimal(lbValue.Text);
            string name = AdjustmentController.GetEmployeeByEmpId(empID).Employee_Name;
            AdjustmentController.AdjMailSend(value, name, remarks);

            loadPage();
            clearDdl();

            ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox",
            "<script language='javascript'>alert('" + "Adjustment Item added successfully." + "');</script>");

            lbStatus.Text = "";
        }
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string itemNo = (string)gvAdj.DataKeys[e.RowIndex].Values[0];
        int empID = 12; // read login user emp id
        DateTime date = Convert.ToDateTime(gvAdj.Rows[e.RowIndex].Cells[1].Text);
        int qty = Convert.ToInt32(gvAdj.Rows[e.RowIndex].Cells[2].Text);
        string remarks = gvAdj.Rows[e.RowIndex].Cells[3].Text;

        // Send email to supervisor or manager to notify on cancellation
        string name = AdjustmentController.GetEmployeeByEmpId(empID).Employee_Name;
        decimal itemPrice = AdjustmentController.RetrieveItemCatalogByItemNo(itemNo).Price;
        decimal value = qty * itemPrice;
        AdjustmentController.AdjMailSendCancel(value, name, remarks);


        //Restore Inventory Qty
        ItemCatalog itemToupdate = AdjustmentController.RetrieveItemCatalogByItemNo(itemNo);
        AdjustmentController.IncreaseInventory(itemToupdate, qty);

        //Delete adjustment from table
        AdjustmentController.RemoveAdjustment(itemNo, empID, date);

        loadPage();
        clearDdl();
    }
}