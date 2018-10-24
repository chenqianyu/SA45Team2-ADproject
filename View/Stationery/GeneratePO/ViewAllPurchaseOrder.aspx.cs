using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Stationery_GeneratePO_ViewAllPurchaseOrder : System.Web.UI.Page
{
  
    DateTime? startDate;
    DateTime? endDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataGridBind();
            startDate = null;
            endDate = null;


        }

    }

    protected void DataGridBind()
    {
        gvPurchaseOrder.DataSource = PurchaseOrderController.RetrievePurchaseOrders(startDate, endDate);
        gvPurchaseOrder.DataBind();
    }

    protected void btnGeneratePurchaseOrder_Click(object sender, EventArgs e)
    {
        PurchaseOrderController.AutoGeneratePurchaseOrder();
           
        DataGridBind();
    }


    protected void gvPurchaseOrder_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "gvPurchaseOrder")
        {

            int id = Int32.Parse(e.CommandArgument.ToString());
            Response.Redirect("ViewPODetails.aspx?purchaseOrderId=" + id);

        }
    }

    protected void loadAll(object sender, EventArgs e)
    {
        startDate = null;
        endDate = null;
        DataGridBind();
    }


    protected void FilterByDate(object sender, EventArgs e)
    {
        if (tbStartDate.Text != null || tbEndDate.Text != null)
        {
            startDate = Convert.ToDateTime(tbStartDate.Text.ToString());
            endDate = Convert.ToDateTime(tbEndDate.Text.ToString());
            DataGridBind();
        }


        //gvPurchaseOrder.DataSource= purchaseOrderController.RetrievePurchaseOrderByDate(startDate, endDate);
        //gvPurchaseOrder.DataBind();

    }



    protected void gvPurchaseOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            PurchaseOrder order = (PurchaseOrder)e.Row.DataItem;
            string supplierName = PurchaseOrderController.GetSuppliersBySupplierID(order.Supplier_ID).Supplier_Name;
            Label lbSupplier = (e.Row.FindControl("lbSupplierName") as Label);
            lbSupplier.Text = supplierName;




        }
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        gvPurchaseOrder.PageIndex = e.NewPageIndex;
        DataGridBind();
    }



}