using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SA45Team02_SSIS;
public partial class Stationery_Supervisior_Approvalpending : System.Web.UI.Page
{
   
    List<String> StatusPO = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (ddlPOAll.SelectedItem.Value == "0")
        {
            gvPurchaseOrder.DataSource = PurchaseOrderController.RetrieveAllPOList();
            gvPurchaseOrder.DataBind();
        }
        else if (ddlPOAll.SelectedItem.Value == "1")
        {
            gvPurchaseOrder.DataSource = PurchaseOrderController.RetrievePendingPOList();
            gvPurchaseOrder.DataBind();

        }
        else if (ddlPOAll.SelectedItem.Value == "2")
        {
            gvPurchaseOrder.DataSource = PurchaseOrderController.RetrieveApprovedPOList();
            gvPurchaseOrder.DataBind();
        }
        else
        {
            gvPurchaseOrder.DataSource = PurchaseOrderController.RetrieveRejectedPOList();
            gvPurchaseOrder.DataBind();
        }
    }


    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            PurchaseOrder order = (PurchaseOrder)e.Row.DataItem;
            Label supplierName = (e.Row.FindControl("lbSupplierName") as Label);
            if (supplierName != null)
                supplierName.Text = PurchaseOrderController.GetSuppliersBySupplierID(order.Supplier_ID).Supplier_Name;


        }
    }


    protected void gvPurchaseOrder_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "gvPurchaseOrder")
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            PurchaseOrder po = PurchaseOrderController.RetrievePurchaseOrderByPO_NO(id);

            Response.Redirect("ApprovalPO.aspx?purchaseOrderId=" + id + "&status=" + po.Remarks);
        }

    }
    protected void OnPaging(Object sender, GridViewPageEventArgs e)
    {
        gvPurchaseOrder.PageIndex = e.NewPageIndex;
        if (ddlPOAll.SelectedItem.Value == "0")
        {
            gvPurchaseOrder.DataSource = PurchaseOrderController.RetrieveAllPOList();
            gvPurchaseOrder.DataBind();
        }
        else if (ddlPOAll.SelectedItem.Value == "1")
        {
            gvPurchaseOrder.DataSource = PurchaseOrderController.RetrievePendingPOList();
            gvPurchaseOrder.DataBind();

        }
        else if (ddlPOAll.SelectedItem.Value == "2")
        {
            gvPurchaseOrder.DataSource = PurchaseOrderController.RetrieveApprovedPOList();
            gvPurchaseOrder.DataBind();
        }
        else
        {
            gvPurchaseOrder.DataSource = PurchaseOrderController.RetrieveRejectedPOList();
            gvPurchaseOrder.DataBind();
        }

        //DataBind();
    }

    protected void ddlPOAll_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPOAll.SelectedItem.Value == "0")
        {
            gvPurchaseOrder.DataSource = PurchaseOrderController.RetrieveAllPOList();
            gvPurchaseOrder.DataBind();
        }
        else if (ddlPOAll.SelectedItem.Value == "1")
        {
            gvPurchaseOrder.DataSource = PurchaseOrderController.RetrievePendingPOList();
            gvPurchaseOrder.DataBind();

        }
        else if (ddlPOAll.SelectedItem.Value == "2")
        {
            gvPurchaseOrder.DataSource = PurchaseOrderController.RetrieveApprovedPOList();
            gvPurchaseOrder.DataBind();
        }
        else
        {
            gvPurchaseOrder.DataSource = PurchaseOrderController.RetrieveRejectedPOList();
            gvPurchaseOrder.DataBind();
        }
    }
}