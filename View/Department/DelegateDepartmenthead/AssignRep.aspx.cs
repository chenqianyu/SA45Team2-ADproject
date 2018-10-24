using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Departmenthead_AssignRep : System.Web.UI.Page
{
    
    DepartmentController depController = new DepartmentController();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadDropDownList();
        }
    }

    public void loadDropDownList()
    {
        ddlEmployees.DataSource = depController.RetrieveEmployeeListInDept("COMM");
        ddlEmployees.DataTextField = "Employee_Name";
        ddlEmployees.DataValueField = "Employee_ID";
        ddlEmployees.DataBind();

        lbCurrentRep.Text = depController.GetCurrentRepByDepID("COMM").Employee_Name;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Read from login user's dept (currently set to "COMM")
        Department dept = depController.RetrieveDeptByDepID("COMM");
        Employee empNewRep = depController.GetEmployeeByEmpId(Convert.ToInt32(ddlEmployees.SelectedValue));
        Representative currentRep = depController.RetrieveRepByEmpID(Convert.ToInt32(depController.GetCurrentRepByDepID("COMM").Employee_ID));

        // Update Employee and Department Table

        depController.UpdateDeptRep(dept, empNewRep);

        depController.RemoveEmpRep(depController.GetCurrentRepByDepID("COMM"));
        depController.UpdateEmpRep(empNewRep);

        // Update Representative Table

        depController.CreateNewRep(empNewRep.Employee_ID, DateTime.Now, "Active");
        depController.UpdateRepEndDate(currentRep);

        lbStatus.Text = "Department Representative updated successfully.";

        //Refresh page view
        loadDropDownList();
    }
}