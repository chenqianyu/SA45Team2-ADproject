using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SA45Team02_SSIS;
using System.Windows;

public partial class View_Stationery_ViewDeliveryOrderDetails : System.Web.UI.Page
{
    

  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        int POID = Convert.ToInt32(Request.QueryString["POID"]);
        gvPODetails.DataSource = DeliveryOrderController.GetDeliveryOrderDetailsList(POID);
        gvPODetails.DataBind();

        if (DeliveryOrderController.RetrievePurchaseOrderByPO_NO(POID).Actual_Delivery_Date != null)
        {
            // To disable edit buttons
            for (int i = 0; i < gvPODetails.DataKeys.Count; i++)
            {
                (gvPODetails.Rows[i].Cells[6]).Enabled = false;
            }

            // To disable acknowledge button
            btnAcknowledge.Enabled = false;
        }
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        gvPODetails.EditIndex = e.NewEditIndex;
        BindGrid();

        btnAcknowledge.Enabled = false;
    }

    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string inputValue = (gvPODetails.Rows[e.RowIndex].FindControl("tbDeliveredQty") as TextBox).Text;

        int actualQty;
        if (Int32.TryParse(inputValue, out actualQty)) // number validation
        {
            GridViewRow row = gvPODetails.Rows[e.RowIndex];

            string itemNo = (string)gvPODetails.DataKeys[e.RowIndex].Values[0];
            int POID = Convert.ToInt32(Request.QueryString["POID"]);

            OrderDetail orderToUpdate = DeliveryOrderController.GetOrderDetailsByPONoAndItemNo(POID, itemNo);

            DeliveryOrderController.UpdateDeliveredQty(orderToUpdate, actualQty);

            gvPODetails.EditIndex = -1;
            BindGrid();
            btnAcknowledge.Enabled = true;
        }
        else {
            ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", 
                "<script language='javascript'>alert('" + "Please enter a valid number." + "');</script>");
        }
    }

    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        gvPODetails.EditIndex = -1;
        BindGrid();
        btnAcknowledge.Enabled = true;
    }

    protected void btnAcknowledge_Click(object sender, EventArgs e)
    {
        Dictionary<string, int> adjVouchers = new Dictionary<string, int>();

        // Loop through each row to update Inventory Qty
        for (int i = 0; i < gvPODetails.DataKeys.Count; i++)
        {
            string itemNo = (string)gvPODetails.DataKeys[i].Value;
            ItemCatalog itemToupdate = DeliveryOrderController.RetrieveItemCatalogByItemNo(itemNo);

            GridViewRow r = gvPODetails.Rows[i];
            int deliveredQty = Convert.ToInt32((r.FindControl("lblDeliveredQty") as Label).Text);

            DeliveryOrderController.IncreaseInventory(itemToupdate, deliveredQty);

            // To disable edit buttons
            (gvPODetails.Rows[i].Cells[6]).Enabled = false;

            // To check whether voucher adjustment required
            int orderedQty = Convert.ToInt32(gvPODetails.Rows[i].Cells[4].Text);

            if (orderedQty < deliveredQty)
            {
                lbAdjVouchers.Text = "Items sent for adjustment acknowledgement: (Free gifts)";

                int adjustmentQty = deliveredQty - orderedQty;
                string adjustmentItem = itemToupdate.Item_No;

                adjVouchers.Add(adjustmentItem, adjustmentQty);
            }
        }

        btnAcknowledge.Enabled = false;
        lbStatus.Text = "Delivery Order acknowledged.";


        // Update Actual Delivery Date in PO Table
        PurchaseOrder PO = DeliveryOrderController.RetrievePurchaseOrderByPO_NO(Convert.ToInt32(Request.QueryString["POID"]));
        DeliveryOrderController.UpdateDeliveryDate(PO);


        // Print out Items needed for Adjustment
        foreach (KeyValuePair <string, int> kvp in adjVouchers)
        {
            lbAdjVouchers.Text += "<br>" + string.Format("Item Code: {0}, Adjustment Qty: {1}", kvp.Key, kvp.Value);
        }

        // Update Adjustment Table
        foreach (KeyValuePair<string, int> kvp in adjVouchers)
        {
            string itemNo = kvp.Key;
            int empID = 5;  //Fetch data from Login user for Emp ID
            DateTime raisedDate = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
            string remarks = "Free Gift";
            int adjQty = kvp.Value;

            DeliveryOrderController.AddAdjustment(itemNo, empID, raisedDate, remarks, adjQty);

            // Send email to supervisor/manager
            decimal itemPrice = DeliveryOrderController.RetrieveItemCatalogByItemNo(itemNo).Price;
            decimal value = adjQty * itemPrice;
          
           // AdjustmentController.AdjMailSend(value);

        }

        // Update unfulfilled orders previously
        RetrievalController.AddRetrievalItemForUnfulfilled();
    }
}