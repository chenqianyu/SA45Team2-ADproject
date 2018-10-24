 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SA45Team02_SSIS;

public partial class Departmenthead_Default : System.Web.UI.Page
{
    
    static List<ReqListView> dataBoundToGV = new List<ReqListView>();
    List<ReqListView> requisitionsSelected = new List<ReqListView>();
    string deptID;
    protected void Page_Load(object sender, EventArgs e)
    {
        RequisitionController.DeptID = "COMM";     //department ID to be retrieved from user session when implemented
        deptID = RequisitionController.DeptID;
        if (!IsPostBack)
        {
            dataBoundToGV = RequisitionController.ReqListByDept;
            bindGridView();
        }
    }

    protected void bindGridView()
    {
        gvRequisitionList.DataSource = dataBoundToGV;
        gvRequisitionList.DataBind();
    }


    protected void btnViewPending_Click(object sender, EventArgs e)
    {
        dataBoundToGV = RequisitionController.ReqListByDept;
        bindGridView();
    }

    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        dataBoundToGV = RequisitionController.AllReqListByDept;
        bindGridView();
    }



    protected void btnApprove_Click(object sender, EventArgs e)
    {
        collateCheckBox();
        RequisitionController.ApproveRequisitions(requisitionsSelected);
        dataBoundToGV = RequisitionController.ReqListByDept;
        bindGridView();
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        collateCheckBox();
        RequisitionController.RejectRequisitions(requisitionsSelected);
        dataBoundToGV = RequisitionController.ReqListByDept;
        bindGridView();
    }

    private void collateCheckBox()
    {
        for (int i = 0; i < gvRequisitionList.Rows.Count; i++)
        {
            CheckBox cbSelect = (CheckBox)gvRequisitionList.Rows[i].FindControl("cbSelect");
            string reqNumString = ((Label)gvRequisitionList.Rows[i].FindControl("lbRequisitionNumber")).Text;
            string reqNum = reqNumString.Substring(reqNumString.IndexOf('/') + 1);
            int requisitionNumber = Convert.ToInt32(reqNum.Substring(reqNum.IndexOf('/') + 1));
            string remarks = ((TextBox)gvRequisitionList.Rows[i].FindControl("tbRemarks")).Text;

            ReqListView rlv = RequisitionController.RequesterDetails(requisitionNumber, deptID);
            rlv.Remarks = remarks;

            if (cbSelect.Checked)
            {
                requisitionsSelected.Add(rlv);
            }
        }
    }



    protected void lbtnViewDetails_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow row = (GridViewRow)lb.NamingContainer;
        int index = row.RowIndex;
        string reqNumString = ((Label)gvRequisitionList.Rows[index].FindControl("lbRequisitionNumber")).Text;
        string reqNum = reqNumString.Substring(reqNumString.IndexOf('/') + 1);
        int requisitionNumber = Convert.ToInt32(reqNum.Substring(reqNum.IndexOf('/') + 1));

        string viewDetailsURL = "ViewRequisitionDetails.aspx?ReqID=" + requisitionNumber.ToString();
        Response.Redirect(viewDetailsURL);
    }

    protected void gvRequisitionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRequisitionList.PageIndex = e.NewPageIndex;
        bindGridView();
    }

}