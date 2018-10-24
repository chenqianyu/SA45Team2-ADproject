using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Department_Employee_RequistionList : System.Web.UI.Page
{

    List<Requisition> l = null;
    List<RequisitionRequest> items = null;
    RequisitionController requisitionCtrl = new RequisitionController();
    int EmployeeNumber = 3;

    protected void Page_Load(object sender, EventArgs e)
    {



        if (!IsPostBack)
        {

            l = RequisitionController.GetRequisitionByEmpID(EmployeeNumber);
            Session["abc"] = l;
            gvViewReqisition.DataSource = l;
            gvViewReqisition.DataBind();
            for (int i = 0; i < gvViewReqisition.Rows.Count; i++)

            {
                if (((Label)gvViewReqisition.Rows[i].FindControl("lblStatus")).Text == Utility.Pending)
                {

                    (((Button)gvViewReqisition.Rows[i].FindControl("btnSelect")).Visible) = true;
                    (((Button)gvViewReqisition.Rows[i].FindControl("btnEdit")).Visible) = true;
                }
                else if (((Label)gvViewReqisition.Rows[i].FindControl("lblStatus")).Text == Utility.Approved)
                {

                    (((Button)gvViewReqisition.Rows[i].FindControl("btnSelect")).Visible) = true;
                }
            }
            Session["def"] = items;
        }

        else
        {
            l = (List<Requisition>)Session["abc"];
            if (l == null)
            {
                l = new List<Requisition>();
            }

            items = (List<RequisitionRequest>)Session["def"];
            if (items == null)
            {
                items = new List<RequisitionRequest>();
            }

        }


    }

    void reBind()
    {
        gvViewReqisition.DataSource = l;
        gvViewReqisition.DataBind();
        for (int i = 0; i < gvViewReqisition.Rows.Count; i++)

        {
            if (((Label)gvViewReqisition.Rows[i].FindControl("lblStatus")).Text == Utility.Pending)
            {

                (((Button)gvViewReqisition.Rows[i].FindControl("btnSelect")).Visible) = true;
                (((Button)gvViewReqisition.Rows[i].FindControl("btnEdit")).Visible) = true;
            }
            else if (((Label)gvViewReqisition.Rows[i].FindControl("lblStatus")).Text == Utility.Approved)
            {

                (((Button)gvViewReqisition.Rows[i].FindControl("btnSelect")).Visible) = true;
            }


        }
    }

    void reBind2()
    {
        gvRequisitionList.DataSource = items;
        gvRequisitionList.DataBind();
        string a = (string)Session["fgh"];
        if (a == Utility.Pending)
        {
            for (int i = 0; i < gvRequisitionList.Rows.Count; i++)
            {
                (((Button)gvRequisitionList.Rows[i].FindControl("btnEdits")).Visible) = true;
                (((Button)gvRequisitionList.Rows[i].FindControl("btnDelete")).Visible) = true;
            }
        }
    }



    protected void gvViewReqisition_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }



    protected void btnDetails_Click(object sender, EventArgs e)
    {

    }

    protected void gvViewReqisition_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int a1 = e.RowIndex;
        Requisition r1 = l.ElementAt(a1);
        r1.Status = (((Label)gvViewReqisition.Rows[a1].FindControl("lblStatus")).Text);
        if (r1.Status == Utility.Pending)
        {
            int reqNo = int.Parse(((Label)gvViewReqisition.Rows[a1].FindControl("lblReq")).Text);

            RequisitionController.CancelRequisition(reqNo);

            r1.Status = Utility.Cancel;

            RequisitionController.DeleteRequisitionItem(reqNo);

            l[a1] = r1;

            gvViewReqisition.EditIndex = -1;
            reBind();
            gvRequisitionList.DataSource = null;
            gvRequisitionList.DataBind();
        }

    }


    protected void gvViewReqisition_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gvViewReqisition_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvViewReqisition.EditIndex = e.NewEditIndex;
        reBind();
    }

    protected void gvViewReqisition_RowUpdating1(object sender, GridViewUpdateEventArgs e)
    {

    }


    protected void gvViewReqisition_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvRequisitionList.DataSource = new List<RequisitionRequest>();
        gvRequisitionList.DataBind();
        gvRequisitionList.EditIndex = -1;
        int a1 = gvViewReqisition.SelectedIndex;
        String tooltip = (((Button)gvViewReqisition.Rows[a1].FindControl("btnSelect")).ToolTip);
        String a = tooltip;
        Session["fgh"] = a;
        int req = (int)gvViewReqisition.SelectedDataKey.Value;

        items = RequisitionController.GetRequisitionRequestByReqNo(req);
        Session["def"] = items;
        reBind2();
        lblRequisition.Visible = true;
    }
    protected void gvRequisitionList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvRequisitionList.EditIndex = -1;
        reBind2();
    }

    protected void gvRequisitionList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int a1 = e.NewEditIndex;
        String a = (String)Session["fgh"];
        if (a != Utility.Approved)
        {


            string status = (((Label)gvRequisitionList.Rows[a1].FindControl("lblQuantityStatus")).Text);

            gvRequisitionList.EditIndex = e.NewEditIndex;
            gvRequisitionList.DataSource = items;
            gvRequisitionList.DataBind();
            for (int i = 0; i < gvRequisitionList.Rows.Count; i++)
            {
                if (i != a1)
                {
                    (((Button)gvRequisitionList.Rows[i].FindControl("btnEdits")).Visible) = true;
                    (((Button)gvRequisitionList.Rows[i].FindControl("btnDelete")).Visible) = true;
                }
            }


        }

    }

    protected void gvRequisitionList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int a1 = e.RowIndex;
        RequisitionRequest r1 = items.ElementAt(a1);
        r1.Requested_Qty = int.Parse(((TextBox)gvRequisitionList.Rows[a1].FindControl("txtReqQty")).Text);
        int q = r1.Requested_Qty;
        String itemNo = (((Label)gvRequisitionList.Rows[a1].FindControl("lblItemNo")).Text);

        int reqNo = int.Parse(((Label)gvRequisitionList.Rows[a1].FindControl("lblReqReq")).Text);
        RequisitionController.UpdateRequisitionItemsByReqNoAndItemNo(itemNo, reqNo, q);


        items[a1] = r1;
        gvRequisitionList.EditIndex = -1;
        gvRequisitionList.DataSource = items;
        gvRequisitionList.DataBind();
        for (int i = 0; i < gvRequisitionList.Rows.Count; i++)
        {
            (((Button)gvRequisitionList.Rows[i].FindControl("btnEdits")).Visible) = true;
            (((Button)gvRequisitionList.Rows[i].FindControl("btnDelete")).Visible) = true;
        }
    }

    protected void gvRequisitionList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        String a = (String)Session["fgh"];

        if (a != Utility.Approved)
        {
            int a1 = e.RowIndex;
            RequisitionRequest r2 = items.ElementAt(a1);
            string status = (((Label)gvRequisitionList.Rows[e.RowIndex].FindControl("lblQuantityStatus")).Text);
            r2.Status = status;
            String itemNo = (((Label)gvRequisitionList.Rows[e.RowIndex].FindControl("lblItemNo")).Text);
            int reqNo = int.Parse(((Label)gvRequisitionList.Rows[e.RowIndex].FindControl("lblReqReq")).Text);
            RequisitionController.DeleteRequisitionItemsByReqNoAndItemNo(itemNo, reqNo);
            items.RemoveAt(a1);


            gvRequisitionList.DataSource = items;
            gvRequisitionList.DataBind();
            for (int i = 0; i < gvRequisitionList.Rows.Count; i++)
            {
                (((Button)gvRequisitionList.Rows[i].FindControl("btnEdits")).Visible) = true;
                (((Button)gvRequisitionList.Rows[i].FindControl("btnDelete")).Visible) = true;
            }
            if (gvRequisitionList.Rows.Count == 0)
            {
                RequisitionController.CancelRequisition(reqNo);
                reBind();
            }


        }
        if (gvRequisitionList.Rows.Count == 0)
        {
            l = RequisitionController.GetRequisitionByEmpID(EmployeeNumber);
            Session["abc"] = l;
            gvViewReqisition.DataSource = l;
            gvViewReqisition.DataBind();
            for (int i = 0; i < gvViewReqisition.Rows.Count; i++)

            {
                if (((Label)gvViewReqisition.Rows[i].FindControl("lblStatus")).Text == Utility.Pending)
                {

                    (((Button)gvViewReqisition.Rows[i].FindControl("btnSelect")).Visible) = true;
                    (((Button)gvViewReqisition.Rows[i].FindControl("btnEdit")).Visible) = true;
                }
                else if (((Label)gvViewReqisition.Rows[i].FindControl("lblStatus")).Text == Utility.Approved)
                {

                    (((Button)gvViewReqisition.Rows[i].FindControl("btnSelect")).Visible) = true;
                }
            }
        }


    }







    protected void gvViewReqisition_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvViewReqisition.PageIndex = e.NewPageIndex;
        reBind();
    }
}