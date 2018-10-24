using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SA45Team02_SSIS;

public partial class Departmenthead_ViewRequisitionDetails : System.Web.UI.Page
{
   
    static List<ReqDetailsView> lrdv = new List<ReqDetailsView>();
    int reqIDClicked;
    ReqListView rlv = new ReqListView();
    string deptID = "COMM";     //change this to take from user logged in
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ReqID"] != null)
        {
            reqIDClicked = Convert.ToInt32(Request.QueryString["ReqID"]);
            lrdv = RequisitionController.RequisitionDetails(reqIDClicked, deptID);
            BindGridView(lrdv);
            rlv = RequisitionController.RequesterDetails(reqIDClicked, deptID);
            if (rlv != null)
            {
                lbEmployeeName.Text = rlv.EmployeeName;
                lbReqFormNumber.Text = rlv.RequisitionNumber.ToString();
                lbRemarks.Text = "Remarks:(Optional)";
                lbRemarks.Font.Bold = true;
                tbRemarks.Visible = true;

                if (RequisitionController.RequisitionStatus(reqIDClicked) != Utility.Pending)
                {
                    ElementVisibility(false);
                }
                else
                {
                    ElementVisibility(true);
                }

               
            }
            else
            {
                ElementVisibility(false);
            }
        }
        else
        {
            ElementVisibility(false);
        }
    }

    private void ElementVisibility(bool set)
    {
        btnApprove.Visible = set;
        btnReject.Visible = set;
        tbRemarks.Visible = set;
        lbRemarks.Visible = set;
    }

    private void BindGridView(List<ReqDetailsView> myList)
    {
        gvRequisitionDetails.DataSource = myList;
        gvRequisitionDetails.DataBind();
    }

    protected void BtnApprove_Click(object sender, EventArgs e)
    {
        rlv.Remarks = tbRemarks.Text;
        List<ReqListView> lrlv = new List<ReqListView>();
        lrlv.Add(rlv);
        RequisitionController.ApproveRequisitions(lrlv);
        Response.Redirect("ViewRequisitionsLists.aspx");
    }

    protected void BtnReject_Click(object sender, EventArgs e)
    {
        rlv.Remarks = tbRemarks.Text;
        List<ReqListView> lrlv = new List<ReqListView>();
        lrlv.Add(rlv);
        RequisitionController.RejectRequisitions(lrlv);
        Response.Redirect("ViewRequisitionsLists.aspx");
    }
}