using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SA45Team02_SSIS;

public partial class Stationery_Supervisior_IssueAdjustment : System.Web.UI.Page
{

  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        string role = "Manager"; // get role from login user emp role
        gvPendingAdjustments.DataSource = AdjustmentController.PendingAdjustmentsList(role);
        gvPendingAdjustments.DataBind();

        if (gvPendingAdjustments.Rows.Count == 0)
        {
            lbStatus.Text = "You have no pending adjustment vouchers for acknowledgement";
            btnAcknowledgeAll.Enabled = false;
        }

        gvAcknowledgedAdjustments.DataSource = AdjustmentController.AcknowledgedAdjustmentsList();
        gvAcknowledgedAdjustments.DataBind();
    }

    protected void btnAcknowledge_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;

        string itemNo = row.Cells[0].Text.ToString();
        int empID = Convert.ToInt32(row.Cells[5].Text);
        DateTime date = Convert.ToDateTime(row.Cells[7].Text);

        int id = 1; // get from login user emp id

        AdjustmentController.AcknowledgeAdjustment(itemNo, empID, date, id);
        BindGrid();
    }


    protected void btnAcknowledgeAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gvPendingAdjustments.Rows.Count; i++)
        {
            GridViewRow r = gvPendingAdjustments.Rows[i];

            string itemNo = r.Cells[0].Text.ToString();
            int empID = Convert.ToInt32(r.Cells[5].Text);
            DateTime date = Convert.ToDateTime(r.Cells[7].Text);
            int id = 1; // get from login user emp id

            AdjustmentController.AcknowledgeAdjustment(itemNo, empID, date, id);

        }

        BindGrid();
    }
}