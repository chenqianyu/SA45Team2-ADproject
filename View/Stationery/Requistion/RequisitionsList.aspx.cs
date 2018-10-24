using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Stationery_RequisitionsList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        tbStartDate.Text = "01/01/1900";
        tbEndDate.Text = (DateTime.Today.Date).ToString();
        BindGridAll();
    }

    private void BindGridAll()
    {
        DateTime startDate = Convert.ToDateTime(tbStartDate.Text);
        DateTime endDate = Convert.ToDateTime(tbEndDate.Text);
        gvRequisitionStatus1.DataSource = RequisitionController.RetrieveRequisitionByDateWithAll(startDate, endDate);
        gvRequisitionStatus1.DataBind();
    }
    private void BindGridApproveUnfulfilled()
    {
        DateTime startDate = Convert.ToDateTime(tbStartDate.Text);
        DateTime endDate = Convert.ToDateTime(tbEndDate.Text);
        gvRequisitionStatus2.DataSource = RequisitionController.RetrieveApprovedRequisitionByDate(startDate, endDate);
        gvRequisitionStatus2.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        this.BindGridAll();
        gvRequisitionStatus2.DataSource = null;
        gvRequisitionStatus2.DataBind();
    }

    protected void btnApproveFulfilled_Click(object sender, EventArgs e)
    {
        this.BindGridApproveUnfulfilled();
        gvRequisitionStatus1.DataSource = null;
        gvRequisitionStatus1.DataBind();
    }

    protected void gvRequisition_RowCommand1(Object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "gvRequisitionStatus1")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Int32.Parse(e.CommandArgument.ToString());
            Response.Redirect("RequisitionDetail.aspx?requisitionID=" + id);
        }

    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRequisitionStatus1.PageIndex = e.NewPageIndex;
        this.BindGridAll();
    }

    protected void gvRequisition_RowCommand2(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "gvRequisitionStatus2")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Int32.Parse(e.CommandArgument.ToString());
            Response.Redirect("RequisitionDetail.aspx?requisitionID=" + id);
        }
    }

    protected void OnPageIndexChanging2(object sender, GridViewPageEventArgs e)
    {
        gvRequisitionStatus2.PageIndex = e.NewPageIndex;
        this.BindGridApproveUnfulfilled();
    }

    //gvRequisitionStatus1.DataSource = rqc.retrieveUnfulfilledRequisitionByDate(startDate, endDate);
    //gvRequisitionStatus1.DataBind();
}