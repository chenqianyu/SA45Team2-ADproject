using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Stationery_Supervisior_ApprovalPO : System.Web.UI.Page
{
    string purchaseOrderId;
    string status;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["totalPrice"] = 0.0;
            purchaseOrderId = Request.QueryString["purchaseOrderId"];
            status = Request.QueryString["status"];
            if (status == Utility.Approved || status == Utility.Rejected)
            {
                btnApprove.Visible = false;
                btnReject.Visible = false;
            }
            else
            {
                btnApprove.Visible = true;
                btnReject.Visible = true;
            }
            lbPurchaseOrder.Text = purchaseOrderId;
            List<OrderDetailsView> l = PurchaseOrderController.RetrieveOrderDetailView(Int32.Parse(purchaseOrderId));

            gvPurchaseOrderDetail.DataSource = l;
            gvPurchaseOrderDetail.DataBind();
            lbTotalAmount.Text = Convert.ToString(ViewState["totalPrice"]);
            Supplier s= PurchaseOrderController.RetrieveSupplierByPOno(Int32.Parse(purchaseOrderId));
            lbSupplierName.Text = s.Supplier_Name;

            PurchaseOrder po = PurchaseOrderController.RetrievePurchaseOrderByPO_NO(Convert.ToInt32(purchaseOrderId));
            Employee emp = PurchaseOrderController.RetrieveEmployeeByEmployeeID(po.Employee_ID);
            lbOrderBy.Text = emp.Employee_Name;
            lbDate.Text = po.PO_Date.ToShortDateString();
            lbDeliveryDate.Text = po.Expected_Delivery_Date.ToString();
        }
    }
    protected void gvPurchaseOrderDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            Label qty = e.Row.FindControl("lbQuantity") as Label;
            Label price = e.Row.FindControl("lbPrice") as Label;
            Label amount = e.Row.FindControl("lbAmount") as Label;
            int qtyvalue = Convert.ToInt32(qty.Text);
            double pricevalue = Convert.ToDouble(price.Text);
            if (amount != null)
                amount.Text = (qtyvalue * pricevalue).ToString();
            if (ViewState["totalPrice"] != null)
            {
                double totalPrice = (double)ViewState["totalPrice"];
                totalPrice += qtyvalue * pricevalue;
                ViewState["totalPrice"] = totalPrice;
            }


        }

    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["purchaseOrderId"]);
        PurchaseOrderController.ApprovePO(id);
        string myStringVariable = "Update Successfully!";
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');window.location.replace('http://localhost/SA45Team02_SSIS/View/Stationery/Supervisior/Approvalpending.aspx')", true);


        //Response.Redirect("Approvalpending.aspx");
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["purchaseOrderId"]);
        PurchaseOrderController.RejectPO(id);
        string myStringVariable = "Rejected Successfully!";
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');window.location.replace('http://localhost/SA45Team02_SSIS/View/Stationery/Supervisior/Approvalpending.aspx')", true);
        //Response.Redirect("Approvalpending.aspx");
    }
}