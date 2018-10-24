using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Supervisor
public partial class Stationery_Supervisior_RelinquishApproval : System.Web.UI.Page
{
  
   
    string deptID = "STORE";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        if (DelegateController.GetDelegateStoreClerk(deptID) != null)
        {
            Panel.Visible = true;
            GridBind();


        }
        else
        {
            Panel.Visible = false;
            string script = "alert('No delegate');";

            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);

        }


        //}
        //ddlItemList.SelectedIndex = 0;
    }
    private void GridBind()
    {
        Employee e = DelegateController.GetDelegateStoreClerk(deptID);
        if (e != null)
        {
            lbName.Text = DelegateController.GetDelegateStoreClerk(deptID).Employee_Name;
            ShowInfo(DelegateController.GetDelegateStoreClerk(deptID).Employee_ID);
        }
        else
        {

        }

    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        Employee e1 = DelegateController.GetDelegateStoreClerk(deptID);
        if (e != null)
        {

            int empId = DelegateController.GetDelegateStoreClerk(deptID).Employee_ID;
            DelegateController.RelinquishStoreClerk(empId);
            ShowInfo(empId);
        }

        string myStringVariable = "Successfully relinquish!";
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');window.location.replace('http://localhost/SA45Team02_SSIS/View/Stationery/Supervisior/DelegateToOther.aspx')", true);

        //lbName.Text = null;
        //lbStartDate = null;
        //lbEndDate = null;

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("DelegateToOther.aspx");
    }

    //protected void ddlItemList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int employeeId = delCtr.getDelegateStoreClerk();
    //    ShowInfo(employeeId);
    //}

    private void ShowInfo(int employeeId)
    {
        DelegateAuthority dl = RelinquishController.GetDelegateAuthorityByEmpId(employeeId);
        if (dl != null)
        {
            lbStartDate.Text = dl.Start_Date.ToShortDateString();
            lbEndDate.Text =
                dl.End_Date.Value.ToShortDateString();
            //tbInput.Text = dl.Status;
        }
        else
        {
            lbStartDate.Text = null;
            lbEndDate.Text = null;
            //tbInput.Text = null;
        }

    }
}