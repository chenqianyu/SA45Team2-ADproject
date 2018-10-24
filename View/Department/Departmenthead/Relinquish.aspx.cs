using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Departmenthead_Relinquish : System.Web.UI.Page
{
  
    string deptID = "ELEC";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        if (DelegateController.GetDelegateEmp(deptID) != null)
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

    }
    private void GridBind()
    {
        Employee e = DelegateController.GetDelegateEmp(deptID);
        if (e != null)
        {
            lbName.Text = DelegateController. GetDelegateEmp(deptID).Employee_Name;
            ShowInfo(DelegateController.GetDelegateEmp(deptID).Employee_ID);
        }
        else
        {

        }

    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //int employeeId = Int32.Parse(ddlItemList.SelectedValue);
        //string employeeName = ddlItemList.SelectedItem.Text;
        Employee e1 = DelegateController.GetDelegateEmp(deptID);
        if (e != null)
        {
            int empId = DelegateController.GetDelegateEmp(deptID).Employee_ID;
            DelegateController.RelinquishEmployee(empId);
            ShowInfo(empId);
        }

        string myStringVariable = "Successful relinquish!";
        ClientScript.RegisterStartupScript
            (this.GetType(), "myalert", "alert('" + myStringVariable + "');window.location.replace('http://localhost/SA45Team02_SSIS/View/Department/Departmenthead/DelegateAuthority.aspx')", true);//lbName.Text = null;


    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("DelegateAuthority.aspx");
    }


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

        }

    }
}