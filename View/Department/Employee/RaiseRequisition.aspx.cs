using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Department_Employee_RaiseRequisition : System.Web.UI.Page
{
    List<ItemCatalog> a = null;
    RequisitionController requisitionCtrl = new RequisitionController();
    int empno = 3;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<String> c = RequisitionController.GetDistinctItemCatalogsByCategory();
            ddlItemCategory.DataSource = c;
            ddlItemCategory.DataBind();
            ddlItemCategory.Items.Insert(0, new ListItem("All", "All"));
            gvItemCatalog.DataSource = RequisitionController.RetrieveItemCatalogsList();
            gvItemCatalog.DataBind();
            a = new List<ItemCatalog>();
            ViewState["abc"] = a;
        }
        else
        {
            a = (List<ItemCatalog>)ViewState["abc"];
            if (a == null)
            {
                a = new List<ItemCatalog>();
            }
        }
    }


    void reBind()
    {
        gvCheckOut.DataSource = a;
        gvCheckOut.DataBind();
    }

    protected void ddlItemCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        string selectedIndex = ddlItemCategory.SelectedItem.Text;
        if (selectedIndex == "All")
        {
            gvItemCatalog.DataSource = RequisitionController.RetrieveItemCatalogsList();
            gvItemCatalog.DataBind();
        }
        else
        {
            gvItemCatalog.DataSource = RequisitionController.RetrieveItemCatalogByCategoryID(selectedIndex);
            gvItemCatalog.DataBind();
        }


    }



    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        a = (List<ItemCatalog>)ViewState["abc"];

        int Quantity = 0;
        for (int count = 0; count < gvItemCatalog.Rows.Count; count++)
        {
            if (((TextBox)gvItemCatalog.Rows[count].FindControl("txtQuantity")).Text.Length>0)
            {
                String quantity = ((TextBox)gvItemCatalog.Rows[count].FindControl("txtQuantity")).Text;
                Quantity = int.Parse(quantity);
                String ItemNo = gvItemCatalog.Rows[count].Cells[0].Text;
                String description = gvItemCatalog.Rows[count].Cells[2].Text;
                ItemCatalog Cartlist = new ItemCatalog();
                Cartlist.Item_No = ItemNo;
                Cartlist.Allocated_Qty = Quantity;
                Cartlist.Description = description;
                if (a.Count == 0)
                {
                    a.Add(Cartlist);
                }
                else
                {
                    ItemCatalog rt = RequisitionController.FindItemCatalogFromGivenListByItemNo(a, ItemNo);


                    if (rt != null)
                    {
                        a.Remove(rt);
                        rt.Allocated_Qty = rt.Allocated_Qty + Quantity;
                        a.Add(rt);
                    }
                    else
                    {
                        a.Add(Cartlist);
                    }
                }

            }
        }


        ViewState["abc"] = a;
        gvCheckOut.DataSource = a;
        gvCheckOut.DataBind();
        btnCheckOut.Visible = true;
    }



    protected void gvCheckOut_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Save")
        {
            Console.WriteLine(e.CommandName);
        }
    }

    protected void gvCheckOut_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCheckOut.EditIndex = e.NewEditIndex;
        reBind();
    }

    protected void gvCheckOut_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCheckOut.EditIndex = -1;
        reBind();
    }

    protected void gvCheckOut_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int a1 = e.RowIndex;
        a.RemoveAt(a1);
        reBind();
    }

    protected void gvCheckOut_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int a1 = e.RowIndex;
        ItemCatalog c1 = a.ElementAt(a1);
        c1.Allocated_Qty = Int32.Parse(((TextBox)gvCheckOut.Rows[a1].FindControl("txtQuantityChange")).Text);
        a[a1] = c1;
        gvCheckOut.EditIndex = -1;
        reBind();
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {

        int reqno;
        int abc = RequisitionController.GetCountByReqNo();
        if (abc == 0)
        {
            reqno = 1;
        }
        else
        {
            Object ao = RequisitionController.RetrieveMaxReqNo();
            Requisition rrr = (Requisition)ao;
            reqno = rrr.Requisition_No + 1;
        }


        string Status1 = Utility.Pending;
        DateTime d = DateTime.Now;
        RequisitionController.AddRequisition(reqno, empno, d, Status1);
        RequisitionController.AddRequisitionItems(a, reqno);
        ViewState["abc"] = null;
        Response.Redirect("RequistionList.aspx");

    }




    protected void gvItemCatalog_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvItemCatalog.PageIndex = e.NewPageIndex;
        gvItemCatalog.DataSource = RequisitionController.GetDistinctItemCatalogsByCategory();
        gvItemCatalog.DataBind();
    }
}