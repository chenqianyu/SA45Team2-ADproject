using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Stationery_GeneratePO_PurchaseOrderConfirmPage : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            ddlItemList.DataSource = PurchaseOrderController.RetrieveItemCatalogsList();
            ddlItemList.DataTextField = "Description";
            ddlItemList.DataValueField = "Item_No";
            ddlItemList.DataBind();

            ddlItemList.SelectedIndex = 0;
            lbItemCode1.Text = ddlItemList.SelectedValue;
            List<TemporaryOrderItem> list = PurchaseOrderController.CreateListForPurchaseOrder();
            Session[Utility.TempPOList] = list;
            SetValueToViewState(list);

            GridBind();
        }
       

    }

    //protected void initializeKeyValuePairsOrderList(List<TemporaryOrderItem> list)
    //{


    //    Dictionary<string, TemporaryOrderItem> Pairs = new Dictionary<string, TemporaryOrderItem>();

    //    foreach (TemporaryOrderItem od in list)
    //    {
    //        Pairs.Add(od.ItemNo, od);
    //    }
    //    ViewState[Utility.OrderItemsList] = Pairs;
    //}


    protected void GridBind()
    {
        List<TemporaryOrderItem> list = (List<TemporaryOrderItem>) Session[Utility.TempPOList];
        gvOrderDetails.DataSource = list;
        gvOrderDetails.DataBind();
    }


    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
       // int purchaseOrderId = Int32.Parse(Request.QueryString["purchaseOrderId"]);
       
        //string itemId = ddlItem.SelectedValue;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TemporaryOrderItem order = (TemporaryOrderItem)e.Row.DataItem;
            
            
            DropDownList ddl = (e.Row.FindControl("ddlSupplier") as DropDownList);
            if (ddl != null)
            {
                ddl.DataSource = PurchaseOrderController.RetrieveSupplierList();
                ddl.DataTextField = "Supplier_ID";
                ddl.DataValueField = "Supplier_Name";
                ddl.DataBind();
                ddl.Items.FindByText(order.SupplierID).Selected = true;
            }

           
            Label lbItemNo = (e.Row.FindControl("lbItemNo") as Label);
            Label lbDescription = (e.Row.FindControl("lbDescription") as Label);
           
            Label lbQty = (e.Row.FindControl("lbQty") as Label);
            lbItemNo.Text = order.ItemNo;
            lbDescription.Text = order.ItemDescription;
            tbQty.Text = order.Qty.ToString();

           
        }
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        gvOrderDetails.EditIndex = e.NewEditIndex;
        GridBind();
    }

    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gvOrderDetails.Rows[e.RowIndex];
        List<TemporaryOrderItem> tempPOList=(List<TemporaryOrderItem>) Session[Utility.TempPOList];
        string itemNo = (row.FindControl("lbItemNo") as Label).Text;
        string description = (row.FindControl("lbDescription") as Label).Text;
        string supplierID = Convert.ToString(((row.FindControl("ddlSupplier") as DropDownList).SelectedItem).Text);
        string supplierName= Convert.ToString((row.FindControl("ddlSupplier") as DropDownList).SelectedValue);
        string qty = (row.FindControl("tbQty") as TextBox).Text;

        List<TemporaryOrderItem> updatedList=PurchaseOrderController.UpdatePurchaseOrderList(tempPOList, itemNo, description, supplierID, supplierName,qty);
        SetValueToViewState(updatedList);
        Session[Utility.TempPOList] = updatedList;

      

        gvOrderDetails.EditIndex = -1;
        GridBind();
    }

    protected void SetValueToViewState(List<TemporaryOrderItem> list)
    {
        Dictionary<string, TemporaryOrderItem> Pairs = new Dictionary<string, TemporaryOrderItem>();

        foreach (TemporaryOrderItem od in list)
        {
            Pairs.Add(od.ItemNo, od);
        }
        ViewState[Utility.OrderItemsList] = Pairs;
    }

    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        gvOrderDetails.EditIndex = -1;
        GridBind();
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = gvOrderDetails.Rows[e.RowIndex];
        string itemNo = (row.FindControl("lbItemNo") as Label).Text;

        List<TemporaryOrderItem> list = (List<TemporaryOrderItem>)Session[Utility.TempPOList];

        PurchaseOrderController.RemoveItemFromPurchaseOrderList(list,itemNo);
        GridBind();
    }


    protected void btnConfirm_Click(object sender, EventArgs e)
    {
       
        List<TemporaryOrderItem> tempOrderList = (List<TemporaryOrderItem>)Session[Utility.TempPOList];
        if (tempOrderList.Count > 0)
        {
            PurchaseOrderController.ManualGeneratePurchaseOrder(tempOrderList);
            Response.Redirect("ViewAllPurchaseOrder.aspx");
        }
        
    }


    //add new Item to purchase order cart
    protected void btnAddItem_Click(object sender, EventArgs e)
    {
        string itemCode = ddlItemList.SelectedValue;
        string itemDescription = ddlItemList.SelectedItem.Text;
        if (tbQty.Text.Length > 0)
        {
            int qty = Convert.ToInt32(tbQty.Text);

            merge(itemCode, itemDescription, qty);
            List<TemporaryOrderItem> MergedOdList = new List<TemporaryOrderItem>();
            Dictionary<string, TemporaryOrderItem> orderItemList = (Dictionary<string, TemporaryOrderItem>)ViewState["orderItemsList"];
            foreach (string key1 in orderItemList.Keys)
            {
                MergedOdList.Add(orderItemList[key1]);
            }
            Session[Utility.TempPOList] = MergedOdList;
            GridBind();
        }
    }


    protected void merge(string itemCode,string itemDescription,int qty)
    {
        //groupind Items
        //by using 
        //(key=> Item Code)
        //(Value => TemporaryOrderItem)
        //and then save them to ViewState
        Dictionary<string, TemporaryOrderItem> Pairs = new Dictionary<string, TemporaryOrderItem>();
        TemporaryOrderItem to = new TemporaryOrderItem();
        if (ViewState[Utility.OrderItemsList] != null)
        {
            Pairs = (Dictionary<string, TemporaryOrderItem>)ViewState[Utility.OrderItemsList];
        }
        string key = ddlItemList.SelectedValue;
        if (Pairs.ContainsKey(key))
        {
            to = Pairs[key];
            to.Qty += qty;
            Pairs[key] = to;
        }
        else
        {
            TemporaryOrderItem oi = new TemporaryOrderItem();
            oi.itemNo = itemCode;
            oi.ItemDescription = itemDescription;
            Supplier s = PurchaseOrderController.GetSupplierByCatalogIDWithFirstPreferenceRank(itemCode);
            oi.SupplierID = s.Supplier_ID;
            oi.supplierName = s.Supplier_Name;
            oi.Qty = qty;
            Pairs.Add(key, oi);
        }
        ViewState[Utility.OrderItemsList] = Pairs;

    }


    protected void ddlItemList_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbItemCode1.Text = ddlItemList.SelectedValue;
    }



    protected void tbQty_TextChanged(object sender, EventArgs e)
    {
        btnAddItem.Enabled = true;
        if (tbQty.Text.Length == 0)
        {
            btnAddItem.Enabled = false;
        }
     
    }
}