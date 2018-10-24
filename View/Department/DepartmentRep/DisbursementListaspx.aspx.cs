using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DepartmentRep_DisbursementListaspx : System.Web.UI.Page
{
   
    string depID = null;
    string depName = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["EmpID"] = 86;
            int empID = Convert.ToInt32(Session["EmpID"]);
            depID = DisbursementController.GetEmployeeByEmpId(empID).Department_ID;
            depName = DisbursementController.RetrieveDeptByDepID(depID).Department_Name;
            List<DisbursementViewDTO> disbursementList = DisbursementController.GetDisbursementByDep(depID);
            if (disbursementList.Count != 0)
            {
                lbRepresentative.Text = DisbursementController.GetRepresentativeByDepartmentID(depID).Employee_Name;
                gvItemToGiveOutToDepartment.DataSource = disbursementList;
                gvItemToGiveOutToDepartment.DataBind();
                onOffVisible(true);
            }
            else
            {
                onOffVisible(false);
                this.showMessage("No Disbursement List for Your Department Yet!");
            }
        }
    }
    private void showMessage(string toShowMsg)
    {
        string message = toShowMsg;
        string script = "window.onload = function(){ alert('";
        script += message;
        script += "')};";
        ClientScript.RegisterStartupScript(this.GetType(), "Message", script, true);
    }
    protected void onOffVisible(bool status)
    {
        cbAcknowledge.Visible = status;
        lbAcknowledgeLetter.Visible = status;
        btnAcknowledge.Visible = status;
        gvItemToGiveOutToDepartment.Visible = status;
        tbRepresentative.Visible = status;
    }
    protected void btnAcknowledge_Click(object sender, EventArgs e)
    {
        if (cbAcknowledge.Checked)
        {
            Session["EmpID"] = 86;
            int empID = Convert.ToInt32(Session["EmpID"]);
            depID = DisbursementController.GetEmployeeByEmpId(empID).Department_ID;
            DisbursementController.UpdateDisbursementStatusAndDate(depID);
            DisbursementController.UpdateCompletedStatus();
            this.showMessage("You have Acknowledged Successfully!");
        }
        else
        {
            this.showMessage("Please Click Checkbox to Acknowledge");
        }
    }
}