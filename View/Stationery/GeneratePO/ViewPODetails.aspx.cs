using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Stationery_GeneratePO_ViewPO : System.Web.UI.Page
{
    OrderDetailsController odc = new OrderDetailsController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlItem.DataSource = odc.RetrieveItemCatalogsList();
            ddlItem.DataTextField = "Description";
            ddlItem.DataValueField = "Item_No";
            ddlItem.DataBind();
            dataBind();
        }

    }

    protected void dataBind()
    {
        int purchaseOrderId = Int32.Parse(Request.QueryString["purchaseOrderId"]);
        List<OrderDetail> list = odc.RetrieveOrderDetails(purchaseOrderId);
        gvOrderDetails.DataSource = list;
        gvOrderDetails.DataBind();
    }

    protected void SearchByItemDescription(object sender, EventArgs e)
    {
        int purchaseOrderId = Int32.Parse(Request.QueryString["purchaseOrderId"]);
        string item_NO = ddlItem.SelectedValue;

        List<OrderDetail> list = odc.RetrieveOrderDetailsByItemNo(purchaseOrderId, item_NO); 
        gvOrderDetails.DataSource = list;
        gvOrderDetails.DataBind();
    }

    protected void ViewAll(object sender, EventArgs e)
    {
        dataBind();
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        int purchaseOrderId = Int32.Parse(Request.QueryString["purchaseOrderId"]);
        string itemId = ddlItem.SelectedValue;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            OrderDetail order = (OrderDetail)e.Row.DataItem;

            string description = odc.RetrieveItemCatalogsListByItemNo(order.Item_No).Description;
            Label lbdescription = (e.Row.FindControl("lbDescription") as Label);
            lbdescription.Text = description;

            string supplier_ID = odc.RetrievePurchaseOrderByPO_NO(order.PO_No).Supplier_ID;
            Supplier s = odc.GetSupplierBySupplierID(supplier_ID);
            Label lbsupplier = (e.Row.FindControl("lbSupplier") as Label);
            lbsupplier.Text = s.Supplier_Name;


        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GeneratePO.aspx");
       
    }
}